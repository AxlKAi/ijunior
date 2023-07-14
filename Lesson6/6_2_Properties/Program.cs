using System;

/**
 * 
1 - Свойства объявляются после конструктора класса. 
2 - public int Armor - сейчас мы в любой точке программы может изменить значение, 
    данные не защищены. Свойство должно быть с приватным сеттером. 
3 - Вместо поля и свойства реализуйте одно автореализуемое свойство. 
    public int Name{get; private set;} Запись станет лаконичнее. 
 * 
 */

namespace _6_2_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("AxlUndeadMan", 99, 55);
            Renderer renderer = new Renderer(10, 10);

            player.IncreaseMana(77);
            player.MoveTo(5, 5);

            renderer.ShowPlayer(player);

            Console.ReadKey();
        }
    }

    class Player
    {
        public Player(string name, int health, int armor)
        {
            Name = name;
            Health = health;
            Armor = armor;
        }

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
        private int _windowTopX = 0;
        private int _windowTopY = 0;

        public Renderer(int windowTopLeftX, int windowTopLeftY)
        {
            _windowTopX = windowTopLeftX;
            _windowTopY = windowTopLeftY;
        }

        public void ShowPlayer(Player player)
        {
            int line = 0;
            int positionX = player.PositionX;
            int positionY = player.PositionY;

            Console.SetCursorPosition(_windowTopX, _windowTopY);
            Console.Write($"Игрок {player.Name}");

            line++;
            Console.SetCursorPosition(_windowTopX, _windowTopY + line);
            Console.Write($"Координаты X={positionX} Y={positionY}");

            line++;
            Console.SetCursorPosition(_windowTopX, _windowTopY + line);
            Console.Write($"Защита игрока {player.Armor}");

            line++;
            Console.SetCursorPosition(_windowTopX, _windowTopY + line);
            Console.Write($"Здоровье игрока {player.Health}");

            line++;
            Console.SetCursorPosition(_windowTopX, _windowTopY + line);
            Console.Write($"Мана игрока {player.ManaAmmount}");
        }
    }
}
