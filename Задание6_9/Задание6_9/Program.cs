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
            Render render = new Render();

            superMarket.AddCustomers(random);

            while (superMarket.GetRemainingCustomersVolue() > 0)
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

    class Render
    {
        private static Random s_random = new Random();

        public void ClearShopCashPlace()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 10))}");
            Console.SetCursorPosition(0, 0);
        }

        public void ClearCustomersQueuePlace()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 10))}");
            Console.SetCursorPosition(0, 2);
        }

        public void ClearCurrentCustomerPLace()
        {
            int customerInfoSize = 13;

            Console.SetCursorPosition(0, 4);

            for (int i = 0; i < customerInfoSize; i++)
            {
                Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 20))}");
            }
            
            Console.SetCursorPosition(0, 4);
        }

        public void ClearDialogPlace()
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 10))}");
            Console.SetCursorPosition(0, 20);
        }

        public int GetRandomNumber(int minVolue, int maxVolue)
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

        private void TakeProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                _basket.Add(products[i]);
            }
        }

        private int GenerateMoney()
        {
            Render render = new Render();

            int minMoneyVolue = 500;
            int maxMoneyVolue = 1000;

            int money = render.GetRandomNumber(minMoneyVolue, maxMoneyVolue);

            return money;
        }

        public int BuyProducts()
        {
            List<Product> products = new List<Product>();

            Render render = new Render();

            int moneyToPay = 0;

            while (_basket.Count > 0)
            {
                int randomProductIndex = render.GetRandomNumber(0, _basket.Count - 1);

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
                Customer customer = new Customer($"{i + 1}", CreateProducts());        
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
            return _customers.Count;
        }
        private List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>();

            Render render = new Render();

            int minProductVolue = 5;
            int maxProductVolue = 10;
            int minProductPrice = 50;
            int maxProductPrice = 700;
            int productsVolue;

            productsVolue = render.GetRandomNumber(minProductVolue, maxProductVolue);

            for (int i = 0; i < productsVolue; i++)
            {
                products.Add(new Product($"продукт номер {i + 1}", render.GetRandomNumber(minProductPrice, maxProductPrice)));
            }

            return products;
        }
    }
}
