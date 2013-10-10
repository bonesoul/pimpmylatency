using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace pimpmylatency
{
    public static class networking
    {
        public static long ping(string host,out IPStatus status)
        {
            try
            {
                Ping p = new Ping();
                PingOptions po = new PingOptions();
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                PingReply pr = p.Send(host, 30, buffer, po);
                status = pr.Status;
                return pr.RoundtripTime;
            }
            catch (Exception e)
            {
                status = IPStatus.TimedOut;
                return -1;
            }
        }

        public static Boolean validate_server_address(string address)
        {
            if (address.Trim() == "") return false;
            try
            {
                IPHostEntry host = Dns.GetHostEntry(address);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
