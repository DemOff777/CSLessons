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
            int passwordRepetitions = 3;

            for (int i = 0; i < passwordRepetitions; i++)
            {
                Console.Write("Введите пароль: ");
                userPassword = Console.ReadLine();

                if (userPassword == password)
                {
                    Console.WriteLine("Очень секретное сообщение");
                    break;
                }

                    if (i == passwordRepetitions)
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
