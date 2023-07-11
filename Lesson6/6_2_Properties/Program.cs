using System;

namespace _6_2_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("AxlUndeadMan", 99, 55);
            Renderer showPlayer = new Renderer(10, 10);

            player.IncreaseMana(77);
            player.MoveTo(5, 5);

            showPlayer.ShowPlayer(player);

            Console.ReadKey();
        }
    }

    class Player
    {
        private int _x;
        private int _y;

        public int Health { get; private set; }

        private int _armor = 0;
        private int _maximumArmor = 100;

        public int Armor
        {
            get { return _armor; }
            set
            {
                if (value < 0)
                    _armor = 0;
                else if (value > _maximumArmor)
                    _armor = _maximumArmor;
                else
                    _armor = value;
            }
        }

        private string _name = "";

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public Player(string name, int health, int armor)
        {
            _name = name;
            Health = health;
            _armor = armor;
        }

        public int ManaAmmount { get; private set; }

        public void MoveTo(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void GetPosition(out int x, out int y)
        {
            x = _x;
            y = _y;
        }

        public void IncreaseMana(int ammount)
        {
            if (ammount > 0)
                ManaAmmount += ammount;
        }
    }

    class Renderer
    {
        private int _windowX = 0;
        private int _windowY = 0;

        public Renderer(int x, int y)
        {
            _windowX = x;
            _windowY = y;
        }

        public void ShowPlayer(Player player)
        {
            int line = 0;
            int x;
            int y;

            player.GetPosition(out x, out y);

            Console.SetCursorPosition(_windowX, _windowY);
            Console.Write($"Игрок {player.Name}");

            line++;
            Console.SetCursorPosition(_windowX, _windowY + line);
            Console.Write($"Координаты X={x} Y={y}");

            line++;
            Console.SetCursorPosition(_windowX, _windowY + line);
            Console.Write($"Защита игрока {player.Armor}");

            line++;
            Console.SetCursorPosition(_windowX, _windowY + line);
            Console.Write($"Здоровье игрока {player.Health}");

            line++;
            Console.SetCursorPosition(_windowX, _windowY + line);
            Console.Write($"Мана игрока {player.ManaAmmount}");
        }
    }
}
