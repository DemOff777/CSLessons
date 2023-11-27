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

            while (superMarket.GiveRemainingCustomersVolue() > 0)
            {
                UserUtils.ShopCashPlaceClear();
                superMarket.ShowCash();
                
                UserUtils.CustomersQueuePlaceClear();
                superMarket.ShowRemainingCustomersVolue();

                UserUtils.CurrentCustomerPLaceClear();
                superMarket.GiveCurrentCustomer().ShowInfo();

                UserUtils.ClearDialogPlace();
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
        static private Random random = new Random();

        public static void ShopCashPlaceClear()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 10))}");
            Console.SetCursorPosition(0, 0);
        }

        public static void CustomersQueuePlaceClear()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 10))}");
            Console.SetCursorPosition(0, 2);
        }

        public static void CurrentCustomerPLaceClear()
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
            int randomVolue;

            randomVolue = random.Next(minVolue, maxVolue + 1);

            return randomVolue;
        }
    }

    class Product
    {
        int _price;

        public Product(string name, int price)
        {
            Name = name;
            _price = price;
        }

        public string Name { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, цена - {_price}");
        }

        public int GivePrice()
        {
            return _price;
        }
    }

    class Customer
    { 
        List<Product> _products = new List<Product>();
        List<Product> _basket = new List<Product>();

        int _money;

        string _name;

        public Customer(string name)
        {
            _name = $"покупатель {name}";
        }

        public List<Product> GetBasket()
        {
            return _basket;
        }

        public void GenerateMoney()
        {
            int minMoneyVolue = 500;
            int maxMoneyVolue = 1000;

            _money = UserUtils.GetRandomNumber(minMoneyVolue, maxMoneyVolue);
        }

        public int BuyProducts()
        {
            int moneyToPay = 0;

            while (_basket.Count > 0)
            {
                int randomProductIndex = UserUtils.GetRandomNumber(0, _basket.Count - 1);

                if (_money >= _basket[randomProductIndex].GivePrice())
                {
                    _money -= _basket[randomProductIndex].GivePrice();
                    moneyToPay += _basket[randomProductIndex].GivePrice();
                    _products.Add(_basket[randomProductIndex]);
                    _basket.RemoveAt(randomProductIndex);
                }
                else
                {
                    Console.WriteLine($"{_name} выложил {_basket[randomProductIndex].Name}");
                    _basket.RemoveAt(randomProductIndex);           
                }
            }

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
        Queue<Customer> _customers = new Queue<Customer>();

        int _money;

        public void AddCustomers(Random random)
        {
            int CustomersVolue = 10;

            for (int i = 0; i < CustomersVolue; i++)
            {
                Customer customer = new Customer($"{i + 1}");
                customer = GetProducts(customer);
                customer.GenerateMoney();
                _customers.Enqueue(customer);
            }
        }

        private Customer GetProducts(Customer customer)
        {
            int minProductVolue = 5;
            int maxProductVolue = 10;
            int minProductPrice = 50;
            int maxProductPrice = 700;
            int productsVolue;

            productsVolue = UserUtils.GetRandomNumber(minProductVolue, maxProductVolue);

            for (int i = 0; i < productsVolue; i++)
            {
                customer.GetBasket().Add(new Product($"продукт номер {i + 1}", UserUtils.GetRandomNumber(minProductPrice, maxProductPrice)));
            }

            return customer;
        }

        public Customer GiveCurrentCustomer()
        {
            return _customers.Peek();
        }

        public void MakeDeal()
        {
            int moneyToPay;
            moneyToPay = _customers.Dequeue().BuyProducts();
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

        public int GiveRemainingCustomersVolue()
        {
            int customersAmount = _customers.Count;
            return customersAmount;
        }
    }
}
