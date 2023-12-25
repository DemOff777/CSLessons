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

            Random random = new Random();

            superMarket.AddCustomers(random);

            while (superMarket.GetRemainingCustomersVolue() > 0)
            {
                Render.ClearShopCashPlace();
                superMarket.ShowCash();
                
                Render.ClearCustomersQueuePlace();
                superMarket.ShowRemainingCustomersVolue();

                Render.ClearCurrentCustomerPLace();
                superMarket.GetCurrentCustomer().ShowInfo();

                Render.ClearDialogPlace();
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

    class Render
    {
        private static Random s_random = new Random();

        public static void ClearShopCashPlace()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 10))}");
            Console.SetCursorPosition(0, 0);
        }

        public static void ClearCustomersQueuePlace()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 10))}");
            Console.SetCursorPosition(0, 2);
        }

        public static void ClearCurrentCustomerPLace()
        {
            int customerInfoSize = 13;

            Console.SetCursorPosition(0, 4);

            for (int i = 0; i < customerInfoSize; i++)
            {
                Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 20))}");
            }
            
            Console.SetCursorPosition(0, 4);
        }

        public static void ClearDialogPlace()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 10))}");
            Console.SetCursorPosition(0, 20);
        }

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

        public Customer(string name)
        {
            _name = $"покупатель {name}";
        }

        public void TakeProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                _basket.Add(products[i]);
            }
        }

        public void GenerateMoney()
        {
            int minMoneyVolue = 500;
            int maxMoneyVolue = 1000;

            _money = Render.GetRandomNumber(minMoneyVolue, maxMoneyVolue);
        }

        public int BuyProducts()
        {
            List<Product> products = new List<Product>();

            int moneyToPay = 0;

            while (_basket.Count > 0)
            {
                int randomProductIndex = Render.GetRandomNumber(0, _basket.Count - 1);

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
    }

    class SuperMarket
    {
        private Queue<Customer> _customers = new Queue<Customer>();

        private int _money;

        public void AddCustomers(Random random)
        {
            List<Product> products = new List<Product>();

            int CustomersVolue = 10;

            for (int i = 0; i < CustomersVolue; i++)
            {
                Customer customer = new Customer($"{i + 1}");
                products = GetProducts();
                customer.TakeProducts(products);
                customer.GenerateMoney();
                _customers.Enqueue(customer);
            }
        }

        public Customer GetCurrentCustomer()
        {
            return _customers.Peek();
        }

        public void MakeDeal()
        {
            int moneyToPay = _customers.Dequeue().BuyProducts();
            _money += moneyToPay;
        }

        public void ShowCash() 
        {
            Console.WriteLine($"В кассе - {_money} рублей");
        }

        public void ShowRemainingCustomersVolue()
        {
            Console.WriteLine($"В очереди осталось {_customers.Count} человек");
        }

        public int GetRemainingCustomersVolue()
        {
            int customersAmount = _customers.Count;
            return customersAmount;
        }
        private List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            int minProductVolue = 5;
            int maxProductVolue = 10;
            int minProductPrice = 50;
            int maxProductPrice = 700;
            int productsVolue;

            productsVolue = Render.GetRandomNumber(minProductVolue, maxProductVolue);

            for (int i = 0; i < productsVolue; i++)
            {
                products.Add(new Product($"продукт номер {i + 1}", Render.GetRandomNumber(minProductPrice, maxProductPrice)));
            }

            return products;
        }
    }
}
