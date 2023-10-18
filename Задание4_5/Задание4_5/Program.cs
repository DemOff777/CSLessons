using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание4_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 10;

            int firstNumber = 0;
            int lastNumber = 20;

            int[] numbers = new int[arraySize];

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(firstNumber, lastNumber);
            }

            ShowArray(numbers);

            SortArrayRandom(numbers);
            Console.WriteLine();

            ShowArray(numbers);
        }

        static void SortArrayRandom(int[] numbers)
        {
            int randomArrayIndex;
            int temporaryNumber;

            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                randomArrayIndex = random.Next(numbers.Length);
                temporaryNumber = numbers[randomArrayIndex];
                numbers[randomArrayIndex] = numbers[i];
                numbers[i] = temporaryNumber;
            }
        }

        static void ShowArray(int[] array)
        {
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
        }
    }
}
