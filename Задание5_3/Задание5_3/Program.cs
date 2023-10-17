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
            const string Sum = "sum";
            const string Exit = "exit";

            int sum = 0;
            int numberValue = 0;

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
                    case Sum:
                        Console.WriteLine(sum);
                        break;

                    case Exit:
                        isProgramWork = false;
                        break;

                    default:
                        if (int.TryParse(userInput, out numberValue))
                        {
                            sum += numberValue;
                            numbers.Add(numberValue);
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое значение");
                        }
                        break;
                }
            }
        }
    }
}
