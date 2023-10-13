using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            }

            Console.WriteLine("Мана закончилась(");
        }

        static void ViewBar(int value, int maxValue, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            int percentStep = 10;

            string bar = "";

            bar = DrawBar(bar, 0, value/percentStep);

            Console.SetCursorPosition(2, 2);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            bar = DrawBar(bar, value / percentStep, maxValue / percentStep);

            Console.Write(bar);
            Console.Write(']');
        }

        static string DrawBar(string bar, int startValue, int maxValue)
        {
            for (int i = startValue; i < maxValue; i++)
            {
                bar += "_";
            }

            return bar;
        }

        static void ChangeBarVolue(ref bool isBarWork, ref int value, int maxValue)
        {
            int temporaryValue;

            Console.SetCursorPosition(2, 4);
            Console.Write("Введите количество маны для изменения: ");
            temporaryValue = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            value += temporaryValue;

            if (temporaryValue >= maxValue - value)
            {
                value = maxValue;
            }

            if (value <= 0)
            {
                isBarWork = false;
            }
        }
    }
}
