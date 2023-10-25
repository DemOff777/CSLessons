using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Задание5_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = new int[10];
            int[] numbers2 = new int[8];

            List<int> finalNumbers = new List<int>();

            Random random = new Random();

            SetRandomNumbers(numbers1, random);
            SetRandomNumbers(numbers2, random);

            ShowNumberArray(numbers1);
            ShowNumberArray(numbers2);

            AddDifferentNumbers(finalNumbers, numbers1);
            AddDifferentNumbers(finalNumbers, numbers2);

            ShowFinalArray(finalNumbers);
        }

        static void SetRandomNumbers(int[] numbers, Random random)
        {
            int numbersMaxVolue = 30;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(numbersMaxVolue + 1);
            }
        }

        static void AddDifferentNumbers(List<int> finalNumbers, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!finalNumbers.Contains(numbers[i]))
                {
                    finalNumbers.Add(numbers[i]);
                }
            }
        }

        static void ShowNumberArray(int[] numbers)
        {
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
        }

        static void ShowFinalArray(List<int> finalNumbers)
        {
            foreach (var number in finalNumbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
