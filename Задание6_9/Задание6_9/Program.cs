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

            superMarket.AddCustomers();

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
    }

    class Product
    {
        string _name;
        int _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name}, цена - {_price}");
        }
        
        public string GiveName()
        {
            return _name;
        }

        public int GivePrice()
        {
            return _price;
        }
    }

    class Customer
    { 
        List<Product> _products = new List<Product>();

        int _money;

        string _name;

        public Customer(string name)
        {
            _name = $"покупатель {name}";
        }

        public void GetProducts()
        {
            int minProductVolue = 5;
            int maxProductVolue = 10;
            int minProductPrice = 50;
            int maxProductPrice = 700;
            int productsVolue;
            int productPrice;

            Random random = new Random();

            productsVolue = random.Next(minProductVolue, maxProductVolue + 1);

            for (int i = 0; i < productsVolue; i++)
            {
                _products.Add(new Product($"продукт номер {i + 1}", random.Next(minProductPrice, maxProductPrice + 1)));
            }
        }

        public void RemoveProduct()
        {
            Product product;

            Random random = new Random();

            int randomProductIndex = random.Next(_products.Count);

            _products.RemoveAt(randomProductIndex);
        }

        public void GetMoney()
        {
            int minMoneyVolue = 500;
            int maxMoneyVolue = 1000;

            Random random = new Random();

            _money = random.Next(minMoneyVolue, maxMoneyVolue + 1);

        }

        public int BuyProducts()
        {
            Random random = new Random();

            int moneyToPay = 0;

            while (_products.Count > 0)
            {
                int randomProductIndex = random.Next(_products.Count);

                if (_money >= _products[randomProductIndex].GivePrice())
                {
                    _money -= _products[randomProductIndex].GivePrice();
                    moneyToPay += _products[randomProductIndex].GivePrice();
                    _products.RemoveAt(randomProductIndex);
                }
                else
                {
                    Console.WriteLine($"{_name} выложил {_products[randomProductIndex].GiveName()}");
                    _products.RemoveAt(randomProductIndex);           
                }
            }

            return moneyToPay;
        }

        public void ShowInfo()
        {
            Console.WriteLine(_name);
            Console.WriteLine("В корзине:");
            Console.WriteLine($"{string.Join("", Enumerable.Repeat("-", 10))}");

            foreach (Product product in _products)
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

        public void AddCustomers()
        {
            int CustomersVolue = 10;

            for (int i = 0; i < CustomersVolue; i++)
            {
                Customer customer = new Customer($"{i + 1}");
                customer.GetProducts();
                customer.GetMoney();
                _customers.Enqueue(customer);
            }
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
