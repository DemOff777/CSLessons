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
            int initialNumber = 0;
            int lastNumber = 101;
            int firstMultipleOf = 3;
            int secondMultipleOf = 5;

            Random random = new Random();
            number = random.Next(initialNumber,lastNumber);
            Console.WriteLine(number);

            for (int i = 0; i <= number ; i++)
            {
                if (i % firstMultipleOf == 0 || i % secondMultipleOf == 0) 
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
