using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = 10;
            int[] array = new int[arrayLength];
            int numberOfArrayMaxVolue = 100;
            int localMaximumNumber;
            int lastIndex = arrayLength - 1;

            Random random = new Random();

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = random.Next(numberOfArrayMaxVolue) + 1;
                Console.Write(array[i] + " ");
            }

            Console.Write("\nЛокальные максимумы: ");

            if (array[0] > array[1])
            {
                Console.Write(array[0] + " ");
            }

            for (int j = 1; j < arrayLength - 1; j++)
            {
                if (array[j - 1] < array[j] && array[j + 1] < array[j])
                {
                    localMaximumNumber = array[j];
                    Console.Write(localMaximumNumber + " ");
                }
            }

            if (array[arrayLength - 1] > array[lastIndex - 1])
            {
                Console.Write(array[arrayLength - 1] + " ");
            }

            Console.WriteLine();
        }
    }
}
