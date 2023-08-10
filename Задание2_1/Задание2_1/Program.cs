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
            Console.WriteLine("Ввдите количество повторов");
            times = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < times; i++)
            {
                Console.WriteLine(phrase);
            }
        }
    }
}
