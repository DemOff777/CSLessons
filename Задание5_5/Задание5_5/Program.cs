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

            FillNumberArray(numbers1, random);
            FillNumberArray(numbers2, random);

            ShowNumberArray(numbers1);
            ShowNumberArray(numbers2);

            AddUniqeValue(finalNumbers, numbers1);
            AddUniqeValue(finalNumbers, numbers2);

            ShowNumberArray(finalNumbers.ToArray());
        }

        static void FillNumberArray(int[] numbers, Random random)
        {
            int numbersMaxVolue = 30;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(numbersMaxVolue + 1);
            }
        }

        static void AddUniqeValue(List<int> finalNumbers, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (finalNumbers.Contains(numbers[i]) == false)
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
    }
}
