using System;
using Byte_Chat_Srarp_Server.ByteChatClasses;
using Byte_Chat_Srarp_Server.Common;

namespace Byte_Chat_Srarp_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\tWelcome to Byte Chat server C# revision");
                Console.ForegroundColor = CommonConstants.DefaultConsoleColor;
                Server.StartServer(ServerCommon.GetServerEndPoint());
                Console.ReadKey();
            }
            catch (ByteChatException exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadKey();
            }
        }
    }
}
