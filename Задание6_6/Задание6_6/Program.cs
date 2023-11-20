﻿using System;
using System.Collections.Generic;

namespace Задание6_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowSellerBag = "1";
            const string CommandShowPlayerBag = "2";
            const string CommandBuyProduct = "3";

            Player player = new Player(UserUtils.FillMoneyAmount());

            Seller seller = new Seller();

            seller.FillBag();

            while (player.Money > 0)
            {
                player.ShowMoney();

                Console.WriteLine($"Посмотреть сумку продавца - {CommandShowSellerBag}");
                Console.WriteLine($"Посмотреть инвентарь - {CommandShowPlayerBag}");
                Console.WriteLine($"Купить товар - {CommandBuyProduct}");
                
                string userInput = Console.ReadLine();

                switch(userInput )
                {
                    case CommandShowSellerBag:
                        seller.ShowInventory();
                        break;
                    case CommandShowPlayerBag:
                        player.ShowInventory();
                        break;
                    case CommandBuyProduct:
                        player.BuyProduct(seller.GetProduct(player));
                        break;
                }
            }

            Console.WriteLine("Деньги закончились - до свидания!");
        } 
    }

    static class UserUtils
    {
        public static void ClearInventory()
        {
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.SetCursorPosition(0, 3);
        }

        public static void ClearMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.SetCursorPosition(0, 0);
        }
        public static int FillMoneyAmount()
        {
            int money;
            int moneyMinAmount = 1000;
            int moneyMaxAmount = 5000;

            Random random = new Random();

            money = random.Next(moneyMinAmount, moneyMaxAmount + 1);

            return money;
        }
    }

    public class Store
    {
        public List<Product> Inventory { get; private set; } = new List<Product>();

        public void ShowInventory()
        {
            UserUtils.ClearInventory();
            Console.SetCursorPosition(0, 4);

            foreach (Product product in Inventory)
            {
                product.Show();
            }

            Console.SetCursorPosition(0, 4);
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

    public class Seller : Store
    {
        public void FillBag()
        {
            int sellersBagCapacity = 20;
            int priceMinVolue = 20;
            int priceMaxVolue = 1000;

            Random priceRandom = new Random();

            for (int i = 0; i < sellersBagCapacity; i++)
            {
                Inventory.Add(new Product($"{i}", priceRandom.Next(priceMinVolue, priceMaxVolue + 1)));
            }
        }

        public Product GetProduct(Player player)
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
                    Inventory.RemoveAt(i);
                    return product;
                }
            }

            UserUtils.ClearMenu();
            Console.WriteLine("Такого товара не найдено. Нажмите любую клавишу");
            Console.ReadKey();

            return product;
        }
    }

    public class Player : Store
    {
        public int Money { get; private set; }

        public Player(int money)
        {
            Money = money;
        }

        public void ShowMoney()
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("               ");
            Console.SetCursorPosition(0, 25);
            Console.WriteLine($"Деньги: {Money}");
            Console.SetCursorPosition(0, 0);
        }

        public void BuyProduct(Product product)
        {
            int moneyToPay;

            if (product != null)
            {
                moneyToPay = product.Price;

                if (Money > moneyToPay)
                {
                    Inventory.Add(product);
                    Money -= moneyToPay;
                }
                else
                {
                    Money -= moneyToPay;
                }
            }
        }
    }
}
