
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
        const char Empty = ' ';
        const char Treasure = '$';
        const char Thorn = '^';
        const char Cherry = '%';

        const int BottomMenuX = 3;
        const int BottomMenuY = 25;

        const string PlayerCollideTreasureMessage = "Вы нашли сокровище!                 ";
        const string PlayerCollideThornMessage = "Вы наступлили на колючку.              ";
        const string PlayerCollideCherryMessage = "Вы скушали вишенку!                  ";

        static string BottomMenuText = $"Нажмите: 1-установить сокровище ({Treasure})  2-установить колючку ({Thorn})  " +
                                       $"3-установить вишенку ({Cherry}) 4-Стену ({Wall})  5-Выход";

        const int PlayerLogMenuX = 3;
        const int PlayerLogMenuY = 24;
        static string PlayerLogPrefix = "Игрок:";

        const int playerStep = 1;

        static char[,] map;

        static int playerX;
        static int playerY;

        static void Main(string[] args)
        {
            map = ReadMap("map");
            bool isPlaying = true;
            Console.CursorVisible = false;

            DrawMap();
            SetPlayerStartPosition();
            ShowMenu();

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MovePlayer(0,-playerStep);
                        break;

                    case ConsoleKey.DownArrow:
                        MovePlayer(0, playerStep);
                        break;

                    case ConsoleKey.LeftArrow:
                        MovePlayer(-playerStep, 0);
                        break;

                    case ConsoleKey.RightArrow:
                        MovePlayer(playerStep, 0);
                        break;

                    case ConsoleKey.D1:
                        PlaceItem(Treasure);
                        break;

                    case ConsoleKey.D2:
                        PlaceItem(Thorn);
                        break;

                    case ConsoleKey.D3:
                        PlaceItem(Cherry);
                        break;

                    case ConsoleKey.D4:
                        PlaceItem(Wall);
                        break;

                    case ConsoleKey.D5:
                        isPlaying = false;
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

        static void DrawMap()
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

        static void SetPlayerStartPosition()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == Empty)
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

        static void HidePlayer()
        {
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(map[playerY,playerX]);
        }

        static void MovePlayer(int dx, int dy)
        {
            if(map[playerY+dy,playerX+dx] != Wall)
            {
                HidePlayer();
                playerX += dx;
                playerY += dy;
                DrawPlayer();
                CollidePlayer();
            }
        }

        static void ShowMenu()
        {
            Console.SetCursorPosition(BottomMenuX, BottomMenuY);
            Console.Write(BottomMenuText);
        }

        static void PlaceItem(char item)
        {
            map[playerY, playerX] = item;
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(item);
        }

        static void CollidePlayer()
        {
            switch (map[playerY, playerX])
            {
                case Treasure:
                    ShowPlayerLog(PlayerCollideTreasureMessage);
                    map[playerY, playerX] = Empty;
                    break;

                case Cherry:
                    ShowPlayerLog(PlayerCollideCherryMessage);
                    map[playerY, playerX] = Empty;
                    break;

                case Thorn:
                    ShowPlayerLog(PlayerCollideThornMessage);
                    map[playerY, playerX] = Empty;
                    break;
            }
        }

        static void ShowPlayerLog(string message)
        {
            Console.SetCursorPosition(PlayerLogMenuX, PlayerLogMenuY);
            Console.Write($"{PlayerLogPrefix} {message}");
        }
    }
}







