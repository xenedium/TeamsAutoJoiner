using System;
using System.Diagnostics;

namespace TeamsAutoJoiner
{
    public static class Log
    {
        public static void Info(string log)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"[-] {log}");
            Console.ResetColor();
        }

        public static void Error(string log)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[err] {log}");
            Process.GetCurrentProcess().Kill();
        }

        public static void Warn(string log)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[!] {log}");
            Console.ResetColor();    
        }
        
    }
}