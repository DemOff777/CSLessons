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
            int maxNumberVolue = 100;
            int minVolueNumber = maxNumberVolue;

            int[] array = new int[arraySize];

            Random arrayRandom = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = arrayRandom.Next(maxNumberVolue + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (j < array.Length - 1)
                    {
                        if (array[j] <= array[j + 1] && array[j] < minVolueNumber)
                        {
                            minVolueNumber = array[j];
                        }
                    }
                }

                if (minVolueNumber > array[array.Length - 1])
                {
                    minVolueNumber = array[array.Length - 1];
                }

                Console.Write(minVolueNumber + " ");

                for (int k = 0; k < array.Length; k++)
                {
                    if (array[k] == minVolueNumber)
                    {
                        array[k] = maxNumberVolue + 1;
                        break;
                    }

                }

                minVolueNumber = maxNumberVolue;
            }    

            Console.WriteLine();
        }
    }
}
