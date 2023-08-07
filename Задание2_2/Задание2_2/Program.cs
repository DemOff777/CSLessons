using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phraseToExit = "exit";
            string userPhrase;

            while (true)
            {
                Console.WriteLine("Введите фразу для выхода");
                userPhrase = Console.ReadLine();
                if (userPhrase == phraseToExit) 
                {
                    Console.WriteLine("Поздравляем, вы вышли!");
                    break;
                }
            }
        }
    }
}
