using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace pimpmylatency
{
    enum SOCKS5
    {
        /* general */
        SOCKS5_VER                          = 0x05, /* socks5 */
        SOCKS5_AUTH_NONE                    = 0x00, /* no authentication */
        SOCKS5_AUTH_GSSAPI                  = 0x01, 
        SOCKS5_AUTH_PASS                    = 0x02, /* password based auth */
        SOCKS5_AUTH_NO_METHODS              = 0xFF,
        /* address types */
        SOCKS5_ATYP_IP4                     = 0x01, /* ipv4 ip address */
        SOCKS5_ATYP_DOMAIN                  = 0x03, /* fully qualified domain name */
        SOCKS5_ATYP_IP6                     = 0x04,  /* ipv6 ip address */
        /* requests */
        SOCKS5_REQ_CMD_CONNECT              = 0x01, /* connect command */
        SOCKS5_REQ_RSV                      = 0x00, /* reserved */
        /* replies */
        SOCKS5_REPLY_OK                     = 0x00, /* succeeded */
        SOCKS5_REPLY_GENERAL_FAILURE        = 0x01, /* general SOCKS server failure */
        SOCKS5_REPLY_CONN_NOT_ALLOWED       = 0x02, /* connection not allowed by ruleset */
        SOCKS5_REPLY_NET_UNREACHABLE        = 0x03, /* Network unreachable */
        SOCKS5_REPLY_HOST_UNREACHABLE       = 0x04, /* Host unreachable */
        SOCKS5_REPLY_CONN_REFUSED           = 0x05, /* Connection refused */
        SOCKS5_REPLY_TTL_EXPIRED            = 0x06, /* TTL expired */
        SOCKS5_REPLY_CMD_NOT_SUPPOPRTED     = 0x07, /* Command not supported */
        SOCKS5_REPLY_ATYPE_NOT_SUPPORTED    = 0x08  /* Address type not supported */
    }

    public enum CONNECTION_STATUS
    {
        NOT_STARTED                 = 0x00,
        SENT_HANDSHAKE              = 0x01,
        HANDSHAKE_COMPLETE          = 0x02,      
        REMOTE_CONNECTION_REQ_SENT  = 0x03,
        READY                       = 0x04,
        FAILED                      = 0x99
    }

    public static class ProxyEngine
    {
        public static Dictionary<int,Connection> connections=null;

        public static IPHostEntry host;
        public static ushort port;

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger(); 

        public static void init(string _addr,ushort _port)
        {
            logger.Trace("ProxyEngine init()..");
            connections = new Dictionary<int, Connection>();
            host = Dns.GetHostEntry(_addr);
            port=_port;

            // setup a threaded poller
            Thread t = new Thread(new ThreadStart(poller));
            t.Start();
        }

        public static void create_connection(string destination, ushort port,int application_socket_id)
        {
            Connection c = new Connection(destination, port,application_socket_id);
            connections.Add(application_socket_id,c);
            c.connect();
        }

        public static void poller()
        {
            logger.Trace("Socket poller thread started..");
            while (true)
            {
                if (connections.Count > 0)
                {
                    try
                    {
                        foreach (KeyValuePair<int, Connection> pair in connections)
                        {
                            if (pair.Value.status != CONNECTION_STATUS.NOT_STARTED)
                                pair.Value.poll();
                        }
                    }
                    catch (Exception e)
                    {
                        logger.WarnException("poller exception", e);
                    }
                }
            }
        }
    }       
}
