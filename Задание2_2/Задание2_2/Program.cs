﻿using System;
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
            string userPhrase;

            Console.WriteLine("Введите фразу для выхода");
            userPhrase = Console.ReadLine();

            while (userPhrase != "exit")
            {
                Console.WriteLine("Введите фразу для выхода");
                userPhrase = Console.ReadLine();
            }
        }
    }
}
