using System;

/*
 
Доработать немного. Хорошо получилось. 
1) Renderer showPlayer = new Renderer(10, 10); - не называйте объекты с глагола. [переименовал] 
    

2) То, что умеете пользоваться разными видами определения свойства - молодец! 
    В будущем пользуйтесь лаконичными автореализуемыми свойствами :) [принял]

3) MoveTo(int x, int y) - что такое x и y?  Внесите конкретику в именование. [во всех методах переименовал по типу positionX]

4)  GetPosition(out int x, out int y) - Да и в целом вам этот метод не нужен [метод удалил, сделал свойства]
 
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
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        private int _armor = 0;
        private int _maximumArmor = 100;

        private string _name = "";

        public Player(string name, int health, int armor)
        {
            _name = name;
            Health = health;
            _armor = armor;
        }

        public int Health { get; private set; }

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

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

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
