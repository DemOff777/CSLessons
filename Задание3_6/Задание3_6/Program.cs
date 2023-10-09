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
            int temporaryMinVolue = 0;
            int temporaryMinNumber = 0;
            int borderNumber = -1;
            int minVolue = borderNumber + 1;

            bool isProgrammWork = true;

            int[] numbers = new int[arraySize];

            Random arrayRandom = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = arrayRandom.Next(borderNumber +1, maxNumberVolue + 1);
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            while (isProgrammWork)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    foreach (int number in numbers)
                    {
                        if (numbers[i] <= number && numbers[i] > borderNumber)
                        {
                            temporaryMinVolue++;
                        }
                    }

                    if (temporaryMinVolue >= minVolue)
                    {
                        minVolue = temporaryMinVolue;
                        temporaryMinNumber = numbers[i];
                    }

                    temporaryMinVolue = 0;
                }

                if (temporaryMinNumber == borderNumber)
                {
                    isProgrammWork = false;
                }

                if (temporaryMinNumber > borderNumber)
                {
                    Console.Write(temporaryMinNumber + " ");
                    minVolue = borderNumber + 1;
                }

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (temporaryMinNumber == numbers[j])
                    {
                        numbers[j] = borderNumber;
                        break;
                    }
                }
            }
        }
    }
}
