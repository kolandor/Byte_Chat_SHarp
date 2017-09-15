using System;
using System.IO;
using System.Windows.Forms;

namespace Byte_Chat_Srarp_Server.Common
{
    public static class ErrorLogger
    {
        public static void LogFile(Exception exception, string adds = "")
        {
            try
            {
                using (FileStream loggerFileStream = new FileStream("ExceptionLog.txt", FileMode.Append, FileAccess.Write))
                {
                    StreamWriter streamWriter = new StreamWriter(loggerFileStream);
                    string exceptionMessage = "\t\t\t" + DateTime.Now + " - " + adds + " " + exception.Message + "\n" + exception.StackTrace + "\n";
                    streamWriter.Write(exceptionMessage);
                    streamWriter.Flush();
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (Exception critException)
            {
                MessageBox.Show(@"Critical exception in logger: " + critException.Message, @"CRITICAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LogConsoleAndFile(Exception exception, string adds = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(adds + " " + exception.Message);
            LogFile(exception, adds);
            Console.ForegroundColor = CommonConstants.DefaultColor;
        }
    }
}
