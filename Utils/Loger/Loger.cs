using System;
using System.IO;

namespace intelligence.Utils.Loger
{
    public static class Logger
    {
        public static void Log(string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";
            Console.WriteLine(logEntry);
            File.AppendAllText("C:\\Users\\IMOE001\\Desktop\\c#\\intelligence\\log.txt", logEntry + Environment.NewLine);
        }
        public static string Read()
        {
            if (!File.Exists("log.txt"))
            {
                return string.Empty;
            }
            return File.ReadAllText("log.txt");
        }
    }
}