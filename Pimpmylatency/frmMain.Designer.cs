namespace pimpmylatency
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lbl_status = new System.Windows.Forms.Label();
            this.ping_timer = new System.Windows.Forms.Timer(this.components);
            this.picturebox1 = new System.Windows.Forms.PictureBox();
            this.group_latency = new DevExpress.XtraEditors.GroupControl();
            this.lbl_latency = new System.Windows.Forms.Label();
            this.ping_progressbar = new DevExpress.XtraEditors.ProgressBarControl();
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            this.group_pimp = new DevExpress.XtraEditors.GroupControl();
            this.lbl_debug = new System.Windows.Forms.LinkLabel();
            this.cmd_config = new DevExpress.XtraEditors.SimpleButton();
            this.progress_bar = new DevExpress.XtraEditors.ProgressBarControl();
            this.lbl_about = new System.Windows.Forms.LinkLabel();
            this.cmd_start = new DevExpress.XtraEditors.SimpleButton();
            this.notify_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.context_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_show = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_exit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_latency)).BeginInit();
            this.group_latency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ping_progressbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group_pimp)).BeginInit();
            this.group_pimp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progress_bar.Properties)).BeginInit();
            this.context_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Location = new System.Drawing.Point(5, 20);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(29, 14);
            this.lbl_status.TabIndex = 0;
            this.lbl_status.Text = "Idle..";
            this.lbl_status.TextChanged += new System.EventHandler(this.lbl_status_TextChanged);
            // 
            // ping_timer
            // 
            this.ping_timer.Enabled = true;
            this.ping_timer.Interval = 5000;
            this.ping_timer.Tick += new System.EventHandler(this.ping_timer_Tick);
            // 
            // picturebox1
            // 
            this.picturebox1.Image = ((System.Drawing.Image)(resources.GetObject("picturebox1.Image")));
            this.picturebox1.Location = new System.Drawing.Point(0, 0);
            this.picturebox1.Name = "picturebox1";
            this.picturebox1.Size = new System.Drawing.Size(312, 96);
            this.picturebox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox1.TabIndex = 4;
            this.picturebox1.TabStop = false;
            // 
            // group_latency
            // 
            this.group_latency.Controls.Add(this.lbl_latency);
            this.group_latency.Controls.Add(this.ping_progressbar);
            this.group_latency.Location = new System.Drawing.Point(5, 102);
            this.group_latency.LookAndFeel.SkinName = "Black";
            this.group_latency.LookAndFeel.UseDefaultLookAndFeel = false;
            this.group_latency.Name = "group_latency";
            this.group_latency.Size = new System.Drawing.Size(302, 59);
            this.group_latency.TabIndex = 8;
            this.group_latency.Text = "VPS Latency";
            // 
            // lbl_latency
            // 
            this.lbl_latency.AutoSize = true;
            this.lbl_latency.Location = new System.Drawing.Point(0, 20);
            this.lbl_latency.Name = "lbl_latency";
            this.lbl_latency.Size = new System.Drawing.Size(71, 14);
            this.lbl_latency.TabIndex = 8;
            this.lbl_latency.Text = "Pinging VPS..";
            // 
            // ping_progressbar
            // 
            this.ping_progressbar.EditValue = "0";
            this.ping_progressbar.Location = new System.Drawing.Point(3, 37);
            this.ping_progressbar.Name = "ping_progressbar";
            this.ping_progressbar.Properties.PercentView = false;
            this.ping_progressbar.Properties.ReadOnly = true;
            this.ping_progressbar.Properties.ShowTitle = true;
            this.ping_progressbar.Size = new System.Drawing.Size(292, 16);
            this.ping_progressbar.TabIndex = 7;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.group_pimp);
            this.panelControl.Controls.Add(this.picturebox1);
            this.panelControl.Controls.Add(this.group_latency);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.LookAndFeel.SkinName = "Black";
            this.panelControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(312, 285);
            this.panelControl.TabIndex = 9;
            // 
            // group_pimp
            // 
            this.group_pimp.Controls.Add(this.lbl_debug);
            this.group_pimp.Controls.Add(this.cmd_config);
            this.group_pimp.Controls.Add(this.progress_bar);
            this.group_pimp.Controls.Add(this.lbl_status);
            this.group_pimp.Controls.Add(this.lbl_about);
            this.group_pimp.Controls.Add(this.cmd_start);
            this.group_pimp.Location = new System.Drawing.Point(6, 167);
            this.group_pimp.LookAndFeel.SkinName = "Black";
            this.group_pimp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.group_pimp.Name = "group_pimp";
            this.group_pimp.Size = new System.Drawing.Size(301, 108);
            this.group_pimp.TabIndex = 10;
            this.group_pimp.Text = "Pimp..";
            // 
            // lbl_debug
            // 
            this.lbl_debug.AutoSize = true;
            this.lbl_debug.Location = new System.Drawing.Point(6, 77);
            this.lbl_debug.Name = "lbl_debug";
            this.lbl_debug.Size = new System.Drawing.Size(38, 14);
            this.lbl_debug.TabIndex = 12;
            this.lbl_debug.TabStop = true;
            this.lbl_debug.Text = "Debug";
            this.lbl_debug.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_debug_LinkClicked);
            // 
            // cmd_config
            // 
            this.cmd_config.Location = new System.Drawing.Point(101, 63);
            this.cmd_config.LookAndFeel.SkinName = "The Asphalt World";
            this.cmd_config.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmd_config.Name = "cmd_config";
            this.cmd_config.Size = new System.Drawing.Size(71, 40);
            this.cmd_config.TabIndex = 10;
            this.cmd_config.Text = "Configure";
            this.cmd_config.Click += new System.EventHandler(this.cmd_config_Click);
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(3, 37);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Properties.PercentView = false;
            this.progress_bar.Properties.ReadOnly = true;
            this.progress_bar.Size = new System.Drawing.Size(294, 20);
            this.progress_bar.TabIndex = 8;
            // 
            // lbl_about
            // 
            this.lbl_about.AutoSize = true;
            this.lbl_about.Location = new System.Drawing.Point(5, 63);
            this.lbl_about.Name = "lbl_about";
            this.lbl_about.Size = new System.Drawing.Size(36, 14);
            this.lbl_about.TabIndex = 11;
            this.lbl_about.TabStop = true;
            this.lbl_about.Text = "About";
            this.lbl_about.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_about_LinkClicked);
            // 
            // cmd_start
            // 
            this.cmd_start.Enabled = false;
            this.cmd_start.Location = new System.Drawing.Point(178, 63);
            this.cmd_start.LookAndFeel.SkinName = "The Asphalt World";
            this.cmd_start.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmd_start.Name = "cmd_start";
            this.cmd_start.Size = new System.Drawing.Size(117, 41);
            this.cmd_start.TabIndex = 2;
            this.cmd_start.Text = "Pimp my latency now";
            this.cmd_start.Click += new System.EventHandler(this.cmd_start_Click);
            // 
            // notify_icon
            // 
            this.notify_icon.ContextMenuStrip = this.context_menu;
            this.notify_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("notify_icon.Icon")));
            this.notify_icon.Text = "Pimp my latency: Idle..";
            this.notify_icon.Visible = true;
            // 
            // context_menu
            // 
            this.context_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_show,
            this.mnu_exit});
            this.context_menu.Name = "context_menu";
            this.context_menu.Size = new System.Drawing.Size(112, 48);
            // 
            // mnu_show
            // 
            this.mnu_show.Name = "mnu_show";
            this.mnu_show.Size = new System.Drawing.Size(111, 22);
            this.mnu_show.Text = "Show";
            this.mnu_show.Click += new System.EventHandler(this.mnu_show_Click);
            // 
            // mnu_exit
            // 
            this.mnu_exit.Name = "mnu_exit";
            this.mnu_exit.Size = new System.Drawing.Size(111, 22);
            this.mnu_exit.Text = "Exit";
            this.mnu_exit.Click += new System.EventHandler(this.mnu_exit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 285);
            this.Controls.Add(this.panelControl);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.Text = "Pimp My Latency!";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.group_latency)).EndInit();
            this.group_latency.ResumeLayout(false);
            this.group_latency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ping_progressbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group_pimp)).EndInit();
            this.group_pimp.ResumeLayout(false);
            this.group_pimp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progress_bar.Properties)).EndInit();
            this.context_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Timer ping_timer;
        private System.Windows.Forms.PictureBox picturebox1;
        private DevExpress.XtraEditors.GroupControl group_latency;
        private DevExpress.XtraEditors.ProgressBarControl ping_progressbar;
        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraEditors.SimpleButton cmd_config;
        private DevExpress.XtraEditors.GroupControl group_pimp;
        private DevExpress.XtraEditors.SimpleButton cmd_start;
        private DevExpress.XtraEditors.ProgressBarControl progress_bar;
        private System.Windows.Forms.Label lbl_latency;
        private System.Windows.Forms.NotifyIcon notify_icon;
        private System.Windows.Forms.ContextMenuStrip context_menu;
        private System.Windows.Forms.LinkLabel lbl_debug;
        private System.Windows.Forms.LinkLabel lbl_about;
        private System.Windows.Forms.ToolStripMenuItem mnu_show;
        private System.Windows.Forms.ToolStripMenuItem mnu_exit;

    }
}

