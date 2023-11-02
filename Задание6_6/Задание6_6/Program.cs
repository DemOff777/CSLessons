using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание6_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowSellerBag = "1";
            const string CommandShowPlayerBag = "2";
            const string CommandBuyProduct = "3";

            Player player = new Player();

            Seller seller = new Seller();

            player.FillMoneyAmount();
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
                        seller.ShowBag();
                        break;
                    case CommandShowPlayerBag:
                        player.ShowInventory();
                        break;
                    case CommandBuyProduct:
                        player.TakeProduct(seller.GetProduct(player));
                        break;
                }
            }

            Console.WriteLine("Деньги закончились - до свидания!");
        } 
    }

    public abstract class Menu
    {
        public void ClearInventory()
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

        public void ClearMenu()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
            Console.WriteLine("                                                     ");
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

    public class Seller : Menu
    {
        private List<Product> _bag = new List<Product>();

        public void FillBag()
        {
            int sellersBagCapacity = 20;
            int priceMinVolue = 20;
            int priceMaxVolue = 1000;

            Random priceRandom = new Random();

            for (int i = 0; i < sellersBagCapacity; i++)
            {
                _bag.Add(new Product($"{i}", priceRandom.Next(priceMinVolue, priceMaxVolue + 1)));
            }
        }

        public void ShowBag()
        {
            ClearInventory();
            Console.SetCursorPosition(0, 4);

            foreach (Product product in _bag)
            {
                product.Show();
            }

            Console.SetCursorPosition(0, 4);
        }

        public Product GetProduct(Player player)
        {
            Product product = null;

            string userInput;

            ClearMenu();
            Console.WriteLine("Введите номер товара");
            Console.SetCursorPosition(0, 3);

            userInput = Console.ReadLine();

            for (int i = 0; i < _bag.Count; i++)
            {
                if (userInput == _bag[i].Name)
                {
                    product = _bag[i];
                    _bag.RemoveAt(i);
                    return product;
                }
            }

            ClearMenu();
            Console.WriteLine("Такого товара не найдено. Нажмите любую клавишу");
            Console.ReadKey();

            return product;
        }
    }

    public class Player : Menu
    {
        private int _moneyToPay;

        private List<Product> _inventory = new List<Product>();

        public int Money { get; private set; }

        public void FillMoneyAmount()
        {
            int moneyMinAmount = 1000;
            int moneyMaxAmount = 5000;

            Random random = new Random();

            Money = random.Next(1000, 5000 + 1);
        }

        public void ShowMoney()
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("               ");
            Console.SetCursorPosition(0, 25);
            Console.WriteLine($"Деньги: {Money}");
            Console.SetCursorPosition(0, 0);
        }

        public void ShowInventory()
        {
            ClearInventory();
            Console.SetCursorPosition(0, 4);

            foreach (Product product in _inventory)
            {
                product.Show();
            }

            Console.SetCursorPosition(0, 4);
        }

        public void TakeProduct(Product product)
        {
            if (product != null)
            {
                _moneyToPay = product.Price;

                if (Money > _moneyToPay)
                {
                    _inventory.Add(product);
                    Money -= _moneyToPay;
                }
                else
                {
                    Money -= _moneyToPay;
                }
            }
        }
    }
}
