using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int powerOfNumber = 0;
            int number = 1;
            int numberLimit;
            int numberToPower = 2;
            int initialNumberMin = 0;
            int initialNumberMax = 100 + 1;

            Random randomNumber = new Random();
            numberLimit = randomNumber.Next(initialNumberMin, initialNumberMax);
            Console.WriteLine(numberLimit);

            while (number < numberLimit)
            {
                number *= numberToPower;
                Console.WriteLine(number);
                powerOfNumber++;
            }
            Console.WriteLine(powerOfNumber);
        }
    }
}
