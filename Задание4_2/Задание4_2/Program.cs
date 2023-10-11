using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mana = 50;
            int manaMaxValue = 100;

            bool isMagicWork = true;

            ConsoleColor manaColor = ConsoleColor.Blue;
  
            while (isMagicWork)
            {
                ViewBar(mana, manaMaxValue, manaColor);
                ChangeBarVolue(ref isMagicWork, ref mana, manaMaxValue);

                Console.WriteLine("Мана закончилась(");
            }
        }

        static void ViewBar(int value, int maxValue, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            int percentStep = 10;

            string bar = "";

            for (int i = 0; i < value/ percentStep; i++)
            {
                bar += "_";
            }

            Console.SetCursorPosition(2, 2);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = value/ percentStep; i < maxValue/percentStep; i++)
            {
                bar += "_";
            }

            Console.Write(bar);
            Console.Write(']');
        }

        static void ChangeBarVolue(ref bool isBarWork, ref int value, int maxValue)
        {
            int temporaryValue;

            Console.SetCursorPosition(2, 4);
            Console.Write("Введите количество маны для изменения: ");
            temporaryValue = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (temporaryValue <= maxValue - value && value - Math.Abs(temporaryValue) >= 0)
            {
                value += temporaryValue;
            }
            else
            {
                Console.WriteLine("Недопустимое значение");
            }

            if (value == 0)
            {
                isBarWork = false;
            }
        }
    }
}
