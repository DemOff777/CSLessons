﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int productOfSecondLine = 1;
            int sumOfColumn = 0;
            int numberOfLine = 2;
            int numberOfColumn = 3;

            int[,] array = new int[,] { { 4, 5, 12, 3 }, { 6, 1, 14, 9 } };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == numberOfLine - 1)
                    {
                        productOfSecondLine *= array[numberOfLine - 1, j];
                    }

                    if (j == numberOfColumn - 1)
                    {
                        sumOfColumn += array[i, numberOfColumn - 1];
                    }
                }
            }

            Console.WriteLine($"сумма {numberOfColumn} столбца равна - {sumOfColumn}");
            Console.WriteLine($"произведение {numberOfLine} строки равно - {productOfSecondLine}");
        }
    }
}
