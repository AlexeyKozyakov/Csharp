using System;
using System.IO;

namespace lab3
{
    public class LineCounter
    {
        public static long Count(string type)
        {
            var linesNum = 0L;
            try
            {
                var files = Directory.GetFiles(Directory.GetCurrentDirectory(), $"*.{type}",
                    SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var lines = File.ReadLines(file);
                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        var trimmed = line.Trim('\n', '\r', '\t', '\v', ' ');
                        if (!trimmed.StartsWith("//"))
                        {
                            ++linesNum;
                        }
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Directory does not contain {type} files");
            }
            return linesNum;
        }
    }
}
