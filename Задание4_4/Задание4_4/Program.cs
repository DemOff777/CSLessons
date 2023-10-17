using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace Задание4_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            char wallChar = '%';

            int playerX;
            int playerY;
            int playerDirectionX = 0;
            int playerDirectionY = 1;

            bool isPlaying = true;

            char[,] map = ReadMap("map1", out playerX, out playerY);

            DrawMap(map);

            while (isPlaying)
            {
                TakeInput(ref playerDirectionX, ref playerDirectionY);

                if (map[playerX + playerDirectionX, playerY + playerDirectionY] != wallChar)
                {
                    Move(ref playerX, ref playerY, playerDirectionX, playerDirectionY);
                }

                System.Threading.Thread.Sleep(100);
            }
        }

        static void Move(ref int positionX, ref int positionY, int directionX, int directionY)
        {
            char playerChar = '#';
            char emptySpaceChar = ' ';

            Console.SetCursorPosition(positionY, positionX);
            Console.WriteLine(emptySpaceChar);

            positionX += directionX;
            positionY += directionY;

            Console.SetCursorPosition(positionY, positionX);
            Console.Write(playerChar);
        }

        static char[,] ReadMap(string mapName, out int positionX, out int positionY)
        {
            positionX = 0;
            positionY = 0;
            
            char playerChar = '#';

            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == playerChar)
                    {
                        positionX = i;
                        positionY = j;
                    }
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void TakeInput(ref int directionX, ref int directionY)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                const ConsoleKey MoveUp = ConsoleKey.UpArrow;
                const ConsoleKey MoveDown = ConsoleKey.DownArrow;
                const ConsoleKey MoveLeft = ConsoleKey.LeftArrow;
                const ConsoleKey MoveRight = ConsoleKey.RightArrow;

                directionX = 0;
                directionY = 0;

                switch (key.Key)
                {
                    case MoveUp:
                        directionX = -1;
                        break;

                    case MoveDown:
                        directionX = 1;
                        break;

                    case MoveLeft:
                        directionY = -1;
                        break;

                    case MoveRight:
                        directionY = 1;
                        break;
                }
            }
        }
    }
}
