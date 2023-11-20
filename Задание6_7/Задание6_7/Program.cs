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
            Train train = new Train();

            bool isWork = true;

            while (isWork)
            {
                train.ShowPassengers();

                Console.SetCursorPosition(0, 17);
                Console.WriteLine("Введите направление");
                string userInput = Console.ReadLine();
                train.TakeDirection(userInput);

                train.TakePassengers(train.GetPassengers());

                Console.WriteLine("Для отправки поезда нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Train 
    {
        List<int> _carriages = new List<int>();

        private int _carriageMaxPassengerAmount = 54;
        private string _direction;

        public void TakeDirection(string userInput)
        {
            _direction = userInput;
        }

        public List<int> GetPassengers()
        {
            List<int> carriages = new List<int>();

            int passengersMinVolue = 50;
            int passengersMaxVolue = 500;
            int passengersInCarriageMinAmount = _carriageMaxPassengerAmount / 2;
            int passengersInCarriageMaxAmount = _carriageMaxPassengerAmount;
            int passengersAmount;
            int temporaryPassengersAmountInCarriage;

            Random randomPassengerAmount = new Random();
            Random randomPassengersInCarriage = new Random();

            passengersAmount = randomPassengerAmount.Next(passengersMinVolue, passengersMaxVolue);

            Console.WriteLine($"{passengersAmount} Пассажиров купили бидеты");

            while(passengersAmount > 0)
            {
                temporaryPassengersAmountInCarriage = randomPassengersInCarriage.Next(passengersInCarriageMinAmount, passengersInCarriageMaxAmount + 1);

                if (passengersAmount > temporaryPassengersAmountInCarriage)
                {
                    carriages.Add(temporaryPassengersAmountInCarriage);
                    passengersAmount -= temporaryPassengersAmountInCarriage;
                }
                else
                {
                    carriages.Add(passengersAmount);
                    break;
                }
            }

            return carriages;
        }

        public void TakePassengers(List<int> carriages)
        {
            _carriages = carriages;
        }

        public void ShowPassengers()
        {
            if (_carriages.Count > 0 )
            {
                Console.WriteLine($"Скорый поезд - {_direction}");

                for (int i = 0; i < _carriages.Count; i++)
                {                   
                    Console.WriteLine($"В вагоне {i + 1} - {_carriages[i]}человек");
                }
            }
            else
            {
                Console.WriteLine("Отправившихся поездов нет");
            }
        }
    }
}
