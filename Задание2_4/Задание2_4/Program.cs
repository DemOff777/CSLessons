using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            int sumTotal;
            int sumPositiveNumber1 = 0;
            int sumPositiveNumber2 = 0;
            int step1 = 3;
            int step2 = 5;
            int initialNumber = 0;
            int lastNumber = 101;

            Random random = new Random();
            number = random.Next(initialNumber,lastNumber);
            Console.WriteLine(number);

            for (int positiveNumber1 = 0, positiveNumber2 = 0; positiveNumber1 <= number || positiveNumber2 <= number; positiveNumber1 += step1,positiveNumber2 += step2)
            {
                Console.WriteLine(positiveNumber1);
                Console.WriteLine(positiveNumber2);
                Console.WriteLine();
                Console.WriteLine("Summa");
                sumPositiveNumber1 += positiveNumber1;
                Console.WriteLine(sumPositiveNumber1);

                if (positiveNumber2 <= number) 
                {
                    sumPositiveNumber2 += positiveNumber2;
                }
                Console.WriteLine(sumPositiveNumber2);
                Console.WriteLine();
            }
            sumTotal = sumPositiveNumber1 + sumPositiveNumber2;
            Console.WriteLine(sumTotal);
        }
    }
}
