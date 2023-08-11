using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userMenuChoice = "start";
            string exit = "exit";
            string password;
            string userPassword;
            string nameSecret = "";
            string menuItem1 = "1";
            string menuItem2 = "2";
            string menuItem3 = "3";
            string menuItem4 = "4";
            string menuItem5 = "5";

            while (userMenuChoice != exit && userMenuChoice != menuItem1 && userMenuChoice != menuItem2 && userMenuChoice != menuItem3 && userMenuChoice != menuItem4 && userMenuChoice != menuItem5)
            {
                string consoleColor = "";
                string textColor = "";
                Console.WriteLine("Основное меню");
                Console.WriteLine("1-Ввести имя");
                Console.WriteLine("2-Установить пароль");
                Console.WriteLine("3-Ввести пароль");
                Console.WriteLine("4-Установить цвет текста");
                Console.WriteLine("5-Установить цвет консоли");
                Console.WriteLine("exit-выход из программы");
                Console.WriteLine();
                userMenuChoice = Console.ReadLine();
                Console.Clear();

                switch (userMenuChoice)
                {
                    case "1":
                        Console.Write("Введите имя:");
                        nameSecret = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Имя установлено");
                        Console.WriteLine();
                        userMenuChoice = "start";
                        break;
                    case "2":
                        Console.Write("Установите пароль:");
                        password = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Пароль установлен");
                        Console.WriteLine();
                        userMenuChoice = "start";
                        break;
                    case "3":
                        Console.Write("Введите пароль:");
                        userPassword = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Секретное послание: " + nameSecret);
                        Console.WriteLine();
                        userMenuChoice = "start";
                        break;
                    case "4":
                        while (consoleColor != menuItem1 && consoleColor != menuItem2 && consoleColor != menuItem3 && consoleColor != menuItem4)
                        {
                            Console.WriteLine("Выберите цвет текста:");
                            Console.WriteLine("1-Зеленый");
                            Console.WriteLine("2-Синий");
                            Console.WriteLine("3-Желтый");
                            Console.WriteLine("4-Белый"); 
                            consoleColor = Console.ReadLine();
                            Console.Clear();

                            switch (consoleColor)
                            {
                                case "1":
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    userMenuChoice = "start";
                                    break;
                                case "2":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    userMenuChoice = "start";
                                    break;
                                case "3":
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    userMenuChoice = "start";
                                    break;
                                case "4":
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    userMenuChoice = "start";
                                    break;
                                default:
                                    Console.WriteLine("Недопустимое значение");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        break;
                    case "5":

                        while (consoleColor != menuItem1 && consoleColor != menuItem2 && consoleColor != menuItem3 && consoleColor != menuItem4)
                        {
                            Console.WriteLine("Выберите цвет фона:");
                            Console.WriteLine("1-Темно-Серый");
                            Console.WriteLine("2-Темно-Синий");
                            Console.WriteLine("3-Голубой");
                            Console.WriteLine("4-Черный");
                            consoleColor = Console.ReadLine();
                            Console.Clear();

                            switch (consoleColor)
                            {
                                case "1":
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    userMenuChoice = "start";
                                    break;
                                case "2":
                                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    userMenuChoice = "start";
                                    break;
                                case "3":
                                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    userMenuChoice = "start";
                                    break;
                                case "4":
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    userMenuChoice = "start";
                                    break;
                                default:
                                    Console.WriteLine("Недопустимое значение");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        break;
                    case "exit":
                        Console.WriteLine("Вы вышли");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Недопустимое значение");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
