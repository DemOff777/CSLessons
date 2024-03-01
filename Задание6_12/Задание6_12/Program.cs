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
        private List<Aviary> _aviaries = new List<Aviary>();

        public void Work()
        {
            CreateAviaries();

            Console.WriteLine($"Вы видите {_aviaries.Count} вольеров");
            Console.WriteLine("Укажите номер вольера к которому вы хотите подойти");

            int aviaryIndex = GiveAviaryIndex();

            _aviaries[aviaryIndex].ShowInfo();
        }

        private int GiveAviaryIndex()
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
                    Console.WriteLine("Значение выходит за рамки имеющихся вальеров, попробуйте еще раз");
                    isInputCorrect = false;
                }
            }
            
            return userInput - arriveIndexCorrection;
        }

        private int GiveAviariesRandomCount()
        {
            int minAviariesCount = 4;
            int maxAviariesCount = 10;

            return UserUtils.GiveRandomNumber(minAviariesCount, maxAviariesCount);
        }

        private void CreateAviaries()
        {
            int aviariesCount = GiveAviariesRandomCount();

            for (int i = 0; i < aviariesCount; i++)
            {
                Aviary aviary = new Aviary();

                _aviaries.Add(aviary);
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        private string _name;

        public Aviary()
        {
            Fill();
            InstallName();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_name} содержит {_animals.Count} животных, {GiveGenderCount(Gender.Male)} {Gender.Male}\bго пола, {GiveGenderCount(Gender.Female)} {Gender.Female}\b\bого пола и {GiveGenderCount(Gender.NotDecide)} {Gender.NotDecide}\b\b\bвшихся");
        }

        private Animal GiveFirstAnimal()
        {
            return _animals[0];
        }

        private int GiveGenderCount(Gender gender)
        {
            int count = 0;

            for (int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].Gender == gender)
                {
                    count++;
                }
            }

            return count;
        }

        private void InstallName()
        {
            _name = $"вольер с {GiveFirstAnimal().Name}ми";
        }

        private void Fill()
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
            int animalRandomIndex = UserUtils.GiveRandomNumber(animals.Count);

            for (int i = 0; i < animalsCount; i++)
            {
                Animal animal = animals[animalRandomIndex].Clone();
                _animals.Add(animal);
            }
        }
    }

    class Animal
    {
        protected string VoiceSound;

        public Gender Gender { get; protected set; }

        public string Name { get; protected set; }

        public virtual Animal Clone()
        {
            return new Animal();
        }

        protected void SetGender()
        {
            Gender[] genders = new Gender[3]
            {
                Gender.Male,
                Gender.Female,
                Gender.NotDecide
            };

            int genderIndex = UserUtils.GiveRandomNumber(genders.Length);

            Gender = genders[genderIndex];
        }
    }

    class Cow : Animal
    {
        public Cow()
        {
            Name = "Корова";
            VoiceSound = "Му";
            SetGender();
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
            VoiceSound = "Ига-га";
            SetGender();
        }

        public override Animal Clone()
        {
            Horse horse = new Horse();
            horse.SetGender();
            return horse;
        }
    }

    class Goat : Animal
    {
        public Goat()
        {
            Name = "Коза";
            VoiceSound = "Бе";
            SetGender();
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
            VoiceSound = "Хрю";
            SetGender();
        }

        public override Animal Clone()
        {
            return new Pig();
        }
    }

    enum Gender
    {
        Male,
        Female,
        NotDecide
    }
}
