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
            int rightBrackets = 0;
            int leftBrackets = 0;
            int bracketsLength;
            int bracketsDepth = 0;

            string brackets;

            bool isExpressionCorrect = true;

            Console.Write("Введите массив скобок:");
            brackets = Console.ReadLine();
            bracketsLength = brackets.Length;

            for (int i = 0; i < bracketsLength; i++)
            {
                if (brackets[i] == '(')
                {
                    leftBrackets++;
                }

                if (brackets[i] == ')')
                {
                    rightBrackets++;
                }
            }

            if (leftBrackets != rightBrackets || brackets[0] == ')' || brackets[bracketsLength - 1] == '(')
            {
                Console.WriteLine("Некорректное скобочное выражение");
                isExpressionCorrect = false;
            }

            leftBrackets = 0; rightBrackets = 0;

            for (int j = 0; j < (bracketsLength) / 2; j++)
            {
                if (brackets[j] == '(')
                {
                    leftBrackets++;
                }

                if (brackets[j] == ')')
                {
                    rightBrackets++;
                }
            }

            if (leftBrackets < rightBrackets && isExpressionCorrect)
            {
                Console.WriteLine("Некорректное скобочное выражение");
                isExpressionCorrect = false;
            }

            while (brackets.Contains("()"))
            {
                brackets = brackets.Replace("()", "");
                bracketsDepth++;
            }

            if (isExpressionCorrect)
            {
                Console.WriteLine($"глубина вложения скобок: {bracketsDepth}");
            }
        }
    }
}
