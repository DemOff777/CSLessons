using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание7_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arstocka arstocka = new Arstocka();

            arstocka.ShowCriminals();
            arstocka.Amnesty();
            arstocka.ShowCriminals();
        }
    }

    class Arstocka
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public Arstocka()
        {
            GeneradeCriminals();
        }

        public void Amnesty()
        {
            var criminalsAmnesty = _criminals.Where(criminal => criminal.Crime == Crime.AntiGovernment);

            Console.WriteLine();
            Console.WriteLine("Амнестированы за антипровительственную деятельнось некоторые заключенные");
            Console.WriteLine();

            foreach (var criminal in criminalsAmnesty)
            {
                criminal.ShowInfo();
            }

            _criminals = _criminals.Except(criminalsAmnesty).ToList();
        }

        public void ShowCriminals()
        {
            Console.WriteLine();
            Console.WriteLine($"Всего заключенных:");
            Console.WriteLine();

            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }

        private void GeneradeCriminals()
        {
            int criminalsValue = 100;

            for (int i = 0; i < criminalsValue; i++)
            {
                _criminals.Add(new Criminal());
            }
        }
    }

    class Criminal
    {
        public Criminal()
        {
            List<Name> names = new List<Name>()
            {
            Name.Alesha,
            Name.Anton,
            Name.Gacha,
            Name.Pacha,
            Name.Denis,
            Name.Vasily,
            Name.Tremor,
            Name.Petya,
            Name.Patrik
            };

            List<Surname> surnames = new List<Surname>()
            {
            Surname.Frakiev,
            Surname.Labuda,
            Surname.Vasyliev,
            Surname.Lomanovsky,
            Surname.Trubadur,
            Surname.Chacha,
            Surname.Togorotov,
            Surname.Menyalkin,
            Surname.Lomovoy,
            Surname.Hristenko,
            Surname.Tvar
            };

            List<Patronymic> patronymics = new List<Patronymic>()
            {
            Patronymic.Grigorievich,
            Patronymic.Vasylevich,
            Patronymic.Tradovich,
            Patronymic.Lermantovich,
            Patronymic.Gribovish,
            Patronymic.Kurovich,
            Patronymic.Zaborovich
            };

            List<Crime> crimes = new List<Crime>()
            {
            Crime.Murder,
            Crime.Steal,
            Crime.Fraud,
            Crime.DrugSales,
            Crime.Extortion,
            Crime.AntiGovernment
            };

            Name = names[UserUtils.GiveRandomNumber(names.Count)];
            Surname = surnames[UserUtils.GiveRandomNumber(surnames.Count)];
            Patronymic = patronymics[UserUtils.GiveRandomNumber(patronymics.Count)];
            Crime = crimes[UserUtils.GiveRandomNumber(crimes.Count)];
        }

        public Name Name { get; private set; }

        public Surname Surname { get; private set; }

        public Patronymic Patronymic { get; private set; }

        public Crime Crime { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Заключенный {Surname} {Name} {Patronymic}, статья - {Crime}");
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GiveRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static int GiveRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }

    enum Crime
    {
        Murder,
        Steal,
        Fraud,
        DrugSales,
        Extortion,
        AntiGovernment
    }

    enum Name
    {
        Alesha,
        Anton,
        Gacha,
        Pacha,
        Denis,
        Vasily,
        Tremor,
        Petya,
        Patrik
    }

    enum Surname
    {
        Frakiev,
        Labuda,
        Vasyliev,
        Lomanovsky,
        Trubadur,
        Chacha,
        Togorotov,
        Menyalkin,
        Lomovoy,
        Hristenko,
        Tvar
    }

    enum Patronymic
    {
        Grigorievich,
        Vasylevich,
        Tradovich,
        Lermantovich,
        Gribovish,
        Kurovich,
        Zaborovich
    }
}
