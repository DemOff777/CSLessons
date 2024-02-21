using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Задание6_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            aquarium.Work();
        }
    }

    static class UserUtils
    {
        static Random s_random = new Random();

        public static int GetRandomNumber(int minVolue, int maxVolue)
        {
            return s_random.Next(minVolue, maxVolue);
        }

        public static void ShowBorder()
        {
            char separateMark = '-';
            Console.WriteLine(string.Join("", Enumerable.Repeat(separateMark, 15)));
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes = new List<Fish>();

        public void Work()
        {
            int maxFishCount = GetMaxFishCount();
            int minFishCount = 0;

            bool isAuquariumWork = true;

            GereradeFishes(maxFishCount);

            while (isAuquariumWork)
            {
                Console.Clear();
                Console.WriteLine("В аквариуме плавает:");
                UserUtils.ShowBorder();
                ShowFishes();
                UserUtils.ShowBorder();
                UserAction(maxFishCount);
                TakeAwayFishesLifeTime();
                Console.WriteLine("Для завершения дня нажмите на любую кнопку");
                Console.ReadKey();
                EndDay();

                if (_fishes.Count <= minFishCount)
                {
                    isAuquariumWork = false;
                }
            }

            Console.WriteLine("Все рыбы погибли. Аквариум завершил свою деятельность");
        }

        private void GereradeFishes(int maxFishesCount)
        {
            int minFishCount = 1;
            int maxFishCount = 10;

            bool isFishesGenerade = false;

            while (isFishesGenerade == false)
            {
                int fishCount = UserUtils.GetRandomNumber(minFishCount, maxFishCount);

                if (fishCount <= maxFishesCount)
                {
                    isFishesGenerade = true;

                    for (int i = 0; i < fishCount; i++)
                    {
                        _fishes.Add(new Fish(SetFishName(), SetLifeTime()));
                    }
                }
            }
        }

        private int GetMaxFishCount()
        {
            Console.WriteLine("Введите максимальное количество рыб");
            int maxFishes = GetInt();
            return maxFishes;
        }

        private int GetInt() 
        {
            int number = 0;

            bool isInputOver = false;

            while (isInputOver == false)
            {
                isInputOver = Int32.TryParse(Console.ReadLine(), out number);

                if (isInputOver == false)
                {
                    Console.WriteLine("Неверное значение, попробуйте ввести еще раз");
                }
            }

            return number;
        }

        private void ShowFishes()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.Write($"{i} ");
                _fishes[i].ShowStats();
            }
        }

        private void UserAction(int maxFishCount)
        {
            const string AddFish = "1";
            const string DeleteFish = "2";
            const string WatchTheFish = "3";

            bool isUserInputCorrect = false;

            Console.WriteLine("Введите желаемое дейсвие");
            Console.WriteLine($"{AddFish} - добавить рыбу");
            Console.WriteLine($"{DeleteFish} - удалить рыбу");
            Console.WriteLine($"{WatchTheFish} - наблюдать за рыбами");

            while (isUserInputCorrect == false)
            {
                isUserInputCorrect = true;
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddFish:
                        this.AddFish(maxFishCount);
                        break;
                    case DeleteFish:
                        this.DeleteFish();
                        break;
                    case WatchTheFish:
                        this.WatchTheFish();
                        break;
                    default:
                        isUserInputCorrect = false;
                        break;
                }
            }
        }

        private void AddFish(int maxFishCount)
        {
            if (_fishes.Count < maxFishCount)
            {    
                _fishes.Add(new Fish(SetFishName(), SetLifeTime()));      
            }
            else
            {
                Console.WriteLine("Добавить рыбу невозможно. Аквариум полностью заполнен");
            }
        }

        private void DeleteFish()
        {
            int userNumber = 0;

            bool isFishDeleted = false;

            Console.WriteLine("Введите номер удаляемой рыбы");

            while (isFishDeleted == false)
            {
                bool isUserInputCorrect = Int32.TryParse(Console.ReadLine(), out userNumber);

                if (isUserInputCorrect == false || userNumber > _fishes.Count - 1 || userNumber < 0)
                {
                    Console.WriteLine("Значение не верно либо превышает количество рыб в аквариуме");
                }
                else
                {
                    isFishDeleted = true; 
                }
            }

            _fishes.RemoveAt(userNumber);
        }

        private void WatchTheFish()
        {
            Console.WriteLine("Вы просто наблюдаете за рыбами");
        }

        private void TakeAwayFishesLifeTime()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                _fishes[i].TakeAwayLifeTime();
            }
        }

        private void EndDay()
        {
            int LifeTimeToDeath = 0;

            bool isAllFishesDeleted = true;

            while (isAllFishesDeleted)
            {
                isAllFishesDeleted = false;

                for (int i = 0; i < _fishes.Count; i++)
                {
                    if (_fishes[i].LifeTime <= LifeTimeToDeath)
                    {
                        _fishes.RemoveAt(i);
                        isAllFishesDeleted = true;
                    }
                }
            }
        }

        private string SetFishName()
        {
            string flounder = "камбала";
            string pike = "щука";
            string carp = "карп";
            string vobla = "вобла";
            string bream = "лещ";

            const int FlounderIndex = 0;
            const int PikeIndex = 1;
            const int CarpIndex = 2;
            const int VoblaIndex = 3;
            const int BreamIndex = 4;

            int fishIndex = UserUtils.GetRandomNumber(FlounderIndex, BreamIndex);
            string name = "";

            switch (fishIndex)
            {
                case FlounderIndex:
                    name = flounder;
                    break;
                case PikeIndex:
                    name = pike;
                    break;
                case CarpIndex:
                    name = carp;
                    break;
                case VoblaIndex:
                    name = vobla;
                    break;
                case BreamIndex:
                    name = bream;
                    break;
            }

            return name;
        }

        private int SetLifeTime()
        {
            int minLifeTime = 3;
            int maxLifeTime = 10;

            int lifeTime = UserUtils.GetRandomNumber(minLifeTime, maxLifeTime);
            return lifeTime;
        }
    }

    class Fish
    {
        private string _name;

        public Fish(string name, int lifeTime)
        {
            _name = name;
            LifeTime = lifeTime;
        }

        public int LifeTime { get; private set; }

        public void TakeAwayLifeTime()
        {
            LifeTime --;
        }

        public void ShowStats()
        {
            Console.WriteLine($"{_name} осталось жить {LifeTime} дней");
        }
    }
}
