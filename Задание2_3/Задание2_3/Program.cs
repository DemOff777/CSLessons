using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberInitial = 5;
            int numberStep = 7;
            int numberLast = 96;

            for(int step = numberInitial; step <= numberLast; step += numberStep)
            {
                Console.WriteLine(step);
            }
        }
    }
}
