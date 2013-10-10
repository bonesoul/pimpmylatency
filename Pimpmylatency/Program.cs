using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace pimpmylatency
{
    static class Program
    {
        public static frmMain mainform;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            debug_log.init();
            debug_log.add_log(log_type.GENERAL, "Program init..");
            mainform = new frmMain();
            Application.Run(mainform);
        }
    }
}
