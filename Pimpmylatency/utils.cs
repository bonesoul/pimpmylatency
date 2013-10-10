using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace pimpmylatency
{
    public static class utils
    {
        public static string get_wow_install_path()
        {
            // read wow's installation path from registery
            try
            {
                RegistryKey key = Registry.LocalMachine;
                RegistryKey key_wow = key.OpenSubKey("Software").OpenSubKey("Blizzard Entertainment").OpenSubKey("World of Warcraft");
                string wow_path = key_wow.GetValue("InstallPath").ToString();
                wow_path += "Wow.exe";
                return wow_path;
            }
            catch(Exception e)
            {
                return "";
            }
        }

        public static Boolean check_file(string filepath)
        {
            if (File.Exists(filepath))
                return true;
            else
                return false;
        }

        public static string get_app_path()
        {
            String app_path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (app_path.StartsWith(@"file:\"))
                app_path = app_path.Substring(6);
            return app_path;
        }

        public static void create_ssh_keys(string host)
        {
            //key: [HKEY_CURRENT_USER\Software\SimonTatham\PuTTY\SshHostKeys]
            System.Windows.Forms.MessageBox.Show("Now we'll try to generate your SSH keys for secure communication with your VPS server. I'll run putty and if it warns with a message box named \"Putty Security Alert\", then Click Yes. If no security alert window shows, this means you've already a valid SSH key. Then please close the putty window.", "Generation of SSH Keys", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            string putty_path = get_app_path() + @"\Resources\putty.exe";
            Process.Start(putty_path, host);
        }

    }
}
