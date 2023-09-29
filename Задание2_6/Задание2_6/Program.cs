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
            const string CommandSetName = "1";
            const string CommandSetPassword = "2";
            const string CommandEnterPassword = "3";
            const string CommandSetTextColor = "4";
            const string CommandSetBackgroungColor = "5";
            const string CommandExit = "6";

            string userMenuChoice = "";
            string password = "";
            string userPassword;
            string nameSecret = "";
            bool isWorking = true;

            while (isWorking == true)
            {
                string menuColor = "";
                bool isMenuColorWork = true;

                Console.WriteLine("Основное меню");
                Console.WriteLine($"{CommandSetName}-Ввести имя");
                Console.WriteLine($"{CommandSetPassword}-Установить пароль");
                Console.WriteLine($"{CommandEnterPassword}-Ввести пароль");
                Console.WriteLine($"{CommandSetTextColor}-Установить цвет текста");
                Console.WriteLine($"{CommandSetBackgroungColor}-Установить цвет консоли");
                Console.WriteLine($"{CommandExit}-Выход из программы");
                Console.WriteLine();
                userMenuChoice = Console.ReadLine();
                Console.Clear();

                switch (userMenuChoice)
                {
                    case CommandSetName:
                        Console.Write("Введите имя:");
                        nameSecret = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Имя установлено");
                        Console.WriteLine();
                        break;

                    case CommandSetPassword:
                        Console.Write("Установите пароль:");
                        password = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Пароль установлен");
                        Console.WriteLine();
                        break;

                    case CommandEnterPassword:
                        Console.Write("Введите пароль:");
                        userPassword = Console.ReadLine();
                        Console.Clear();

                        if (userPassword == password)
                        {
                            Console.WriteLine("Секретное послание: " + nameSecret);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Пароль неверен");
                            Console.WriteLine();
                        }

                        break;

                    case CommandSetTextColor:
                        const string CommandTextColorGreen = "1";
                        const string CommandTextColorBlue = "2";
                        const string CommandTextColorYellow = "3";
                        const string CommandTextColorWhite = "4";

                        while (isMenuColorWork == true)
                        {
                            Console.WriteLine("Выберите цвет текста:");
                            Console.WriteLine($"{CommandTextColorGreen}-Зеленый");
                            Console.WriteLine($"{CommandTextColorBlue}-Синий");
                            Console.WriteLine($"{CommandTextColorYellow}-Желтый");
                            Console.WriteLine($"{CommandTextColorWhite}-Белый"); 
                            menuColor = Console.ReadLine();
                            Console.Clear();

                            switch (menuColor)
                            {
                                case CommandTextColorGreen:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    isMenuColorWork = false;
                                    break;

                                case CommandTextColorBlue:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    isMenuColorWork = false;
                                    break;

                                case CommandTextColorYellow:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    isMenuColorWork = false;
                                    break;

                                case CommandTextColorWhite:
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Цвет консоли установлен");
                                    Console.WriteLine();
                                    isMenuColorWork = false;
                                    break;

                                default:
                                    Console.WriteLine("Недопустимое значение");
                                    Console.WriteLine();
                                    break;
                            }
                        }

                        break;

                    case CommandSetBackgroungColor:
                        const string CommandBackgroundDarkGray = "1";
                        const string CommandBackgroundDarkBlue = "2";
                        const string CommandBackgroundDarkCyan = "3";
                        const string CommandBackgroundBlack = "4";

                        while (isMenuColorWork == true)
                        {
                            Console.WriteLine("Выберите цвет фона:");
                            Console.WriteLine($"{CommandBackgroundDarkGray}-Темно-Серый");
                            Console.WriteLine($"{CommandBackgroundDarkBlue}-Темно-Синий");
                            Console.WriteLine($"{CommandBackgroundDarkCyan}-Голубой");
                            Console.WriteLine($"{CommandBackgroundBlack}-Черный");
                            menuColor = Console.ReadLine();
                            Console.Clear();

                            switch (menuColor)
                            {
                                case CommandBackgroundDarkGray:
                                    Console.BackgroundColor = ConsoleColor.DarkGray;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    isMenuColorWork = false;
                                    break;

                                case CommandBackgroundDarkBlue:
                                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    isMenuColorWork = false;
                                    break;

                                case CommandBackgroundDarkCyan:
                                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    isMenuColorWork = false;
                                    break;

                                case CommandBackgroundBlack:
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine("Цвет фона установлен");
                                    Console.WriteLine();
                                    isMenuColorWork = false;
                                    break;

                                default:
                                    Console.WriteLine("Недопустимое значение");
                                    Console.WriteLine();
                                    break;
                            }
                        }

                    break;

                    case CommandExit:
                        Console.WriteLine("Вы вышли");
                        Console.WriteLine();
                        isWorking = false;
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
