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
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Armor { get; private set; }

        public Player(string name, int health, int armor=0)
        {
            Name = name;
            Health = health;
            Armor = armor;
        }

        public void ShowStatistics()
        {
            Console.WriteLine($"Player name: {Name}");
            Console.WriteLine($"Player heath: {Health}");
            Console.WriteLine($"Player armor: {Armor}");
        }
    }
}
