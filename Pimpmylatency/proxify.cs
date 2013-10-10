using System;
using System.Collections.Generic;
using System.Text;

namespace pimpmylatency
{
    public static class proxify
    {
        public static tool_manager tm;
        public static void start(config cfg)
        {
            tm = new tool_manager();

            // plink 
            StringBuilder args = new StringBuilder();
            args.Append("-D " + cfg.port + " ");
            args.Append(cfg.username + "@" + cfg.server_address);
            args.Append(" -pw " + cfg.password);
            args.Append(" -N");
            tool p = new tool(tool_type.plink, args.ToString());
            tm.tools.Add(p);
            debug_log.add_log(log_type.PROXIFY, "Creating tool_manager job - plink");

            // freecap
            args = new StringBuilder();
            args.Append("-f freecap.xml "); 
            args.Append(@" """ + cfg.wow_path + @""" ");
            tool f = new tool(tool_type.freecap, args.ToString());
            debug_log.add_log(log_type.PROXIFY, "Creating tool_manager job - freecap");
            tm.tools.Add(f);

            tm.start_execution();
        }

        public static void kill_tools()
        {
            if(tm!=null)
            foreach (tool t in tm.tools)
            {
                try
                {
                    t.tool_process.Kill();
                }
                catch(Exception e)
                {}
            }
        }
    }
}
