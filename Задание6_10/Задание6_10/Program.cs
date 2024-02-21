using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static int GetRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }

    }

    class BattleGround
    {
        private Squad _firstCountrySquad = new Squad();
        private Squad _secondCountrySquad = new Squad();
        private Squad _turnQueue = new Squad();

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
            int soldiersMinCount = 0;

            while (_firstCountrySquad.GetCount() != soldiersMinCount && _secondCountrySquad.GetCount() != soldiersMinCount)
            {
                int firstSquadIndex = 1;

                bool isSoldiersMakeTurnFalse = false;
                bool isSoldiersMakeTurnTrue = false;

                _turnQueue.ShowTurnQueueStats();

                if (_turnQueue.GetFirstSoldier().SquadNumber == firstSquadIndex)
                {
                    _turnQueue.MakeTurn(_firstCountrySquad, _secondCountrySquad);
                }
                else
                {
                    _turnQueue.MakeTurn(_secondCountrySquad, _firstCountrySquad);
                }

                _turnQueue.RemoveDeadSoldiers();

                isSoldiersMakeTurnFalse = _turnQueue.HaveAllSoldirsMadeTurn(false);
                isSoldiersMakeTurnTrue = _turnQueue.HaveAllSoldirsMadeTurn(true);

                if (isSoldiersMakeTurnFalse == true || isSoldiersMakeTurnTrue == true)
                {
                    _turnQueue.SortQueueBySpeed();
                }

                Console.WriteLine();
                _firstCountrySquad.ShowStats();
                _secondCountrySquad.ShowStats();
                Console.WriteLine("Для того чтобы выполнить следующий ход нажмите любую клавишу");
                Console.ReadKey();
            }

            Console.WriteLine("Бой закончилася");

            if (_firstCountrySquad.GetCount() > soldiersMinCount)
            {
                Console.WriteLine($"Победу одержал {_firstCountrySquad.Name}");
            }
            else
            {
                Console.WriteLine($"Победу одержал {_secondCountrySquad.Name}");
            }
        }

        private void GetSoldiers()
        {
            int firstSquadIndex = 1;
            int secondSquadIndex = 2;

            _firstCountrySquad.GetName(firstSquadIndex);
            _firstCountrySquad.FillSquad();
            _firstCountrySquad.GetSquadMark(firstSquadIndex);
            _secondCountrySquad.GetName(secondSquadIndex);
            _secondCountrySquad.FillSquad();
            _secondCountrySquad.GetSquadMark(secondSquadIndex);
        }
    }

    class Squad
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public string Name { get; private set; }

        public void GetName(int number)
        {
            Name = $"Взвод {number}";
        }

        public void ShowTurnQueueStats()
        {
            ShowStats();
        }

        public int GetCount()
        {
            return _soldiers.Count;
        }

        public Soldier GetFirstSoldier()
        {
            int firstSoldierIndex = 0;
            return _soldiers[firstSoldierIndex];
        }

        public void FillSquad()
        {
            int soldiersInSquad = 6;
            int minRandomNumber = 1;
            int maxRandomNumber = 6;

            List<Soldier> soldiers = new List<Soldier>()
            {
                new Soldier(), 
                new StormTrooper(),
                new Medic(),
                new DroneOperator(),
                new Sniper(),
                new MachineGunner()
            };

            for (int i = 0; i < soldiersInSquad; i++)
            {
                int randomSoldierIndex = UserUtils.GetRandomNumber(_soldiers.Count);
                _soldiers.Add(soldiers[randomSoldierIndex].Clone());
            }
        }

        public void FillTurnQueue(Squad firstSquad, Squad secondSquad)
        {
            for (int i = 0; i < firstSquad._soldiers.Count; i++)
            {
                _soldiers.Add(firstSquad._soldiers[i]);
            }

            for (int i = 0; i < secondSquad._soldiers.Count; i++)
            {
                _soldiers.Add(secondSquad._soldiers[i]);
            }
        }

        public void SortQueueBySpeed()
        {
            Soldier temporarySoldier = null;

            bool isSortingEnd = false;

            while (isSortingEnd == false)
            {
                isSortingEnd = true;

                for (int i = 0; i < _soldiers.Count - 1; i++)
                {
                    if (_soldiers[i].SquadNumber != _soldiers[i + 1].SquadNumber && _soldiers[i].Speed == _soldiers[i + 1].Speed)
                    {
                        int chanceIndex = GetFiftyPercentChanceSquadIndex();

                        if (chanceIndex == _soldiers[i].SquadNumber)
                        {
                            temporarySoldier = _soldiers[i + 1];
                            _soldiers[i + 1] = _soldiers[i];
                            _soldiers[i] = temporarySoldier;
                        }

                        if (chanceIndex == _soldiers[i + 1].SquadNumber)
                        {
                            temporarySoldier = _soldiers[i];
                            _soldiers[i] = _soldiers[i + 1];
                            _soldiers[i + 1] = temporarySoldier;
                        }
                    }

                    if (_soldiers[i].Speed < _soldiers[i + 1].Speed)
                    {
                        temporarySoldier = _soldiers[i + 1];
                        _soldiers[i + 1] = _soldiers[i];
                        _soldiers[i] = temporarySoldier;
                        isSortingEnd = false;
                    }

                    if (_soldiers[_soldiers.Count - 1].Speed > _soldiers[_soldiers.Count - 2].Speed)
                    {
                        temporarySoldier = _soldiers[_soldiers.Count - 2];
                        _soldiers[_soldiers.Count - 2] = _soldiers[_soldiers.Count - 1];
                        _soldiers[_soldiers.Count - 1] = temporarySoldier;
                        isSortingEnd = false;
                    }
                }
            }
        }

        public void GetSquadMark(int markIndex)
        {
            for (int i = 0; i < _soldiers.Count; i++)
            {
                _soldiers[i].GetSquadMark(markIndex);
            }
        }

        public void ShowStats()
        {
            char separateMark = '-';

            Console.WriteLine(Name);
            Console.WriteLine(string.Join("", Enumerable.Repeat(separateMark, 15)));

            for (int i = 0; i < _soldiers.Count; i++)
            {
                _soldiers[i].ShowStats();
            }

            Console.WriteLine();
        }

        public void MakeTurn(Squad activeSquad, Squad passiveSquad)
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

            damage = _soldiers[turnIndex].GetDamage();
            passiveSquad.TakeDamage(damage);
            bonusIndex = _soldiers[turnIndex].UseBonus();

            if (bonusIndex == grenadeIndex)
            {
                passiveSquad.TakeAreaDamage(grenadeDamage);
            }

            if (bonusIndex == radioSetIndex)
            {
                activeSquad._soldiers[UserUtils.GetRandomNumber(0, activeSquad._soldiers.Count)].TakeSpeedBonus(radioSetSpeedBonus);
            }

            if (bonusIndex == medKitIndex)
            {
                int lastSoldierIndex = 1;
                int fullHealthSoldiers = 0;

                bool isBonusUsed = false;

                while (isBonusUsed == false)
                {
                    for (int k = 0; k < activeSquad._soldiers.Count; k++)
                    {
                        if (activeSquad._soldiers[k].Health == fullHealth)
                        {
                            fullHealthSoldiers++;
                        }
                    }

                    if (fullHealthSoldiers == activeSquad._soldiers.Count - 1 && _soldiers[turnIndex].Health < fullHealth)
                    {
                        isBonusUsed = true;
                    }
                    else if (fullHealthSoldiers == activeSquad._soldiers.Count)
                    {
                        isBonusUsed = true;
                    }

                    if (activeSquad._soldiers.Count == lastSoldierIndex)
                    {
                        isBonusUsed = true;
                    }

                    int temporarySoldierIndex = UserUtils.GetRandomNumber(0, activeSquad._soldiers.Count);

                    if (activeSquad._soldiers[temporarySoldierIndex].Health < fullHealth && activeSquad._soldiers[temporarySoldierIndex] != _soldiers[turnIndex])
                    {
                        activeSquad._soldiers[temporarySoldierIndex].TakeHealth(medKitBonus);
                        isBonusUsed = true;
                    }
                }
            }

            skillIndex = _soldiers[turnIndex].UseSkill();

            if (skillIndex == soldierSkillIndex)
            {
                for (int l = 0; l < activeSquad._soldiers.Count; l++)
                {
                    if (activeSquad._soldiers[l] != _soldiers[turnIndex])
                    {
                        activeSquad._soldiers[l].TakeDamageBonus(soldierSkillBonus);
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
                    for (int k = 0; k < activeSquad._soldiers.Count; k++)
                    {
                        if (activeSquad._soldiers[k].Health == fullHealth)
                        {
                            fullHealthSoldiers++;
                        }
                    }

                    if (fullHealthSoldiers == activeSquad._soldiers.Count - 1 && _soldiers[turnIndex].Health < fullHealth)
                    {
                        isMedicSkillUsed = true;
                    }
                    else if (fullHealthSoldiers == activeSquad._soldiers.Count)
                    {
                        isMedicSkillUsed = true;
                    }

                    if (activeSquad._soldiers.Count == lastSoldierIndex)
                    {
                        isMedicSkillUsed = true;
                    }

                    int temporarySoldierIndex = UserUtils.GetRandomNumber(0, activeSquad._soldiers.Count);

                    if (activeSquad._soldiers[temporarySoldierIndex].Health < fullHealth && activeSquad._soldiers[temporarySoldierIndex] != _soldiers[turnIndex])
                    {
                        activeSquad._soldiers[temporarySoldierIndex].TakeHealth(medKitBonus);
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
                    int firstTemporarySoldierIndex = UserUtils.GetRandomNumber(0, activeSquad._soldiers.Count);
                    int secondTemporarySoldierIndex = UserUtils.GetRandomNumber(0, activeSquad._soldiers.Count);

                    if (activeSquad._soldiers[firstTemporarySoldierIndex] != _soldiers[turnIndex] && activeSquad._soldiers[secondTemporarySoldierIndex] != _soldiers[turnIndex] && firstTemporarySoldierIndex != secondTemporarySoldierIndex)
                    {
                        activeSquad._soldiers[firstTemporarySoldierIndex].TakeSpeedBonus(radioSetSpeedBonus);
                        activeSquad._soldiers[secondTemporarySoldierIndex].TakeSpeedBonus(radioSetSpeedBonus);
                        isDroneOperatorSkillUsed = true;
                    }

                    if (activeSquad._soldiers.Count <= bonusMaxSoldiersCount && activeSquad._soldiers[firstTemporarySoldierIndex] != _soldiers[turnIndex])
                    {
                        activeSquad._soldiers[firstTemporarySoldierIndex].TakeSpeedBonus(radioSetSpeedBonus);
                        isDroneOperatorSkillUsed = true;
                    }

                    if (activeSquad._soldiers.Count == bonusMinSoldiersCount)
                    {
                        isDroneOperatorSkillUsed = true;
                    }
                }
            }

            if (skillIndex == sniperSkillIndex)
            {
                _soldiers[turnIndex].Cover();
            }

            if (_soldiers[turnIndex].IsDoubleTurnActive == false)
            {
                _soldiers[turnIndex].SwitchTurnTumbler();
                _soldiers.Add(_soldiers[turnIndex]);
                _soldiers.RemoveAt(turnIndex);
            }
            else if (skillIndex == machineGunnerSkillIndex)
            {
                isDoubleTurnOnceUsed = true;
                Console.WriteLine($"патронная лента не закончилась и Пулемётчик делает еще один ход");
                _soldiers[turnIndex].SetDoubleTurnFalse();
            }

            if (skillIndex == machineGunnerSkillIndex && isDoubleTurnOnceUsed == false)
            {
                _soldiers[_soldiers.Count - 1].SetDoubleTurnTrue();
            }
        }

        public void RemoveDeadSoldiers()
        {
            _soldiers.RemoveAll(Soldier => Soldier.IsDead == true);
        }

        public bool HaveAllSoldirsMadeTurn(bool activeValue)
        {
            bool isAllSoldiersMadeTurn = false;
            int soldiersMadeTurnCount = 0;

            for (int i = 0; i < _soldiers.Count; i++)
            {
                if (_soldiers[i].IsTurnOver == activeValue)
                {
                    soldiersMadeTurnCount++;
                }
            }

            if (soldiersMadeTurnCount == _soldiers.Count)
            {
                isAllSoldiersMadeTurn = true;
            }

            return isAllSoldiersMadeTurn;
        }

        private void TakeDamage(int damage)
        {
            bool isDamageTaked = false;
            bool isSoldierDead = false;

            if (_soldiers.Count > 0)
            {
                while (isDamageTaked == false)
                {
                    int randomSoldierIndex = UserUtils.GetRandomNumber(0, _soldiers.Count);

                    isDamageTaked = _soldiers[randomSoldierIndex].TryTakeDamage(damage);
                    isSoldierDead = _soldiers[randomSoldierIndex].IsSoldierDead();

                    if (isSoldierDead == true)
                    {
                        Console.WriteLine($"{_soldiers[randomSoldierIndex].Name} погиб");
                        _soldiers.RemoveAt(randomSoldierIndex);
                    }
                }
            }
        }

        private void TakeAreaDamage(int areaDamage)
        {
            int minPartsCount = 1;
            int damageParts = UserUtils.GetRandomNumber(minPartsCount, _soldiers.Count + 1);
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
    }

    class Soldier
    {
        protected int _fullhealth = 100;
        protected int _armor = 10;
        protected int _damage = 10;

        protected string _bonus;

        protected bool _isBonusUsed = false;
        protected bool _isCovered = false;

        public Soldier()
        {
            GetBonus();
        }

        public int SquadNumber { get; protected set; }

        public int Health { get; protected set; } = 100;

        public int Speed { get; protected set; } = 10;

        public string Name { get; protected set; } = "Солдат";

        public bool IsDoubleTurnActive { get; protected set; } = false;

        public bool IsDead => Health <= 0;

        public bool IsTurnOver { get; protected set; } = false;

        public virtual Soldier Clone()
        {
            return new Soldier();
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name} Здоровье - {Health} Броня - {_armor} Скорость - {Speed} Урон - {_damage} Бонус - {_bonus} [{SquadNumber}]Отряд");
        }

        public virtual void GetBonus()
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

            int randomBonusIndex = UserUtils.GetRandomNumber(Grenade, BonusArmor);

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
            int zeroArmorValue = 0;
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
                if (_armor != zeroArmorValue)
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

        public bool IsSoldierDead()
        {
            return Health <= 0;
        }

        public void TakeHealth(int healthBonus)
        {
            Health += healthBonus;

            if (Health > _fullhealth)
            {
                Health = _fullhealth;
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

        private int UseGrenade()
        {
            int grenadeIndex = 1;
            _isBonusUsed = true;
            Console.WriteLine($"{Name} использует гранату");
            return grenadeIndex;
        }

        private int UseRadioSet()
        {
            int radioSetIndex = 2;
            _isBonusUsed = true;
            Console.WriteLine($"{Name} использует радиостанцию");
            return radioSetIndex;
        }

        private int UseMedKit()
        {
            int medKitIndex = 3;
            _isBonusUsed = true;
            Console.WriteLine($"{Name} использует аптечку");
            return medKitIndex;
        }

        private void UseBonusSpeed()
        {
            int bonusIndex = 10;
            _isBonusUsed = true;
            Speed += bonusIndex;
            Console.WriteLine($"{Name} получает бонус: {bonusIndex} к скорости");
        }

        private void UseBonusDamage()
        {
            int bonusIndex = 10;
            _isBonusUsed = true;
            _damage += bonusIndex;
            Console.WriteLine($"{Name} получает бонус: {bonusIndex} к урону");
        }

        private void UseBonusArmor()
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
    }

    class StormTrooper : Soldier
    {
        public StormTrooper()
        {
            Name = "Штурмовик";
            _armor = 30;
            Speed = 20;
            _damage = 20;
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new StormTrooper();    
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
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new Medic();
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
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new DroneOperator();
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
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new Sniper();
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
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new MachineGunner();
        }

        public override int UseSkill()
        {
            int machineGunnerSkillIndex = 6;
            return machineGunnerSkillIndex;
        }
    }
}