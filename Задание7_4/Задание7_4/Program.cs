using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание7_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleGround battleGround = new BattleGround();

            battleGround.Work();
        }
    }

    class BattleGround
    {
        List<Player> _players = new List<Player>();

        public BattleGround()
        {
            GeneradePlayers();
        }

        public void Work()
        {
            Console.WriteLine("Игроки:");
            ShowPlayers(_players);
            List<Player> playersSortedByLevel = SortPlayersByLevel();
            List<Player> playersSortedByStrenght = SortPlayersByStrenght();

            Console.WriteLine();
            Console.WriteLine("Игроки отсортированы по уровню:");
            ShowPlayers(playersSortedByLevel);

            Console.WriteLine();
            Console.WriteLine("Игроки отсортированы по силе:");
            ShowPlayers(playersSortedByStrenght);
        }

        private List<Player> SortPlayersByLevel()
        {
            return _players.OrderBy(player => player.Level).ToList();
        }

        private List<Player> SortPlayersByStrenght()
        {
            return _players.OrderBy(player => player.Strenght).ToList();
        }

        private void GeneradePlayers()
        {
            int minPlayersCount = 10;

            for (int i = 0; i < minPlayersCount; i++)
            {
                _players.Add(new Player());
            }
        }

        private void ShowPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                player.ShowStats();
            }
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

    class Player
    {
        public string Name { get; private set; }

        public int Level { get; private set; }

        public int Strenght { get; private set; }

        public Player()
        {
            string[] names = { "Nagibator", "Pobegdator", "Terminator", "Fedya", "UgeBilo", "BigTick", "LamerOnline", "Shimorisan", "Dracula", "Pistolet" };

            Name = names[UserUtils.GeneradeRandomNumber(names.Length)];
            Level = GeneradeRandomLevel();
            Strenght = GeneradeRandomStrenght();
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name}, уровень {Level}, сила {Strenght}");
        }

        private int GeneradeRandomLevel()
        {
            int minLevelValue = 1;
            int maxLevelValue = 100;

            return UserUtils.GeneradeRandomNumber(minLevelValue, maxLevelValue);
        }

        private int GeneradeRandomStrenght()
        {
            int minStrenghtValue = 10;
            int maxStrenghtValue = 50;

            return UserUtils.GeneradeRandomNumber(minStrenghtValue, maxStrenghtValue);
        }
    }
}
