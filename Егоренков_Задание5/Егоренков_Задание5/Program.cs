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
            string partBody1 = "Правая";
            string side1 = "Рука";

            Console.WriteLine("Часть тела: " + partBody1 + "; Сторона: " + side1) ;

            string partBody2 = side1;
            string side2 = partBody1;

            Console.WriteLine ("Часть тела: " + partBody2 + "; Сторона: " + side2);
        }
    }
}
