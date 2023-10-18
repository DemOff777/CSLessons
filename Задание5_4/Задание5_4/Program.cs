using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandShowAllDossiers = "2";
            const string CommandDeleteDossier = "3";
            const string CommandExit = "4";

            bool isProgrammWork = true;

            string userInput;

            Dictionary<string, string> dossiers = new Dictionary<string, string> ();

            while (isProgrammWork)
            {
                Console.WriteLine("Выберите команду:");
                Console.WriteLine($"Добавить досье - {CommandAddDossier}");
                Console.WriteLine($"Показать все досье - {CommandShowAllDossiers}");
                Console.WriteLine($"Удалить досье - {CommandDeleteDossier}");
                Console.WriteLine($"Выход - {CommandExit}");
                userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(dossiers);
                        break;

                    case CommandShowAllDossiers:
                        ShowAllDossiers(dossiers);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(dossiers);
                        break;

                    case CommandExit:
                        isProgrammWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, string> dossiers)
        {
            string name;
            string position;

            Console.WriteLine("Введите имя и фамилию");
            name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите должность");
            position = Console.ReadLine();
            Console.Clear();

            dossiers.Add(name, position);   
        }

        static void ShowAllDossiers(Dictionary<string, string> dossiers)
        {
            foreach (var name in dossiers)
            {
                Console.WriteLine($"{name.Key} {name.Value}");
            }

            Console.WriteLine("Нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            string userInput;
            Console.WriteLine("Введите имя удаляемого сотрудника");
            userInput = Console.ReadLine();

            if (dossiers.ContainsKey(userInput))
            {
                dossiers.Remove(userInput);
                Console.WriteLine("Досье удалено. Нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Досье не найдено");
            }
        }
    }
}
