using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Empty;

            bool isDrugNameCorrect = true;

            Dictionary<string, string> medicines = new Dictionary<string, string>();

            medicines.Add("церукал", "средство от тошноты");
            medicines.Add("аспирин", "средство от болей");
            medicines.Add("лоперамид", "средство от диареи");

            while (isDrugNameCorrect)
            {
                Console.WriteLine("Введите название препарата: ");
                userInput = Console.ReadLine().ToLower();

                if (medicines.ContainsKey(userInput))
                {
                    Console.WriteLine(medicines[userInput]);
                }
                else
                {
                    isDrugNameCorrect = false;
                    Console.WriteLine("Такого препарата нет");
                }
            }
        }
    }
}
