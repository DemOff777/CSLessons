using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phrase;
            int times;
            Console.WriteLine("Ввдите фразу");
            phrase = Console.ReadLine();
            Console.WriteLine("Ввдите количество попыток");
            times = Convert.ToInt32(Console.ReadLine());

            while (times-- > 0) 
            {
                Console.WriteLine(phrase);
            }
        }
    }
}
