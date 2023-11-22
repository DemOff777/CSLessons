using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                arena.MakeFigthTurn();
                arena.ShowPlayersStats();
                isFigthOver = arena.CheckPlayersHealth();
            }
        }
    }

    class Arena
    {
        public Character Player1 = new Character();
        public Character Player2 = new Character();

        public bool Player1Turn { get; private set; }

        public bool Player2Turn { get; private set; }

        public void ChooseCharacters()
        {
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
                        Player1 = PickNobody(ref isPLayerPicked);
                        break;
                    case LuckyStrike:
                        Player1 = PickLuckyStrike(ref isPLayerPicked);
                        break;
                    case BlindVampireSurvivor:
                        Player1 = PickBlindVampireSurvivor(ref isPLayerPicked);
                        break;
                    case LoopHeroStanding:
                        Player1 = PickLoopHeroStanding(ref isPLayerPicked);
                        break;
                    case DungeonestDarkness:
                        Player1 = PickDungeonestDarkness(ref isPLayerPicked);
                        break;
                    default:
                        Console.WriteLine("Неверный формат");
                        break;
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
                        Player2 = PickNobody(ref isPLayerPicked);
                        break;
                    case LuckyStrike:
                        Player2 = PickLuckyStrike(ref isPLayerPicked);
                        break;
                    case BlindVampireSurvivor:
                        Player2 = PickBlindVampireSurvivor(ref isPLayerPicked);
                        break;
                    case LoopHeroStanding:
                        Player2 = PickLoopHeroStanding(ref isPLayerPicked);
                        break;
                    case DungeonestDarkness:
                        Player2 = PickDungeonestDarkness(ref isPLayerPicked);
                        break;
                    default:
                        Console.WriteLine("Неверный формат");
                        break;
                }
            }
        }

        public Nobody PickNobody(ref bool isPLayerPicked)
        {
            Nobody player = new Nobody();

            player.GetStats();

            isPLayerPicked = true;

            return player;
        }

        public LuckyStrike PickLuckyStrike(ref bool isPLayerPicked)
        {
            LuckyStrike player = new LuckyStrike();

            player.GetStats();

            isPLayerPicked = true;

            return player;
        }

        public BlindVampireSurvivor PickBlindVampireSurvivor(ref bool isPLayerPicked)
        {
            BlindVampireSurvivor player = new BlindVampireSurvivor();

            player.GetStats();

            isPLayerPicked = true;

            return player;
        }

        public LoopHeroStanding PickLoopHeroStanding(ref bool isPLayerPicked)
        {
            LoopHeroStanding player = new LoopHeroStanding();

            player.GetStats();

            isPLayerPicked = true;

            return player;
        }

        public DungeonestDarkness PickDungeonestDarkness(ref bool isPLayerPicked)
        {
            DungeonestDarkness player = new DungeonestDarkness();

            player.GetStats();

            isPLayerPicked = true;

            return player;
        }

        public void MakeFigthTurn()
        {
            Player1Turn = true;
            Player2Turn = true;

            while (Player1Turn)
            {
                Player1Turn = false;
                Player1Turn = Player1.UseSkill(Player2.TakeDamage(Player1.GetDamage()));
            }

            while (Player2Turn)
            {
                Player2Turn = false;
                Player2Turn = Player2.UseSkill(Player1.TakeDamage(Player2.GetDamage()));
            }
        }

        public void ShowPlayersStats()
        {
            Console.WriteLine("---------------");
            Player1.ShowStats();
            Console.WriteLine("---------------");
            Player2.ShowStats();
            Console.WriteLine("---------------");

            Console.WriteLine("Для следующего хода нажмите любую клавишу");
            Console.ReadKey();
            Console.WriteLine("---------------");
        }

        public bool CheckPlayersHealth()
        {
            bool isFightOver = false;

            if (Player1.Health > 0 && Player2.Health <= 0)
            {
                Console.WriteLine($"Победил {Player1.Name}");
                isFightOver = true;
            }

            if (Player2.Health > 0 && Player1.Health <= 0)
            {
                Console.WriteLine($"Победил {Player2.Name}");
                isFightOver = true;
            }

            if (Player1.Health <= 0 && Player2.Health <= 0)
            {
                Console.WriteLine($"Игроки убили друг друга");
                isFightOver = true;
            }

            return isFightOver;
        }
    }

    class Character
    {
        public string Name { get; set; }

        public int Health { get; set; } = 100;
        public int Armor;
        public int Strength;
        public int Accuracy;
        public int Agility;
        public int Concentration;
        public int Luck;

        Random Random = new Random();

        public int GetDamage()
        {
            int damage;

            if (GetRandomChance() <= Accuracy)
            {
                if (GetRandomChance() <= Concentration)
                {
                    damage = Strength * 2;
                    Console.WriteLine($"{Name} наносит двойной урон");
                }
                else
                {
                    damage = Strength;
                }

                if (GetRandomChance() <= Luck)
                {
                    damage += Strength / 2;
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
            if (GetRandomChance() <= Agility)
            {
                damage = 0;
                Console.WriteLine($"{Name} увернулся");
            }
            else
            {
                damage -= damage * Armor / 100 ;
            }

            if (GetRandomChance() <= Luck)
            {
                damage -= damage * Agility / 100;
                Console.WriteLine($"{Name} сопутствует удача и он получает меньше урона");
            }

            Console.WriteLine($"{Name} получает {damage} урона");

            Health -= damage;

            return damage;
        }

        public int GetRandomChance()
        {
            int minBonusChance = 1;
            int maxBonusChance = 100;

            int bonusChance = Random.Next(minBonusChance, maxBonusChance + 1);

            return bonusChance;
        }

        public virtual bool UseSkill(int damage)
        {
            bool makeTurn = false;
            Console.WriteLine($"{Name} ничего не делает");
            return makeTurn;
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
            Luck = 50;
        }

        public override bool UseSkill(int damage)
        {
            int strengthIndex = 3;
            bool makeTurn = false;

            if (GetRandomChance() <= Luck)
            {
                Console.WriteLine($"Счастливчик {Name} увеличивает свою силу на {strengthIndex}");
                Strength += strengthIndex;
            }
            else
            {
                Console.WriteLine($"{Name} ничего не делает в этот раз");
            }

            return makeTurn;
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
            bool makeTurn = false;

            Console.WriteLine($"{Name} восстанавливает {damage * vampireIndex} здоровья");

            if (Health < 100)
            {
                Health += damage * vampireIndex;

                if (Health > 100)
                {
                    Health = 100;
                }
            }

            return makeTurn;
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
            bool makeTurn = false;

            if (GetRandomChance() <= Luck)
            {
                Console.WriteLine($"По счастливой случайности {Name} атакует еще раз");
                makeTurn = true;
            }
            else
            {
                Console.WriteLine($"{Name} ничего не делает в этот раз");
            }

            return makeTurn;
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
            bool makeTurn = false;

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

            return makeTurn;
        }
    }
}
