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
            int arrayLength = 1;
            int userNumber;
            int sumOfNumbers = 0;

            const string CommandSum = "sum";
            const string CommandExit = "exit";

            string userCommand = string.Empty;

            int[] numbers = new int[arrayLength];

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
                        for (int i = 0; i < arrayLength; i++)
                        {
                            sumOfNumbers += numbers[i];
                        }

                        Console.Write(sumOfNumbers);
                        sumOfNumbers = 0;   
                        break;

                    default:
                        userNumber = Convert.ToInt32(userCommand);
                        Console.Clear();
                        numbers[arrayLength - 1] = userNumber;

                        arrayLength++;

                        int[] newNumbers = new int[arrayLength];

                        for (int i = 0; i < arrayLength; i++)
                        {
                            if (i < arrayLength - 1)
                            {
                                newNumbers[i] = numbers[i];
                                Console.Write(newNumbers[i] + " ");
                            }
                        }

                        numbers = newNumbers;

                        break;
                }
            }
        }
    }
}
