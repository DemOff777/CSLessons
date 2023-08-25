using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberInitial;
            int rangeMax = 1000;
            int rangeMin = 99;
            int amountOfNumbers = 1;

            Random random = new Random();
            numberInitial = random.Next(1,28);

            Console.WriteLine(numberInitial);

            for (int i = 0; i < rangeMax; i += numberInitial)
            {
                if (i > rangeMin)
                {
                    amountOfNumbers++;
                }
            }
            Console.WriteLine(amountOfNumbers);
        }
    }
}
