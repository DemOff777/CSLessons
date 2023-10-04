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
            int maxRepeatAmount = 0;

            int[] array = new int[arraySize];

            Random arrayRandon = new Random();
            ;

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = arrayRandon.Next(maxValue + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for (int j = 0; j < arraySize; j++)
            {
                if ( j <= arraySize - 2)
                {
                    if (array[j] == array[j + 1])
                    {
                        repeatsAmount++;
                        Console.Write(array[j] + " ");

                        for (int k = j + 1; k < arraySize; k++)
                        {
                            if (k <= arraySize - 2)
                            {
                                while (array[j] == array[k + 1])
                                {
                                    repeatsAmount++;
                                    k++;
                                    Console.Write(array[j] + " ");
                                }
                            }

                            j = k;
                            break;
                        }

                        if (repeatsAmount > maxRepeatAmount)
                        {
                            maxRepeatAmount = repeatsAmount;
                            maxRepeatedNumber = array[j];
                        }

                        repeatsAmount = 0;
                        Console.Write(array[j] + "   ");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Число {maxRepeatedNumber} повторилось больше всего раз, а именно {maxRepeatAmount + 1}");
        }
    }
}
