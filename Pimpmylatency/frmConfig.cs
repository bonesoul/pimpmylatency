using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace pimpmylatency
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void cmd_save_Click(object sender, EventArgs e)
        {   
            // validate address
            if(!networking.validate_server_address(txt_server.Text))
            {
                MessageBox.Show("Invalid VPS Server Address. Please check it.","Invalid Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl.SelectedTab = tabVPS;
                txt_server.Focus();
                txt_server.SelectAll();
                return;
            }

            if (txt_username.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your username for VPS Server", "Need Username", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControl.SelectedTab = tabVPS;
                txt_username.Focus();
                return;
            }

            if (txt_password.Text.Trim() == "")
            {
                MessageBox.Show("Please enter your password for VPS Server", "Need Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControl.SelectedTab = tabVPS;
                txt_password.Focus();
                return;
            }

            if (txt_wow_path.Text.Trim() == "")
            {
                MessageBox.Show("Please choose World of Warcraft Path", "Need Game Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControl.SelectedTab = tabWOW;
                txt_wow_path.Focus();
                return;
            }

            config cfg=new config();
            cfg.server_address = txt_server.Text;
            cfg.port = 6666;
            cfg.username = txt_username.Text;
            cfg.password = txt_password.Text;
            cfg.remember_password = chk_remember_password.Checked;
            cfg.wow_path = txt_wow_path.Text;
            // create the SSH keys
            utils.create_ssh_keys(cfg.server_address);
            debug_log.add_log(log_type.GENERAL, "Saving configuration for " + cfg.server_address);
            config_manager.save_config(cfg);

            this.Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
                Boolean ret = config_manager.load_config();
                if (ret)
                {
                    config cfg = config_manager.loaded_config;
                    // load values back
                    txt_server.Text = cfg.server_address;
                    txt_username.Text = cfg.username;
                    txt_password.Text = cfg.password;
                    chk_remember_password.Checked = cfg.remember_password;
                    if (utils.check_file(cfg.wow_path))
                        txt_wow_path.Text = cfg.wow_path;
                    else
                        txt_wow_path.Text = utils.get_wow_install_path();

                }
                else
                {
                    // at least find the wow path
                    txt_wow_path.Text = utils.get_wow_install_path();
                }
                
        }

        private void cmd_choose_path_Click(object sender, EventArgs e)
        {
            string selected;
            openFileDialog.Filter="exe files (*.exe)|*.exe";
            openFileDialog.Title = "Select your World of Warcraft executable";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selected = openFileDialog.FileName;
                txt_wow_path.Text = selected;
            }
        }

        private void cmd_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_vps_providers_latency_check_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmVPSProviders fvps = new frmVPSProviders();
            fvps.ShowDialog();
        }

        private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
