using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание4_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;

            number = ReadInt();

            Console.WriteLine($"Введенное число: {number}");
        }

        static int ReadInt()
        {
            int userNumber = 0;

            bool isConvertationCorrect = false;

            while (isConvertationCorrect == false)
            {             
                Console.Write("Введите число: ");

                isConvertationCorrect = int.TryParse(Console.ReadLine(), out userNumber);

                if (isConvertationCorrect == false)
                {
                    Console.WriteLine("Неверный формат");
                }
            }

            return userNumber;
        }
    }
}
