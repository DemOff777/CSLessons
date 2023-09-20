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
            string frameChar;
            string frameLine = "";
            int frameLength;

            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите символ: ");
            frameChar = Convert.ToString(Console.Read());
            Console.WriteLine();
            frameLength = name.Length + 2;

            for (int i = 0; i < frameLength; i++)
            {
                frameLine += $"{frameChar}";
            }
            Console.WriteLine();
            Console.WriteLine(frameLine);
            Console.Write(frameChar);
            Console.Write(name);
            Console.WriteLine(frameChar);
            Console.WriteLine(frameLine);
        }
    }
}
