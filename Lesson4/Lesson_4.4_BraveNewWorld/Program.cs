
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

        enum Direction { Up, Down, Left, Right }

        static void Main(string[] args)
        {
            const ConsoleKey UpKey = ConsoleKey.UpArrow;
            const ConsoleKey DownKey = ConsoleKey.DownArrow;
            const ConsoleKey LeftKey = ConsoleKey.LeftArrow;
            const ConsoleKey RightKey = ConsoleKey.RightArrow;
            const ConsoleKey PlaceTreasureKey = ConsoleKey.D1;
            const ConsoleKey PlaceThornKey = ConsoleKey.D2;
            const ConsoleKey PlaceCherryKey = ConsoleKey.D3;
            const ConsoleKey PlaceWallKey = ConsoleKey.D4;
            const ConsoleKey ExitKey = ConsoleKey.D5;
            const ConsoleKey DrawModeKey = ConsoleKey.D6;

            char[,] map;

            int playerPositionX;
            int playerPositionY;

            bool isPlaying = true;
            bool isDrawMode = true;

            Console.CursorVisible = false;

            map = ReadMap("map");
            DrawMap(map);
            InitializePlayerStartPosition(map, out playerPositionX, out playerPositionY);
            DrawPlayer(playerPositionX, playerPositionY);

            ShowMenu(isDrawMode);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case UpKey:
                        MovePlayer(Direction.Up, ref playerPositionX, ref playerPositionY, map, isDrawMode);
                        break;

                    case DownKey:
                        MovePlayer(Direction.Down, ref playerPositionX, ref playerPositionY, map, isDrawMode);
                        break;

                    case LeftKey:
                        MovePlayer(Direction.Left, ref playerPositionX, ref playerPositionY, map, isDrawMode);
                        break;

                    case RightKey:
                        MovePlayer(Direction.Right, ref playerPositionX, ref playerPositionY, map, isDrawMode);
                        break;

                    case PlaceTreasureKey:
                        if (isDrawMode)
                            PlaceItem(playerPositionX, playerPositionY, map, Treasure);
                        break;

                    case PlaceThornKey:
                        if (isDrawMode)
                            PlaceItem(playerPositionX, playerPositionY, map, Thorn);
                        break;

                    case PlaceCherryKey:
                        PlaceItem(playerPositionX, playerPositionY, map, Cherry);
                        break;

                    case PlaceWallKey:
                        if (isDrawMode)
                            PlaceItem(playerPositionX, playerPositionY, map, Wall);
                        break;

                    case ExitKey:
                        isPlaying = false;
                        break;

                    case DrawModeKey:
                        isDrawMode = false;
                        ShowMenu(isDrawMode);
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

        static void InitializePlayerStartPosition(char[,] map, out int playerPositionX, out int playerPositionY)
        {
            playerPositionX = 0;
            playerPositionY = 0;

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

        static void MovePlayer(Direction direction, ref int playerPositionX, ref int playerPositionY, char[,] map, bool isDrawMode)
        {
            int minPositionX = 0;
            int minPositionY = 0;
            int maxPositionX = map.GetLength(1) - 1;
            int maxPositionY = map.GetLength(0) - 1;

            int deltaX, deltaY;

            GetMovementDirection(direction, out deltaX, out deltaY);

            if (isDrawMode || map[playerPositionY + deltaY, playerPositionX + deltaX] != Wall)
            {
                HidePlayer(playerPositionX, playerPositionY, map);
                playerPositionX += deltaX;
                playerPositionY += deltaY;

                if (playerPositionX < minPositionX)
                    playerPositionX = minPositionX;

                if (playerPositionX > maxPositionX)
                    playerPositionX = maxPositionX;

                if (playerPositionY < minPositionY)
                    playerPositionY = minPositionY;

                if (playerPositionY > maxPositionY)
                    playerPositionY = maxPositionY;

                DrawPlayer(playerPositionX, playerPositionY);

                if (isDrawMode == false)
                    CollidePlayer(playerPositionX, playerPositionY, map);
            }
        }

        static void GetMovementDirection(Direction direction, out int deltaX, out int deltaY)
        {
            deltaX = 0;
            deltaY = 0;
 
            if(direction == Direction.Up)
                deltaY = -1;

            if (direction == Direction.Down)
                deltaY = 1;

            if (direction == Direction.Left)
                deltaX = -1;

            if (direction == Direction.Right)
                deltaX = 1;
        }

        static void ShowMenu(bool isDrawMode)
        {
            int bottomMenuX = 0;
            int bottomMenuY = 22;

            string bottomMenuText;

            if (isDrawMode)
                bottomMenuText = $"Вы в режиме редактирования карты. \n" +
                    $"1-установить сокровище ({Treasure}) \n" +
                    $"2-установить колючку ({Thorn})       \n" +
                    $"3-установить вишенку ({Cherry})      \n" +
                    $"4-установить Стену ({Wall})          \n" +
                    $"5-Выход                              \n" +
                    $"6-Начать игру.                  ";
            else
                bottomMenuText = $"Вы в режиме игры.                   \n " +
                    "                                     \n" +
                    $"Кушайте вишню ({Cherry}),           \n" +
                    $"собирайте сокровища ({Treasure}).   \n" +
                    $"избегайте колючек ({Thorn}),         \n" +
                    $"                                    \n" +
                    $"5-Выход                              ";

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
            int playerLogMenuX = 0;
            int playerLogMenuY = 23;

            string playerLogPrefix = "Игрок:";

            Console.SetCursorPosition(playerLogMenuX, playerLogMenuY);
            Console.Write($"{playerLogPrefix} {message}");
        }
    }
}







