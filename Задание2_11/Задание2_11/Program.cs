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
            int bracketsDepth = 0;

            string brackets;
            string closedBrackets = "()";

            char leftBracketAmount = '(';
            char rightBracketAmount = ')';

            bool isExpressionCorrect = true;

            Console.Write("Введите массив скобок:");
            brackets = Console.ReadLine();

            int halfBracketsLengh = brackets.Length / 2;

            for (int i = 0; i < brackets.Length; i++)
            {
                if (brackets[i] == leftBracketAmount)
                {
                    leftBrackets++;
                }

                if (brackets[i] == rightBracketAmount)
                {
                    rightBrackets++;
                }
            }

            if (leftBrackets != rightBrackets || brackets[0] == leftBracketAmount || brackets[brackets.Length - 1] == rightBracketAmount)
            {
                Console.WriteLine("Некорректное скобочное выражение");
                isExpressionCorrect = false;
            }

            leftBrackets = 0; rightBrackets = 0;

            for (int j = 0; j < halfBracketsLengh; j++)
            {
                if (brackets[j] == leftBracketAmount)
                {
                    leftBrackets++;
                }

                if (brackets[j] == rightBracketAmount)
                {
                    rightBrackets++;
                }
            }

            if (leftBrackets < rightBrackets && isExpressionCorrect)
            {
                Console.WriteLine("Некорректное скобочное выражение");
                isExpressionCorrect = false;
            }

            while (brackets.Contains(closedBrackets))
            {
                brackets = brackets.Replace(closedBrackets, "");
                bracketsDepth++;
            }

            if (isExpressionCorrect)
            {
                Console.WriteLine($"глубина вложения скобок: {bracketsDepth}");
            }
        }
    }
}
