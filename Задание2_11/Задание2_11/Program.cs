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
            int rightBracketsAmount = 0;
            int leftBracketsAmount = 0;
            int bracketsDepth = 0;

            string brackets;
            string closedBrackets = "()";

            char leftBracket = '(';
            char rightBracket = ')';

            bool isExpressionCorrect = true;

            Console.Write("Введите массив скобок:");
            brackets = Console.ReadLine();

            int halfBracketsLengh = brackets.Length / 2;

            for (int i = 0; i < brackets.Length; i++)
            {
                if (brackets[i] == leftBracket || brackets[i] == rightBracket)
                {
                    leftBracketsAmount++;
                    rightBracketsAmount++;
                }
            }

            if (leftBracketsAmount != rightBracketsAmount || brackets[0] != leftBracket || brackets[brackets.Length - 1] != rightBracket)
            {
                Console.WriteLine("Некорректное скобочное выражение");
                isExpressionCorrect = false;
            }

            leftBracketsAmount = 0; rightBracketsAmount = 0;

            for (int j = 0; j < halfBracketsLengh; j++)
            {
                if (brackets[j] == leftBracket)
                {
                    leftBracketsAmount++;
                }

                if (brackets[j] == rightBracket)
                {
                    rightBracketsAmount++;
                }
            }

            if (leftBracketsAmount < rightBracketsAmount && isExpressionCorrect)
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
