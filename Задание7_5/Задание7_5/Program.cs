using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание7_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();

            storage.Work();
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GeneradeRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue + 1);
        }

        public static int GeneradeRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }

    class Storage
    {
        private List<Stew> _stews = new List<Stew>();

        public Storage()
        {
            GeneradeStews();
        }

        public void Work()
        {
            int presentYear = 2024;

            ShowStews();

            _stews = _stews.Where(stew => presentYear - stew.ProductionYear <= stew.ExpirationDate).ToList();

            Console.WriteLine();
            Console.WriteLine();

            ShowStews();
        }

        private void GeneradeStews()
        {
            int stewsCount = 100;

            for (int i = 0; i < stewsCount; i++)
            {
                _stews.Add(new Stew());
            }
        }

        private void ShowStews()
        {
            foreach (var stew in _stews)
            {
                stew.ShowStats();
            }
        }
    }

    class Stew
    {
        private string _name;

        public Stew()
        {
            string[] names = { "Говядина", "Свинина", "Конина", "Крольчатина", "Козлятина", "Гусятина", "Баранина"};

            _name = names[UserUtils.GeneradeRandomNumber(names.Length)];
            GeneradeProductionYear();
            GeneradeExpirationDate();
        }

        public int ProductionYear { get; private set; }

        public int ExpirationDate { get; private set; }

        public void ShowStats()
        {
            Console.WriteLine($"{_name} производства {ProductionYear} года, Срок годности: {ExpirationDate} лет.");
        }

        private void GeneradeProductionYear()
        {
            int minYearValue = 2010;
            int maxYearValue = 2024;

            ProductionYear = UserUtils.GeneradeRandomNumber(minYearValue, maxYearValue);
        }

        private void GeneradeExpirationDate()
        {
            int minYearValue = 4;
            int maxYearValue = 10;

            ExpirationDate = UserUtils.GeneradeRandomNumber(minYearValue, maxYearValue);
        }
    }
}
