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
            int nameLength = 0;
            int frameThickness = 1;
            char frameChar;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите символ: ");
            frameChar = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();
            nameLength = name.Length + frameThickness;

            for (int i = 0; i <= nameLength; i++)
            {
                Console.Write(frameChar);
            }
            Console.WriteLine();
            Console.Write(frameChar);
            Console.Write(name);
            Console.Write(frameChar);
            Console.WriteLine();

            for (int i = 0; i <= nameLength; i++)
            {
                Console.Write(frameChar);
            }
            Console.WriteLine();
        }
    }
}
