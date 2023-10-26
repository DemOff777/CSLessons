using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Redrerer renderer1 = new Redrerer();
            Player player1 = new Player(10, 10);

            renderer1.DrawPlayer(player1.X, player1.Y);
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Redrerer
    {
        public void DrawPlayer(int x, int y)
        {
            char playerChar = '#';

            Console.SetCursorPosition(x, y);
            Console.Write(playerChar);
        }
    }
}
