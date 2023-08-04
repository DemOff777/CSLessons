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
            string bufferName;

            Console.WriteLine("Имя: " + name + "; Фамилия: " + surname);

            bufferName = name;
            name = surname;
            surname = bufferName;
            
            Console.WriteLine ("Имя: " + name + "; Фамилия: " + surname);
        }
    }
}
