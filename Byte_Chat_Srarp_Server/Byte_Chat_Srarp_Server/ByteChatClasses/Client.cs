using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Byte_Chat_Srarp_Server.ByteChatContracts;
using Byte_Chat_Srarp_Server.Common;

namespace Byte_Chat_Srarp_Server.ByteChatClasses
{
    public class Client : IClient, IDisposable
    {
        private readonly Socket _clientSocket;

        private readonly List<IClient> _clients;

        private readonly object _criticalSection;

        private Thread _clientThread;

        public Client(Socket currentClientSocket, List<IClient> clients, string name, object criticalSection)
        {
            if (currentClientSocket == null)
                throw new ByteChatException("Socket is null", "Client constructor: ");
            _clientSocket = currentClientSocket;

            Name = name;

            if (currentClientSocket == null)
                throw new ByteChatException("Clients list is null", "Client constructor: ");
            _clients = clients;


            if (criticalSection == null)
                throw new ByteChatException("Critical section is null", "Client constructor: ");
            _criticalSection = criticalSection;

            _clientThread = new Thread(ThreadReceiveMessages) {IsBackground = true};
            _clientThread.Start();
        }

        ~Client()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_clients != null)
            {
                _clients.Remove(this);
            }
            lock (_criticalSection)
            {
                if (_clientSocket != null)
                {
                    if(_clientSocket.Connected)
                        _clientSocket.Disconnect(false);
                    _clientSocket.Close();
                    _clientSocket.Dispose();
                }
            }
            _clientThread = null;
        }


        public void SendMessage(string message)
        {
            try
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                _clientSocket.Send(messageBytes, SocketFlags.None);
            }
            catch (Exception exception)
            {
                ErrorLogger.LogConsoleAndFile(exception);
            }
        }

        public void Disconnect()
        {
            if (_clientSocket != null)
            {
                Dispose();
            }
        }

        public string Name { get; }

        private void ThreadReceiveMessages()
        {
            try
            {
                while (_clientSocket.Connected)
                {
                    byte[] rceivedBytes = new byte[CommonConstants.MessageLength];

                    int receivedCount = _clientSocket.Receive(rceivedBytes);

                    string message = Encoding.UTF8.GetString(rceivedBytes, 0, receivedCount);

                    lock (_criticalSection)
                    {
                        message = Name + ": " + message;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(message);
                        Console.ForegroundColor = CommonConstants.DefaultColor;

                        Server.SendAll(message);
                    }
                }
            }
            catch (Exception exception)
            {
                //client diconnected or some other socket problem
                string disconnectMessage = "Disconnected: " + Name;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(disconnectMessage + " [" + exception.Message + "]");
                Console.ForegroundColor = CommonConstants.DefaultColor;

                Server.SendAll(disconnectMessage, this);

                Disconnect();
            }
        }
    }
}
