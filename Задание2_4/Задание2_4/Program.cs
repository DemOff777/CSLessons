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
            int sumOfThree = 0;
            int sumOfFive = 0;
            int sumFinish;

            Random random = new Random();
            number = random.Next(0, 101);
            Console.WriteLine(number);
            for (int multipleOfThree = 0; multipleOfThree <= number; multipleOfThree += 3)
            {
                sumOfThree += multipleOfThree;
            }
            for (int multipleOfFive = 0; multipleOfFive <= number; multipleOfFive += 5)
            {
                sumOfFive += multipleOfFive;
            }
            sumFinish = sumOfThree + sumOfFive;
            Console.WriteLine(sumFinish);
        }
    }
}
