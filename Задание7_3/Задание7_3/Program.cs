using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание7_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();
        
        public static int GeneradeRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }

        public static int GeneradeRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue + 1);
        }
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            GeneradePatients();
        }

        public void Work()
        {
            const int CommandSortByName = 1;
            const int CommandSortByAge = 2;
            const int CommandShowIllnessPatients = 3;
            const int CommandExit = 4;

            bool isWork = true;

            while (isWork)
            {
                ShowPatients(_patients);

                Console.WriteLine();
                Console.WriteLine("Введите команду:");
                Console.WriteLine($"Сортировать пациентов по ФИО - {CommandSortByName}");
                Console.WriteLine($"Сортировать пациентов по возрасту - {CommandSortByAge}");
                Console.WriteLine($"Показать пациентов с определенным заболеванием - {CommandShowIllnessPatients}");
                Console.WriteLine($"Для выхода нажмите {CommandExit}");

                int userInput = GiveUserInput();

                switch (userInput)
                {
                    case CommandSortByName:
                        SortPatientsByInitials();
                        break;
                    case CommandSortByAge:
                        SortPatientsByAge();
                        break;
                    case CommandShowIllnessPatients:
                        ShowIllnessPatients();
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Неправильная комманда, попробуйте еще раз");
                        break;
                }
            }

            Console.WriteLine("Госпиталь закончил свою работу");
        }

        private void SortPatientsByInitials()
        {
            const int CommandSortByName = 1;
            const int CommandSortBySurname = 2;
            const int CommandSortByPatronymic = 3;

            Console.WriteLine($"Сортировать пациентов по Имени - {CommandSortByName}");
            Console.WriteLine($"Сортировать пациентов по Фамилии - {CommandSortBySurname}");
            Console.WriteLine($"Сортировать пациентов по Отчеству - {CommandSortByPatronymic}");

            int userInput = GiveUserInput();

            switch (userInput)
            {
                case CommandSortByName:
                    SortPatientsByName();
                    break;
                case CommandSortBySurname:
                    SortPatientsBySurname();
                    break;
                case CommandSortByPatronymic:
                    SortPatientsByPatronymic();
                    break;
            }
        }

        private void SortPatientsByName()
        {
            _patients = _patients.OrderBy(patient => patient.Name).ToList();
        }

        private void SortPatientsBySurname()
        {
            _patients = _patients.OrderBy(patient => patient.Surname).ToList();
        }

        private void SortPatientsByPatronymic()
        {
            _patients = _patients.OrderBy(patient => patient.Patronymic).ToList();
        }

        private void SortPatientsByAge()
        {
            _patients = _patients.OrderBy(patient => patient.Age).ToList();
        }

        private void ShowIllnessPatients()
        {
            List<Illness> illneses = new List<Illness>()
            {
                Illness.Snuffle,
                Illness.Diarrhea,
                Illness.Otitis,
                Illness.Allergy,
                Illness.Headache,
                Illness.Appendicitis
            };

            Console.WriteLine("Введите название заболевания");

            string userInput = Console.ReadLine();
            Illness userIllness = (Illness)Enum.Parse(typeof(Illness), userInput);

            var userIllnessPatients = _patients.Where(patient => patient.Illness == userIllness);

            ShowPatients(userIllnessPatients.ToList());
        }

        private int GiveUserInput()
        {
            int userInput = 0;
            bool isUserInputCorrect = false;

            while (isUserInputCorrect == false)
            {
                isUserInputCorrect = Int32.TryParse(Console.ReadLine(), out userInput);

                if (isUserInputCorrect == false)
                {
                    Console.WriteLine("Неверное значение, попробуйте ввести еще раз");
                }
            }

            return userInput;
        }

        private void GeneradePatients()
        {
            int patientsCount = 100;

            for (int i = 0; i < patientsCount; i++)
            {
                _patients.Add(new Patient());
            }
        }

        private void ShowPatients(List<Patient> patients)
        {
            foreach (var patient in patients)
            {
                patient.ShowInfo();
            }
        }
    }

    class Patient
    {
        private List<Name> _names = new List<Name>()
        {
            Name.Fedya,
            Name.Vasya,
            Name.Uriy,
            Name.Petr,
            Name.Stas,
            Name.Kolya
        };

        private List<Surname> _surnames = new List<Surname>()
        {
            Surname.Kuznucov,
            Surname.Borisov,
            Surname.Hanov,
            Surname.Gnecov,
            Surname.Zabolotsky,
            Surname.Grinvich
        };

        private List<Patronymic> _patronymic = new List<Patronymic>()
        {
            Patronymic.Aleksandrovich,
            Patronymic.Alekseevich,
            Patronymic.Dmitrievich,
            Patronymic.Tamarovich,
            Patronymic.Romanovich
        };

        private List<Illness> _illness = new List<Illness>()
        {
            Illness.Snuffle,
            Illness.Diarrhea,
            Illness.Otitis,
            Illness.Allergy,
            Illness.Headache,
            Illness.Appendicitis
        };

        public Patient()
        {
            GeneradeName();
            GeneradeSurname();
            GeneradePatronymic();
            GeneradeIllness();
            GeneradeAge();
        }

        public Name Name { get; private set; }

        public Surname Surname { get; private set; }

        public Patronymic Patronymic { get; private set; }

        public int Age { get; private set; }

        public Illness Illness { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} {Surname} {Patronymic} Возраст - {Age} лет, Заболевание - {Illness}");
        }

        private void GeneradeName()
        {
            Name = _names[UserUtils.GeneradeRandomNumber(_names.Count)];
        }

        private void GeneradeSurname()
        {
            Surname = _surnames[UserUtils.GeneradeRandomNumber(_surnames.Count)];
        }

        private void GeneradePatronymic()
        {
            Patronymic = _patronymic[UserUtils.GeneradeRandomNumber(_patronymic.Count)];
        }

        private void GeneradeIllness()
        {
            Illness = _illness[UserUtils.GeneradeRandomNumber(_illness.Count)];
        }

        private void GeneradeAge()
        {
            int minAgeValue = 7;
            int maxAgeValue = 70;

            Age = UserUtils.GeneradeRandomNumber(minAgeValue, maxAgeValue);
        }
    }

    enum Name
    {
        Fedya,
        Kolya,
        Petr,
        Stas,
        Uriy,
        Vasya
    }

    enum Surname
    {
        Borisov,
        Gnecov,
        Grinvich,
        Hanov,
        Kuznucov,
        Zabolotsky,
    }
    enum Patronymic
    {
        Aleksandrovich,
        Alekseevich,
        Dmitrievich,
        Romanovich,
        Tamarovich
    }

    enum Illness
    {
        Snuffle,
        Diarrhea,
        Otitis,
        Allergy,
        Headache,
        Appendicitis
    }
}
