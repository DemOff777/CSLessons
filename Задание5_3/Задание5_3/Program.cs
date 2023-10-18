using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            bool isProgramWork = true;

            string userInput = string.Empty;

            List<int> numbers = new List<int>();

            while (isProgramWork)
            {
                foreach (int number in numbers)
                {
                    Console.Write(number + " ");
                }

                Console.Write("\nВведите число: ");
                userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandSum:
                        Console.WriteLine(numbers.Sum());
                        break;

                    case CommandExit:
                        isProgramWork = false;
                        break;

                    default:
                        TryAddNumberValue(numbers, userInput);
                        break;
                }
            }
        }

        static void TryAddNumberValue (List<int> numbers, string userInput)
        {
            int numberValue = 0;

            if (int.TryParse(userInput, out numberValue))
            {
                numbers.Add(numberValue);
            }
            else
            {
                Console.WriteLine("Недопустимое значение");
            }
        }

    }
}
