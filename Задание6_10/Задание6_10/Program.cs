using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        private List<Soldier> _turnQueue = new List<Soldier>();

        public void PrepareForFigth()
        {
            GetSoldiers();
            FillTurnQueue(_firstCountrySquad, _secondCountrySquad);
            SortQueueBySpeed();
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
                int firstSoldierIndex = 0;

                bool isSoldiersMakeTurnFalse = false;
                bool isSoldiersMakeTurnTrue = false;

                ShowStats();

                if (_turnQueue[firstSoldierIndex].SquadNumber == firstSquadIndex)
                {
                    MakeTurn(_firstCountrySquad, _secondCountrySquad);
                }
                else
                {
                    MakeTurn(_secondCountrySquad, _firstCountrySquad);
                }

                RemoveDeadSoldiers();

                isSoldiersMakeTurnFalse = HaveAllSoldirsMadeTurn(false);
                isSoldiersMakeTurnTrue = HaveAllSoldirsMadeTurn(true);

                if (isSoldiersMakeTurnFalse == true || isSoldiersMakeTurnTrue == true)
                {
                    SortQueueBySpeed();
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

        public void MakeTurn(Squad activeSquad, Squad passiveSquad)
        {
            int firstSoldierIndex = 0;
            _turnQueue[firstSoldierIndex].Attack(passiveSquad);
            _turnQueue[firstSoldierIndex].UseBonus(activeSquad, passiveSquad);
            _turnQueue[firstSoldierIndex].UseSkill(activeSquad, passiveSquad);
            MoveSoldierToTurnEnd();
            SetDoubleTurn();
        }

        private void FillTurnQueue(Squad firstSquad, Squad secondSquad)
        {
            for (int i = 0; i < firstSquad.GetCount(); i++)
            {
                _turnQueue.Add(firstSquad.GetSoldier(i));
            }

            for (int i = 0; i < secondSquad.GetCount(); i++)
            {
                _turnQueue.Add(secondSquad.GetSoldier(i));
            }
        }

        private void SortQueueBySpeed()
        {
            Soldier temporarySoldier = null;

            int penultSoldierIndex = 2;

            bool isSortingEnd = false;

            while (isSortingEnd == false)
            {
                isSortingEnd = true;

                for (int i = 0; i < _turnQueue.Count - 1; i++)
                {
                    if (_turnQueue[i].SquadNumber != _turnQueue[i + 1].SquadNumber && _turnQueue[i].Speed == _turnQueue[i + 1].Speed)
                    {
                        int chanceIndex = GiveFiftyPercentChanceIndex();

                        if (chanceIndex == _turnQueue[i].SquadNumber)
                        {
                            temporarySoldier = _turnQueue[i + 1];
                            _turnQueue[i + 1] = _turnQueue[i];
                            _turnQueue[i] = temporarySoldier;
                        }

                        if (chanceIndex == _turnQueue[i + 1].SquadNumber)
                        {
                            temporarySoldier = _turnQueue[i];
                            _turnQueue[i] = _turnQueue[i + 1];
                            _turnQueue[i + 1] = temporarySoldier;
                        }
                    }

                    if (_turnQueue[i].Speed < _turnQueue[i + 1].Speed)
                    {
                        temporarySoldier = _turnQueue[i + 1];
                        _turnQueue[i + 1] = _turnQueue[i];
                        _turnQueue[i] = temporarySoldier;
                        isSortingEnd = false;
                    }

                    if (_turnQueue[_turnQueue.Count - 1].Speed > _turnQueue[_turnQueue.Count - penultSoldierIndex].Speed)
                    {
                        temporarySoldier = _turnQueue[_turnQueue.Count - penultSoldierIndex];
                        _turnQueue[_turnQueue.Count - penultSoldierIndex] = _turnQueue[_turnQueue.Count - 1];
                        _turnQueue[_turnQueue.Count - 1] = temporarySoldier;
                        isSortingEnd = false;
                    }
                }
            }
        }

        private int GiveFiftyPercentChanceIndex()
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

        private void GetSoldiers()
        {
            int firstSquadIndex = 1;
            int secondSquadIndex = 2;

            _firstCountrySquad.GetName(firstSquadIndex);
            _firstCountrySquad.Fill();
            _firstCountrySquad.SetSquadMark(firstSquadIndex);
            _secondCountrySquad.GetName(secondSquadIndex);
            _secondCountrySquad.Fill();
            _secondCountrySquad.SetSquadMark(secondSquadIndex);
        }

        private void MoveSoldierToTurnEnd()
        {
            int firstSoldierIndex = 0;
            if (_turnQueue[firstSoldierIndex].IsDoubleTurnActive == false)
            {
                _turnQueue[firstSoldierIndex].SwitchTurnTumbler();
                _turnQueue.Add(_turnQueue[firstSoldierIndex]);
                _turnQueue.Remove(_turnQueue[firstSoldierIndex]);
            }
        }

        private void ShowStats()
        {
            char separateMark = '-';

            Console.WriteLine(string.Join("", Enumerable.Repeat(separateMark, 15)));

            for (int i = 0; i < _turnQueue.Count; i++)
            {
                _turnQueue[i].ShowStats();
            }

            Console.WriteLine();
        }

        private void RemoveDeadSoldiers()
        {
            _turnQueue.RemoveAll(Soldier => Soldier.IsDead == true);
        }

        private bool HaveAllSoldirsMadeTurn(bool activeValue)
        {
            bool isAllSoldiersMadeTurn = false;
            int soldiersMadeTurnCount = 0;

            for (int i = 0; i < _turnQueue.Count; i++)
            {
                if (_turnQueue[i].IsTurnOver == activeValue)
                {
                    soldiersMadeTurnCount++;
                }
            }

            if (soldiersMadeTurnCount == _turnQueue.Count)
            {
                isAllSoldiersMadeTurn = true;
            }

            return isAllSoldiersMadeTurn;
        }

        private void SetDoubleTurn()
        {
            int firstSoldierIndex = 0;

            if (_turnQueue[firstSoldierIndex].IsDoubleTurnOnceRun)
            {
                _turnQueue[firstSoldierIndex].SwitchDoubleTurnFalse();
            }

            if (_turnQueue[firstSoldierIndex].IsDoubleTurnActive == false && _turnQueue[firstSoldierIndex].IsDoubleTurnOnceRun == false)
            {
                _turnQueue[_turnQueue.Count - 1].SwitchDoubleTurnTrue();
            }
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

        public int GetCount()
        {
            return _soldiers.Count;
        }

        public Soldier GetRandomSoldier()
        {
            int randomSoldireIndex = UserUtils.GetRandomNumber(_soldiers.Count);
            return _soldiers[randomSoldireIndex]; 
        }

        public Soldier GetSoldier(int index)
        {
            return _soldiers[index];
        }

        public Soldier GetFirstSoldier()
        {
            int firstSoldierIndex = 0;
            return _soldiers[firstSoldierIndex];
        }

        public void Fill()
        {
            int soldiersInSquad = 6;

            List<Soldier> soldiers = new List<Soldier>()
            {
                new Marksman(), 
                new StormTrooper(),
                new Medic(),
                new DroneOperator(),
                new Sniper(),
                new MachineGunner()
            };

            for (int i = 0; i < soldiersInSquad; i++)
            {
                int randomSoldierIndex = UserUtils.GetRandomNumber(soldiersInSquad);
                _soldiers.Add(soldiers[randomSoldierIndex].Clone());
            }
        }

        public void SetSquadMark(int markIndex)
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

        public void TakeDamage(int damage)
        {
            bool isDamageTaked = false;

            if (_soldiers.Count > 0)
            {
                while (isDamageTaked == false)
                {
                    int randomSoldierIndex = UserUtils.GetRandomNumber(0, _soldiers.Count);

                    isDamageTaked = _soldiers[randomSoldierIndex].TryTakeDamage(damage);

                    if (_soldiers[randomSoldierIndex].IsDead == true)
                    {
                        Console.WriteLine($"{_soldiers[randomSoldierIndex].Name} погиб");
                        _soldiers.RemoveAt(randomSoldierIndex);
                    }
                }
            }
        }

        public void TakeAreaDamage(int areaDamage)
        {
            int minPartsCount = 1;
            int damageParts = UserUtils.GetRandomNumber(minPartsCount, _soldiers.Count + 1);
            int damage = areaDamage / damageParts;

            for (int i = 0; i < damageParts; i++)
            {
                TakeDamage(damage);
            }
        }
    }

    class Bonus
    {
        public string Name { get; protected set; }

        public virtual Bonus Clone()
        {
            return new Bonus();
        }

        public virtual void Use(Squad activeSquad, Squad passiveSquad, Soldier turnSoldier) {}
    }

    class Grenade : Bonus
    {
        public Grenade()
        {
            Name = "grenade";
        }

        public int Damage { get; private set; } = 70;

        public override Bonus Clone()
        {
            return new Grenade();
        }

        public override void Use(Squad activeSquad, Squad passiveSquad, Soldier turnSoldier)
        {
            Console.WriteLine($"{turnSoldier.Name} кидает гранату");
            passiveSquad.TakeAreaDamage(Damage);
        }
    }

    class RadioSet : Bonus
    {
        public RadioSet()
        {
            Name = "radioSet";
        }

        public int SpeedBonusValue { get; private set; } = 5;

        public override Bonus Clone()
        {
            return new RadioSet();
        }

        public override void Use(Squad activeSquad, Squad passiveSquad, Soldier turnSoldier)
        {
            bool isBonusUsed = false;

            while (isBonusUsed == false)
            {
                int soldierRandomIndex = UserUtils.GetRandomNumber(activeSquad.GetCount());

                if (activeSquad.GetSoldier(soldierRandomIndex) != turnSoldier)
                {
                    Console.WriteLine($"{turnSoldier.Name} использует рацию");
                    activeSquad.GetSoldier(soldierRandomIndex).TakeSpeedBonus(SpeedBonusValue);
                    isBonusUsed = true;
                }
            }
        }
    }

    class MedKit : Bonus
    {
        public MedKit()
        {
            Name = "medKit";
        }

        public int HealthRecoveryValue { get; private set; } = 50;

        public override Bonus Clone()
        {
            return new MedKit();
        }

        public override void Use(Squad activeSquad, Squad passiveSquad, Soldier turnSoldier)
        {
            int lastSoldierValue = 1;
            int fullHealthSoldiers = 0;

            bool isBonusUsed = false;

            while (isBonusUsed == false)
            {
                for (int k = 0; k < activeSquad.GetCount(); k++)
                {
                    if (activeSquad.GetSoldier(k).Health == activeSquad.GetSoldier(k).FullHealth)
                    {
                        fullHealthSoldiers++;
                    }
                }

                if (fullHealthSoldiers == activeSquad.GetCount() - 1 && turnSoldier.Health < turnSoldier.FullHealth)
                {
                    isBonusUsed = true;
                }
                else if (fullHealthSoldiers == activeSquad.GetCount())
                {
                    isBonusUsed = true;
                }

                if (activeSquad.GetCount() == lastSoldierValue)
                {
                    isBonusUsed = true;
                }

                int temporarySoldierIndex = UserUtils.GetRandomNumber(activeSquad.GetCount());

                if (activeSquad.GetSoldier(temporarySoldierIndex).Health < activeSquad.GetSoldier(temporarySoldierIndex).FullHealth && activeSquad.GetSoldier(temporarySoldierIndex) != turnSoldier)
                {
                    Console.WriteLine($"{turnSoldier.Name} использует аптечку");
                    activeSquad.GetSoldier(temporarySoldierIndex).TakeHealth(HealthRecoveryValue);
                    isBonusUsed = true;
                }
            }
        }
    }

    class SpeedBonus : Bonus
    {
        public SpeedBonus()
        {
            Name = "speedBonus";
        }

        public int Value { get; private set; } = 10;

        public override Bonus Clone()
        {
            return new SpeedBonus();
        }

        public override void Use(Squad activeSquad, Squad passiveSquad, Soldier turnSoldier)
        {
            turnSoldier.TakeSpeedBonus(Value);
            turnSoldier.RemoveBonus();
        }
    }

    class DamageBonus : Bonus
    {
        public DamageBonus()
        {
            Name = "damageBonus";
        }

        public int Value { get; private set; } = 10;

        public override Bonus Clone()
        {
            return new DamageBonus();
        }

        public override void Use(Squad activeSquad, Squad passiveSquad, Soldier turnSoldier)
        {
            turnSoldier.TakeDamageBonus(Value);
            turnSoldier.RemoveBonus();
        }
    }

    class ArmorBonus : Bonus
    {
        public ArmorBonus()
        {
            Name = "armorBonus";
        }

        public int Value { get; private set; } = 10;

        public override Bonus Clone()
        {
            return new ArmorBonus();
        }

        public override void Use(Squad activeSquad, Squad passiveSquad, Soldier turnSoldier)
        {
            turnSoldier.TakeArmorBonus(Value);
            turnSoldier.RemoveBonus();
        }
    }

    abstract class Soldier
    {
        protected int Armor;
        protected int Damage;

        protected bool IsCovered = false;

        private Bonus Bonus;

        private List<Bonus> _bonuses = new List<Bonus>()
        {
            new Grenade(),
            new RadioSet(),
            new MedKit(),
            new SpeedBonus(),
            new DamageBonus(),
            new ArmorBonus()
        };


        public int FullHealth { get; protected set; } = 100;

        public int SquadNumber { get; protected set; }

        public int Health { get; protected set; } = 100;

        public int Speed { get; protected set; }

        public string Name { get; protected set; }

        public bool IsDoubleTurnActive { get; protected set; } = false;

        public bool IsDead => Health <= 0;

        public bool IsTurnOver { get; protected set; } = false;

        public bool IsDoubleTurnOnceRun { get; protected set; } = true;

        public virtual Soldier Clone()
        {
            return null;
        }

        public void ShowStats()
        {
            string bonusValue;

            if (Bonus != null)
            {
                bonusValue = Bonus.Name;
            }
            else
            {
                bonusValue = "использован";
            }

            Console.WriteLine($"{Name} Здоровье - {Health} Броня - {Armor} Скорость - {Speed} Урон - {Damage} Бонус - {bonusValue} [{SquadNumber}]Отряд");
        }

        public virtual void InstallBonus()
        {
            int randomBonusIndex = UserUtils.GetRandomNumber(_bonuses.Count);
            Bonus = _bonuses[randomBonusIndex];
        }

        public void Attack(Squad passiveSquad)
        {
            Console.WriteLine($"{Name} наносит {Damage} урона");
            passiveSquad.TakeDamage(Damage);
        }

        public bool TryTakeDamage(int damage)
        {
            int zeroArmorValue = 0;
            int finishDamage;
            bool isdamageTaked = false;

            if (IsCovered)
            {
                isdamageTaked = true;
                IsCovered = false;
                Console.WriteLine($"{Name} избегает урона");
            }

            if (Health > 0 && isdamageTaked == false)
            {
                if (Armor != zeroArmorValue)
                {
                    finishDamage = damage - (damage / (100 / Armor));
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

        public void TakeHealth(int healthBonus)
        {
            Health += healthBonus;

            if (Health > FullHealth)
            {
                Health = FullHealth;
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
            Damage += damageBonus;
            Console.WriteLine($"{Name} получает {damageBonus} к урону");
        }

        public void TakeArmorBonus(int armorBonus)
        {
            int maxArmorValue = 50;

            Armor += armorBonus;

            if (Armor > maxArmorValue)
            {
                Armor = maxArmorValue;
            }
        }

        public virtual void UseSkill(Squad activeSquad, Squad passiveSquad){}

        public void Cover()
        {
            IsCovered = true;
        }

        public void GetSquadMark(int markIndex)
        {
            SquadNumber = markIndex;
        }

        public void SwitchDoubleTurnTrue()
        {
            IsDoubleTurnActive = true;
        }

        public void SwitchDoubleTurnFalse()
        {
            IsDoubleTurnActive = false;
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

        public void RemoveBonus()
        {
            Bonus = null;
        }

        public void UseBonus(Squad activeSquad, Squad passiveSquad)
        {
            if (Bonus != null)
            {
                Bonus.Use(activeSquad, passiveSquad, this);
            }
        }
    }

    class Marksman : Soldier
    {
        public Marksman()
        {
            Name = "Стрелок";
            Armor = 10;
            Speed = 10;
            Damage = 10;
            InstallBonus();
        }

        public override Soldier Clone()
        {
            return new Marksman();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad)
        {
            int soldierSkillBonusValue = 5;

            for (int i = 0; i < activeSquad.GetCount(); i++)
            {
                if (activeSquad.GetSoldier(i) != this)
                {
                    Console.WriteLine($"{Name} повышает боевой дух группы");
                    activeSquad.GetSoldier(i).TakeDamageBonus(soldierSkillBonusValue);
                }
            }
        }
    }

    class StormTrooper : Soldier
    {
        public StormTrooper()
        {
            Name = "Штурмовик";
            Armor = 30;
            Speed = 20;
            Damage = 20;
            InstallBonus();
        }

        public override Soldier Clone()
        {
            return new StormTrooper();    
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad)
        {
            Grenade grenade = new Grenade();
            Console.WriteLine($"{Name} кидает гранату");
            passiveSquad.TakeAreaDamage(grenade.Damage);
        }
    }

    class Medic : Soldier
    {
        public Medic()
        {
            Name = "Медик";
            Armor = 10;
            Speed = 10;
            Damage = 10;
            InstallBonus();
        }

        public override Soldier Clone()
        {
            return new Medic();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad)
        {
            int fullHealth = 100;
            int lastSoldierValue = 1;
            int fullHealthSoldiers = 0;
            bool isMedicSkillUsed = false;

            while (isMedicSkillUsed == false)
            {
                for (int k = 0; k < activeSquad.GetCount(); k++)
                {
                    if (activeSquad.GetSoldier(k).Health == fullHealth)
                    {
                        fullHealthSoldiers++;
                    }
                }

                if (fullHealthSoldiers == activeSquad.GetCount() - 1 && Health < fullHealth)
                {
                    isMedicSkillUsed = true;
                }
                else if (fullHealthSoldiers == activeSquad.GetCount())
                {
                    isMedicSkillUsed = true;
                }

                if (activeSquad.GetCount() == lastSoldierValue)
                {
                    isMedicSkillUsed = true;
                }

                int temporarySoldierIndex = UserUtils.GetRandomNumber(activeSquad.GetCount());

                if (activeSquad.GetSoldier(temporarySoldierIndex).Health < fullHealth && activeSquad.GetSoldier(temporarySoldierIndex) != this)
                {
                    MedKit medKit = new MedKit();
                    Console.WriteLine($"{Name} лечит одного из бойцов");
                    activeSquad.GetSoldier(temporarySoldierIndex).TakeHealth(medKit.HealthRecoveryValue);
                    isMedicSkillUsed = true;
                }
            }
        }
    }

    class DroneOperator : Soldier
    {
        public DroneOperator()
        {
            Name = "Оператор Дрона";
            Armor = 10;
            Speed = 50;
            Damage = 0;
            InstallBonus();
        }

        public override Soldier Clone()
        {
            return new DroneOperator();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad)
        {
            int radioSetSpeedBonus = 5;
            int bonusMaxSoldiersCount = 2;
            int bonusMinSoldiersCount = 1;
            bool isDroneOperatorSkillUsed = false;

            while (isDroneOperatorSkillUsed == false)
            {
                int firstTemporarySoldierIndex = UserUtils.GetRandomNumber(activeSquad.GetCount());
                int secondTemporarySoldierIndex = UserUtils.GetRandomNumber(activeSquad.GetCount());

                if (activeSquad.GetSoldier(firstTemporarySoldierIndex) != this && activeSquad.GetSoldier(secondTemporarySoldierIndex) != this && firstTemporarySoldierIndex != secondTemporarySoldierIndex)
                {
                    Console.WriteLine($"{Name} увеличивает скорость двум бойцам");
                    activeSquad.GetSoldier(firstTemporarySoldierIndex).TakeSpeedBonus(radioSetSpeedBonus);
                    activeSquad.GetSoldier(secondTemporarySoldierIndex).TakeSpeedBonus(radioSetSpeedBonus);
                    isDroneOperatorSkillUsed = true;
                }

                if (activeSquad.GetCount() <= bonusMaxSoldiersCount && activeSquad.GetSoldier(firstTemporarySoldierIndex) != this)
                {
                    Console.WriteLine($"{Name} увеличивает скорость одному бойцу");
                    activeSquad.GetSoldier(firstTemporarySoldierIndex).TakeSpeedBonus(radioSetSpeedBonus);
                    isDroneOperatorSkillUsed = true;
                }

                if (activeSquad.GetCount() == bonusMinSoldiersCount)
                {
                    isDroneOperatorSkillUsed = true;
                }
            }
        }
    }

    class Sniper : Soldier
    {
        public Sniper()
        {
            Name = "Снайпер";
            Armor = 0;
            Speed = 5;
            Damage = 110;
            InstallBonus();
        }

        public override Soldier Clone()
        {
            return new Sniper();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad)
        {
            Console.WriteLine($"{Name} укрывается от следующей атаки");
            Cover();
        }
    }

    class MachineGunner : Soldier
    {
        public MachineGunner()
        {
            Name = "Пулеметчик";
            Armor = 20;
            Speed = 10;
            Damage = 30;
            IsDoubleTurnActive = true;
            IsDoubleTurnOnceRun = false;
            InstallBonus();
        }

        public override Soldier Clone()
        {
            return new MachineGunner();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad)
        {
            if (IsDoubleTurnActive)
            {
                IsDoubleTurnOnceRun = true;
                Console.WriteLine($"боеприпасы не закончилась и {Name} делает еще один ход");
            }
            else
            {
                IsDoubleTurnOnceRun = false;
            }
        }
    }
}