namespace pimpmylatency
{
    partial class frmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabVPS = new System.Windows.Forms.TabPage();
            this.lbl_vps_providers_latency_check = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.chk_remember_password = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabWOW = new System.Windows.Forms.TabPage();
            this.cmd_choose_path = new System.Windows.Forms.Button();
            this.txt_wow_path = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmd_save = new System.Windows.Forms.Button();
            this.cmd_cancel = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabVPS.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabWOW.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabVPS);
            this.tabControl.Controls.Add(this.tabWOW);
            this.tabControl.Location = new System.Drawing.Point(3, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(391, 201);
            this.tabControl.TabIndex = 0;
            // 
            // tabVPS
            // 
            this.tabVPS.Controls.Add(this.lbl_vps_providers_latency_check);
            this.tabVPS.Controls.Add(this.tableLayoutPanel1);
            this.tabVPS.Controls.Add(this.label1);
            this.tabVPS.Location = new System.Drawing.Point(4, 23);
            this.tabVPS.Name = "tabVPS";
            this.tabVPS.Padding = new System.Windows.Forms.Padding(3);
            this.tabVPS.Size = new System.Drawing.Size(383, 174);
            this.tabVPS.TabIndex = 0;
            this.tabVPS.Text = "VPS Account Setup";
            this.tabVPS.UseVisualStyleBackColor = true;
            // 
            // lbl_vps_providers_latency_check
            // 
            this.lbl_vps_providers_latency_check.AutoSize = true;
            this.lbl_vps_providers_latency_check.Location = new System.Drawing.Point(3, 153);
            this.lbl_vps_providers_latency_check.Name = "lbl_vps_providers_latency_check";
            this.lbl_vps_providers_latency_check.Size = new System.Drawing.Size(162, 14);
            this.lbl_vps_providers_latency_check.TabIndex = 2;
            this.lbl_vps_providers_latency_check.TabStop = true;
            this.lbl_vps_providers_latency_check.Text = "VPS Providers Latency Checker";
            this.lbl_vps_providers_latency_check.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_vps_providers_latency_check_LinkClicked);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_server, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_username, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_password, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chk_remember_password, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 100);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "VPS Server Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 1;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // txt_server
            // 
            this.txt_server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_server.Location = new System.Drawing.Point(185, 3);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(177, 20);
            this.txt_server.TabIndex = 3;
            // 
            // txt_username
            // 
            this.txt_username.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_username.Location = new System.Drawing.Point(185, 28);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(177, 20);
            this.txt_username.TabIndex = 4;
            // 
            // txt_password
            // 
            this.txt_password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_password.Location = new System.Drawing.Point(185, 53);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(177, 20);
            this.txt_password.TabIndex = 5;
            // 
            // chk_remember_password
            // 
            this.chk_remember_password.AutoSize = true;
            this.chk_remember_password.Checked = true;
            this.chk_remember_password.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_remember_password.Location = new System.Drawing.Point(185, 78);
            this.chk_remember_password.Name = "chk_remember_password";
            this.chk_remember_password.Size = new System.Drawing.Size(147, 18);
            this.chk_remember_password.TabIndex = 6;
            this.chk_remember_password.Text = "Remember my password";
            this.chk_remember_password.UseVisualStyleBackColor = true;
            this.chk_remember_password.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your VPS Accounts information here";
            // 
            // tabWOW
            // 
            this.tabWOW.Controls.Add(this.cmd_choose_path);
            this.tabWOW.Controls.Add(this.txt_wow_path);
            this.tabWOW.Controls.Add(this.label5);
            this.tabWOW.Location = new System.Drawing.Point(4, 23);
            this.tabWOW.Name = "tabWOW";
            this.tabWOW.Padding = new System.Windows.Forms.Padding(3);
            this.tabWOW.Size = new System.Drawing.Size(383, 174);
            this.tabWOW.TabIndex = 1;
            this.tabWOW.Text = "WOW Settings";
            this.tabWOW.UseVisualStyleBackColor = true;
            // 
            // cmd_choose_path
            // 
            this.cmd_choose_path.Location = new System.Drawing.Point(346, 34);
            this.cmd_choose_path.Name = "cmd_choose_path";
            this.cmd_choose_path.Size = new System.Drawing.Size(28, 23);
            this.cmd_choose_path.TabIndex = 2;
            this.cmd_choose_path.Text = "...";
            this.cmd_choose_path.UseVisualStyleBackColor = true;
            this.cmd_choose_path.Click += new System.EventHandler(this.cmd_choose_path_Click);
            // 
            // txt_wow_path
            // 
            this.txt_wow_path.Enabled = false;
            this.txt_wow_path.Location = new System.Drawing.Point(12, 34);
            this.txt_wow_path.Name = "txt_wow_path";
            this.txt_wow_path.Size = new System.Drawing.Size(328, 20);
            this.txt_wow_path.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "World of Warcraft Path";
            // 
            // cmd_save
            // 
            this.cmd_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_save.Location = new System.Drawing.Point(306, 219);
            this.cmd_save.Name = "cmd_save";
            this.cmd_save.Size = new System.Drawing.Size(75, 23);
            this.cmd_save.TabIndex = 1;
            this.cmd_save.Text = "Save";
            this.cmd_save.UseVisualStyleBackColor = true;
            this.cmd_save.Click += new System.EventHandler(this.cmd_save_Click);
            // 
            // cmd_cancel
            // 
            this.cmd_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmd_cancel.Location = new System.Drawing.Point(225, 219);
            this.cmd_cancel.Name = "cmd_cancel";
            this.cmd_cancel.Size = new System.Drawing.Size(75, 23);
            this.cmd_cancel.TabIndex = 2;
            this.cmd_cancel.Text = "Cancel";
            this.cmd_cancel.UseVisualStyleBackColor = true;
            this.cmd_cancel.Click += new System.EventHandler(this.cmd_cancel_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 256);
            this.Controls.Add(this.cmd_cancel);
            this.Controls.Add(this.cmd_save);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.Text = "Pimp My Latency - Configuration";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfig_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabVPS.ResumeLayout(false);
            this.tabVPS.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabWOW.ResumeLayout(false);
            this.tabWOW.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabVPS;
        private System.Windows.Forms.TabPage tabWOW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_server;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_wow_path;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmd_choose_path;
        private System.Windows.Forms.Button cmd_save;
        private System.Windows.Forms.Button cmd_cancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox chk_remember_password;
        private System.Windows.Forms.LinkLabel lbl_vps_providers_latency_check;

    }
}