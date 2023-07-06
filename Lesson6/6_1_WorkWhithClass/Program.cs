using System;

namespace _6_1_WorkWhithClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("AxlUndeadmen", 100, 10);
            player.ShowStatistics();
            Console.ReadKey();
        }
    }

    class Player
    {
        private string _name;
        private int _health;
        private int _armor;

        public Player(string name, int health, int armor)
        {
            _name = name;
            _health = health;
            _armor = armor;
        }

        public void ShowStatistics()
        {
            Console.WriteLine($"Player name: {_name}");
            Console.WriteLine($"Player heath: {_health}");
            Console.WriteLine($"Player armor: {_armor}");
        }
    }
}
