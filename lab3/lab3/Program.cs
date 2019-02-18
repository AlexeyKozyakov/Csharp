using System;
using System.IO;

namespace lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                printUsage();
                return;
            }

            var lineNum = LineCounter.Count(args[0]);
            Console.WriteLine($"{lineNum} lines in .{args[0]} files in dir {Directory.GetCurrentDirectory()}");
        }

        private static void printUsage()
        {
            Console.WriteLine($"usage: {AppDomain.CurrentDomain.FriendlyName}");
        }
    }
}