using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int customersAmount = 5;
            int productsMinAmount = 1;
            int productsMaxAmount = 10;
            int productMinPrice = 10;
            int productMaxPrice = 500;
            int cashBox = 0;
            int randomIndex;

            Random random = new Random();

            Console.Write("Начать покупки");
            Console.ReadKey();
            Console.WriteLine();

            for (int i = 0; i < customersAmount; i++)
            {
                randomIndex = random.Next(productsMinAmount, productsMaxAmount + 1);

                Queue<int> customerBuys = new Queue<int>();

                for (int j = 0; j < randomIndex; j++)
                {
                    customerBuys.Enqueue(random.Next(productMinPrice, productMaxPrice + 1));
                }

                while (customerBuys.Count != 0)
                {
                    Console.WriteLine($"Покупка {customerBuys.Peek()} рублей");
                    cashBox += customerBuys.Dequeue();
                }
         
                Console.WriteLine($"\nВ кассе: {cashBox} рублей");
                Console.WriteLine("Товары закончились, нажмите любую клавишу чтобы перейти к следующему покупателю");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
 