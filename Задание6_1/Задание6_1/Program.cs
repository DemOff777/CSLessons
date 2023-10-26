using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Rex", "Killer", 100, 10);

            player1.ShowPlayerInfo();
        }
    }

    class Player
    {
        public string Name;
        public string Class;
        public int Health;
        public int Mana;

        public Player(string name, string @class, int health, int mana)
        {
            Name = name;
            Class = @class;
            Health = health;
            Mana = mana;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine($"{Name} - {Class}: HP - {Health} MANA - {Mana}");
        }
    }
}
