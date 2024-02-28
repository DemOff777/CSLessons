using System;
using System.Collections.Generic;

namespace Задание6_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Work();
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        public static int GiveRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static int GiveRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }

    class Zoo
    {
        List<Aviary> _aviaries = new List<Aviary>();

        public void Work()
        {
            CreateAviaries();

            Console.WriteLine($"Вы видите {_aviaries.Count} вольеров");
            Console.WriteLine("Укажите номер вольера к которому вы хотите подойти");

            int userInput = GiveUserInput();

            _aviaries[userInput].ShowInfo();
        }

        private int GiveUserInput()
        {
            int arriveFirstValueIndex = 1;
            int arriveMaxValueIndex = _aviaries.Count;
            int arriveIndexCorrection = 1;
            int userInput = 0;
            bool isInputCorrect = false;

            while (isInputCorrect == false)
            {
                isInputCorrect = Int32.TryParse(Console.ReadLine(), out userInput);

                if (isInputCorrect == false)
                {
                    Console.WriteLine("Неправильное значение попробуйте еще раз");
                }

                if (userInput < arriveFirstValueIndex || userInput > arriveMaxValueIndex)
                {

                }
            }
            
            return userInput - arriveIndexCorrection;
        }

        private int GiveAviariesCount()
        {
            int minAviariesCount = 4;
            int maxAviariesCount = 10;

            return UserUtils.GiveRandomNumber(minAviariesCount, maxAviariesCount);
        }

        private void CreateAviaries()
        {
            int aviariesCount = GiveAviariesCount();

            for (int i = 0; i < aviariesCount; i++)
            {
                Aviary aviary = new Aviary();
                aviary.Fill();
                aviary.InstallName();
                _aviaries.Add(aviary);
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        private string _name;

        public void Fill()
        {
            int minAnimalsCount = 1;
            int maxAnimalsCount = 51;

            List<Animal> animals = new List<Animal>()
            {
                new Cow(),
                new Horse(),
                new Goat(),
                new Pig()
            };

            int animalsCount = UserUtils.GiveRandomNumber(minAnimalsCount, maxAnimalsCount);

            for (int i = 0; i < animalsCount; i++)
            {
                Animal animal = animals[UserUtils.GiveRandomNumber(animals.Count)].Clone();
                animal.SetGender();
                _animals.Add(animal);
            }
        }

        public void InstallName()
        {
            _name = $"вольер с {GiveFirstAnimal().Name}ми";
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} содержит {_animals.Count} животных, {GiveMaleCount()} {Gender.Мужской}\bго пола, {GiveFemaleCount()} {Gender.Женский}\b\bого пола и {GiveNotDecidedCount()} {Gender.Не_Определился}\b\b\bвшихся");
        }

        private Animal GiveFirstAnimal()
        {
            return _animals[0];
        }

        private int GiveMaleCount()
        {
            int count = 0;

            for (int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].Gender == Gender.Мужской)
                {
                    count++;
                }
            }

            return count;
        }

        private int GiveFemaleCount()
        {
            int count = 0;

            for (int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].Gender == Gender.Женский)
                {
                    count++;
                }
            }

            return count;
        }

        private int GiveNotDecidedCount()
        {
            int count = 0;

            for (int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].Gender == Gender.Не_Определился)
                {
                    count++;
                }
            }

            return count;
        }
    }

    class Animal
    {
        protected string _voiceSound;

        public Gender Gender { get; protected set; }

        public string Name { get; protected set; }

        public void SetGender()
        {
            Gender[] genders = new Gender[3]
            {
                Gender.Мужской,
                Gender.Женский,
                Gender.Не_Определился
            };

            int genderIndex = UserUtils.GiveRandomNumber(genders.Length);

            Gender = genders[genderIndex];
        }

        public virtual Animal Clone()
        {
            return new Animal();
        }
    }

    class Cow : Animal
    {
        public Cow()
        {
            Name = "Корова";
            _voiceSound = "Му";
        }

        public override Animal Clone()
        {
            return new Cow();
        }
    }

    class Horse : Animal
    {
        public Horse()
        {
            Name = "Лошадь";
            _voiceSound = "Ига-га";
        }

        public override Animal Clone()
        {
            return new Horse();
        }
    }

    class Goat : Animal
    {
        public Goat()
        {
            Name = "Коза";
            _voiceSound = "Бе";
        }

        public override Animal Clone()
        {
            return new Goat();
        }
    }

    class Pig : Animal
    {
        public Pig()
        {
            Name = "Свинья";
            _voiceSound = "Хрю";
        }

        public override Animal Clone()
        {
            return new Pig();
        }
    }

    enum Gender
    {
        Мужской,
        Женский,
        Не_Определился
    }
}
