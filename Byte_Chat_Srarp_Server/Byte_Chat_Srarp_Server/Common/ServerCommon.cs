using System;
using System.Net;

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
                    
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
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
