using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace pimpmylatency
{
    public class tool_manager
    {
        public ArrayList tools;
        private Int32 curr;

        public tool_manager()
        {
            debug_log.add_log(log_type.PROXIFY, "Initializing toolchain..");
            Program.mainform.update_status_message(1, "Initializing toolchain..");
            tools = new ArrayList();
            curr = 0;
        }

        public void start_execution()
        {
            Program.mainform.set_progress_max(tools.Count + 2);
            debug_log.add_log(log_type.PROXIFY, "Starting toolchain execution.. Jobs in chain: " + tools.Count);
            process_next_tool();
        }

        private void process_next_tool()
        {
            string tool_status="";
            tool t = (tool)tools[curr];

            switch (t.type )
	        {
		        case tool_type.plink:
                    debug_log.add_log(log_type.PROXIFY, "Setting up SSH connection to VPS");
                    tool_status = "Setting up SSH connection to VPS";
                    break;
                case tool_type.freecap:
                    debug_log.add_log(log_type.PROXIFY, "Directing traffic to VPS");
                    tool_status = "Directing traffic to VPS";
                    break;
            }

            Program.mainform.update_status_message((curr + 2), tool_status);
            t.process();
        }

        public void tool_complete()
        {
            curr++;
            if (curr < tools.Count)
                process_next_tool();
            else
                toolchain_completed();
        }

        public void toolchain_completed()
        {
            debug_log.add_log(log_type.PROXIFY, "Toolchain completed..");
            Program.mainform.update_status_message(tools.Count+3,"Pimped your latency..!");
            Program.mainform.Hide();
        }
    }

    public enum tool_type
    {
        plink,
        freecap
    }

    public class tool
    {
        public tool_type type;
        public string args;
        private string tool_name;
        public Process tool_process;

        private delegate void execution_completed();

        public tool(tool_type _type,string _args)
        {
            type = _type;
            switch (type)
            {
                case tool_type.plink:
                    tool_name = "plink.exe";
                    break;
                case tool_type.freecap:
                    tool_name = "freecapcon.exe";
                    break;
            }
            args = _args;
        }

        private void exec_complete()
        {
            proxify.tm.tool_complete();
        }

        public void process()
        {
            Thread t = new Thread
            (
                delegate()
                {
                    execute_tool();
                    Program.mainform.Invoke(new execution_completed(exec_complete));
                }
            );
            t.Start();
        }

        private void execute_tool()
        {
            string tool_path = utils.get_app_path() + @"\Resources\" + tool_name;
            ProcessStartInfo psi = new ProcessStartInfo(tool_path, args);
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.WorkingDirectory = utils.get_app_path() + @"\Resources";
            psi.RedirectStandardError = true;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            tool_process = Process.Start(psi);
            
            //asnyc read the standart error and out
            tool_process.ErrorDataReceived += new DataReceivedEventHandler(std_error_handler);
            tool_process.OutputDataReceived += new DataReceivedEventHandler(std_output_handler);

            tool_process.BeginErrorReadLine();
            tool_process.BeginOutputReadLine();
        }

        private static void std_error_handler(object sendingProcess, DataReceivedEventArgs err_line)
        {
            if (err_line.Data != null)
            {
                Program.mainform.Show();
                System.Windows.Forms.MessageBox.Show(err_line.Data);
                debug_log.add_log(log_type.PROXIFY_ERROR, err_line.Data);
            }
        }

        private static void std_output_handler(object sendingProcess, DataReceivedEventArgs out_line)
        {
            if (out_line.Data != null)
            {
                Program.mainform.Show();
                System.Windows.Forms.MessageBox.Show(out_line.Data);
                debug_log.add_log(log_type.PROXIFY_ERROR, out_line.Data);
            }
        }


    }
}

