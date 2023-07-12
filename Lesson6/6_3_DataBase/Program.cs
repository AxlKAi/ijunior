using System;
using System.Collections.Generic;

namespace _6_3_DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            Player player1 = dataBase.GetPlayerById(7);
            Player player4 = new Player("Player 4", 4);

            player1 = dataBase.GetPlayerById(1);

            dataBase.ShowAllWrites();

            player1?.ShowPlayerStats();
            player1?.IncreaseLevel();
            player1?.IncreaseLevel();
            player1?.SetBan(true);
            player1?.ShowPlayerStats();
            dataBase.SavePlayer(player1);
            player1?.SetBan(false);
            Console.WriteLine("Уберем бан с player1, но не будем записывать в базу." +
                " Убедимся что объекты игрока и запись в базе не связана.");
            
            dataBase.SavePlayer(player4);
            dataBase.SetBanStateById(4, true);
            dataBase.SetBanStateById(4, false);

            dataBase.DeletePlayerById(2);
            dataBase.DeletePlayerById(7);

            dataBase.ShowAllWrites();

            Console.ReadKey();
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

        public Player(Player player)
        {
            Name = player.Name;
            Level = player.Level;
            Id = player.Id;
            IsBanned = player.IsBanned;
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

        public void ShowPlayerStats()
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
                Console.WriteLine("Player is active.");
            }

            Console.WriteLine();
        }

        public void SetBan(bool state)
        {
            IsBanned = state;
        }
    }

    class DataBase
    {
        private List<Player> _players = new List<Player>();

        public DataBase()
        {
            Player player1 = new Player("Player 1", 1);
            Player player2 = new Player("Player 2", 2);
            Player player3 = new Player("Player 3", 3);

            this.SavePlayer(player1);
            this.SavePlayer(player2);
            this.SavePlayer(player3);
        }

        public void SavePlayer(Player player)
        {
            if (player == null)
                return;

            Player clonePlayer = new Player(player);

            if (clonePlayer.Id == 0)
            {
                int id = GetLastId() + 1;
                clonePlayer.ChangeId(id);
                player.ChangeId(id);
                _players.Add(clonePlayer);
                Console.WriteLine($"Добавлена новая запись в базу, " +
                    $"id={clonePlayer.Id}, имя игрока={clonePlayer.Name}");
            }
            else
            {
                RewriteEntry(clonePlayer);
            }
        }

        private void RewriteEntry(Player player)
        {
            int index = IndexOfId(player.Id);

            if (index >= 0)
            {
                _players[index] = player;
                Console.WriteLine($"Обновлена запись базы index={index}, " +
                    $"игрок id={player.Id}, имя игрока={player.Name}");
            }
            else
            {
                Console.WriteLine("Не могу найти игрока по id");
            }
        }

        private int IndexOfId(int id)
        {
            int index = -1;

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].Id == id)
                {
                    return i;
                }
            }

            return index;
        }

        public int GetLastId()
        {
            int lastId = 0;

            foreach (Player player in _players)
                if (player.Id > lastId)
                    lastId = player.Id;

            return lastId;
        }

        public void ShowAllWrites()
        {
            Console.WriteLine("База данных:");

            for (int i = 0; i < _players.Count; i++)
            {
                Console.WriteLine($"[{i}] {_players[i].Id} | {_players[i].Name} " +
                    $"| Level = {_players[i].Level} | Ban = {_players[i].IsBanned}");
            }

            Console.WriteLine();
        }

        public Player GetPlayerById(int id)
        {
            int index = IndexOfId(id);

            if (index >= 0)
            {
                Player player = new Player(_players[index]);
                return player;
            }
            else
            {
                Console.WriteLine($"Игрок с id={id} не найден.");
                return null;
            }
        }

        public void SetBanStateById(int id, bool isBanned)
        {
            int index = IndexOfId(id);

            if (index >= 0)
            {
                _players[index].SetBan(isBanned);
                Console.WriteLine($"Игрок {_players[index].Name} " +
                    $"с id= {_players[index].Id} Бан={_players[index].IsBanned}.");
            }
            else
            {
                Console.WriteLine($"Не могу найти игрока с id = {id}");
            }
        }

        public void DeletePlayerById(int id)
        {
            int index = IndexOfId(id);

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
    }
}
