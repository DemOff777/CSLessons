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
            int searchCorridorMax = 1000;
            int searchCorridorMin = 99;
            int amountOfNumbers = 0;
            int initialNumberMin = 1;
            int initialNumberMax = 27;

            Random random = new Random();
            numberInitial = random.Next(initialNumberMin,initialNumberMax) + 1  ;

            Console.WriteLine(numberInitial);

            for (int i = 0; i < searchCorridorMax; i += numberInitial)
            {
                if (i > searchCorridorMin)
                {
                    amountOfNumbers++;
                }
            }

            Console.WriteLine(amountOfNumbers);
        }
    }
}
