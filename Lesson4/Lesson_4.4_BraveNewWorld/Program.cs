
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4._4_BraveNewWorld
{
    class Program
    {
        const char Wall = '#';
        const char Player = '@';

        const string  = "";

        const int bottomMenuX = 3;
        const int bottomMenuY = 30;

        static int playerX;
        static int playerY;

        static void Main(string[] args)
        {
            char[,] map = ReadMap("map");
            bool isPlaying = true;
            DrawMap(map);
            SetPlayerStartPosition(map);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Write("up ");
                        break;

                    case ConsoleKey.DownArrow:
                        Console.Write("down ");
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.Write("left ");
                        break;

                    case ConsoleKey.RightArrow:
                        Console.Write("ri ");
                        break;
                }
            }
        }

        static char[,] ReadMap(string mapName)
        {
            string[] mapFile = File.ReadAllLines($"map/{mapName}.txt");
            char[,] map = new char[mapFile.Length,mapFile[0].Length];

            for(int i=0; i<mapFile.Length; i++)
            {
                for(int j=0; j< mapFile[0].Length; j++)
                {
                    map[i, j] = mapFile[i][j];
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

        static void SetPlayerStartPosition(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == ' ')
                    {
                        playerX = j;
                        playerY = i;
                        DrawPlayer();
                        return;
                    }
                }
            }
        }

        static void DrawPlayer()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(Player);
        }
    }
}
