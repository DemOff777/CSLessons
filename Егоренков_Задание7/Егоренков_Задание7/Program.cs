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
            int timeInTurnHours;
            int timeInTurnMinutes;
            int minutesInHour = 60;

            Console.Write("Введите количество старушек в очереди ");
            peoplesInTurn = Convert.ToInt32(Console.ReadLine());
            timeInTurnHours = peoplesInTurn * timeOfAppointment / minutesInHour;
            timeInTurnMinutes = peoplesInTurn * timeOfAppointment % minutesInHour;
            Console.WriteLine($"Время ожидания в очереди {timeInTurnHours} часов и {timeInTurnMinutes} минут");

        }
    }
}
