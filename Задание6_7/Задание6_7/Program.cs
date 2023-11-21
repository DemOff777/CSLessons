using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание6_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Depot depot = new Depot();

            bool isWork = true;

            Console.WriteLine("Отправившихся поездов нет.");

            while (isWork)
            {
                depot.CreateTrain();
                depot.TakeCurrentTrain().SetDirection();
                depot.TakeCurrentTrain().GetPassengers();

                Console.WriteLine("Для отправки поезда нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();

                depot.TakeCurrentTrain().ShowDirection();
                depot.TakeCurrentTrain().ShowPassengers();
            }
        }
    }

    class Depot
    {
        private Stack<Train> _trains = new Stack<Train>();

        public void CreateTrain() 
        { 
            Train train = new Train();

            _trains.Push(train);
        }

        public Train TakeCurrentTrain()
        {
            return _trains.Peek();
        }
    }

    class Train 
    {
        private List<int> _carriages = new List<int>();

        Direction _direction = new Direction();

        public void GetPassengers()
        {
            int passengersMinVolue = 50;
            int passengersMaxVolue = 500;
            int passengersInCarriageMinAmount = 27;
            int passengersInCarriageMaxAmount = 54;
            int passengersAmount;
            int temporaryPassengersAmountInCarriage;

            Random random = new Random();

            passengersAmount = random.Next(passengersMinVolue, passengersMaxVolue);

            Console.WriteLine($"{passengersAmount} Пассажиров купили бидеты");

            while(passengersAmount > 0)
            {
                temporaryPassengersAmountInCarriage = random.Next(passengersInCarriageMinAmount, passengersInCarriageMaxAmount + 1);

                if (passengersAmount > temporaryPassengersAmountInCarriage)
                {
                    _carriages.Add(temporaryPassengersAmountInCarriage);
                    passengersAmount -= temporaryPassengersAmountInCarriage;
                }
                else
                {
                    _carriages.Add(passengersAmount);
                    break;
                }
            }
        }

        public void ShowPassengers()
        {
            for (int i = 0; i < _carriages.Count; i++)
            {                   
                Console.WriteLine($"В вагоне {i + 1} - {_carriages[i]}человек");
            }
        }

        public void ShowDirection()
        {
            _direction.ShowPoints();
        }

        public void SetDirection()
        {
            _direction.GetPoints();
        }
    }

    class Direction
    {
        private string _departurePoint;
        private string _arrivalPoint;

        public void GetPoints()
        {
            bool isPointsCorrect = false;

            while (isPointsCorrect == false)
            {
                Console.SetCursorPosition(0, 17);
                Console.WriteLine("Введите место отправки");
                string userInput = Console.ReadLine();
                _departurePoint = userInput;

                Console.WriteLine("Введите место прибытия");
                userInput = Console.ReadLine();

                if (_departurePoint != userInput)
                {
                    _arrivalPoint = userInput;
                    isPointsCorrect = true;
                }
                else
                {
                    Console.WriteLine("Пункт отправки и пункт назначения совпадают, попробуйте другой вариант");
                }
            }
        }

        public void ShowPoints()
        {
            Console.WriteLine($"пункт отправления - {_departurePoint} | пункт прибытия - {_arrivalPoint}");
        }
    }
}
