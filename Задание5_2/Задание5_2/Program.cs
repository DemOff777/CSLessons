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
            int customerMinBuy = 10;
            int customerMaxBuy = 500;
            int cashBox = 0;
            int randomIndex;

            Random random = new Random();

            Console.Write("Начать покупки");
            Console.ReadKey();
            Console.WriteLine();

            Queue<int> customers = new Queue<int>();

            for (int j = 0; j < customersAmount; j++)
            {
                customers.Enqueue(random.Next(customerMinBuy, customerMaxBuy + 1));
            }

            while (customers.Count != 0)
            {
                cashBox = AddBuy(customers, cashBox);
            }
        }

        static int AddBuy(Queue<int> customer, int cashBox) 
        {
            Console.WriteLine($"Покупка {customer.Peek()} рублей");
            cashBox += customer.Dequeue();
            Console.WriteLine($"\nВ кассе: {cashBox} рублей");
            Console.WriteLine("Расчет произведен, нажмите любую клавишу чтобы перейти к следующему покупателю");
            Console.ReadKey();
            Console.Clear();
            return cashBox;
        }
    }
}
 