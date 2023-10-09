using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bracketsDepth = 0;
            int bracketsAmount = 0; 

            string brackets;

            char leftBracket = '(';
            char rightBracket = ')';

            Console.Write("Введите массив скобок:");
            brackets = Console.ReadLine();

            for (int i = 0; i < brackets.Length; i++)
            {
                if (brackets[i] == leftBracket)
                {
                    bracketsAmount++;

                    if (bracketsAmount > bracketsDepth)
                    {
                        bracketsDepth = bracketsAmount;
                    }
                }

                if (brackets[i] == rightBracket)
                {
                    bracketsAmount--;
                }

                if (bracketsAmount < 0)
                {
                    Console.WriteLine("Некорректное скобочное выражение");
                    break;
                }
            }

            if (bracketsAmount == 0)
            {
                Console.WriteLine("Корректное скобочное выражение");
                Console.WriteLine("Глубина вложения скобок: " + bracketsDepth);
            }
            else if (bracketsAmount > 0)
            {
                Console.WriteLine("Некорректное скобочное выражение");
            }
        }
    }
}
