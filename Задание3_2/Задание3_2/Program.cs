using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = 10;
            int numberOfColumns = 10;
            int minNumber = 0;
            int maxNumber = 100;
            int matrixMaxValue = int.MinValue;
            int newSymbolOfMaxVolue = 0;

            int[,] matrix = new int[numberOfLines, numberOfColumns];

            Random rand = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = rand.Next(minNumber,maxNumber + 1);
                    Console.Write(matrix[i, j] + " ");

                    if (matrixMaxValue < matrix[i,j])
                    {
                        matrixMaxValue = matrix[i,j];
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine(matrixMaxValue);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrixMaxValue == matrix[i, j])
                    {
                        matrix[i, j] = newSymbolOfMaxVolue;
                    }

                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
