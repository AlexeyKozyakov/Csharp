
using System;
using System.Linq;
using System.Text;

namespace lab2
{
    public class GuessGame
    {
        private static readonly string[] Phrases = {
            "не сдавайтесь, у вас почти получилось!",
            "вы молодец, но вам стоит попробовать ещё!",
            "вы лучший игрок за всю историю, продолжайте!",
            "чтобы угадать число нужно только... (читать продолжение в платном источнике)"
        };
        
        private int _attempts = 0;
        private readonly StringBuilder _history = new StringBuilder(256);
        private string _username;
        private int _number;
        private readonly Random _random = new Random();
        
        
        public void Start()
        {
            Console.WriteLine("Как вас зовут?");
            _username = Console.ReadLine();
            _number = _random.Next(51);
            GuessLoop();
            
        }

        private void GuessLoop()
        {
            Console.WriteLine("Угадайте случайное число от 0 до 50");
            DateTime startTime = DateTime.Now;
            while (true)
            {
                ++_attempts;

                string userInput = Console.ReadLine();
                if (userInput == "q")
                {
                    Console.WriteLine("До свидания...");
                    break;
                }

                while (string.IsNullOrEmpty(userInput) || !userInput.All(char.IsDigit))
                {
                    Console.WriteLine("Вы ввели не число, попробуйте ещё раз");
                    userInput = Console.ReadLine();
                }
                
                int userNumber = int.Parse(userInput);

                if (userNumber < _number)
                {
                    Console.WriteLine("Не верно, число меньше загаданного, попробуйте ещё раз");
                    _history.Append($"{userNumber} меньше\n");
                }

                if (userNumber > _number)
                {
                    Console.WriteLine("Не верно, число больше загаданного, попробуйте ещё раз");
                    _history.Append($"{userNumber} больше\n");
                }

                if (userNumber == _number)
                {
                    int ellapsedMinutes = (DateTime.Now - startTime).Minutes;
                    Console.WriteLine($"Поздравляю, вы угадали!\nКоличество попыток: {_attempts}");
                    Console.WriteLine($"История:\n{_history}Затраченное время: {ellapsedMinutes} мин");
                    break;
                }

                if (_attempts % 4 == 0)
                {
                    Console.WriteLine($"{_username}, {Phrases[_random.Next(Phrases.Length)]}");
                }
            }
        }
    }
}