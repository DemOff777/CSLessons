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
            string cerukalName = "церукал";
            string aspirinName = "аспирин";
            string loperamidName = "лоперамид";
            string cerukalDescription = "средство от тошноты";
            string aspirinDescription = "средство от болей";
            string loperamidDescription = "средство от диареи";
            string userInput = string.Empty;

            bool isDrugNameCorrect = true;

            Dictionary<string, string> medicines = new Dictionary<string, string>();

            medicines = AddDrug(medicines, cerukalName, cerukalDescription);
            medicines = AddDrug(medicines, aspirinName, aspirinDescription);
            medicines = AddDrug(medicines, loperamidName, loperamidDescription);

            while (isDrugNameCorrect)
            {
                Console.WriteLine("Введите название препарата: ");
                userInput = Console.ReadLine();

                if (isDrugNameCorrect == medicines.ContainsKey(userInput))
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

        static Dictionary<string, string> AddDrug(Dictionary<string, string> medicines, string drug, string description)
        {
            medicines.Add(drug, description);
            return medicines;
        }
    }
}
