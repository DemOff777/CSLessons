using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Задание4_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int playerX = 0;
            int playerY = 0;
            int playerDX = 0;
            int playerDY = 1;

            bool isPlaying = true;

            char[,] map = ReadMap("map1", ref playerX, ref playerY);

            DrawMap(map);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            playerDX = -1;
                            playerDY = 0;
                            break;

                        case ConsoleKey.DownArrow:
                            playerDX = 1;
                            playerDY = 0;
                            break;

                        case ConsoleKey.LeftArrow:
                            playerDX = 0;
                            playerDY = -1;
                            break;

                        case ConsoleKey.RightArrow:
                            playerDX = 0;
                            playerDY = 1;
                            break;
                    }
                }

                if (map[playerX + playerDX, playerY + playerDY] != '%')
                {
                    Move(ref playerX, ref playerY, ref playerDX, ref playerDY);
                }

                System.Threading.Thread.Sleep(100);
            }
        }

        static void Move(ref int X, ref int Y, ref int DX, ref int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.WriteLine(' ');

            X += DX;
            Y += DY;

            Console.SetCursorPosition(Y, X);
            Console.Write('#');
        }

        static char[,] ReadMap(string mapName, ref int x, ref int y)
        {
            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '#')
                    {
                        x = i;
                        y = j;
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
    }
}
