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
            string name = "Костякова";
            string surname = "Ирина";

            Console.WriteLine("Имя: " + name + "; Фамилия: " + surname);

            string name1 = surname;
            string surname1 = name;
            name = name1;
            surname = surname1;

            Console.WriteLine ("Имя: " + name + "; Фамилия: " + surname);
        }
    }
}
