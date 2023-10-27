using System;


namespace Задание6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Redrerer renderer = new Redrerer();
            Player player = new Player(10, 10, '#');

            renderer.DrawPlayer(player.PositionX, player.PositionY, player.PlayerChar);
        }
    }

    class Player
    {
        public Player(int positionX, int positionY, char playerChar)
        {
            PositionX = positionX;
            PositionY = positionY;
            PlayerChar = playerChar;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char PlayerChar { get; private set; }
    }

    class Redrerer
    {
        public void DrawPlayer(int positionX, int positionY, char playerChar)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(playerChar);
        }
    }
}
