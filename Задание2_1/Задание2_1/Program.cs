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
            int repetitions;
            Console.WriteLine("Ввдите фразу");
            phrase = Console.ReadLine();
            Console.WriteLine("Ввдите количество повторов");
            repetitions = Convert.ToInt32(Console.ReadLine());

            for (int repeat = 0; repeat < repetitions; repeat++)
            {
                Console.WriteLine(phrase);
            }
        }
    }
}
