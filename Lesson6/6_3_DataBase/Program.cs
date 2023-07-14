using System;
using System.Collections.Generic;

namespace _6_3_DataBase
{
    class Program
    {
        const string ShowAllEntrysCommand = "1";
        const string CreatePlayerCommand = "2";
        const string DeletePlayerCommand = "3";
        const string SetBanPlayerCommand = "4";
        const string RemoveBanPlayerCommand = "5";
        const string IncreasePlayerLevelCommand = "6";
        const string ShowPlayerCommand = "7";
        const string ExitCommand = "8";

        static Database database;

        static void Main(string[] args)
        {
            database = new Database();

            MainLoop();
        }

        static void WaitToPressKey()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения.....");
            Console.ReadKey();
        }

        static void MainLoop()
        {
            int id;
            Player player;
            bool isMainLoopActive = true;

            while (isMainLoopActive)
            {
                ShowMainMenu();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ShowAllEntrysCommand:
                        database.ShowAllEntires();
                        break;

                    case CreatePlayerCommand:
                        Console.WriteLine("Добавление нового игрока.");
                        Console.WriteLine("Введите имя:");
                        string name = Console.ReadLine();
                        database.AddPlayer(new Player(name, 1));
                        break;

                    case DeletePlayerCommand:
                        database.ShowAllEntires();
                        Console.WriteLine("Удаление игрока.");
                        Console.WriteLine("Введите id:");

                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            database.DeletePlayerById(id);
                        }
                        else
                        {
                            Console.WriteLine("Не могу распознать. Введите только цифры.");
                        }

                        break;

                    case SetBanPlayerCommand:
                        database.ShowAllEntires();
                        Console.WriteLine("Установить БАН игрока.");
                        Console.WriteLine("Введите id:");

                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            database.SetBanById(id);
                        }

                        break;

