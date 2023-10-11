using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание3_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 10;
            int maxNumberValue = 10;
            int temporaryNumber = 0;

            bool isNumbersSorted = false;

            int[] numbers = new int[arraySize];

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maxNumberValue + 1);
                Console.Write(numbers[i] + " ");
            }

            while (isNumbersSorted == false)
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] < numbers[i + 1])
                    {
                        isNumbersSorted = true;
                    }
                }

                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        temporaryNumber = numbers[i + 1];
                        numbers[i + 1] = numbers[i];
                        numbers[i] = temporaryNumber;
                        isNumbersSorted = false;
                    }
                }
            }

            Console.WriteLine();

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
