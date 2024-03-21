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
        const string CancelExitKey = "n";

        public void Run()
        {
            Database database = new Database();
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
                        database.SetBanById(true);
                        break;

                    case RemoveBanPlayerCommand:
                        database.SetBanById(false);
                        break;

                    case IncreasePlayerLevelCommand:
                        database.IncreasePlayerLevelById();
                        break;

                    case ShowPlayerCommand:
                        database.GetPlayerInfoById();
                        break;

                    case ExitCommand:
                        if (TryUserWantExit())
                            isMainLoopActive = false;
                        break;
                }

                WaitToPressKey();
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"{ShowAllEntrysCommand}. Показать всю базу.");
            Console.WriteLine($"{CreatePlayerCommand}. Создать игрока.");
            Console.WriteLine($"{DeletePlayerCommand}. Удалить игрока.");
            Console.WriteLine($"{SetBanPlayerCommand}. Дать бан игроку.");
            Console.WriteLine($"{RemoveBanPlayerCommand}. Снять бан у игрока.");
            Console.WriteLine($"{IncreasePlayerLevelCommand}. Увеличить уровень игрока.");
            Console.WriteLine($"{ShowPlayerCommand}. Показать статистику игрока.");
            Console.WriteLine($"{ExitCommand}. Выход.");
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
            Console.Write($"Вы хотите выйти? ({CancelExitKey} - нет, другой - да):");
            userInput = Console.ReadLine();

            if (userInput == CancelExitKey)
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

        public void Unban()
        {
            IsBanned = false;
        }
    }

    class PlayerUtils
    {
        public static bool IsNameCorrect(string name)
        {
            name = System.Text.RegularExpressions.Regex.Replace(name, @"\s+", " ");

            if (name == "" || name == " ")
            {
                Console.WriteLine("Введено не корректное имя игрока.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public Database()
        {
            AddPlayer("Player1", 1);
            AddPlayer("Player2", 2);
            AddPlayer("Player3", 3);
        }

        public void AddPlayer(string name = "", int level = 1)
        {
            Console.WriteLine("Добавление нового игрока.");
            Console.WriteLine("Введите имя:");

            if (name == "")
                name = Console.ReadLine();

            if (PlayerUtils.IsNameCorrect(name))
            {
                Player player = new Player(name, level);

                _players.Add(player);
                Console.WriteLine($"Добавлена новая запись в базу, " +
                        $"id={player.Id}, имя игрока={player.Name}");
            }
            else
            {
                Console.WriteLine($"Указанно не корректное имя игрока = {name}");
                Console.WriteLine("Запись в базу данных не сделана.");
            }
        }

        public void ShowAllEntires()
        {
            Console.WriteLine("База данных:");

            foreach (var player in _players)
                Console.WriteLine($"id={player.Id} | {player.Name} " +
                    $"| Level = {player.Level} | Ban = {player.IsBanned}");

            Console.WriteLine();
        }

        public void SetBanById(bool isBan)
        {
            Player player;

            if (TryGetPlayerByInput(out player, $"Установить бан={isBan} для игрока."))
            {
                if (isBan == true)
                    player.Ban();
                else
                    player.Unban();

                Console.WriteLine($"Игрок {player.Name} " +
                    $"с id= {player.Id} состояние ban = {player.IsBanned}");
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
                foreach (var element in _players)
                {
                    if (element.Id == id)
                    {
                        player = element;
                        return true;
                    }
                }

                Console.WriteLine($"Не могу найти игрока с id = {id}");
            }
            else
            {
                Console.WriteLine("Введите только цыфры, не могу распознать id.");
            }

            return false;
        }
    }
}