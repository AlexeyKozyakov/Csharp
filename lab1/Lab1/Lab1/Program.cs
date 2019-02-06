using System;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter date");
            while (true)
            {
                var date = Console.ReadLine();
                ShowCalendar(date);
            }
        }

        private static void ShowCalendar(string date)
        {
            if (!DateTime.TryParse(date, out var currentDate))
            {
                Console.WriteLine("Wrong date format");
                return;
            }
            Console.WriteLine("Пн Вт Ср Чт Пт Сб Вс");
            var firstDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            var dayOfWeek = (int) firstDate.DayOfWeek == 0 ? 7 : (int) firstDate.DayOfWeek;
            for (var i = 0; i < dayOfWeek - 1; i++)
            {
                Console.Write("   ");
            }

            var month = firstDate.Month;
            var count = 0;
            for (; firstDate.Month == month; firstDate = firstDate.AddDays(1))
            {
                if (firstDate.DayOfWeek == DayOfWeek.Monday && firstDate.Day != 1)
                {
                    Console.WriteLine();
                }
                Console.Write(firstDate.Day + (firstDate.Day / 10 == 0 ? "  " : " "));
                if (firstDate.DayOfWeek != DayOfWeek.Saturday && firstDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++count;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Number of working days " + count);
        }
        
    }
}