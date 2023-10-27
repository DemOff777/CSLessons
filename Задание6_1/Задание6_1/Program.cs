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
        private string _name;
        private string _character;
        private int _health;
        private int _mana;

        public Player(string name, string character, int health, int mana)
        {
            _name = name;
            _character = character;
            _health = health;
            _mana = mana;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine($"{_name} - {_character}: HP - {_health} MANA - {_mana}");
        }
    }
}
