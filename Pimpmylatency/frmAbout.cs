using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace pimpmylatency
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void lbl_web_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.pimpmylatency.com");
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lbl_version.Text = Application.ProductVersion;
        }
    }
}
