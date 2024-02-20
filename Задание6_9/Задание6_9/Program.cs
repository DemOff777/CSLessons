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
        private static string border1 = string.Join("", Enumerable.Repeat(" ", 10));
        private static string border2 = string.Join("", Enumerable.Repeat(" ", 20));

        private static Random s_random = new Random();
        public static int GenerateRandomNumber(int minVolue, int maxVolue)
        {
            return s_random.Next(minVolue, maxVolue + 1);
        }

        public static void ShowBorder1()
        {
            Console.WriteLine($"{border1}");
        }

        public static void ShowBorder2()
        {
            Console.WriteLine($"{border2}");
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
            int allProductsPrice = 0;
            int randomProductIndex;

            bool isBuyComplete = false;

            while (isBuyComplete == false)
            {
                allProductsPrice = 0;

                for (int i = 0; i < _basket.Count; i++)
                {
                    allProductsPrice += _basket[i].Price;
                }

                if (_money < allProductsPrice)
                {
                    randomProductIndex = UserUtils.GenerateRandomNumber(0, _basket.Count - 1);
                    Console.WriteLine($"{_name} выложил {_basket[randomProductIndex].Name}");
                    _basket.RemoveAt(randomProductIndex);
                }
                else
                {
                    isBuyComplete = true;
                    _money -= allProductsPrice;
                }   
            }

            return allProductsPrice;
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
            int maxMoneyVolue = 4000;

            int money = UserUtils.GenerateRandomNumber(minMoneyVolue, maxMoneyVolue);

            return money;
        }     
    }

    class SuperMarket
    {
        private int _money;

        private Queue<Customer> _сustomers = new Queue<Customer>();

        private List<Product> _allProducts = new List<Product>();

        public void Work()
        {
            CreateProducts();
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
            UserUtils.ShowBorder1();
            Console.SetCursorPosition(0, 0);
        }

        private void ClearCustomersQueuePlace()
        {
            Console.SetCursorPosition(0, 2);
            UserUtils.ShowBorder1();
            Console.SetCursorPosition(0, 2);
        }

        private void ClearCurrentCustomerPLace()
        {
            int customerInfoSize = 13;

            Console.SetCursorPosition(0, 4);

            for (int i = 0; i < customerInfoSize; i++)
            {
                UserUtils.ShowBorder2();
            }

            Console.SetCursorPosition(0, 4);
        }

        private void ClearDialogPlace()
        {
            Console.SetCursorPosition(0, 20);
            UserUtils.ShowBorder1();
            Console.SetCursorPosition(0, 20);
        }

        private void AddCustomers()
        {
            int CustomersCount = 10;

            for (int i = 0; i < CustomersCount; i++)
            {
                Customer customer = new Customer($"{i + 1}", GetRandomProducts());        
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

        private void CreateProducts()
        {
            int minProductPrice = 50;
            int maxProductPrice = 700;
            int productsVolue = 100;

            for (int i = 0; i < productsVolue; i++)
            {
                _allProducts.Add(new Product($"продукт номер {i + 1}", UserUtils.GenerateRandomNumber(minProductPrice, maxProductPrice)));
            }
        }

        private List<Product> GetRandomProducts()
        {
            List<Product> randomProducts = new List<Product>();

            int minProductsCount = 5;
            int maxProductsCount = 10;
            int productsCount = UserUtils.GenerateRandomNumber(minProductsCount, maxProductsCount);

            for (int i = 0; i < productsCount; i++)
            {
                int minProductIndex = 0;
                int randomProductIndex = UserUtils.GenerateRandomNumber(minProductIndex, _allProducts.Count - 1);

                randomProducts.Add(_allProducts[randomProductIndex]);
                _allProducts.RemoveAt(randomProductIndex);
            }

            return randomProducts;
        }
    }
}
