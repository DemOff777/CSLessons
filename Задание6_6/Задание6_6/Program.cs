﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание6_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowSellerBag = "1";
            const string CommandShowPlayerBag = "2";
            const string CommandBuyProduct = "3";

            Shop shop = new Shop();

            while (shop.GivePlayer().Money > 0)
            {
                UserUtils.ClearMenu();
                Console.WriteLine($"Посмотреть сумку продавца - {CommandShowSellerBag}");
                Console.WriteLine($"Посмотреть инвентарь - {CommandShowPlayerBag}");
                Console.WriteLine($"Купить товар - {CommandBuyProduct}");
                
                string userInput = Console.ReadLine();

                switch(userInput )
                {
                    case CommandShowSellerBag:
                        shop.ShowSellerStats();
                        break;
                    case CommandShowPlayerBag:
                        shop.ShowPlayerStats();
                        break;
                    case CommandBuyProduct:
                        shop.Trade();
                        break;
                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
            }

            Console.WriteLine("Деньги закончились - до свидания!");
        } 
    }

    static class UserUtils
    {
        private static Random _random = new Random();

        public static void ClearInventory()
        {
            int inventorySize = 21;

            Console.SetCursorPosition(0, 3);

            for (int i = 0; i < inventorySize; i++)
            {
                Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 53))}");
            }

            Console.SetCursorPosition(0, 3);
        }

        public static void ClearMenu()
        {
            int menuSize = 4;

            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < menuSize; i++)
            {
                Console.WriteLine($"{string.Join("", Enumerable.Repeat(" ", 53))}");
            }

            Console.SetCursorPosition(0, 0);
        }

        public static int FillMoneyAmount()
        {
            int money;
            int moneyMinAmount = 1000;
            int moneyMaxAmount = 5000;

            money = _random.Next(moneyMinAmount, moneyMaxAmount + 1);

            return money;
        }

        public static List<Product> FillInventory()
        {
            List<Product> inventory = new List<Product>();

            int sellersBagCapacity = 20;
            int priceMinVolue = 20;
            int priceMaxVolue = 1000;

            for (int i = 0; i < sellersBagCapacity; i++)
            {
                inventory.Add(new Product($"{i}", _random.Next(priceMinVolue, priceMaxVolue + 1)));
            }

            return inventory;
        }

    }

    class Shop
    {
        private Player _player = new Player(UserUtils.FillMoneyAmount(), new List<Product>());

        private Seller _seller = new Seller(0, UserUtils.FillInventory());
        
        public void Trade()
        {
            int moneyTemporary;
            Product productTemporary;

            productTemporary = _seller.TryGiveProduct();
            moneyTemporary = _player.CheckMoneyAmount(productTemporary);

            if (moneyTemporary > 0)
            {
                _player.GiveMoney(moneyTemporary);
                _seller.TakeMoney(moneyTemporary);
                _seller.GiveProduct(productTemporary);
                _player.TakeProduct(productTemporary);
            }
            else
            {
                _player.GiveMoney(moneyTemporary);
            }
        }

        public Player GivePlayer()
        {
            return _player;
        }

        public Seller GiveSeller()
        {
            return _seller;
        }

        public void ShowSellerStats()
        {
            _seller.ShowStats();
        }

        public void ShowPlayerStats()
        {
            _player.ShowStats();
        }
    }

    public class Character
    {
        protected List<Product> Inventory = new List<Product>();

        public int Money { get; protected set; }

        public void ShowStats()
        {
            UserUtils.ClearInventory();
            Console.SetCursorPosition(0, 4);

            foreach (Product product in Inventory)
            {
                product.Show();
            }

            Console.SetCursorPosition(0, 25);
            Console.WriteLine("               ");
            Console.SetCursorPosition(0, 25);
            Console.WriteLine($"Деньги: {Money}");
            Console.SetCursorPosition(0, 0);
        }
    }

    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public void Show()
        {
            Console.WriteLine($"Продукт номер: {Name}, цена {Price}");
        }
    }

    public class Seller : Character
    {
        public Seller(int money, List<Product> inventory)
        {
            Money = money;
            Inventory = inventory;
        }

        public Product TryGiveProduct()
        {
            Product product = null;

            string userInput;

            UserUtils.ClearMenu();
            Console.WriteLine("Введите номер товара");
            Console.SetCursorPosition(0, 3);

            userInput = Console.ReadLine();

            for (int i = 0; i < Inventory.Count; i++)
            {
                if (userInput == Inventory[i].Name)
                {
                    product = Inventory[i];
                    return product;
                }
            }

            UserUtils.ClearMenu();
            Console.WriteLine("Такого товара не найдено. Нажмите любую клавишу");
            Console.ReadKey();

            return product;
        }

        public void GiveProduct(Product product)
        {
            Inventory.Remove(product);
        }

        public void TakeMoney(int money)
        {
            Money += money;
        }
    }

    public class Player : Character
    {
        public Player(int money, List<Product> inventory)
        {
            Money = money;
            Inventory = inventory;
        }

        public int CheckMoneyAmount(Product product)
        {
            int moneyToPay = 0;

            if (product != null)
            {
                moneyToPay = product.Price;
            }

            return moneyToPay;
        }

        public void GiveMoney(int moneyToPay)
        {
            Money -= moneyToPay;
        }

        public void TakeProduct(Product product)
        {
            Inventory.Add(product);
        }
    }
}
