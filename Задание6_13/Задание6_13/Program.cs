using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание6_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();

            carService.Work();
        }
    }

    static class UserUtils
    {
        private static Random s_random = new Random();

        private static string s_border1 = string.Join("-", Enumerable.Repeat("", 10));

        public static int GenerateRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue + 1);
        }

        public static void ShowBorder1()
        {
            Console.WriteLine($"{s_border1}");
        }
    }

    class CarService
    {
        private List<CarPart> _carPartsStorage = new List<CarPart>();
        private Queue<Client> _clients = new Queue<Client>();

        private int _money = 10000;

        public CarService()
        {
            List<CarPart> carParts = new List<CarPart>()
            {
                new HeadLight(),
                new Fender(),
                new Wheel(),
                new Engine(),
                new WindShileld()
            };

            CreateCarPartsStorageCount(carParts);
            CreateClientsQueue();
        }

        public void Work()
        {
            while (_clients.Count > 0)
            {
                Console.WriteLine($"в кассе {_money} рублей");
                UserUtils.ShowBorder1();
                Console.WriteLine($"в очереди осталось {_clients.Count} клиентов");
                Console.WriteLine($"Текущая заявка: Поломка = {_clients.Peek().BrokenCarPart.Name}");
                Console.WriteLine("Для того чтобы пригласить следующего клиента нажмите любую клавишу");
                Console.ReadKey();

                SolveProblem();
                _clients.Dequeue();

                UserUtils.ShowBorder1();
                Console.WriteLine("Для того чтобы закончить ремонт нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("чередь клиентов закончилась");
        }

        private void CreateCarPartsStorageCount(List<CarPart> carParts)
        {
            int minPartsStorageCount = 5;
            int maxPartsStorageCount = 20;

            int carPartsStorageCount = UserUtils.GenerateRandomNumber(minPartsStorageCount, maxPartsStorageCount);

            for (int i = 0; i < carPartsStorageCount; i++)
            {
                int randomCarPartIndex = UserUtils.GenerateRandomNumber(carParts.Count);
                _carPartsStorage.Add(carParts[randomCarPartIndex].Clone());
            }
        }

        private void CreateClientsQueue()
        {
            int minClientsCount = 5;
            int maxClientCount = 20;

            int clientsCount = UserUtils.GenerateRandomNumber(minClientsCount, maxClientCount);

            for (int i = 0; i < clientsCount; i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        private void SolveProblem()
        {
            int fineIndex = 2;
            int workPriceIndex = 3;
            int fineValue = _clients.Peek().BrokenCarPart.Price / fineIndex;
            int workPrice = _clients.Peek().BrokenCarPart.Price / workPriceIndex;
            int repairCount = _clients.Peek().BrokenCarPart.Price + workPrice;

            CarPart carPart = TryFindCarPart(_clients.Peek().BrokenCarPart);

            if (carPart == _clients.Peek().BrokenCarPart)
            {
                Console.WriteLine($"Вы отказываете клиенту в ремонте и выплачиваете штраф {fineValue} рублей");
                _money -= fineValue;
            }
            else
            {
                Console.WriteLine($"Вы ремонтируете автомобиль клиента и получаете {repairCount} рублей");
                int money = _clients.Peek().GiveMoney(repairCount);
                _money += money;
                _clients.Peek().TakeCarPart(carPart);
                _carPartsStorage.Remove(carPart);
            }
        }

        private CarPart TryFindCarPart(CarPart brokenCarPart)
        {
            CarPart carPartFound = brokenCarPart;

            for (int i = 0; i < _carPartsStorage.Count; i++)
            {
                if (_carPartsStorage[i].Name == brokenCarPart.Name)
                {
                    carPartFound = _carPartsStorage[i];
                    Console.WriteLine($"{carPartFound.Name} для ремонта имеется на складе");
                    return carPartFound;
                }
            }

            if (carPartFound == brokenCarPart)
            {
                Console.WriteLine("Подходящей детали не найдено");
            }

            return brokenCarPart;
        }
    }

    class Client
    {
        private int _money;

        private CarPart _repairCarPart = null;

        public Client()
        {
            List<CarPart> carParts = new List<CarPart>()
            {
                new HeadLight(),
                new Fender(),
                new Wheel(),
                new Engine(),
                new WindShileld()
            };

            BrokenCarPart = carParts[UserUtils.GenerateRandomNumber(carParts.Count)];

            _money = BrokenCarPart.Price * 2;
        }

        public CarPart BrokenCarPart { get; private set; }

        public int GiveMoney(int repairCount)
        {
            _money -= repairCount;
            return repairCount;
        }

        public void TakeCarPart(CarPart carPart)
        {
            BrokenCarPart = null;
            _repairCarPart = carPart;
        }
    }

    abstract class CarPart
    {
        public int Price { get; protected set; }
        public string Name { get; protected set; }

        public virtual CarPart Clone()
        {
            return null;
        } 
    }

    class HeadLight : CarPart
    {
        public HeadLight()
        {
            Name = "Фара";
            Price = 3000;
        }

        public override CarPart Clone()
        {
            return new HeadLight();
        } 
    }

    class Fender : CarPart
    {
        public Fender()
        {
            Name = "Крыло";
            Price = 12500;
        }

        public override CarPart Clone()
        {
            return new Fender();
        }
    }

    class Wheel : CarPart
    {
        public Wheel()
        {
            Name = "Колесо";
            Price = 4500;
        }

        public override CarPart Clone()
        {
            return new Wheel();
        }
    }

    class Engine : CarPart
    {
        public Engine()
        {
            Name = "Двигатель";
            Price = 47500;
        }

        public override CarPart Clone()
        {
            return new Engine();
        }
    }

    class WindShileld : CarPart
    {
        public WindShileld()
        {
            Name = "Лобовое стекло";
            Price = 8000;
        }

        public override CarPart Clone()
        {
            return new WindShileld();
        }
    }
}