                    case RemoveBanPlayerCommand:
                        database.ShowAllEntires();
                        Console.WriteLine("Снять бан с игрока.");
                        Console.WriteLine("Введите id:");

                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            database.RemoveBanById(id);
                        }

                        break;


                    case IncreasePlayerLevelCommand:
                        database.ShowAllEntires();
                        Console.WriteLine("Увеличить уровень игрока.");
                        Console.WriteLine("Введите id:");

                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            if (database.TryGetPlayerById(out player, id))
                            {
                                player.IncreaseLevel();
                            }
                        }

                        break;

                    case ShowPlayerCommand:
                        database.ShowAllEntires();
                        Console.WriteLine("Показать статистику игрока.");
                        Console.WriteLine("Введите id:");

                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            if (database.TryGetPlayerById(out player, id))
                            {
                                player.ShowStats();
                            }
                        }

                        break;

                    case ExitCommand:
                        isMainLoopActive = false;
                        break;
                }

                WaitToPressKey();
            }
        }

        static void ShowMainMenu()
        {
            string showAllEntrys = "Показать всю базу.";
            string createPlayer = "Создать игрока.";
            string deletePlayer = "Удалить игрока.";
            string setBanPlayer = "Дать бан игроку.";
            string removeBanPlayer = "Снять бан у игрока.";
            string increasePlayerLevel = "Увеличить уровень игрока.";
            string showPlayer = "Показать статистику игрока.";
            string exitMenuText = "Выход.";

            Console.Clear();
            Console.WriteLine($"{ShowAllEntrysCommand}. {showAllEntrys}");
            Console.WriteLine($"{CreatePlayerCommand}. {createPlayer}");
            Console.WriteLine($"{DeletePlayerCommand}. {deletePlayer}");
            Console.WriteLine($"{SetBanPlayerCommand}. {setBanPlayer}");
            Console.WriteLine($"{RemoveBanPlayerCommand}. {removeBanPlayer}");
            Console.WriteLine($"{IncreasePlayerLevelCommand}. {increasePlayerLevel}");
            Console.WriteLine($"{ShowPlayerCommand}. {showPlayer}");
            Console.WriteLine($"{ExitCommand}. {exitMenuText}");
            Console.WriteLine();
        }
    }

    class Player
    {
        public Player(string name, int level)
        {
            Name = name;
            Level = level;
            Id = 0;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; } = false;

        public void ChangeId(int id)
        {
            Id = id;
        }

        public void IncreaseLevel()
        {
            if (IsBanned)
            {
                Console.WriteLine("Игрок забанен, и не может увеличить уровень.");
                return;
            }

            Level++;
            Console.WriteLine($"===> Player \"{Name}\" is increase level, up to {Level}.");
        }

        public void ShowStats()
        {
            Console.WriteLine("Статистика игрока:");
            Console.WriteLine($"---| {Name} *Lvl-{Level}* |---");
            Console.WriteLine($"Player id = {Id}");

            if (IsBanned)
            {
                Console.WriteLine("Player is banned !!!");
            }
            else
            {
                Console.WriteLine("Игрок не имеет блокировок.");
            }

            Console.WriteLine();
        }

        public void SetBan()
        {
            IsBanned = true;
        }

        public void RemoveBan()
        {
            IsBanned = false;
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        private int _lastPlayerId = 0;

        public Database()
        {
            Player player1 = new Player("Player 1", 1);
            Player player2 = new Player("Player 2", 2);
            Player player3 = new Player("Player 3", 3);

            this.AddPlayer(player1);
            this.AddPlayer(player2);
            this.AddPlayer(player3);
        }

        public void AddPlayer(Player player)
        {
            if (player == null)
                return;

            if (_players.Contains(player))
            {
                Console.WriteLine("Данный игрок уже находится в базе.");
                return;
            }

            player.ChangeId(++_lastPlayerId);
            _players.Add(player);
            Console.WriteLine($"Добавлена новая запись в базу, " +
                    $"id={player.Id}, имя игрока={player.Name}");
        }

        public void ShowAllEntires()
        {
            Console.WriteLine("База данных:");

            for (int i = 0; i < _players.Count; i++)
            {
                Console.WriteLine($"[{i}] {_players[i].Id} | {_players[i].Name} " +
                    $"| Level = {_players[i].Level} | Ban = {_players[i].IsBanned}");
            }

            Console.WriteLine();
        }

        public bool TryGetPlayerById(out Player player, int id)
        {
            int index = FindIndexOfId(id);

            if (index >= 0)
            {
                player = _players[index];
                return true;
            }
            else
            {
                Console.WriteLine($"Игрок с id={id} не найден.");
                player = null;
                return false;
            }
        }

        public void SetBanById(int id)
        {
            int index = FindIndexOfId(id);

            if (index >= 0)
            {
                _players[index].SetBan();
                Console.WriteLine($"Игрок {_players[index].Name} " +
                    $"с id= {_players[index].Id} Установлен бан!");
            }
        }

        public void RemoveBanById(int id)
        {
            int index = FindIndexOfId(id);

            if (index >= 0)
            {
                _players[index].RemoveBan();
                Console.WriteLine($"Игрок {_players[index].Name} " +
                    $"с id= {_players[index].Id}, блокировки (бан) нет.");
            }
        }

        public void DeletePlayerById(int id)
        {
            int index = FindIndexOfId(id);

            if (index >= 0)
            {
                Console.WriteLine($"Игрок \"{_players[index].Name}\" " +
                    $"с id= {_players[index].Id} удален из базы.");
                _players.RemoveAt(index);
            }
            else
            {
                Console.WriteLine($"Не могу удалить игрока с id = {id}");
            }
        }

        private int FindIndexOfId(int id)
        {
            int index = -1;

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == id)
                {
                    return i;
                }
            }

            Console.WriteLine($"Не могу найти игрока с id = {id}");

            return index;
        }
    }
}
