using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Byte_Chat_Srarp_Server.ByteChatContracts;
using Byte_Chat_Srarp_Server.Common;

namespace Byte_Chat_Srarp_Server.ByteChatClasses
{
    /// <summary>
    /// Byte chat server class
    /// </summary>
    public static class Server
    {
        private static Thread _serverThread;

        private static object _criticalSection = false;

        private static List<IClient> _clients;

        /// <summary>
        /// Start Server Thread
        /// </summary>
        /// <param name="endPoint"></param>
        public static void StartServer(IPEndPoint endPoint)
        {
            try
            {
                if(endPoint == null)
                    throw new ByteChatException("IP End Point is null", "Start Server: ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                
                if (_serverThread != null)
                {
                    Console.WriteLine("Stop previously launched thread...");
                    _serverThread.Abort();
                    _serverThread = null;
                    
                    lock (_criticalSection)
                    {
                        if (_clients != null)
                        {
                            _clients.Clear();
                            _clients = null;
                        }
                    }
                }

                Console.WriteLine("Starting server thread...");
                Console.ForegroundColor = CommonConstants.DefaultColor;

                _serverThread = new Thread(ServerThreadMethod) { IsBackground = true };
                _serverThread.Start(endPoint);
            }
            catch (Exception exception)
            {
                ErrorLogger.LogConsoleAndFile(exception, "Start Server: ");
            }
        }

        private static void ServerThreadMethod(object endPoint)
        {
            try
            {
                lock (_criticalSection)
                {
                    _clients = new List<IClient>();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Start binding...");
                //prepare end point for binding
                IPEndPoint localEndPoint = (IPEndPoint)endPoint;


                Console.WriteLine("End point binded on Address: " + localEndPoint.Address);
                Console.WriteLine("End point binded on Port: " + localEndPoint.Port);


                Console.WriteLine("Your IP addresses:");
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.WriteLine("\t " + ip);
                    }
                }

                // Create a TCP/IP socket.
                Socket serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                //Binding server socket
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(10);
                Console.WriteLine("Socket binded.");

                Console.WriteLine("Start listening...");

                Console.ForegroundColor = CommonConstants.DefaultColor;
                while (true)
                {
                    Socket newClientSocket = serverSocket.Accept();

                    string messageConnectedClient;
                    string clientIP;

                    lock (_criticalSection)
                    {
                        byte[] rceivedBytes = new byte[CommonConstants.MessageLength];

                        int receivedCount = newClientSocket.Receive(rceivedBytes);

                        string messageName = Encoding.UTF8.GetString(rceivedBytes, 0, receivedCount);
                        
                        IClient client = new Client(newClientSocket, _clients, messageName, _criticalSection);

                        _clients.Add(client);

                        clientIP = ((IPEndPoint) newClientSocket.RemoteEndPoint).Address.ToString();

                        messageConnectedClient = "Connected: " + client.Name;
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(messageConnectedClient + " IP: " + clientIP);
                    Console.ForegroundColor = CommonConstants.DefaultColor;

                    SendAll(messageConnectedClient);
                }
            }
            catch (Exception exception)
            {
                ErrorLogger.LogConsoleAndFile(exception, "Server Thread stopping: ");
            }
            finally
            {
                _serverThread = null;

                if (_clients != null)
                {
                    lock (_criticalSection)
                    {
                        _clients.Clear();
                        _clients = null;
                    }
                }
            }
        }

        public static void SendAll(string message, IClient clientNotSend = null)
        {
            try
            {
                lock (_criticalSection)
                {
                    foreach (var client in _clients)
                    {
                        try
                        {
                            if(!client.Equals(clientNotSend))
                                client.SendMessage(message);
                        }
                        catch (Exception localException)
                        {
                            Console.WriteLine("Error sending message to " + client.Name + ": " + localException.Message);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ErrorLogger.LogConsoleAndFile(exception);
            }
        }
    }
}
