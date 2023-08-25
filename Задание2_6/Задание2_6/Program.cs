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
            const string MenuExit = "6";

            string userMenuChoice = "";
            string password = "";
            string userPassword;
            string nameSecret = "";

            while (userMenuChoice != MenuExit)
            {
                const string MenuSetName = "1";
                const string MenuSetPassword = "2";
                const string MenuEnterPassword = "3";
                const string MenuSetTextColor = "4";
                const string MenuSetBackgroungColor = "5";

                string Color = "";

                Console.WriteLine("Основное меню");
                Console.WriteLine("1-Ввести имя");
                Console.WriteLine("2-Установить пароль");
                Console.WriteLine("3-Ввести пароль");
                Console.WriteLine("4-Установить цвет текста");
                Console.WriteLine("5-Установить цвет консоли");
                Console.WriteLine("6-Выход из программы");
                Console.WriteLine();
                userMenuChoice = Console.ReadLine();
                Console.Clear();

                switch (userMenuChoice)
                {
                    case MenuSetName:
                        Console.Write("Введите имя:");
                        nameSecret = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Имя установлено");
                        Console.WriteLine();
                        break;

                    case MenuSetPassword:
                        Console.Write("Установите пароль:");
                        password = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Пароль установлен");
                        Console.WriteLine();
                        break;

                    case MenuEnterPassword:
                        Console.Write("Введите пароль:");
                        userPassword = Console.ReadLine();
                        Console.Clear();

                        if (userPassword == password)
                        {
                            Console.WriteLine("Секретное послание: " + nameSecret);
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Пароль неверен");
                            Console.WriteLine();
                            break;
                        }
                    case MenuSetTextColor:

                        const string MenuTextColorGreen = "1";
                        const string MenuTextColorBlue = "2";
                        const string MenuTextColorYellow = "3";
                        const string MenuTextColorWhite = "4";

                        while (Color != MenuTextColorGreen && Color != MenuTextColorBlue && Color != MenuTextColorYellow && Color != MenuTextColorWhite)
                        {
                            Console.WriteLine("Выберите цвет текста:");
                            Console.WriteLine("1-Зеленый");
                            Console.WriteLine("2-Синий");
                            Console.WriteLine("3-Желтый");
                            Console.WriteLine("4-Белый"); 
                            Color = Console.ReadLine();
                            Console.Clear();

                            switch (Color)
                            {
                                case MenuTextColorGreen:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    break;

                                case MenuTextColorBlue:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    break;

                                case MenuTextColorYellow:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    break;

                                case MenuTextColorWhite:
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    break;

                                default:
                                    Console.WriteLine("Недопустимое значение");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        break;

                    case MenuSetBackgroungColor:

                        while (Color != MenuSetName && Color != MenuSetPassword && Color != MenuEnterPassword && Color != MenuSetTextColor)
                        {
                            const string MenuBackgroundDarkGray = "1";
                            const string MenuBackgroundDarkBlue = "2";
                            const string MenuBackgroundDarkCyan = "3";
                            const string MenuBackgroundBlack = "4";

                            Console.WriteLine("Выберите цвет фона:");
                            Console.WriteLine("1-Темно-Серый");
                            Console.WriteLine("2-Темно-Синий");
                            Console.WriteLine("3-Голубой");
                            Console.WriteLine("4-Черный");
                            Color = Console.ReadLine();
                            Console.Clear();

                            switch (Color)
                            {
                                case MenuBackgroundDarkGray:
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    break;

                                case MenuBackgroundDarkBlue:
                                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    break;

                                case MenuBackgroundDarkCyan:
                                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    break;

                                case MenuBackgroundBlack:
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    break;

                                default:
                                    Console.WriteLine("Недопустимое значение");
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        break;

                    case MenuExit:
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
