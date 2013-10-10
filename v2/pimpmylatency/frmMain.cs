using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pimpmylatency
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            ProxyEngine.init("127.0.0.1", 6666); // initialize the proxy
            ProxyEngine.create_connection("www.google.com", 80, 9999);            
            //HookEngine.init("firefox.exe"); // initialize the hook engine
        }
    }
}
