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
                    MakeTurn(_firstCountrySquad, _secondCountrySquad);
                }
                else
                {
                    MakeTurn(_secondCountrySquad, _firstCountrySquad);
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

        public void MakeTurn(Squad activeSquad, Squad passiveSquad)
        {
            int damage = _turnQueue.GetFirstSoldier().GetDamage();
            passiveSquad.TakeDamage(damage);
            _turnQueue.GetFirstSoldier().UseBonus(activeSquad, passiveSquad);
            _turnQueue.GetFirstSoldier().UseSkill(activeSquad, passiveSquad, _turnQueue);
            MoveSoldierToTurnEnd(_turnQueue.GetFirstSoldier(), _turnQueue);
            _turnQueue.GetFirstSoldier().SetDoubleTurn(_turnQueue);
        }

        private void GetSoldiers()
        {
            int firstSquadIndex = 1;
            int secondSquadIndex = 2;

            _firstCountrySquad.GetName(firstSquadIndex);
            _firstCountrySquad.Fill();
            _firstCountrySquad.GetSquadMark(firstSquadIndex);
            _secondCountrySquad.GetName(secondSquadIndex);
            _secondCountrySquad.Fill();
            _secondCountrySquad.GetSquadMark(secondSquadIndex);
        }

        private void MoveSoldierToTurnEnd(Soldier turnSoldier, Squad turnQueue)
        {
            if (turnSoldier.IsDoubleTurnActive == false)
            {
                turnSoldier.SwitchTurnTumbler();
                turnQueue.TakeSoldier(turnSoldier);
                turnQueue.RemoveSoldier(turnSoldier);
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

        public void ShowTurnQueueStats()
        {
            ShowStats();
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
                new Soldier(), 
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

            int penultSoldierIndex = 2;

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

                    if (_soldiers[_soldiers.Count - 1].Speed > _soldiers[_soldiers.Count - penultSoldierIndex].Speed)
                    {
                        temporarySoldier = _soldiers[_soldiers.Count - penultSoldierIndex];
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

        public void TakeDamage(int damage)
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

        public void TakeSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
        }

        public void RemoveSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
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

    class Soldier
    {
        protected int Armor = 10;
        protected int Damage = 10;

        protected bool IsBonusUsed = false;
        protected bool IsCovered = false;

        public Soldier()
        {
            GetBonus();
        }

        public int FullHealth { get; protected set; } = 100;

        public int SquadNumber { get; protected set; }

        public int Health { get; protected set; } = 100;

        public int Speed { get; protected set; } = 10;

        public string Name { get; protected set; } = "Солдат";

        public bool IsDoubleTurnActive { get; protected set; } = false;

        public bool IsDead => Health <= 0;

        public bool IsTurnOver { get; protected set; } = false;

        public Bonus Bonus;

        public virtual Soldier Clone()
        {
            return new Soldier();
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

        public virtual void GetBonus()
        {
            List<Bonus> bonuses= new List<Bonus>()
            {
                new Grenade(),
                new RadioSet(),
                new MedKit(),
                new SpeedBonus(),
                new DamageBonus(),
                new ArmorBonus()
            };

            int randomBonusIndex = UserUtils.GetRandomNumber(bonuses.Count);
            Bonus = bonuses[randomBonusIndex];
        }

        public int GetDamage()
        {
            Console.WriteLine($"{Name} наносит {Damage} урона");
            return Damage;        
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

        public bool IsSoldierDead()
        {
            return Health <= 0;
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

        public virtual void UseSkill(Squad activeSquad, Squad passiveSquad, Squad turnQueue)
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

        public virtual void SetDoubleTurn(Squad turnQueue) { }

        public void Cover()
        {
            IsCovered = true;
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

    class StormTrooper : Soldier
    {
        public StormTrooper()
        {
            Name = "Штурмовик";
            Armor = 30;
            Speed = 20;
            Damage = 20;
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new StormTrooper();    
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad, Squad turnQueue)
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
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new Medic();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad, Squad turnQueue)
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
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new DroneOperator();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad, Squad turnQueue)
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
            GetBonus();
        }

        public override Soldier Clone()
        {
            return new Sniper();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad, Squad turnQueue)
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
            GetBonus();
        }

        private bool _isDoubleTurnOnceRun = false;

        public override Soldier Clone()
        {
            return new MachineGunner();
        }

        public override void UseSkill(Squad activeSquad, Squad passiveSquad, Squad turnQueue)
        {
            if (IsDoubleTurnActive)
            {
                _isDoubleTurnOnceRun = true;
                Console.WriteLine($"боеприпасы не закончилась и {Name} делает еще один ход");
            }
            else
            {
                _isDoubleTurnOnceRun = false;
            }
        }

        public override void SetDoubleTurn(Squad turnQueue)
        {
            if (_isDoubleTurnOnceRun)
            {
                IsDoubleTurnActive = false;
            }

            if (IsDoubleTurnActive == false && _isDoubleTurnOnceRun == false)
            {
                turnQueue.GetSoldier(turnQueue.GetCount() - 1).SetDoubleTurnTrue();
            }
        }
    }
}