using System;
using System.Collections.Generic;

namespace _6_3_DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();

            application.Run();
        }
    }

    class Application
    {
        const string ShowAllEntrysCommand = "1";
        const string CreatePlayerCommand = "2";
        const string DeletePlayerCommand = "3";
        const string SetBanPlayerCommand = "4";
        const string RemoveBanPlayerCommand = "5";
        const string IncreasePlayerLevelCommand = "6";
        const string ShowPlayerCommand = "7";
        const string ExitCommand = "8";

        Database database = new Database();

        public void Run()
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
                        database.AddPlayer();
                        break;

                    case DeletePlayerCommand:
                        database.DeletePlayerById();
                        break;

                    case SetBanPlayerCommand:
                        database.BanById();
                        break;

                    case RemoveBanPlayerCommand:
                        database.UnBanById();
                        break;

                    case IncreasePlayerLevelCommand:
                        database.IncreasePlayerLevelById();
                        break;

                    case ShowPlayerCommand:
                        database.GetPlayerInfoById();
                        break;

                    case ExitCommand:
                        isMainLoopActive = !TryUserWantExit();                        
                        break;
                }

                WaitToPressKey();
            }            
        }

        private void ShowMainMenu()
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

        private void WaitToPressKey()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения.....");
            Console.ReadKey();
        }

        private bool TryUserWantExit()
        {
            string userInput;
            Console.Write("Вы хотите выйти? (n - нет, другой - да):");
            userInput = Console.ReadLine();

            if(userInput == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("До свиданья....");
                return true;
            }
        }
    }

    class Player
    {
        private static int _lastId = 0;

        public Player(string name, int level)
        {
            Name = name;
            Level = level;
            Id = ++_lastId;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; } = false;

        public static bool CheckNameIsCorrect(string name)
        {
            name = System.Text.RegularExpressions.Regex.Replace(name, @"\s+", " ");

            if (name == "" || name == " ")
            {
                Console.WriteLine("Введено не корректное имя игрока.");
                return false;
            }
            else
                return true;
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

        public void Ban()
        {
            IsBanned = true;
        }

        public void UnBan()
        {
            IsBanned = false;
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public Database()
        {
            CreatePlayerEntry("Player1", 1);
            CreatePlayerEntry("Player2", 2);
            CreatePlayerEntry("Player3", 3);
        }

        public void AddPlayer()
        {
            Console.WriteLine("Добавление нового игрока.");
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            if (Player.CheckNameIsCorrect(name))
            {
                CreatePlayerEntry(name, 1);
            }
        }

        public void ShowAllEntires()
        {
            Console.WriteLine("База данных:");

            foreach(var player in _players)
                Console.WriteLine($"id={player.Id} | {player.Name} " +
                    $"| Level = {player.Level} | Ban = {player.IsBanned}");

            Console.WriteLine();
        }

        public bool TryGetPlayerById(out Player player, int id)
        {
            player = null;

            foreach (var element in _players)
            {
                if (element.Id == id)
                {
                    player = element;
                    return true;
                }
            }

            Console.WriteLine($"Не могу удалить игрока с id = {id}");
            return false;
        }

        public void BanById()
        {
            Player player; 

            if (TryGetPlayerByInput(out player, "Снять бан с игрока."))
            {
                player.Ban();
                Console.WriteLine($"Игрок {player.Name} " +
                    $"с id= {player.Id} Установлен бан!");
            }
        }

        public void UnBanById()
        {
            Player player; 

            if (TryGetPlayerByInput(out player, "Установить БАН игрока."))
            {
                player.UnBan();
                Console.WriteLine($"Игрок {player.Name} " +
                    $"с id= {player.Id}, блокировки (бан) нет.");
            }
        }

        public void DeletePlayerById()
        {
            Player player;

            if (TryGetPlayerByInput(out player, "Удаление игрока."))
            {
                _players.Remove(player);
                Console.WriteLine($"Игрок \"{player.Name}\" " +
                                  $"с id= {player.Id} удален из базы.");
            }
            else
            {
                Console.WriteLine("Не могу найти игрока.");
            }
        }

        public void IncreasePlayerLevelById()
        {
            Player player;

            if (TryGetPlayerByInput(out player, "Увеличить уровень игрока."))
            {
                player.IncreaseLevel();
            }
        }

        public void GetPlayerInfoById()
        {
            Player player;

            if (TryGetPlayerByInput(out player, "Показать статистику игрока."))
            {
                player.ShowStats();
            }
        }

        private void CreatePlayerEntry(string name, int level)
        {
            Player player = new Player(name, 1);

            _players.Add(player);
            Console.WriteLine($"Добавлена новая запись в базу, " +
                    $"id={player.Id}, имя игрока={player.Name}");
        }

        private bool TryGetPlayerByInput(out Player player, string inputPrompt)
        {
            player = null;

            if (_players.Count == 0)
            {
                Console.WriteLine("База пуста...");
                return false;
            }

            int id;

            ShowAllEntires();
            Console.WriteLine(inputPrompt);
            Console.WriteLine("Введите id:");

            if (int.TryParse(Console.ReadLine(), out id))
            {
                if (TryGetPlayerById(out player, id))
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Введите только цыфры, не могу распознать id.");
            }

            return false;
        }
    }
}