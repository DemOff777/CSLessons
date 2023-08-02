using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Егоренков_Задание4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int picRow = 3;
            int picTotal = 52;

            Console.WriteLine($"Всего рядов {picTotal / picRow}, остаток {picTotal % picRow}");
        }
    }
}
