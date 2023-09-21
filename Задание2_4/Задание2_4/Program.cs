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
            int lastNumber = 100;
            int divider1 = 3;
            int divider2 = 5;

            Random random = new Random();
            number = random.Next(lastNumber + 1);
            Console.WriteLine(number);

            for (int i = 0; i <= number ; i++)
            {
                if (i % divider1 == 0 || i % divider2 == 0) 
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
