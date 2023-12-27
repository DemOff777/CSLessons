using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание6_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SuperMarket superMarket = new SuperMarket();

            Render render = new Render();

            superMarket.AddCustomers();

            while (superMarket.Customers.Count() > 0)
            {
                render.ClearShopCashPlace();
                superMarket.ShowCash();

                render.ClearCustomersQueuePlace();
                superMarket.ShowRemainingCustomersVolue();

                render.ClearCurrentCustomerPLace();
                superMarket.GetCurrentCustomer().ShowInfo();

                render.ClearDialogPlace();
                Console.WriteLine("Для того чтобы пробить товар нажмите на любую клавишу");
                Console.ReadKey();

                superMarket.MakeDeal();

                Console.WriteLine("Для того чтобы перейти к следующему покупателю нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Очередь закончилась - магазин закрыт!");
        }
    }

    static class UserUtils
    {
        private static Random _random = new Random();

        public static int GetRandomNumber(int minVolue, int maxVolue)
        {
            return _random.Next(minVolue, maxVolue + 1);
        }
    }

    class Render
    {
        private string _borber1 = string.Join("", Enumerable.Repeat(" ", 10));
        private string _border2 = string.Join("", Enumerable.Repeat(" ", 20));

        public void ClearShopCashPlace()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{_borber1}");
            Console.SetCursorPosition(0, 0);
        }

        public void ClearCustomersQueuePlace()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{_borber1}");
            Console.SetCursorPosition(0, 2);
        }

        public void ClearCurrentCustomerPLace()
        {
            int customerInfoSize = 13;

            Console.SetCursorPosition(0, 4);

            for (int i = 0; i < customerInfoSize; i++)
            {
                Console.WriteLine($"{_border2}");
            }
            
            Console.SetCursorPosition(0, 4);
        }

        public void ClearDialogPlace()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"{_borber1}");
            Console.SetCursorPosition(0, 20);
        }
    }

    class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }

        public int Price { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, цена - {Price}");
        }
    }

    class Customer
    { 
        private List<Product> _basket = new List<Product>();

        private int _money;
        private string _name;

        public Customer(string name, List<Product> products)
        {
            _name = $"покупатель {name}";
            _money = GenerateMoney();

            TakeProducts(products);
        }

        public int BuyProducts()
        {
            List<Product> products = new List<Product>();

            int moneyToPay = 0;

            while (_basket.Count > 0)
            {
                int randomProductIndex = UserUtils.GetRandomNumber(0, _basket.Count - 1);

                if (_money >= _basket[randomProductIndex].Price)
                {
                    _money -= _basket[randomProductIndex].Price;
                    moneyToPay += _basket[randomProductIndex].Price;
                    products.Add(_basket[randomProductIndex]);
                    _basket.RemoveAt(randomProductIndex);
                }
                else
                {
                    Console.WriteLine($"{_name} выложил {_basket[randomProductIndex].Name}");
                    _basket.RemoveAt(randomProductIndex);
                }
            }

            _basket = products;

            return moneyToPay;
        }

        public void ShowInfo()
        {
            Console.WriteLine(_name);
            Console.WriteLine("В корзине:");
            Console.WriteLine($"{string.Join("", Enumerable.Repeat("-", 10))}");

            foreach (Product product in _basket)
            {
                product.ShowInfo();
            }

            Console.WriteLine($"В кошельке {_money} рублей");
        }

        private void TakeProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                _basket.Add(products[i]);
            }
        }

        private int GenerateMoney()
        {
            int minMoneyVolue = 500;
            int maxMoneyVolue = 1000;

            int money = UserUtils.GetRandomNumber(minMoneyVolue, maxMoneyVolue);

            return money;
        }     
    }

    class SuperMarket
    {
        private int _money;

        public Queue<Customer> Customers { get; private set; } = new Queue<Customer>();

        public void AddCustomers()
        {
            int CustomersCount = 10;

            for (int i = 0; i < CustomersCount; i++)
            {
                Customer customer = new Customer($"{i + 1}", CreateProducts());        
                Customers.Enqueue(customer);
            }
        }

        public Customer GetCurrentCustomer()
        {
            return Customers.Peek();
        }

        public void MakeDeal()
        {
            int moneyToPay = Customers.Dequeue().BuyProducts();
            _money += moneyToPay;
        }

        public void ShowCash() 
        {
            Console.WriteLine($"В кассе - {_money} рублей");
        }

        public void ShowRemainingCustomersVolue()
        {
            Console.WriteLine($"В очереди осталось {Customers.Count} человек");
        }

        private List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>();

            int minProductVolue = 5;
            int maxProductVolue = 10;
            int minProductPrice = 50;
            int maxProductPrice = 700;
            int productsVolue;

            productsVolue = UserUtils.GetRandomNumber(minProductVolue, maxProductVolue);

            for (int i = 0; i < productsVolue; i++)
            {
                products.Add(new Product($"продукт номер {i + 1}", UserUtils.GetRandomNumber(minProductPrice, maxProductPrice)));
            }

            return products;
        }
    }
}
