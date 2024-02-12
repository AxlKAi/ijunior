
using System;
using System.IO;

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

        static void Main(string[] args)
        {
            char[,] map;

            int playerPositionX = 0;
            int playerPositionY = 0;
            int PlayerStep = 1;
            bool isPlaying = true;

            string bottomMenuText = $"Нажмите: 1-установить сокровище ({Treasure})  2-установить колючку ({Thorn})  " +
                           $"3-установить вишенку ({Cherry}) 4-Стену ({Wall})  5-Выход";

            Console.CursorVisible = false;

            map = ReadMap("map");
            DrawMap(map);
            SetPlayerStartPosition(map, ref playerPositionX, ref playerPositionY);
            DrawPlayer(playerPositionX, playerPositionY);

            ShowMenu(bottomMenuText);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        MovePlayer(0, -PlayerStep, ref playerPositionX, ref playerPositionY, map);
                        break;

                    case ConsoleKey.DownArrow:
                        MovePlayer(0, PlayerStep, ref playerPositionX, ref playerPositionY, map);
                        break;

                    case ConsoleKey.LeftArrow:
                        MovePlayer(-PlayerStep, 0, ref playerPositionX, ref playerPositionY, map);
                        break;

                    case ConsoleKey.RightArrow:
                        MovePlayer(PlayerStep, 0, ref playerPositionX, ref playerPositionY, map);
                        break;

                    case ConsoleKey.D1:
                        PlaceItem(playerPositionX, playerPositionY, map, Treasure);
                        break;

                    case ConsoleKey.D2:
                        PlaceItem(playerPositionX, playerPositionY, map, Thorn);
                        break;

                    case ConsoleKey.D3:
                        PlaceItem(playerPositionX, playerPositionY, map, Cherry);
                        break;

                    case ConsoleKey.D4:
                        PlaceItem(playerPositionX, playerPositionY, map, Wall);
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
            char[,] map = new char[mapFile.Length, mapFile[0].Length];

            for (int i = 0; i < mapFile.Length; i++)
            {
                for (int j = 0; j < mapFile[0].Length; j++)
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

        static void SetPlayerStartPosition(char[,] map, ref int playerPositionX, ref int playerPositionY)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == Empty)
                    {
                        playerPositionX = j;
                        playerPositionY = i;

                        return;
                    }
                }
            }
        }

        static void DrawPlayer(int playerPositionX, int playerPositionY)
        {
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(Player);
        }

        static void HidePlayer(int playerPositionX, int playerPositionY, char[,] map)
        {
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(map[playerPositionY, playerPositionX]);
        }

        static void MovePlayer(int deltaX, int deltaY, ref int playerPositionX, ref int playerPositionY, char[,] map)
        {
            if (map[playerPositionY + deltaY, playerPositionX + deltaX] != Wall)
            {
                HidePlayer(playerPositionX, playerPositionY, map);
                playerPositionX += deltaX;
                playerPositionY += deltaY;
                DrawPlayer(playerPositionX, playerPositionY);
                CollidePlayer(playerPositionX, playerPositionY, map);
            }
        }

        static void ShowMenu(string bottomMenuText)
        {
            int bottomMenuX = 3;
            int bottomMenuY = 25;

            Console.SetCursorPosition(bottomMenuX, bottomMenuY);
            Console.Write(bottomMenuText);
        }

        static void PlaceItem(int playerPositionX, int playerPositionY, char[,] map, char item)
        {
            map[playerPositionY, playerPositionX] = item;
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.Write(item);
        }

        static void CollidePlayer(int playerPositionX, int playerPositionY, char[,] map)
        {
            string playerCollideTreasureMessage = "Вы нашли сокровище!                 ";
            string playerCollideThornMessage = "Вы наступлили на колючку.              ";
            string playerCollideCherryMessage = "Вы скушали вишенку!                  ";

            switch (map[playerPositionY, playerPositionX])
            {
                case Treasure:
                    ShowPlayerLog(playerCollideTreasureMessage);
                    map[playerPositionY, playerPositionX] = Empty;
                    break;

                case Cherry:
                    ShowPlayerLog(playerCollideCherryMessage);
                    map[playerPositionY, playerPositionX] = Empty;
                    break;

                case Thorn:
                    ShowPlayerLog(playerCollideThornMessage);
                    map[playerPositionY, playerPositionX] = Empty;
                    break;
            }
        }

        static void ShowPlayerLog(string message)
        {
            int playerLogMenuX = 3;
            int playerLogMenuY = 24;

            string playerLogPrefix = "Игрок:";

            Console.SetCursorPosition(playerLogMenuX, playerLogMenuY);
            Console.Write($"{playerLogPrefix} {message}");
        }
    }
}







