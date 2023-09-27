﻿using System;
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
            int arrayLength = 30;
            int[] array = new int[arrayLength];
            int numberOfArrayMaxVolue = 100;
            int localMaximumNumber;

            Random rand = new Random();

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = rand.Next(numberOfArrayMaxVolue) + 1;
                Console.Write(array[i] + " ");
            }

            Console.Write("\nЛокальные максимумы: ");

            for (int j = 0; j < arrayLength; j++)
            {
                if (j > 0 && j < arrayLength - 2)
                {
                    if (array[j - 1] < array[j] && array[j + 1] < array[j])
                    {
                        localMaximumNumber = array[j];
                        Console.Write(localMaximumNumber + " ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
