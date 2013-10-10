using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace pimpmylatency
{
    public class Connection
    {
        private IPHostEntry host;
        private ushort port;
        private int application_socket_id;

        private IPEndPoint endpoint = null;
        private Socket socket = null;
        public CONNECTION_STATUS status = CONNECTION_STATUS.NOT_STARTED;

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger(); 

        public Connection(string _host, ushort _port,int _socket_id)
        {
            host = Dns.GetHostEntry(_host);
            port = _port;
            application_socket_id = _socket_id;
        }

        public void connect() // create a new connection to proxy server
        {
            logger.Trace("[CONNECT_PROXY_SERVER] [on behalf of: " + application_socket_id.ToString() + "]");
            byte[] ip=new byte[4];
            ip[0]=127;
            ip[1]=0;
            ip[2]=0;
            ip[3]=1;
            endpoint = new IPEndPoint(new IPAddress(ip), ProxyEngine.port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endpoint);
            send_hello();
        }

        public void poll() // polls the socket for new data
        {
            if (socket.Poll(0, SelectMode.SelectRead))
            {
                this.recieve_data();
            }
        }

        private void recieve_data()
        {
            byte[] data = new byte[256];
            try
            {
                if (socket.Receive(data) > 0)
                {
                    parse_reply(data);
                }
            }
            catch (SocketException e)
            {
                logger.WarnException("[SOCKETEXCEPTION] [on behalf of :" + this.application_socket_id.ToString() + "]",e);
            }
        }

        private void parse_reply(byte[] data)
        {
            byte ver = data[0];
            if (status!= CONNECTION_STATUS.READY && ver != (byte)SOCKS5.SOCKS5_VER) // this should never occur
                return;

            switch (status)
            {
                case CONNECTION_STATUS.NOT_STARTED: // should never occur
                case CONNECTION_STATUS.HANDSHAKE_COMPLETE:
                    break;
                case CONNECTION_STATUS.SENT_HANDSHAKE:
                    if (data[1] == (byte)SOCKS5.SOCKS5_AUTH_NONE)
                    {
                        status = CONNECTION_STATUS.HANDSHAKE_COMPLETE;
                        logger.Trace("[PROXY_RECV_HANDSHAKE] [on behalf of: " + application_socket_id.ToString() + "]");
                        start_bridge();
                    }
                    break;
                case CONNECTION_STATUS.REMOTE_CONNECTION_REQ_SENT:
                    if (data[1] == (byte)SOCKS5.SOCKS5_REPLY_OK)
                        ready();
                    else
                        failure();
                    break;
                case CONNECTION_STATUS.READY:
                    bridge_traffic(data);
                    break;
                default:
                    break;
            }
        }

        private void bridge_traffic(byte[] data)
        {
            Encoding enc = System.Text.Encoding.Default;
            logger.Trace("[PROXY_RECV] [on behalf of: " + application_socket_id.ToString() + "] [data: " + enc.GetString(data) + "]");
        }

        public void send_data(string data)
        {
            Encoding enc = System.Text.Encoding.Default;
            byte[] buffer = enc.GetBytes(data);
            socket.Send(buffer, buffer.Length, SocketFlags.None);
        }

        private void send_hello()
        {
            byte[] request = new byte[3];
            request[0] = (byte)SOCKS5.SOCKS5_VER;
            request[1] = 0x01; // number of auth methods
            request[2] = (byte)SOCKS5.SOCKS5_AUTH_NONE;
            socket.Send(request, 3, SocketFlags.None);
            status = CONNECTION_STATUS.SENT_HANDSHAKE;
            logger.Trace("[PROXY_SENT_HANDSHAKE] [on behalf of: " + application_socket_id.ToString() + "]");
        }

        private void start_bridge() // starts a connection over proxy to a remote endpoint
        {
            logger.Trace("[PROXY_REQUEST_CONNECT] [on behalf of: " + application_socket_id.ToString() + "] [destination: " + host.AddressList[0].ToString() + ":" + port.ToString()+"]");
            byte[] request = new byte[256];
            request[0] = (byte)SOCKS5.SOCKS5_VER;
            request[1] = (byte)SOCKS5.SOCKS5_REQ_CMD_CONNECT; // command: connect
            request[2] = (byte)SOCKS5.SOCKS5_REQ_RSV; // reserved byte
            request[3] = (byte)SOCKS5.SOCKS5_ATYP_IP4; // send ipv4 ip 

            /* inject the destination ip */
            int i = 4;
            byte[] tmp_ip = host.AddressList[0].GetAddressBytes();
            tmp_ip.CopyTo(request, i);
            i += tmp_ip.Length;

            /* inject the destination port in big-endian order */
            byte[] tmp_port = new byte[2];
            tmp_port[0] = Convert.ToByte(port / 256);
            tmp_port[1] = Convert.ToByte(port % 256);
            tmp_port.CopyTo(request, i);
            i += tmp_port.Length;
            //for (int j = tmp_port.Length - 1; j >= 0; j--)
            //{
            //    request[i] = tmp_port[j];
            //    i++;
            //}
            socket.Send(request, i, SocketFlags.None);
            status = CONNECTION_STATUS.REMOTE_CONNECTION_REQ_SENT;
        }

        private void ready()
        {
            status = CONNECTION_STATUS.READY;
            logger.Trace("[PROXY_CONNECTED_REMOTE] [on behalf of: " + application_socket_id.ToString() + "]");
            send_data("GET / HTTP/1.1\r\nUser-Agent: NiceCleanExample of TCPListener\r\nHost: www.nps.gov\r\nConnection: Close\r\n\r\n");
        }

        private void failure()
        {
            status = CONNECTION_STATUS.FAILED;
            logger.Trace("[PROXY_FAILED_REMOTE] [on behalf of: " + application_socket_id.ToString() + "]");
        }
    }
}
