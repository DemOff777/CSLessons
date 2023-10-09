using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание3_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stepLeft;
            int maxNumber = 10;
            int arraySize = 5;
            int temporaryStorageOfNumber;

            bool isProgrammRunning = true;

            int[] numbers = new int[arraySize];

            Random arrayRandom = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                numbers[i] = arrayRandom.Next(maxNumber + 1);
            }

            while (isProgrammRunning)
            {
                foreach (int item in numbers)
                {
                    Console.Write(item + " ");
                }

                Console.Write("\nВведите шаг для сдвига влево: ");
                stepLeft = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < stepLeft; i++)
                {
                    temporaryStorageOfNumber = numbers[0];

                    for (int j = 0; j < numbers.Length - 1; j++)
                    {
                        numbers[j] = numbers[j + 1];
                    }

                    numbers[numbers.Length - 1] = temporaryStorageOfNumber;
                }
            }
        }
    }
}
