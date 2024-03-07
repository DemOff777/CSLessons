using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание7_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Barracks barracks = new Barracks();

            barracks.ShowSoldiers();
            Console.WriteLine();
            Console.WriteLine("Отсортированные солдаты");
            Console.WriteLine();
            barracks.ShowSortedSoldiers();
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

    class Barracks
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Barracks()
        {
            GeneradeSoldiers();
        }

        public void ShowSortedSoldiers()
        {
            var soldiersSorted = _soldiers.Select(soldier => new { soldier.Name, soldier.Rank });

            foreach (var soldier in soldiersSorted)
            {
                Console.WriteLine($"{soldier.Name} {soldier.Rank}");
            }
        }

        public void ShowSoldiers()
        {
            foreach (var soldier in _soldiers)
            {
                soldier.ShowStats();
            }
        }

        private void GeneradeSoldiers()
        {
            int soldiesCount = 20;

            for (int i = 0; i < soldiesCount; i++)
            {
                _soldiers.Add(new Soldier());
            }
        }
    }

    class Soldier
    {
        public Soldier()
        {
            string[] names = { "Petya", "Vasya", "Kolya", "Gerasim", "Luka", "Kostya", "Igor", "Ivan" };
            string[] weapons = { "Pistol", "MachineGun", "RocketLauncher", "Riffle", "GrenadeLauncher", "ShotGun" };
            string[] ranks = { "Private", "Sergant", "Foreman", "Lieutenant", "Captain", "General" };

            Name = names[UserUtils.GeneradeRandomNumber(names.Length)];
            Weapon = weapons[UserUtils.GeneradeRandomNumber(weapons.Length)];
            Rank = ranks[UserUtils.GeneradeRandomNumber(ranks.Length)];

            GeneradeServiceTime();
        }

        public string Name { get; private set; }

        public string Weapon { get; private set; }

        public string Rank { get; private set; }

        public int ServiceTime { get; private set; }

        public void ShowStats()
        {
            Console.WriteLine($"{Name} имеет вооружение {Weapon}, в звании {Rank}, Срок службы {ServiceTime} месяцев");
        }

        private void GeneradeServiceTime()
        {
            int minServiceTimeValue = 12;
            int maxServiceTimeValue = 50;

            ServiceTime = UserUtils.GeneradeRandomNumber(minServiceTimeValue, maxServiceTimeValue);
        }
    }
}
