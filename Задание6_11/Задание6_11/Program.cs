using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        List<Fish> _fishes = new List<Fish>();

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
                UserActions(maxFishCount);
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
                        _fishes.Add(new Fish());
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

        private void UserActions(int maxFishCount)
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
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddFish:
                        isUserInputCorrect = this.AddFish(maxFishCount);
                        break;
                    case DeleteFish:
                        isUserInputCorrect = this.DeleteFish();
                        break;
                    case WatchTheFish:
                        isUserInputCorrect = this.WatchTheFish();
                        break;
                    default:
                        Console.WriteLine("Некорректное значение. Попробуйте еще раз");
                        break;
                }
            }
        }

        private bool AddFish(int maxFishCount)
        {
            bool isFishAdded = true;

            if (_fishes.Count < maxFishCount)
            {    
                _fishes.Add(new Fish());      
            }
            else
            {
                Console.WriteLine("Добавить рыбу невозможно. Аквариум полностью заполнен");
            }

            return isFishAdded;
        }

        private bool DeleteFish()
        {
            int userNumber = 0;

            bool isUserInputCorrect = false;

            Console.WriteLine("Введите номер удаляемой рыбы");

            while (isUserInputCorrect == false)
            {
                isUserInputCorrect = Int32.TryParse(Console.ReadLine(), out userNumber);

                if (isUserInputCorrect == false && userNumber > _fishes.Count - 1)
                {
                    Console.WriteLine("Значение не верно либо превышает количество рыб в аквариуме");
                }
            }

            _fishes.RemoveAt(userNumber);
            bool isFishDeleted = true;
            return isFishDeleted;
        }

        private bool WatchTheFish()
        {
            bool isFishSwim = true;
            Console.WriteLine("Вы просто наблюдаете за рыбами");
            return isFishSwim;
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
    }

    class Fish
    {
        private string _name;

        public int LifeTime { get; private set; }

        public Fish()
        {
            SetName();
            SetLifeTime();
        }

        public void TakeAwayLifeTime()
        {
            LifeTime --;
        }

        private void SetName()
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
            
            switch(fishIndex)
            {
                case FlounderIndex:
                    _name = flounder;
                    break;
                case PikeIndex:
                    _name = pike;
                    break;
                case CarpIndex:
                    _name = carp;
                    break;
                case VoblaIndex:
                    _name = vobla;
                    break;
                case BreamIndex:
                    _name = bream;
                    break;
            }
        }

        private void SetLifeTime()
        {
            int minLifeTime = 3;
            int maxLifeTime = 10;

            LifeTime = UserUtils.GetRandomNumber(minLifeTime, maxLifeTime);
        }

        public void ShowStats()
        {
            Console.WriteLine($"{_name} осталось жить {LifeTime} дней");
        }
    }
}
