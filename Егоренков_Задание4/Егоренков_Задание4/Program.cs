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
            int picturesRow = 3;
            int picturesTotal = 52;
            int rowsTotal = picturesTotal / picturesRow;
            int picturesLeft = picturesTotal % picturesRow;

            Console.WriteLine($"Всего рядов {rowsTotal}, остаток {picturesLeft}");
        }
    }
}
