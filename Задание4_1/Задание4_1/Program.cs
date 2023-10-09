using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userMenuChoise;
            string userNameSearch;

            int userEnterPersonData;

            const string CommandEnterDossier = "1";
            const string CommandShowAllDossiers = "2";
            const string CommandDeleteDossier = "3";
            const string CommandSearchDossiers = "4";
            const string CommandExit = "5";

            bool isDossierMenuWork = true;

            string[] name = new string[0];

            string[] position = new string[0];

            while (isDossierMenuWork)
            {
                Console.WriteLine($"{CommandEnterDossier} Ввести данные по досье");
                Console.WriteLine($"{CommandShowAllDossiers} Показать все досье");
                Console.WriteLine($"{CommandDeleteDossier} Удалить досье");
                Console.WriteLine($"{CommandSearchDossiers} Поиск по фамилии");
                Console.WriteLine($"{CommandExit} Выход");
                Console.Write("Введите нужный пункт меню: ");

                switch (Convert.ToString(Console.ReadKey().KeyChar))
                {
                    case CommandEnterDossier:
                        Console.Clear();
                        Console.Write("Введите имя: ");
                        EnterPersonData(ref name);
                        Console.Write("Введите должность: ");
                        EnterPersonData(ref position);
                        break;

                    case CommandShowAllDossiers:
                        Console.Clear();
                        ShowAllData(ref name, ref position);
                        break;

                    case CommandDeleteDossier:
                        Console.Clear();
                        Console.Write("Введите номер досье: ");
                        userEnterPersonData = Convert.ToInt32(Console.ReadLine());
                        DeleteData(ref name, userEnterPersonData);
                        DeleteData(ref position, userEnterPersonData);
                        break;

                    case CommandSearchDossiers:
                        Console.Clear();
                        Console.Write("Введите фамилию: ");
                        userNameSearch = Console.ReadLine();
                        SearchDataByName(name, userNameSearch);
                        break;

                    case CommandExit:
                        isDossierMenuWork = false;
                        Console.Clear();
                        Console.WriteLine("Вы вышли");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\nНе допустимое значение");
                        Console.Write("\nНажмите любую клавишу");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        static void EnterPersonData(ref string[] personData)
        {
            string userEnterPersonData;

            string[] newPersonData = new string[personData.Length + 1];

            for (int i = 0; i < personData.Length; i++)
            {
                newPersonData[i] = personData[i];
            }

            userEnterPersonData = Console.ReadLine();
            Console.Clear();
            newPersonData[newPersonData.Length - 1] = userEnterPersonData;
            personData = newPersonData;
        }
        static void ShowAllData(ref string[] name, ref string[] position)
        {
            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine($"-{i + 1}. Имя: {name[i]} Должность: {position[i]}");
            }

            Console.Write("\nНажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();
        }
        static void DeleteData(ref string[] personData, int userEnterPersonData)
        {
            string[] newPersonData = new string[personData.Length - 1];

            for (int i = 0; i < personData.Length; i++)
            {
                if (i < userEnterPersonData - 1)
                {
                    newPersonData[i] = personData[i];                  
                }

                if (i > userEnterPersonData - 1)
                {
                    newPersonData[i-1] = personData[i];
                }
            }

            Console.Clear();
            personData = newPersonData;
        }
        static void SearchDataByName(string[] name, string userSearch)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i].ToLower() == userSearch.ToLower())
                {
                    Console.Clear();   
                    Console.WriteLine($"Досье на имя: {name[i]} находится под номером {i}\n");
                }
            }
        }
    }
}
