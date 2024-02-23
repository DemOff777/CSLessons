using System;
using System.Collections.Generic;
using System.Linq;

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

        public static int GetRandomNumber(int maxVolue)
        {
            return s_random.Next(maxVolue);
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
            int maxFishCount = GiveMaxFishCount();
            int minFishCount = 0;

            bool isWork = true;

            GeneradeFishes(maxFishCount);

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("В аквариуме плавает:");
                UserUtils.ShowBorder();
                ShowFishes();
                UserUtils.ShowBorder();
                MakeUserAction(maxFishCount);
                TakeAwayFishesLifeTime();
                Console.WriteLine("Для завершения дня нажмите на любую кнопку");
                Console.ReadKey();
                EndDay();

                if (_fishes.Count <= minFishCount)
                {
                    isWork = false;
                }
            }

            Console.WriteLine("Все рыбы погибли. Аквариум завершил свою деятельность");
        }

        private void GeneradeFishes(int maxFishesCount)
        {
            int minFishCount = 1;
            int maxFishCount = 10;
            int fishCount = 0;

            bool isFishesGenerade = false;

            while (isFishesGenerade == false)
            {
                fishCount = UserUtils.GetRandomNumber(minFishCount, maxFishCount);

                if (fishCount <= maxFishesCount)
                {
                    isFishesGenerade = true;
                }
            }

            for (int i = 0; i < fishCount; i++)
            {
                _fishes.Add(new Fish(SetFishName(), SetLifeTime()));
            }
        }

        private int GiveMaxFishCount()
        {
            Console.WriteLine("Введите максимальное количество рыб");
            return GiveInt();
        }

        private int GiveInt() 
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

        private void MakeUserAction(int maxFishCount)
        {
            const string CommandAddFish = "1";
            const string CommandDeleteFish = "2";
            const string CommandWatchTheFish = "3";

            bool isUserInputCorrect = false;

            Console.WriteLine("Введите желаемое дейсвие");
            Console.WriteLine($"{CommandAddFish} - добавить рыбу");
            Console.WriteLine($"{CommandDeleteFish} - удалить рыбу");
            Console.WriteLine($"{CommandWatchTheFish} - наблюдать за рыбами");

            while (isUserInputCorrect == false)
            {
                isUserInputCorrect = true;
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddFish:
                        AddFish(maxFishCount);
                        break;
                    case CommandDeleteFish:
                        DeleteFish();
                        break;
                    case CommandWatchTheFish:
                        WatchTheFish();
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

            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].LifeTime <= LifeTimeToDeath)
                {
                    _fishes.RemoveAt(i);
                    i--;
                }
            }
        }

        private string SetFishName()
        {
            string[] names = new string[] { "камбала", "щука", "карп", "вобла", "лещ" };

            return names[UserUtils.GetRandomNumber(names.Length)];
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
