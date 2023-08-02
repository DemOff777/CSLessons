using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Егоренков_Задание6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gold;
            int crystals;
            int crystalPrice = 10;

            Console.Write("Сколько у вас золота? ");
            gold = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько кристаллов вы хотите преобрести по цене 10 за штуку ");
            crystals = Convert.ToInt32(Console.ReadLine());
            gold -= crystalPrice * crystals;
            Console.WriteLine($"Отлично, теперь в вашей сумке {crystals} кристалов и {gold} золота");

        }
    }
}
