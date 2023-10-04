using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание3_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userNumber;
            int sumOfNumbers = 0;

            const string CommandSum = "sum";
            const string CommandExit = "exit";

            string userCommand = string.Empty;

            int[] numbers = new int[0];

            bool isUserEnterNumbers = true;

            while (isUserEnterNumbers)
            {
                Console.WriteLine();
                Console.WriteLine($"{CommandExit} - завершить программу.");
                Console.WriteLine($"{CommandSum} - суммировать введенные числа");
                Console.Write("Введите число или команду: ");
                userCommand = Console.ReadLine();

                switch (userCommand)
                {
                    case CommandExit:
                        isUserEnterNumbers = false;
                        Console.WriteLine("Вы вышли");
                        break;

                    case CommandSum:
                        Console.Clear();
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            sumOfNumbers += numbers[i];
                        }

                        Console.Write(sumOfNumbers);
                        sumOfNumbers = 0;   
                        break;

                    default:
                        Console.Clear();

                        int[] newNumbers = new int[numbers.Length + 1];

                        for (int i = 0; i < numbers.Length; i++)
                        {
                            newNumbers[i] = numbers[i];
                            Console.Write(newNumbers[i] + " ");
                        }

                        numbers = newNumbers;
                        userNumber = Convert.ToInt32(userCommand);
                        numbers[numbers.Length - 1] = userNumber;
                        Console.Write(userNumber);
                        break;
                }
            }
        }
    }
}
