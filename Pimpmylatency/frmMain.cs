using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

// http://georgelantz.com/2007/09/10/access-mysql-through-ssh-tunnel-in-a-windows-net-application/
// http://granados.sourceforge.net/
// http://www.tamirgal.com/home/dev.aspx?Item=SharpSsh


namespace pimpmylatency
{
    public partial class frmMain : Form
    {
        private config cfg;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            debug_log.add_log(log_type.GENERAL,"Main form loaded..");
            load_config();
        }

        private void load_config()
        {
            Boolean ret = config_manager.load_config();
            notify_icon.Visible = true;
            if (ret)
            {
                cfg = config_manager.loaded_config;
                debug_log.add_log(log_type.GENERAL, "Configuration found for " + cfg.server_address);
                cmd_start.Enabled = true;
                ping_timer_Tick(this, null);
            }
            else
            {
                debug_log.add_log(log_type.WARNING, "No valid configuration found..");
                lbl_status.Text = "You do not have any configured VPS account.";
                cmd_start.Enabled = false;
            }
        }
        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                ping_timer.Enabled = false;
            }
        }


        private void ping_timer_Tick(object sender, EventArgs e)
        {
            long latency=-1;
            IPStatus status;
            if (cfg != null)
            {
                latency = networking.ping(cfg.server_address, out status);
                if (status == IPStatus.Success)
                {
                    ping_progressbar.Properties.Maximum = 1000;
                    ping_progressbar.Position = (int)latency;
                    lbl_latency.Text  = "Ping success; " + (int)latency + " ms";
                }
                else
                {
                    ping_progressbar.Position = 0;
                    lbl_latency.Text  = "Timeout or unknown error";
                }
            }
            else
                lbl_latency.Text = "No configured VPS exists..!";
        }

        private void cmd_config_Click(object sender, EventArgs e)
        {
            frmConfig c = new frmConfig();
            c.ShowDialog();
            // try to reload the config
            load_config();
        }

        private void cmd_start_Click(object sender, EventArgs e)
        {
            if (cfg != null)
            {
                proxify.start(cfg);
            }
            else
            {
                MessageBox.Show("Seems you have no saved configuration. Please do it now!", "Need configuration");
                frmConfig fcfg = new frmConfig();
                fcfg.ShowDialog();
            }
        }

        public void set_progress_max(int max)
        {
            progress_bar.Properties.Minimum = 0;
            progress_bar.Properties.Maximum = max;
        }

        public void update_status_message(int step, string msg)
        {
            progress_bar.Position = step;
            lbl_status.Text = msg;
        }

        private void lbl_debug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDebug dbg = new frmDebug();
            dbg.Show();
        }

        private void lbl_status_TextChanged(object sender, EventArgs e)
        {
            notify_icon.Text = lbl_status.Text;
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            proxify.kill_tools();
            Application.Exit();
        }

        private void mnu_show_Click(object sender, EventArgs e)
        {
            ping_timer.Enabled = true;
            this.Show();
        }

        private void lbl_about_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

    }
}
