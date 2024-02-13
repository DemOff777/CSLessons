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

            superMarket.Work();

            Console.WriteLine("Очередь закончилась - магазин закрыт!");
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int minVolue, int maxVolue)
        {
            return s_random.Next(minVolue, maxVolue + 1);
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

        private string _borber1 = string.Join("", Enumerable.Repeat(" ", 10));
        private string _border2 = string.Join("", Enumerable.Repeat(" ", 20));

        public Queue<Customer> _сustomers = new Queue<Customer>();

        public void Work()
        {
            AddCustomers();

            while (_сustomers.Count() > 0)
            {
                ClearShopCashPlace();
                ShowCash();

                ClearCustomersQueuePlace();
                ShowRemainingCustomersVolue();

                ClearCurrentCustomerPLace();
                GetCurrentCustomer().ShowInfo();

                ClearDialogPlace();
                Console.WriteLine("Для того чтобы пробить товар нажмите на любую клавишу");
                Console.ReadKey();

                MakeDeal();

                Console.WriteLine("Для того чтобы перейти к следующему покупателю нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ClearShopCashPlace()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{_borber1}");
            Console.SetCursorPosition(0, 0);
        }

        private void ClearCustomersQueuePlace()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{_borber1}");
            Console.SetCursorPosition(0, 2);
        }

        private void ClearCurrentCustomerPLace()
        {
            int customerInfoSize = 13;

            Console.SetCursorPosition(0, 4);

            for (int i = 0; i < customerInfoSize; i++)
            {
                Console.WriteLine($"{_border2}");
            }

            Console.SetCursorPosition(0, 4);
        }

        private void ClearDialogPlace()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"{_borber1}");
            Console.SetCursorPosition(0, 20);
        }

        private void AddCustomers()
        {
            int CustomersCount = 10;

            for (int i = 0; i < CustomersCount; i++)
            {
                Customer customer = new Customer($"{i + 1}", CreateProducts());        
                _сustomers.Enqueue(customer);
            }
        }

        private Customer GetCurrentCustomer()
        {
            return _сustomers.Peek();
        }

        private void MakeDeal()
        {
            int moneyToPay = _сustomers.Dequeue().BuyProducts();
            _money += moneyToPay;
        }

        private void ShowCash() 
        {
            Console.WriteLine($"В кассе - {_money} рублей");
        }

        private void ShowRemainingCustomersVolue()
        {
            Console.WriteLine($"В очереди осталось {_сustomers.Count} человек");
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
