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
            int maxRandomValue = 10;
            int arraySize = 5;
            int temporaryNumber;

            int[] numbers = new int[arraySize];

            Random random = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                numbers[i] = random.Next(maxRandomValue + 1);
            }

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.Write("\n\nВведите шаг для сдвига влево: ");
            stepLeft = Convert.ToInt32(Console.ReadLine());
            stepLeft = stepLeft % arraySize;

            for (int i = 0; i < stepLeft; i++)
            {
                temporaryNumber = numbers[0];

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];

                }

                numbers[numbers.Length - 1] = temporaryNumber;
            }

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
