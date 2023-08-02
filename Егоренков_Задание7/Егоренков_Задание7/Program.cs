using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Егоренков_Задание7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peoplesInTurn;
            int timeOfAppointment = 10;
            int timeInTurnHouers;
            int timeInTurnMinutes;

            Console.Write("Введите количество старушек в очереди ");
            peoplesInTurn = Convert.ToInt32(Console.ReadLine());
            timeInTurnHouers = peoplesInTurn * timeOfAppointment / 60;
            timeInTurnMinutes = peoplesInTurn * timeOfAppointment % 60;
            Console.WriteLine($"Время ожидания в очереди {timeInTurnHouers} часов и {timeInTurnMinutes} минут");

        }
    }
}
