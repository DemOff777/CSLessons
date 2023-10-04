using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание3_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Нет, Саша - это конкретно водовозка!";
            string[] textSplited = text.Split();

            foreach (string word in textSplited)
            {
                Console.WriteLine(word);
            }
        }
    }
}
