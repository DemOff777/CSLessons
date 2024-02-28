using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        private static string _border1 = string.Join("-", Enumerable.Repeat("", 10));

        public static int GiveRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
        public static int GiveRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue + 1);
        }

        public static void ShowBorder1()
        {
            Console.WriteLine($"{_border1}");
        }
    }

    class CarService
    {
        private List<CarPart> _carParts = new List<CarPart>()
        {
            new HeadLight(),
            new Fender(),
            new Wheel(),
            new Engine(),
            new WindShileld()
        };

        private List<CarPart> _carPartsStorage = new List<CarPart>();
        private Queue<Client> _clients = new Queue<Client>();

        private int _money = 10000;

        public void Work()
        {
            bool isWork = true;

            CreateCarPartsStorageCount();
            CreateClientsQueue();

            while (_clients.Count > 0)
            {
                Console.WriteLine($"в кассе {_money} рублей");
                UserUtils.ShowBorder1();
                Console.WriteLine($"в очереди осталось {_clients.Count} клиентов");
                Console.WriteLine($"Текущая заявка: Поломка = {_clients.Peek().Problem.Name}");
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

        private void CreateCarPartsStorageCount()
        {
            int minPartsStorageCount = 5;
            int maxPartsStorageCount = 20;

            int carPartsStorageCount = UserUtils.GiveRandomNumber(minPartsStorageCount, maxPartsStorageCount);

            for (int i = 0; i < carPartsStorageCount; i++)
            {
                int randomCarPartIndex = UserUtils.GiveRandomNumber(_carParts.Count);
                _carPartsStorage.Add(_carParts[randomCarPartIndex].Clone());
            }
        }

        private void CreateClientsQueue()
        {
            int minClientsCount = 5;
            int maxClientCount = 20;

            int clientsCount = UserUtils.GiveRandomNumber(minClientsCount, maxClientCount);

            for (int i = 0; i < clientsCount; i++)
            {
                _clients.Enqueue(new Client(GenerateProblem()));
            }
        }

        private void SolveProblem()
        {
            int fineValue = _clients.Peek().Problem.Price / 2;
            int workPrice = _clients.Peek().Problem.Price / 3;
            int repairCount = _clients.Peek().Problem.Price + workPrice;

            CarPart carPart = TryFindCarPart(_clients.Peek().Problem);

            if (carPart == _clients.Peek().Problem)
            {
                Console.WriteLine($"Вы отказываете клиенту в ремонте и выплачиваете штраф {fineValue} рублей");
                _money -= fineValue;
            }
            else
            {
                Console.WriteLine($"Вы ремонтируете автомобиль клиента и получаете {repairCount} рублей");
                int money = _clients.Peek().GiveMoney(repairCount);
                _money += money;
                _carPartsStorage.Remove(carPart);
            }
        }

        private CarPart TryFindCarPart(CarPart problem)
        {
            for (int i = 0; i < _carPartsStorage.Count; i++)
            {
                if (_carPartsStorage[i] is HeadLight headLight)
                {
                    Console.WriteLine("Подходящая фара для ремонта имеется на складе");
                    return headLight;
                }
                else if (_carPartsStorage[i] is Fender fender)
                {
                    Console.WriteLine("Подходящее крыло для ремонта имеется на складе");
                    return fender;
                }
                else if (_carPartsStorage[i] is Wheel wheel)
                {
                    Console.WriteLine("Подходящее колесо для ремонта имеется на складе");
                    return wheel;
                }
                else if (_carPartsStorage[i] is Engine engine)
                {
                    Console.WriteLine("Подходящий двигатель для ремонта имеется на складе");
                    return engine;
                }
                else if (_carPartsStorage[i] is WindShileld windShileld)
                {
                    Console.WriteLine("Подходящий двигатель для ремонта имеется на складе");
                    return windShileld;
                }
                else
                {
                    Console.WriteLine("Подходящая деталь для ремонта не найдена");
                }

            }

            return problem;
        }

        private CarPart GenerateProblem()
        {
            CarPart carPart;

            int randomNumber;
            int maxRandomValue = 5;

            randomNumber = UserUtils.GiveRandomNumber(maxRandomValue);

            carPart = _carParts[randomNumber];

            return carPart;
        }
    }

    class Client
    {
        private int _money;

        public Client(CarPart carPart)
        {
            Problem = carPart;
            _money = carPart.Price * 2;
        }

        public CarPart Problem { get; private set; }

        public string GiveCarPartName()
        {
            return $"{Problem}";
        }

        public int GiveMoney(int repairCount)
        {
            _money -= repairCount;
            return repairCount;
        }

        public void TakeMoney(int money)
        {
            _money += money;
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
