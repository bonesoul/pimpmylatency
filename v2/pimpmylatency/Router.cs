using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.InteropServices;

namespace pimpmylatency
{
    public static class Router
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger(); 

        public static void route(Hook h, List<object> parameters)
        {
            switch (h.type)
            {
                case HOOK_TYPE.WINSOCK2_CONNECT:
                    connect(h, parameters);
                    break;
                case HOOK_TYPE.WINSOCK2_SEND:
                    send(h, parameters);
                    break;
                default:
                    break;
            }
        }

        /* connect: http://msdn.microsoft.com/en-us/library/ms737625(VS.85).aspx */
        private static void connect(Hook h, List<object> parameters)
        {
            int application_socked_id = int.Parse(((DeviareParams.IParam)parameters[0]).Value.ToString());
            sockaddr addr = (sockaddr)SocketStructures.cast_to_struct(((DeviareParams.IParam)parameters[1]).Evaluated.ValueArray, typeof(sockaddr));
            IPEndPoint endpoint=new IPEndPoint(new IPAddress(addr.in_addr),addr.sin_port);

            if (endpoint.ToString() != "0.0.0.0:0")
            {
                logger.Trace("[ROUTER_CONNECT] [socket_id: " + application_socked_id.ToString() + "] [destination: " + endpoint.ToString()+"]");
                ProxyEngine.create_connection(endpoint.Address.ToString(), (ushort)endpoint.Port, application_socked_id);
            }
        }

        private static void send(Hook h, List<object> parameters)
        {
            int application_socked_id = int.Parse(((DeviareParams.IParam)parameters[0]).Value.ToString());
            string buffer = ((DeviareParams.IParam)parameters[1]).Value.ToString();
            logger.Trace("[ROUTER_SEND] [socket_id: " + application_socked_id.ToString() + "] [data: " + buffer + "]");
            ProxyEngine.connections[application_socked_id].send_data(buffer);
        }

    }
}
