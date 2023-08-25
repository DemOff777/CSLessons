using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "рыбамеч";
            string userPassword;
            int repetition = 3;

            for (int i = 1; i <= repetition; i++)
            {
                Console.Write("Введите пароль: ");
                userPassword = Console.ReadLine();

                if (userPassword == password)
                {
                    Console.WriteLine("Очень секретное сообщение");
                    break;
                }
                    if (i == 3)
                    {
                        Console.WriteLine("Количество попыток закончилось");
                    }
                else
                {
                    Console.WriteLine("Пароль неверен");
                }
            }

        }
    }
}
