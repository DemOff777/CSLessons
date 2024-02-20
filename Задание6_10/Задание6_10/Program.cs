using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание6_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleGround battleGround = new BattleGround();

            battleGround.PrepareForFigth();
            battleGround.Battle();
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GetRandomNumber(int minVolue, int maxVolue)
        {
            return s_random.Next(minVolue, maxVolue);
        }
    }

    class BattleGround
    {
        private Squad _firstCountrySquad = new Squad();
        private Squad _secondCountrySquad = new Squad();
        private Squad _turnQueue = new Squad();

        private int firstCountryIndex = 1;
        private int secondCountryIndex = 2;

        public void PrepareForFigth()
        {
            GetSoldiers();
            _turnQueue.FillTurnQueue(_firstCountrySquad, _secondCountrySquad);
            _turnQueue.SortQueueBySpeed();
            _firstCountrySquad.ShowStats();
            _secondCountrySquad.ShowStats();

            Console.WriteLine("Чтобы начать битву нажмите любую клавишу");
            Console.ReadKey();
        }

        public void Battle()
        {
            _turnQueue.Fight(_firstCountrySquad, _secondCountrySquad);
        }

        private void GetSoldiers()
        {
            int firstSquadIndex = 1;
            int secondSquadIndex = 2;

            _firstCountrySquad.GetName(firstCountryIndex);
            _firstCountrySquad.FillSquad();
            _firstCountrySquad.GetSquadMark(firstSquadIndex);
            _secondCountrySquad.GetName(secondCountryIndex);
            _secondCountrySquad.FillSquad();
            _secondCountrySquad.GetSquadMark(secondSquadIndex);
        }
    }

    class Squad
    {
        private List<Soldier> Soldiers = new List<Soldier>();

        public string Name { get; private set; }

        public void Fight(Squad firstCountrySquad, Squad secondCountrySquad)
        {
            int soldiersMinCount = 0;

            while (firstCountrySquad.Soldiers.Count != soldiersMinCount && secondCountrySquad.Soldiers.Count != soldiersMinCount)
            {
                int activeTurnIndex = 0;
                int firstSquadIndex = 1;

                bool isSoldiersMakeTurnFalse = false;
                bool isSoldiersMakeTurnTrue = false;

                ShowTurnQueueStats();

                if (Soldiers[activeTurnIndex].SquadNumber == firstSquadIndex)
                {
                    MakeTurn(firstCountrySquad, secondCountrySquad);
                }
                else
                {
                    MakeTurn(secondCountrySquad, firstCountrySquad);
                }

                RemoveDeadSoldiers();

                isSoldiersMakeTurnFalse = CheckAllSoldirsMakeTurn(false);
                isSoldiersMakeTurnTrue = CheckAllSoldirsMakeTurn(true);

                if (isSoldiersMakeTurnFalse == true || isSoldiersMakeTurnTrue == true)
                {
                    SortQueueBySpeed();
                }

                Console.WriteLine();
                firstCountrySquad.ShowStats();
                secondCountrySquad.ShowStats();
                Console.WriteLine("Для того чтобы выполнить следующий ход нажмите любую клавишу");
                Console.ReadKey();
            }

            Console.WriteLine("Бой закончилася");

            if (firstCountrySquad.Soldiers.Count > soldiersMinCount)
            {
                Console.WriteLine($"Победу одержал {firstCountrySquad.Name}");
            }
            else if (secondCountrySquad.Soldiers.Count > soldiersMinCount)
            {
                Console.WriteLine($"Победу одержал {secondCountrySquad.Name}");
            }
            else
            {
                Console.WriteLine("Оба взвода погибли - трагическая ничья");
            }
        }

        private void MakeTurn(Squad activeSquad, Squad passiveSquad)
        {
            int grenadeIndex = 1;
            int radioSetIndex = 2;
            int medKitIndex = 3;
            int soldierSkillIndex = 1;
            int stormTrooperSkillIndex = 2;
            int medicSkillIndex = 3;
            int droneOperatorSkillIndex = 4;
            int sniperSkillIndex = 5;
            int machineGunnerSkillIndex = 6;
            int grenadeDamage = 70;
            int radioSetSpeedBonus = 5;
            int medKitBonus = 50;
            int fullHealth = 100;
            int soldierSkillBonus = 5;
            int turnIndex = 0;
            int damage;
            int bonusIndex;
            int skillIndex;

            bool isDoubleTurnOnceUsed = false;

            damage = Soldiers[turnIndex].GetDamage();
            passiveSquad.TakeDamage(damage);
            bonusIndex = Soldiers[turnIndex].UseBonus();

            if (bonusIndex == grenadeIndex)
            {
                passiveSquad.TakeAreaDamage(grenadeDamage);
            }

            if (bonusIndex == radioSetIndex)
            {
                activeSquad.Soldiers[UserUtils.GetRandomNumber(0, activeSquad.Soldiers.Count)].TakeSpeedBonus(radioSetSpeedBonus);
            }

            if (bonusIndex == medKitIndex)
            {
                int lastSoldierIndex = 1;
                int fullHealthSoldiers = 0;

                bool isBonusUsed = false;

                while (isBonusUsed == false)
                {
                    for (int k = 0; k < activeSquad.Soldiers.Count; k++)
                    {
                        if (activeSquad.Soldiers[k].Health == fullHealth)
                        {
                            fullHealthSoldiers++;
                        }
                    }

                    if (fullHealthSoldiers == activeSquad.Soldiers.Count - 1 && Soldiers[turnIndex].Health < fullHealth)
                    {
                        isBonusUsed = true;
                    }
                    else if (fullHealthSoldiers == activeSquad.Soldiers.Count)
                    {
                        isBonusUsed = true;
                    }

                    if (activeSquad.Soldiers.Count == lastSoldierIndex)
                    {
                        isBonusUsed = true;
                    }

                    int temporarySoldierIndex = UserUtils.GetRandomNumber(0, activeSquad.Soldiers.Count);

                    if (activeSquad.Soldiers[temporarySoldierIndex].Health < fullHealth && activeSquad.Soldiers[temporarySoldierIndex] != Soldiers[turnIndex])
                    {
                        activeSquad.Soldiers[temporarySoldierIndex].TakeHealth(medKitBonus);
                        isBonusUsed = true;
                    }
                }
            }

            skillIndex = Soldiers[turnIndex].UseSkill();

            if (skillIndex == soldierSkillIndex)
            {
                for (int l = 0; l < activeSquad.Soldiers.Count; l++)
                {
                    if (activeSquad.Soldiers[l] != Soldiers[turnIndex])
                    {
                        activeSquad.Soldiers[l].TakeDamageBonus(soldierSkillBonus);
                    }
                }
            }

            if (skillIndex == stormTrooperSkillIndex)
            {
                passiveSquad.TakeAreaDamage(grenadeDamage);
            }

            if (skillIndex == medicSkillIndex)
            {
                int lastSoldierIndex = 1;
                int fullHealthSoldiers = 0;
                bool isMedicSkillUsed = false;

                while (isMedicSkillUsed == false)
                {
                    for (int k = 0; k < activeSquad.Soldiers.Count; k++)
                    {
                        if (activeSquad.Soldiers[k].Health == fullHealth)
                        {
                            fullHealthSoldiers++;
                        }
                    }

                    if (fullHealthSoldiers == activeSquad.Soldiers.Count - 1 && Soldiers[turnIndex].Health < fullHealth)
                    {
                        isMedicSkillUsed = true;
                    }
                    else if (fullHealthSoldiers == activeSquad.Soldiers.Count)
                    {
                        isMedicSkillUsed = true;
                    }

                    if (activeSquad.Soldiers.Count == lastSoldierIndex)
                    {
                        isMedicSkillUsed = true;
                    }

                    int temporarySoldierIndex = UserUtils.GetRandomNumber(0, activeSquad.Soldiers.Count);

                    if (activeSquad.Soldiers[temporarySoldierIndex].Health < fullHealth && activeSquad.Soldiers[temporarySoldierIndex] != Soldiers[turnIndex])
                    {
                        activeSquad.Soldiers[temporarySoldierIndex].TakeHealth(medKitBonus);
                        isMedicSkillUsed = true;
                    }
                }
            }

            if (skillIndex == droneOperatorSkillIndex)
            {
                int bonusMaxSoldiersCount = 2;
                int bonusMinSoldiersCount = 1;
                bool isDroneOperatorSkillUsed = false;

                while (isDroneOperatorSkillUsed == false)
                {
                    int firstTemporarySoldierIndex = UserUtils.GetRandomNumber(0, activeSquad.Soldiers.Count);
                    int secondTemporarySoldierIndex = UserUtils.GetRandomNumber(0, activeSquad.Soldiers.Count);

                    if (activeSquad.Soldiers[firstTemporarySoldierIndex] != Soldiers[turnIndex] && activeSquad.Soldiers[secondTemporarySoldierIndex] != Soldiers[turnIndex] && firstTemporarySoldierIndex != secondTemporarySoldierIndex)
                    {
                        activeSquad.Soldiers[firstTemporarySoldierIndex].TakeSpeedBonus(radioSetSpeedBonus);
                        activeSquad.Soldiers[secondTemporarySoldierIndex].TakeSpeedBonus(radioSetSpeedBonus);
                        isDroneOperatorSkillUsed = true;
                    }

                    if (activeSquad.Soldiers.Count <= bonusMaxSoldiersCount && activeSquad.Soldiers[firstTemporarySoldierIndex] != Soldiers[turnIndex])
                    {
                        activeSquad.Soldiers[firstTemporarySoldierIndex].TakeSpeedBonus(radioSetSpeedBonus);
                        isDroneOperatorSkillUsed = true;
                    }

                    if (activeSquad.Soldiers.Count == bonusMinSoldiersCount)
                    {
                        isDroneOperatorSkillUsed = true;
                    }
                }
            }

            if (skillIndex == sniperSkillIndex)
            {
                Soldiers[turnIndex].Cover();
            }

            if (Soldiers[turnIndex].IsDoubleTurnActive == false)
            {
                Soldiers[turnIndex].SwitchTurnTumbler();
                Soldiers.Add(Soldiers[turnIndex]);
                Soldiers.RemoveAt(turnIndex);
            }
            else if (skillIndex == machineGunnerSkillIndex)
            {
                isDoubleTurnOnceUsed = true;
                Console.WriteLine($"патронная лента не закончилась и Пулемётчик делает еще один ход");
                Soldiers[turnIndex].SetDoubleTurnFalse();
            }

            if (skillIndex == machineGunnerSkillIndex && isDoubleTurnOnceUsed == false)
            {
                Soldiers[Soldiers.Count - 1].SetDoubleTurnTrue();
            }
        }

        public void GetName(int number)
        {
            Name = $"Взвод {number}";
        }

        public void FillSquad()
        {
            Soldier soldier = null;

            const int CreateSoldier = 1;
            const int CreateStormTrooper = 2;
            const int CreateMedic = 3;
            const int CreateDroneOperator = 4;
            const int CreateSniper = 5;
            const int CreateMachineGunner = 6;

            int soldiersInSquad = 6;
            int randomSoldierIndex;
            int minRandomNumber = 1;
            int maxRandomNumber = 6;

            for (int i = 0; i < soldiersInSquad; i++)
            {
                randomSoldierIndex = UserUtils.GetRandomNumber(minRandomNumber, maxRandomNumber + 1);

                switch (randomSoldierIndex)
                {
                    case CreateSoldier:
                        soldier = new Soldier();
                        break;

                    case CreateStormTrooper:
                        soldier = new StormTrooper();
                        break;

                    case CreateMedic:
                        soldier = new Medic();
                        break;

                    case CreateDroneOperator:
                        soldier = new DroneOperator();
                        break;

                    case CreateSniper:
                        soldier = new Sniper();
                        break;

                    case CreateMachineGunner:
                        soldier = new MachineGunner();
                        break;
                }

                randomSoldierIndex = UserUtils.GetRandomNumber(minRandomNumber, maxRandomNumber + 1);

                soldier.GetBonus(randomSoldierIndex);
                Soldiers.Add(soldier);
            }
        }

        public void FillTurnQueue(Squad firstSquad, Squad secondSquad)
        {
            for (int i = 0; i < firstSquad.Soldiers.Count; i++)
            {
                Soldiers.Add(firstSquad.Soldiers[i]);
            }

            for (int i = 0; i < secondSquad.Soldiers.Count; i++)
            {
                Soldiers.Add(secondSquad.Soldiers[i]);
            }
        }

        public void SortQueueBySpeed()
        {
            Soldier temporarySoldier = null;

            bool isSortingEnd = false;

            while (isSortingEnd == false)
            {
                isSortingEnd = true;

                for (int i = 0; i < Soldiers.Count - 1; i++)
                {
                    if (Soldiers[i].SquadNumber != Soldiers[i + 1].SquadNumber && Soldiers[i].Speed == Soldiers[i + 1].Speed)
                    {
                        int chanceIndex = GetFiftyPercentChanceSquadIndex();

                        if (chanceIndex == Soldiers[i].SquadNumber)
                        {
                            temporarySoldier = Soldiers[i + 1];
                            Soldiers[i + 1] = Soldiers[i];
                            Soldiers[i] = temporarySoldier;
                        }

                        if (chanceIndex == Soldiers[i + 1].SquadNumber)
                        {
                            temporarySoldier = Soldiers[i];
                            Soldiers[i] = Soldiers[i + 1];
                            Soldiers[i + 1] = temporarySoldier;
                        }
                    }

                    if (Soldiers[i].Speed < Soldiers[i + 1].Speed)
                    {
                        temporarySoldier = Soldiers[i + 1];
                        Soldiers[i + 1] = Soldiers[i];
                        Soldiers[i] = temporarySoldier;
                        isSortingEnd = false;
                    }

                    if (Soldiers[Soldiers.Count - 1].Speed > Soldiers[Soldiers.Count - 2].Speed)
                    {
                        temporarySoldier = Soldiers[Soldiers.Count - 2];
                        Soldiers[Soldiers.Count - 2] = Soldiers[Soldiers.Count - 1];
                        Soldiers[Soldiers.Count - 1] = temporarySoldier;
                        isSortingEnd = false;
                    }
                }
            }
        }

        public void GetSquadMark(int markIndex)
        {
            for (int i = 0; i < Soldiers.Count; i++)
            {
                Soldiers[i].GetSquadMark(markIndex);
            }
        }

        public void ShowStats()
        {
            char separateMark = '-';

            Console.WriteLine(Name);
            Console.WriteLine(string.Join("", Enumerable.Repeat(separateMark, 15)));

            for (int i = 0; i < Soldiers.Count; i++)
            {
                Soldiers[i].ShowStats();
            }

            Console.WriteLine();
        }

        private void RemoveDeadSoldiers()
        {
            Soldiers.RemoveAll(Soldier => Soldier.IsDead == true);
        }

        private bool CheckAllSoldirsMakeTurn(bool activeValue)
        {
            bool isAllSoldiersMakeTurn = false;
            int soldiersMakeTurnCount = 0;

            for (int i = 0; i < Soldiers.Count; i++)
            {
                if (Soldiers[i].IsTurnOver == activeValue)
                {
                    soldiersMakeTurnCount++;
                }
            }

            if (soldiersMakeTurnCount == Soldiers.Count)
            {
                isAllSoldiersMakeTurn = true;
            }

            return isAllSoldiersMakeTurn;
        }

        private void TakeDamage(int damage)
        {
            bool isDamageTaked = false;
            bool isSoldierDead = false;

            if (Soldiers.Count > 0)
            {
                while (isDamageTaked == false)
                {
                    int randomSoldierIndex = UserUtils.GetRandomNumber(0, Soldiers.Count);

                    isDamageTaked = Soldiers[randomSoldierIndex].TryTakeDamage(damage);
                    isSoldierDead = Soldiers[randomSoldierIndex].TestDeath();

                    if (isSoldierDead == true)
                    {
                        Soldiers[randomSoldierIndex].SetDeath();
                        Console.WriteLine($"{Soldiers[randomSoldierIndex].Name} погиб");
                        Soldiers.RemoveAt(randomSoldierIndex);
                    }
                }
            }
        }

        private void TakeAreaDamage(int areaDamage)
        {
            int minPartsCount = 1;
            int damageParts = UserUtils.GetRandomNumber(minPartsCount, Soldiers.Count + 1);
            int damage = areaDamage / damageParts;

            for (int i = 0; i < damageParts; i++)
            {
                TakeDamage(damage);
            }
        }

        private int GetFiftyPercentChanceSquadIndex()
        {
            int chanceBorder = 49;
            int chanceMax = 100;
            int firstSquadIndex = 1;
            int secondSquadIndex = 2;

            int chanceNumber = UserUtils.GetRandomNumber(0, chanceMax);

            if (chanceNumber <= chanceBorder)
            {
                return firstSquadIndex;
            }
            else
            {
                return secondSquadIndex;
            }
        }

        private void ShowTurnQueueStats()
        {
            ShowStats();
        }
    }

    class Soldier
    {
        protected int _armor = 10;
        protected int _damage = 10;
        protected string _bonus;

        protected bool _isBonusUsed = false;
        protected bool _isCovered = false;

        public string Name { get; protected set; } = "Солдат";

        public int SquadNumber { get; protected set; }

        public int Health { get; protected set; } = 100;

        public int Speed { get; protected set; } = 10;

        public bool IsDoubleTurnActive { get; protected set; } = false;

        public bool IsDead { get; protected set; } = false;

        public bool IsTurnOver { get; protected set; } = false;

        public void ShowStats()
        {
            Console.WriteLine($"{Name} Здоровье - {Health} Броня - {_armor} Скорость - {Speed} Урон - {_damage} Бонус - {_bonus} [{SquadNumber}]Отряд");
        }

        public void GetBonus(int randomBonusIndex)
        {
            const int Grenade = 1;
            const int RadioSet = 2;
            const int MedKit = 3;
            const int BonusSpeed = 4;
            const int BonusDamage = 5;
            const int BonusArmor = 6;

            string grenade = "grenade";
            string radioSet = "radioSet";
            string medKit = "medKit";
            string bonusSpeed = "bonusSpeed";
            string bonusDamage = "bonusDamage";
            string bonusArmor = "bonusArmor";

            switch (randomBonusIndex)
            {
                case Grenade:
                    _bonus = grenade;
                    break;

                case RadioSet:
                    _bonus = radioSet;
                    break;

                case MedKit:
                    _bonus = medKit;
                    break;

                case BonusSpeed:
                    _bonus = bonusSpeed;
                    break;

                case BonusDamage:
                    _bonus = bonusDamage;
                    break;

                case BonusArmor:
                    _bonus = bonusArmor;
                    break;
            }
        }

        public int GetDamage()
        {
            Console.WriteLine($"{Name} наносит {_damage} урона");
            return _damage;        
        }

        public bool TryTakeDamage(int damage)
        {
            int zeroArmorVolue = 0;
            int finishDamage;
            bool isdamageTaked = false;

            if (_isCovered)
            {
                isdamageTaked = true;
                _isCovered = false;
                Console.WriteLine($"{Name} избегает урона");
            }

            if (Health > 0 && isdamageTaked == false)
            {
                if (_armor != zeroArmorVolue)
                {
                    finishDamage = damage - (damage / (100 / _armor));
                    Health -= finishDamage;
                    isdamageTaked = true;
                    Console.WriteLine($"{Name} получает {finishDamage} урона");
                }
                else
                {
                    Health -= damage;
                    isdamageTaked = true;
                    Console.WriteLine($"{Name} получает {damage} урона");
                }   
            }
            
            return isdamageTaked;
        }

        public bool TestDeath()
        {
            return Health <= 0;
        }

        public void TakeHealth(int healthBonus)
        {
            int fullHealth = 100;
            Health += healthBonus;

            if (Health > fullHealth)
            {
                Health = fullHealth;
            }

            Console.WriteLine($"{Name} восстанавливает {healthBonus} здоровья");
        }

        public void TakeSpeedBonus(int speedBonus)
        {
            Speed += speedBonus;
            Console.WriteLine($"{Name} получает {speedBonus} к скорости");
        }

        public void TakeDamageBonus(int damageBonus)
        {
            _damage += damageBonus;
            Console.WriteLine($"{Name} получает {damageBonus} к урону");
        }

        public int UseBonus()
        {
            int bonusIndex = 0;

            if (_isBonusUsed == false)
            {
                const string Grenade = "grenade";
                const string RadioSet = "radioSet";
                const string MedKit = "medKit";
                const string BonusSpeed = "bonusSpeed";
                const string BonusDamage = "bonusDamage";
                const string BonusArmor = "bonusArmor";

                switch (_bonus)
                {
                    case Grenade:
                        bonusIndex = UseGrenade();
                        break;

                    case RadioSet:
                        bonusIndex = UseRadioSet();
                        break;

                    case MedKit:
                        bonusIndex = UseMedKit();
                        break;

                    case BonusSpeed:
                        UseBonusSpeed();
                        break;

                    case BonusDamage:
                        UseBonusDamage();
                        break;

                    case BonusArmor:
                        UseBonusArmor();
                        break;
                }
            }

            return bonusIndex;
        }

        public int UseGrenade()
        {
            int grenadeIndex = 1;
            _isBonusUsed = true;
            Console.WriteLine($"{Name} использует гранату");
            return grenadeIndex;
        }

        public int UseRadioSet()
        {
            int radioSetIndex = 2;
            _isBonusUsed = true;
            Console.WriteLine($"{Name} использует радиостанцию");
            return radioSetIndex;
        }

        public int UseMedKit()
        {
            int medKitIndex = 3;
            _isBonusUsed = true;
            Console.WriteLine($"{Name} использует аптечку");
            return medKitIndex;
        }

        public void UseBonusSpeed()
        {
            int bonusIndex = 10;
            _isBonusUsed = true;
            Speed += bonusIndex;
            Console.WriteLine($"{Name} получает бонус: {bonusIndex} к скорости");
        }

        public void UseBonusDamage()
        {
            int bonusIndex = 10;
            _isBonusUsed = true;
            _damage += bonusIndex;
            Console.WriteLine($"{Name} получает бонус: {bonusIndex} к урону");
        }

        public void UseBonusArmor()
        {
            int maxBonusVolue = 50;
            int bonusIndex = 10;
            _isBonusUsed = true;
            _armor += bonusIndex;
            Console.WriteLine($"{Name} получает бонус: {bonusIndex} к броне");

            if (_armor >= maxBonusVolue)
            {
                _armor = maxBonusVolue;
                Console.WriteLine($"{Name} достиг максимального значения брони: {maxBonusVolue}");
            }
        }

        public virtual int UseSkill()
        {
            int soldierSkillIndex = 1;
            Console.WriteLine($"{Name} повышает общий боевой дух");
            return soldierSkillIndex;
        }

        public void Cover()
        {
            _isCovered = true;
        }

        public void GetSquadMark(int markIndex)
        {
            SquadNumber = markIndex;
        }

        public void SetDoubleTurnFalse()
        {
            IsDoubleTurnActive = false;
        }

        public void SetDoubleTurnTrue()
        {
            IsDoubleTurnActive = true;
        }

        public void SetDeath()
        {
            IsDead = true;
        }

        public void SwitchTurnTumbler()
        {
            if (IsTurnOver == true)
            {
                IsTurnOver = false;
            }
            else
            {
                IsTurnOver = true;
            }
        }
    }

    class StormTrooper : Soldier
    {
        public StormTrooper()
        {
            Name = "Штурмовик";
            _armor = 30;
            Speed = 20;
            _damage = 20;
        }

        public override int UseSkill()
        {
            int stormTrooperSkillIndex = 2;
            Console.WriteLine($"{Name} использует гранату");
            return stormTrooperSkillIndex;
        }
    }

    class Medic : Soldier
    {
        public Medic()
        {
            Name = "Медик";
            _armor = 10;
            Speed = 10;
            _damage = 10;
        }

        public override int UseSkill()
        {
            int medicSkillIndex = 3;
            Console.WriteLine($"{Name} применяет свои навыки и лечит дружественного бойца");
            return medicSkillIndex;
        }
    }

    class DroneOperator : Soldier
    {
        public DroneOperator()
        {
            Name = "Оператор Дрона";
            _armor = 10;
            Speed = 50;
            _damage = 0;
        }

        public override int UseSkill()
        {
            int droneOperatorSkillIndex = 4;
            Console.WriteLine($"{Name} увеличивает скорость двух дружественных бойцов");
            return droneOperatorSkillIndex;
        }
    }

    class Sniper : Soldier
    {
        public Sniper()
        {
            Name = "Снайпер";
            _armor = 0;
            Speed = 5;
            _damage = 110;
        }

        public override int UseSkill()
        {
            int sniperSkillIndex = 5;
            Console.WriteLine($"{Name} скрывается от следующей атаки");
            return sniperSkillIndex;
        }
    }

    class MachineGunner : Soldier
    {
        public MachineGunner()
        {
            Name = "Пулеметчик";
            _armor = 20;
            Speed = 10;
            _damage = 30;
            IsDoubleTurnActive = true;
        }

        public override int UseSkill()
        {
            int machineGunnerSkillIndex = 6;
            return machineGunnerSkillIndex;
        }
    }
}