using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание6_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();

            bool isFigthOver = false;

            arena.ChoosePlayers();

            while (isFigthOver == false)
            {
                arena.MakePlayersTurns();
                arena.ShowPlayersStats();
                isFigthOver = arena.TestPlayersDeath();
            }
        }
    }

    class Arena
    {
        private Character _player1 = new Character();
        private Character _player2 = new Character();

        private bool _isPlayerTurnRuns;

        private Character ChoosePlayer()
        {
            List<Character> players = new List<Character>();

            Character player = null;

            players.Add(new Nobody());
            players.Add(new LuckyStrike());
            players.Add(new BlindVampireSurvivor());
            players.Add(new LoopHeroStanding());
            players.Add(new DungeonestDarkness());

            int userInput;

            bool isPLayerPicked = false;

            while (isPLayerPicked == false)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {players[i].Name}");
                }

                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput > 0 && userInput <= players.Count)
                {
                    for (int i = 0; i < players.Count; i++)
                    {
                        if (userInput == i + 1)
                        {
                            player = players[i];
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Неверное значение. опробуйте еще раз");
                }

                if (player != null)
                {
                    isPLayerPicked = true;
                }
            }

            return player;
        }

        public void ChoosePlayers()
        {
            Console.WriteLine("Выберите первого бойца");
            _player1 = ChoosePlayer();

            Console.WriteLine("Выберите второго бойца");
            _player2 = ChoosePlayer();
        }

        public void MakePlayersTurns()
        {
            MakePlayerTurn(_player1, _player2);
            MakePlayerTurn(_player2, _player1);
        }

        private void MakePlayerTurn(Character player1, Character player2)
        {
            _isPlayerTurnRuns = true;

            while (_isPlayerTurnRuns)
            {
                _isPlayerTurnRuns = false;
                _isPlayerTurnRuns = player1.Attack(player2);
            }
        }

        public void ShowPlayersStats()
        {
            char separatorMark = '-';
            string border = string.Join("", Enumerable.Repeat(separatorMark, 15));

            Console.WriteLine(border);
            _player1.ShowStats();
            Console.WriteLine(border);
            _player2.ShowStats();
            Console.WriteLine(border);

            Console.WriteLine("Для следующего хода нажмите любую клавишу");
            Console.ReadKey();
            Console.WriteLine(border);
        }

        public bool TestPlayersDeath()
        {
            bool isFightOver = false;

            if (_player1.Health > 0 && _player2.Health <= 0)
            {
                Console.WriteLine($"Победил {_player1.Name}");
                isFightOver = true;
            }
            else if (_player2.Health > 0 && _player1.Health <= 0)
            {
                Console.WriteLine($"Победил {_player2.Name}");
                isFightOver = true;
            }
            else if (_player1.Health <= 0 && _player2.Health <= 0)
            {
                Console.WriteLine($"Игроки убили друг друга");
                isFightOver = true;
            }

            return isFightOver;
        }
    }

    class Character
    {
        protected int Armor;
        protected int Strength;
        protected int Accuracy;
        protected int Agility;
        protected int Concentration;
        protected int Luck;

        private Random _random = new Random();

        public string Name { get; protected set; }

        public int Health { get; protected set; } = 100;

        protected int GetDamage()
        {
            int criticalDamageIndex = 2;
            int bonusDamageIndex = 2;
            int damage;

            if (GetRandomChance() <= Accuracy)
            {
                if (GetRandomChance() <= Concentration)
                {
                    damage = Strength * criticalDamageIndex;
                    Console.WriteLine($"{Name} наносит двойной урон");
                }
                else
                {
                    damage = Strength;
                }

                if (GetRandomChance() <= Luck)
                {
                    damage += Strength / bonusDamageIndex;
                    Console.WriteLine($"{Name} сопутствует удача и его удар стал в половину сильнее");
                }
            }
            else
            {
                Console.WriteLine($"{Name} промахивается и ненаносит урона");
                damage = 0;
            }

            return damage;
        }

        public virtual bool Attack(Character enemy)
        {
            bool isTurnRuns = false;
            int damage = GetDamage();
            enemy.TakeDamage(damage);
            return isTurnRuns;
        }

        public void TakeDamage(int damage)
        {
            int percentIndex = 100;

            if (GetRandomChance() <= Agility)
            {
                damage = 0;
                Console.WriteLine($"{Name} увернулся");
            }
            else
            {
                damage -= damage * Armor / percentIndex;
            }

            if (GetRandomChance() <= Luck)
            {
                damage -= damage * Agility / percentIndex;
                Console.WriteLine($"{Name} сопутствует удача и он получает меньше урона");
            }

            Console.WriteLine($"{Name} получает {damage} урона");

            Health -= damage;
        }

        protected int GetRandomChance()
        {
            int minBonusChance = 1;
            int maxBonusChance = 100;

            int bonusChance = _random.Next(minBonusChance, maxBonusChance + 1);

            return bonusChance;
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name}");
            Console.WriteLine($"Здоровье {Health}");
            Console.WriteLine($"Броня {Armor}");
            Console.WriteLine($"Сила {Strength}");
            Console.WriteLine($"Ловкость {Agility}");
            Console.WriteLine($"Концентрация {Concentration}");
            Console.WriteLine($"Удача {Luck}");
        }
    }

    class Nobody : Character
    {
        public Nobody()
        {
            Name = "Nobody";
            Armor = 10;
            Strength = 10;
            Accuracy = 90;
            Agility = 10;
            Concentration = 10;
            Luck = 10;
        }
    }

    class LuckyStrike : Character
    {
        public LuckyStrike()
        {
            Name = "LuckyStrike";
            Armor = 0;
            Strength = 3;
            Accuracy = 90;
            Agility = 10;
            Concentration = 10;
            Luck = 60;
        }

        public override bool Attack(Character enemy)
        {
            int strengthIndex = 3;

            bool isTurnRuns = false;

            int damage = GetDamage();
            enemy.TakeDamage(damage);

            if (GetRandomChance() <= Luck)
            {
                Console.WriteLine($"Счастливчик {Name} увеличивает свою силу на {strengthIndex}");
                Strength += strengthIndex;
            }
            else
            {
                Console.WriteLine($"{Name} ничего не делает в этот раз");
            }

            return isTurnRuns;
        }
    }

    class BlindVampireSurvivor : Character
    {
        public BlindVampireSurvivor()
        {
            Name = "BlindVampireSurvivor";
            Armor = 10;
            Strength = 10;
            Accuracy = 50;
            Agility = 10;
            Concentration = 10;
            Luck = 10;
        }

        public override bool Attack(Character enemy)
        {
            int vampireIndex = 3;
            int fullHealthAmount = 100;

            bool isTurnRuns = false;

            int damage = GetDamage();
            enemy.TakeDamage(damage);

            Console.WriteLine($"{Name} восстанавливает {damage * vampireIndex} здоровья");

            if (Health < fullHealthAmount)
            {
                Health += damage * vampireIndex;

                if (Health > fullHealthAmount)
                {
                    Health = fullHealthAmount;
                }
            }

            return isTurnRuns;
        }
    }

    class LoopHeroStanding : Character
    {
        public LoopHeroStanding()
        {
            Name = "LoopHeroStanding";
            Armor = 60;
            Strength = 5;
            Accuracy = 90;
            Agility = 10;
            Concentration = 10;
            Luck = 30;
        }

        public override bool Attack(Character enemy)
        {
            bool isTurnRuns = false;

            int damage = GetDamage();
            enemy.TakeDamage(damage);

            if (GetRandomChance() <= Luck)
            {
                Console.WriteLine($"По счастливой случайности {Name} атакует еще раз");
                isTurnRuns = true;
            }
            else
            {
                Console.WriteLine($"{Name} ничего не делает в этот раз");
            }

            return isTurnRuns;
        }
    }

    class DungeonestDarkness : Character
    {
        public DungeonestDarkness()
        {
            Name = "DungeonestDarkness";
            Armor = 10;
            Strength = 20;
            Accuracy = 90;
            Agility = 0;
            Concentration = 0;
            Luck = 10;
        }

        public override bool Attack(Character enemy)
        {
            int deathNumber = 10;
            int fullHealth = 100;

            bool isTurnRuns = false;

            int damage = GetDamage();
            enemy.TakeDamage(damage);

            if (Health <= 0)
            {
                Health = fullHealth;
                Console.WriteLine($"{Name} возродился");
            }
            if(Health % deathNumber == 0 && Health != fullHealth)
            {
                Health = 0;
                Console.WriteLine($"{Name} был повержен в уязвимое место");
            }

            return isTurnRuns;
        }
    }
}
