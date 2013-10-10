using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pimpmylatency
{
    public partial class frmDebug : Form
    {
        public frmDebug()
        {
            InitializeComponent();
        }

        private void frmDebug_Load(object sender, EventArgs e)
        {
            foreach (log_item  i in debug_log.logs)
            {
                add_log_item(i);
            }

            debug_log.debug_window = this;
        }

        public void add_log_item(log_item i)
        {
            string type = "";
            switch (i.type)
            {
                case log_type.GENERAL:
                    type = "[General]";
                    break;
                case log_type.WARNING:
                    type = "[WARNING]";
                    break;
                case log_type.PROXIFY:
                    type = "[PROXIFY]";
                    break;
                case log_type.PROXIFY_ERROR:
                    type = "[PROXIFY ERROR]";
                    break;
            }
            string time = "[" + i.time.Hour.ToString("00") + ":" + i.time.Minute.ToString("00") + ":" + i.time.Second.ToString("00") + "] ";
            lst_debug.Items.Add(time + type + " :" + i.message);
        }
    }
}
