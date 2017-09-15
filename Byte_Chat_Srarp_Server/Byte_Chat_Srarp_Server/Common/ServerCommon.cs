using System;
using System.Net;
using System.Net.Sockets;

namespace Byte_Chat_Srarp_Server.Common
{
    public static class ServerCommon
    {
        public static IPEndPoint GetServerEndPoint()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write("Input server port: ");
                string strPort = Console.ReadLine();
                if (strPort != null)
                {
                    int port = int.Parse(strPort);

                    IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                    IPAddress ipAddress = null;

                    foreach (IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            ipAddress = ip;
                            break;
                        }
                    }

                    if(ipAddress == null)
                        throw new ByteChatException("Local IP Address Not Found!");

                    IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
                    return endPoint;
                }

                Console.ForegroundColor = CommonConstants.DefaultColor;
            }
            catch (Exception exception)
            {
                ErrorLogger.LogConsoleAndFile(exception);
            }
            return null;
        }
    }
}
