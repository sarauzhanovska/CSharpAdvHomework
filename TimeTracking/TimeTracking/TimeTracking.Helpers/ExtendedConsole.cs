﻿

namespace TimeTracking.Helpers
{
    public class ExtendedConsole
    {
        public static void PrintInColor(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintTitle(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintSuccess(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void PrintError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadLine();
        }

        public static string GetInput(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        public static int GetInputInt(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }
    }
}
