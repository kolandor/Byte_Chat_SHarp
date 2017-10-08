using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

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

                Console.ForegroundColor = CommonConstants.DefaultConsoleColor;
            }
            catch (Exception exception)
            {
                ErrorLogger.LogConsoleAndFile(exception);
            }
            return null;
        }

        public static void ShowServerIpInfo()
        {
            
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            if (host.AddressList.Length > 0)
            {
                ConsoleColor currentColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Your local IP addresses:");

                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.WriteLine($"\t  {ip}");
                    }
                }

                Console.WriteLine("Your Internet IP address:");

                Console.WriteLine($"\t {GetInternalIp()}");
                Console.ForegroundColor = CommonConstants.DefaultConsoleColor;

                Console.ForegroundColor = currentColor;
            }
        }

        private static string GetInternalIp()
        {

            try
            {
                WebRequest request = WebRequest.Create("http://geoip.hidemyass.com/");
                Stream responseStream = request.GetResponse().GetResponseStream();

                if (responseStream != null)
                {
                    StreamReader reader = new StreamReader(responseStream);

                    string html = reader.ReadToEnd();

                    Regex regex = new Regex("\\d+\\.\\d+\\.\\d+\\.\\d+");

                    MatchCollection matches = regex.Matches(html);

                    foreach (Match match in matches)
                    {
                        return match.Value;
                    }

                    reader.Close();
                    reader.Dispose();
                    responseStream.Close();
                    responseStream.Dispose();
                }
            }
            catch
            {
                return "Error: Can't get external IP";
            }
            return "Can't get external IP";
        }
    }
}
