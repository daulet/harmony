using System;

namespace Logger.Provider
{
    public class ColorfulConsole : ILogger
    {
        public void Error(string message)
        {
            WriteLine(message, ConsoleColor.Red);
        }

        public void Info(string message)
        {
            WriteLine(message, Console.ForegroundColor);
        }

        public void Verbose(string message)
        {
            WriteLine(message, ConsoleColor.DarkGray);
        }

        public void Warning(string message)
        {
            WriteLine(message, ConsoleColor.Yellow);
        }

        private static void WriteLine(string message, ConsoleColor foregroundColor)
        {
            var currentColor = Console.ForegroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
