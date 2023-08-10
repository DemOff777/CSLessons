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
            int sum = 0;
            int step = 3;
            int initialNumber = 0;
            int lastNumber = 101;

            Random random = new Random();
            number = random.Next(initialNumber, lastNumber);
            Console.WriteLine(number);

            for (int positiveNumber = 0; positiveNumber <= number; positiveNumber += step)
            {
                sum += positiveNumber;
            }
            Console.WriteLine(sum);
        }
    }
}
