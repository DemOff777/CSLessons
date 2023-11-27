using System;
using System.Linq;


namespace Задание6_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();

            bool isFigthOver = false;

            arena.ChooseCharacters();

            while (isFigthOver == false)
            {
                arena.MakeTurn(arena.GivePlayer1(), arena.GivePlayer2());
                arena.MakeTurn(arena.GivePlayer2(), arena.GivePlayer1());
                arena.ShowPlayersStats();
                isFigthOver = arena.CheckWinner();
            }
        }
    }

    class Arena
    {
        Character _player1 = new Character();
        Character _player2 = new Character();
        Character _playerCheck = new Character();

        bool IsPlayerTurnRuns;

        public Character GivePlayer1()
        {
            return _player1;
        }

        public Character GivePlayer2()
        {
            return _player2;
        }

        public void SetPlayersCheckExample()
        {
            _player1 = _playerCheck;
            _player2 = _playerCheck;
        }
        public void ChooseCharacters()
        {
            SetPlayersCheckExample();

            const string Nobody = "1";
            const string LuckyStrike = "2";
            const string BlindVampireSurvivor = "3";
            const string LoopHeroStanding = "4";
            const string DungeonestDarkness = "5";

            string userInput;

            bool isPLayerPicked = false;

            while (isPLayerPicked == false)
            {
                Console.WriteLine("Выберите первого бойца");
                Console.WriteLine($"Nobody - {Nobody}");
                Console.WriteLine($"LuckyStrike - {LuckyStrike}");
                Console.WriteLine($"BlindVampireSurvivor - {BlindVampireSurvivor}");
                Console.WriteLine($"LoopHeroStanding - {LoopHeroStanding}");
                Console.WriteLine($"DungeonestDarkness - {DungeonestDarkness}");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case Nobody:
                        _player1 = PickNobody();
                        break;
                    case LuckyStrike:
                        _player1 = PickLuckyStrike();
                        break;
                    case BlindVampireSurvivor:
                        _player1 = PickBlindVampireSurvivor();
                        break;
                    case LoopHeroStanding:
                        _player1 = PickLoopHeroStanding();
                        break;
                    case DungeonestDarkness:
                        _player1 = PickDungeonestDarkness();
                        break;
                    default:
                        Console.WriteLine("Неверный формат");
                        break;
                }

                if (_player1 != _playerCheck)
                {
                    isPLayerPicked = true;
                }
            }

            isPLayerPicked = false;

            while (isPLayerPicked == false)
            {
                Console.WriteLine("Выберите второго бойца");
                Console.WriteLine($"Nobody - {Nobody}");
                Console.WriteLine($"LuckyStrike - {LuckyStrike}");
                Console.WriteLine($"BlindVampireSurvivor - {BlindVampireSurvivor}");
                Console.WriteLine($"LoopHeroStanding - {LoopHeroStanding}");
                Console.WriteLine($"DungeonestDarkness - {DungeonestDarkness}");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case Nobody:
                        _player2 = PickNobody();
                        break;
                    case LuckyStrike:
                        _player2 = PickLuckyStrike();
                        break;
                    case BlindVampireSurvivor:
                        _player2 = PickBlindVampireSurvivor();
                        break;
                    case LoopHeroStanding:
                        _player2 = PickLoopHeroStanding();
                        break;
                    case DungeonestDarkness:
                        _player2 = PickDungeonestDarkness();
                        break;
                    default:
                        Console.WriteLine("Неверный формат");
                        break;
                }

                if (_player2 != _playerCheck)
                {
                    isPLayerPicked = true;
                }
            }
        }

        private Nobody PickNobody()
        {
            Nobody player = new Nobody();

            player.GetStats();

            return player;
        }

        private LuckyStrike PickLuckyStrike()
        {
            LuckyStrike player = new LuckyStrike();

            player.GetStats();

            return player;
        }

        private BlindVampireSurvivor PickBlindVampireSurvivor()
        {
            BlindVampireSurvivor player = new BlindVampireSurvivor();

            player.GetStats();

            return player;
        }

        private LoopHeroStanding PickLoopHeroStanding()
        {
            LoopHeroStanding player = new LoopHeroStanding();

            player.GetStats();

            return player;
        }

        private DungeonestDarkness PickDungeonestDarkness()
        {
            DungeonestDarkness player = new DungeonestDarkness();

            player.GetStats();

            return player;
        }

        public void MakeTurn(Character playerActive, Character playerPassive)
        {
            IsPlayerTurnRuns = true;

            while (IsPlayerTurnRuns)
            {
                IsPlayerTurnRuns = false;
                IsPlayerTurnRuns = playerActive.UseSkill(playerPassive.TakeDamage(playerActive.Attack()));
            }
        }

        public void ShowPlayersStats()
        {
            char separatorMark = '-';

            Console.WriteLine(string.Join("", Enumerable.Repeat(separatorMark, 15)));
            _player1.ShowStats();
            Console.WriteLine(string.Join("", Enumerable.Repeat(separatorMark, 15)));
            _player2.ShowStats();
            Console.WriteLine(string.Join("", Enumerable.Repeat(separatorMark, 15)));

            Console.WriteLine("Для следующего хода нажмите любую клавишу");
            Console.ReadKey();
            Console.WriteLine(string.Join("", Enumerable.Repeat(separatorMark, 15)));
        }

        public bool CheckWinner()
        {
            bool isFightOver = false;

            if (_player1.Health > 0 && _player2.Health <= 0)
            {
                Console.WriteLine($"Победил {_player1.Name}");
                isFightOver = true;
            }

            if (_player2.Health > 0 && _player1.Health <= 0)
            {
                Console.WriteLine($"Победил {_player2.Name}");
                isFightOver = true;
            }

            if (_player1.Health <= 0 && _player2.Health <= 0)
            {
                Console.WriteLine($"Игроки убили друг друга");
                isFightOver = true;
            }

            return isFightOver;
        }
    }

    class Character
    {
        public string Name { get; protected set; }

        public  int Health { get; protected set; } = 100;

        protected int Armor;
        protected int Strength;
        protected int Accuracy;
        protected int Agility;
        protected int Concentration;
        protected int Luck;

        Random Random = new Random();

        public int Attack()
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

        public int TakeDamage(int damage)
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

            return damage;
        }

        protected int GetRandomChance()
        {
            int minBonusChance = 1;
            int maxBonusChance = 100;

            int bonusChance = Random.Next(minBonusChance, maxBonusChance + 1);

            return bonusChance;
        }

        public virtual bool UseSkill(int damage)
        {
            bool isTurnRuns = false;
            return isTurnRuns;
        }

        public virtual void ShowSkill()
        {
            Console.WriteLine($"{Name} ничего не делает");
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
        public void GetStats()
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
        public void GetStats()
        {
            Name = "LuckyStrike";
            Armor = 0;
            Strength = 3;
            Accuracy = 90;
            Agility = 10;
            Concentration = 10;
            Luck = 60;
        }

        public override bool UseSkill(int damage)
        {
            int strengthIndex = 3;
            bool isTurnRuns = false;

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
        public void GetStats()
        {
            Name = "BlindVampireSurvivor";
            Armor = 10;
            Strength = 10;
            Accuracy = 50;
            Agility = 10;
            Concentration = 10;
            Luck = 10;
        }

        public override bool UseSkill(int damage)
        {
            int vampireIndex = 3;
            bool isTurnRuns = false;

            Console.WriteLine($"{Name} восстанавливает {damage * vampireIndex} здоровья");

            if (Health < 100)
            {
                Health += damage * vampireIndex;

                if (Health > 100)
                {
                    Health = 100;
                }
            }

            return isTurnRuns;
        }
    }

    class LoopHeroStanding : Character
    {
        public void GetStats()
        {
            Name = "LoopHeroStanding";
            Armor = 60;
            Strength = 5;
            Accuracy = 90;
            Agility = 10;
            Concentration = 10;
            Luck = 30;
        }

        public override bool UseSkill(int damage)
        {
            bool isTurnRuns = false;

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
        public void GetStats()
        {
            Name = "DungeonestDarkness";
            Armor = 10;
            Strength = 20;
            Accuracy = 90;
            Agility = 0;
            Concentration = 0;
            Luck = 10;
        }

        public override bool UseSkill(int damage)
        {
            bool isTurnRuns = false;

            if(Health <= 0)
            {
                Health = 100;
                Console.WriteLine($"{Name} возродился");
            }
            if(Health % 10 == 0 && Health != 100)
            {
                Health = 0;
                Console.WriteLine($"{Name} был повержен в уязвимое место");
            }

            return isTurnRuns;
        }
    }
}
