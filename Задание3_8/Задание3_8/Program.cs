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

            int[] array = new int[arraySize];

            Random arrayRandom = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = arrayRandom.Next(maxNumber + 1);
            }

            while (isProgrammRunning)
            {
                foreach (int item in array)
                {
                    Console.Write(item + " ");
                }

                Console.Write("\nВведите шаг для сдвига влево: ");
                stepLeft = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < stepLeft; i++)
                {
                    temporaryStorageOfNumber = array[0];

                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }

                    array[array.Length - 1] = temporaryStorageOfNumber;
                }
            }
        }
    }
}
