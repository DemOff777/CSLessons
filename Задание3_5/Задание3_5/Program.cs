using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Задание3_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int repeatsAmount = 0;
            int arraySize = 30;
            int maxValue = 10;
            int maxRepeatedNumber = 0;
            int maxRepeatAmount = 1;

            int[] array = new int[arraySize];

            Random random = new Random();
            ;

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = random.Next(maxValue + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for (int j = 0; j < arraySize - 1; j++)
            {
                if (array[j] == array[j + 1])
                {
                    repeatsAmount++;
                }

                if (repeatsAmount >= maxRepeatAmount)
                {
                    maxRepeatedNumber = array[j];
                    maxRepeatAmount = repeatsAmount;
                }

                if (array[j] != array[j + 1])
                {
                    repeatsAmount = 0;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Число {maxRepeatedNumber} повторилось больше всего раз подряд, а именно {maxRepeatAmount}");
        }
    }
}
