using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание7_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Barracks barracks = new Barracks();

            barracks.Work();
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GeneradeRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }

    class Barracks
    {
        private List<Soldier> _soldiers1 = new List<Soldier>();
        private List<Soldier> _soldiers2 = new List<Soldier>();

        public Barracks()
        {
            GeneradeSoldiers(_soldiers1);
            GeneradeSoldiers(_soldiers2);
        }

        public void Work()
        {
            Console.WriteLine("Первый отряд");
            Console.WriteLine();
            ShowSoldiers(_soldiers1);
            Console.WriteLine();
            Console.WriteLine("Второй отряд");
            Console.WriteLine();
            ShowSoldiers(_soldiers2);

            MergeSquads();

            Console.WriteLine();
            Console.WriteLine("Первый отряд");
            Console.WriteLine();
            ShowSoldiers(_soldiers1);
            Console.WriteLine();
            Console.WriteLine("Второй отряд");
            Console.WriteLine();
            ShowSoldiers(_soldiers2);
        }

        private void GeneradeSoldiers(List<Soldier> soldiers)
        {
            int soldiersCount = 20;

            for (int i = 0; i < soldiersCount; i++)
            {
                soldiers.Add(new Soldier());
            }
        }

        private void MergeSquads()
        {
            string sortLetter = "B";
            var sortedSoldiers = _soldiers1.Where(soldier => soldier.Name.StartsWith(sortLetter)).ToList();
            _soldiers1 = _soldiers1.Except(sortedSoldiers).ToList();
            _soldiers2 = _soldiers2.Union(sortedSoldiers).ToList();
        }

        private void ShowSoldiers(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"{soldier.Name}");
            }
        }
    }

    class Soldier
    {
        public Soldier()
        {
            string[] names = { "Boris", "Fedya", "Aleks", "Beslan", "Bogumil", "Arseniy", "Valenok", "Lamer" };

            Name = names[UserUtils.GeneradeRandomNumber(names.Length)];
        }

        public string Name { get; private set; }
    }
}

