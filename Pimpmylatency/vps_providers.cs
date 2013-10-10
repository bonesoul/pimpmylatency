using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using System.Threading;

namespace pimpmylatency
{
    public static class vps_providers
    {
        public static ArrayList list;
        private static System.Windows.Forms.Timer timer;
        public static Divelements.SandGrid.Specialized.GridProgressBarColumn col_latency;

        public static void init()
        {
            list = new ArrayList();
            read_xml();
            timer = new System.Windows.Forms.Timer();
            timer.Enabled = false;
        }

        public static vps_provider get_provider(string name)
        {
            foreach (vps_provider i in list)
            {
                if (i.name.ToLower() == name.ToLower())
                    return i;
            }

            return null;
        }

        public static void set_timer_interval(int interval)
        {
            timer.Interval = interval * 1000;
        }

        public static void enable_timer()
        {
            timer.Tick += new EventHandler(timer_tick);
            timer.Enabled = true;
        }

        public static void disable_timer()
        {
            timer.Enabled = false;
        }

        private static void ping_vps_providers()
        {
            long ping;
            Int32 max = 0;

            System.Net.NetworkInformation.IPStatus status;
            foreach (vps_provider p in list)
            {
                ping = networking.ping(p.address, out status);
                if (status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    p.pings.Add(ping);
                    Int32 i32_ping = (Int32)p.calculate_avarage();
                    p.cell_latency.SetValue(i32_ping);
                    p.cell_intlatency.SetValue(i32_ping);
                    p.cell_lastping.Text = ping.ToString();
                    if (i32_ping > max)
                        max = i32_ping;
                }
                else
                    p.cell_lastping.Text = status.ToString();
            }

            col_latency.Maximum = max + 100;
        }

        private static void timer_tick(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ping_vps_providers));
            t.Start();
        }

        public static void read_xml()
        {
            try
            {
                XmlDocument xml_doc = new XmlDocument();
                xml_doc.Load(Properties.Settings.Default["VPSProviders"].ToString());

                XmlNodeList providers_list = xml_doc.SelectNodes("provider_list");
                XmlNodeList _providers = providers_list.Item(0).SelectNodes("provider");

                foreach (XmlNode node in _providers)
                {
                    vps_provider p = new vps_provider();
                    XmlNodeList props = node.ChildNodes;
                    foreach (XmlNode prop in props)
                    {
                        switch (prop.Name)
                        {
                            case "name":
                                p.name = prop.InnerText;
                                break;
                            case "address":
                                p.address = prop.InnerText;
                                break;
                            case "location":
                                p.location = prop.InnerText;
                                break;
                        }
                    }
                    list.Add(p);
                }

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Could not read VPS Providers XML file: " + e.Message);
            }
        }


    }

    public class vps_provider
    {
        public string name;
        public string address;
        public string location;
        public Divelements.SandGrid.GridCell cell_latency;
        public Divelements.SandGrid.GridCell cell_intlatency;
        public Divelements.SandGrid.GridCell cell_lastping;
        public ArrayList pings;

        public vps_provider()
        {
            name = address = location = "";
            pings = new ArrayList();
        }

        public long calculate_avarage()
        {
            long total=0;

            if (pings.Count > 0)
            {
                try
                {
                    foreach (long ping in pings)
                    {
                        total += ping;
                    }

                    return total / pings.Count;
                }
                catch (Exception e)
                {
                    return -1;
                }
            }

            return -1;
        }
    }
}
