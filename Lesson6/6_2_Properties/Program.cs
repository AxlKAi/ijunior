using System;

namespace _6_2_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("AxlUndeadMan", '*', 99, 55);
            Renderer renderer = new Renderer();

            player.IncreaseMana(77);
            player.MoveTo(5, 5);

            renderer.ShowPlayer(player);
            renderer.ShowPlayerInfo(player,5,15);

            Console.ReadKey();
        }
    }

    class Player
    {
        public Player(string name, char skin, int health, int armor)
        {
            Name = name;
            Health = health;
            Armor = armor;
            Skin = skin;
        }

        public char Skin { get; private set; }
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int Health { get; private set; }
        public int Armor { get; private set; }
        public string Name { get; private set; }
        public int ManaAmmount { get; private set; }

        public void MoveTo(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public void IncreaseMana(int ammount)
        {
            if (ammount > 0)
                ManaAmmount += ammount;
        }
    }

    class Renderer
    {
        public void ShowPlayer(Player player)
        {
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.Write(player.Skin);
        }

        public void ShowPlayerInfo(Player player, int windowTopX, int windowTopY)
        {
            int line = 0;

            Console.SetCursorPosition(windowTopX, windowTopY);
            Console.Write($"Игрок {player.Name}");

            line++;
            Console.SetCursorPosition(windowTopX, windowTopY + line);
            Console.Write($"Координаты X={player.PositionX} Y={player.PositionY}");

            line++;
            Console.SetCursorPosition(windowTopX, windowTopY + line);
            Console.Write($"Защита игрока {player.Armor}");

            line++;
            Console.SetCursorPosition(windowTopX, windowTopY + line);
            Console.Write($"Здоровье игрока {player.Health}");

            line++;
            Console.SetCursorPosition(windowTopX, windowTopY + line);
            Console.Write($"Мана игрока {player.ManaAmmount}");
        }
    }
}
