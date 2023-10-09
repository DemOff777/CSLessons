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
            int number;

            Convertation(out number);

            Console.WriteLine("Введенное число: " + number);
        }
        static int Convertation(out int number)
        {
            int userNumber = 0;
            bool isValueCorrect = false;

            while (isValueCorrect == false)
            {
                Console.Write("Введите число: ");
                isValueCorrect = int.TryParse(Console.ReadLine(), out userNumber);
            }

            number = userNumber;
            return number;
        }
    }
}
