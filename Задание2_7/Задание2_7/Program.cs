using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            string middleLine = ""; 
            string frame = "";
            char frameChar;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Введите символ: ");
            frameChar = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();

            middleLine = $"{frameChar} {name} {frameChar}";

            for (int i = 0; i < middleLine.Length; i++)
            {
                frame += frameChar;
            }

            Console.WriteLine();
            Console.WriteLine(frame);
            Console.WriteLine(middleLine);
            Console.WriteLine(frame);
            Console.WriteLine();
        }
    }
}
