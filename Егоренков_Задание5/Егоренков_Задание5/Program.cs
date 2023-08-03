using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Егоренков_Задание5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = "Костякова";
            string surname1 = "Ирина";

            Console.WriteLine("Имя: " + name1 + "; Фамилия: " + surname1) ;

            string name2 = surname1;
            string surname2 = name1;

            Console.WriteLine ("Имя: " + name2 + "; Фамилия: " + surname2);
        }
    }
}
