using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PoliceOffice policeOffice = new PoliceOffice();

            policeOffice.Work();
        }
    }

    class PoliceOffice
    {
        private List<Criminal> _criminals = new List<Criminal>();   

        public PoliceOffice()
        {
            GenerateCriminals();
        }

        public void Work()
        {  
            bool isCriminalFound = false;

            while (isCriminalFound == false)
            {
                Console.WriteLine("Введите рост подозреваемого");
                int criminalHeight = GiveUserInput();
                Console.WriteLine("Введите вес подозреваемого");
                int criminalWeight = GiveUserInput();
                Console.WriteLine("Введите национальность подозреваемого");
                Nationality criminalNationality = GiveUserCriminalNationality();

                var criminalsFound = _criminals.Where(criminal => criminal.Weight == criminalWeight && criminal.Height == criminalHeight && criminal.Nationality == criminalNationality && criminal.IsInJeil == false);

                foreach (var criminal in criminalsFound)
                {
                    criminal.ShowInfo();
                }

                isCriminalFound = true;

                if (criminalsFound.Count() == 0)
                {
                    Console.WriteLine("По вашему запросу ничего не найдено, опробуйте еще раз");
                    isCriminalFound= false;
                }
            }
        }

        private int GiveUserInput()
        {
            bool isInputCorrect = false;
            int userInput = 0;

            while (isInputCorrect == false)
            {
                isInputCorrect = Int32.TryParse(Console.ReadLine(), out userInput);

                if (isInputCorrect == false)
                {
                    Console.WriteLine("Неверное нрачение, попробуйте еще раз");
                }
            }

            return userInput;
        }

        private Nationality GiveUserCriminalNationality()
        {
            List<string> nationalities = new List<string>()
            {
                Convert.ToString(Nationality.Russian),
                Convert.ToString(Nationality.Prostokvashin),
                Convert.ToString(Nationality.African),
                Convert.ToString(Nationality.European),
                Convert.ToString(Nationality.Asian),
                Convert.ToString(Nationality.American)
            };

            string nationality = "";

            bool isNationalityCorrect = false;

            while (isNationalityCorrect == false)
            {
                nationality = Console.ReadLine();
                
                if (nationalities.Contains(nationality))
                {
                    isNationalityCorrect = true;
                }
                else
                {
                    Console.WriteLine("Национальность введена не правильно, попробуйте еще раз");
                }
            }

            return (Nationality)Enum.Parse(typeof(Nationality), nationality);
        }

        private void GenerateCriminals()
        {
            int criminalsWanted = 100000;

            for (int i = 0; i < criminalsWanted; i++)
            {
                _criminals.Add(new Criminal());
            }
        }
    }

    class Criminal
    {
        private Name _name;
        private Surname _surname;
        private Patronymic _patronymic;

        public Criminal()
        {
            List<Name> names = new List<Name>()
        {
            Name.Aleks,
            Name.Oleg,
            Name.Gerasim,
            Name.ChuCha,
            Name.Taras,
            Name.Magneto,
            Name.Osip,
            Name.Parenek
        };

            List<Surname> surnames = new List<Surname>()
        {
            Surname.Fehtel,
            Surname.Ribakov,
            Surname.Sandalskiy,
            Surname.Propp,
            Surname.Udya,
            Surname.Shevchenko,
            Surname.Aslanov
        };

            List<Patronymic> patronymics = new List<Patronymic>()
        {
            Patronymic.Olgovich,
            Patronymic.Marinovich,
            Patronymic.RamizOgli,
            Patronymic.Gelievich,
            Patronymic.Papikovich,
            Patronymic.Arslan
        };

            List<Nationality> nationalities = new List<Nationality>()
        {
            Nationality.Russian,
            Nationality.Prostokvashin,
            Nationality.American,
            Nationality.African,
            Nationality.European,
            Nationality.Asian
            };

            _name = names[UserUtils.GiveRandomNumber(names.Count)];
            _surname = surnames[UserUtils.GiveRandomNumber(surnames.Count)];
            _patronymic = patronymics[UserUtils.GiveRandomNumber(patronymics.Count)];
            Nationality = nationalities[UserUtils.GiveRandomNumber(nationalities.Count)];
            GeneradeRandomHeight();
            GeneradeRandomWeight();
            GetInJailBool();
        }

        public Nationality Nationality { get; private set; }

        public int Height { get; private set; }

        public int Weight { get; private set; }

        public bool IsInJeil { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Розыскиваемый {_surname} {_name} {_patronymic} рост - {Height} см, вес - {Weight} кг. национальность - {Nationality}");
        }

        private void GetInJailBool()
        {
            int trueIndex = 2;

            IsInJeil =  Convert.ToBoolean(UserUtils.GiveRandomNumber(trueIndex));
        }

        private void GeneradeRandomHeight()
        {
            int minHeight = 150;
            int maxHeight = 210;

            Height = UserUtils.GiveRandomNumber(minHeight, maxHeight);
        }

        private void GeneradeRandomWeight()
        {
            int minWeight = 40;
            int maxWeight = 110;

            Weight = UserUtils.GiveRandomNumber(minWeight, maxWeight);
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GiveRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue + 1);
        }

        public static int GiveRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }

    enum Name
    {
        Aleks,
        Oleg,
        Gerasim,
        ChuCha,
        Taras,
        Magneto,
        Osip,
        Parenek
    }

    enum Surname
    {
        Fehtel,
        Ribakov,
        Sandalskiy,
        Propp,
        Udya,
        Shevchenko,
        Aslanov
    }

    enum Patronymic
    {
        Olgovich,
        Marinovich,
        RamizOgli,
        Gelievich,
        Papikovich,
        Arslan
    }

    enum Nationality
    {
        Russian,
        Prostokvashin,
        American,
        European,
        African,
        Asian
    }
}
