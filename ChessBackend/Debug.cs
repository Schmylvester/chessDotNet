using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend
{
    class Debug
    {
        public static void printError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
