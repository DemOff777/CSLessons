using System;
using System.Collections.Generic;

namespace Задание6_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            
            const string CommandAddPlayer = "1";
            const string CommandRemovePlayer = "2";
            const string CommandBanPlayer = "3";
            const string CommandUnbanPlayer = "4";
            const string CommandShowPlayers = "5";
            const string CommandExit = "6";

            bool isWork = true;

            while(isWork)
            {
                Console.WriteLine($"Добавить игрока - нажмите {CommandAddPlayer}");
                Console.WriteLine($"Удалить игрока - нажмите {CommandRemovePlayer}");
                Console.WriteLine($"Забанить игрока - нажмите {CommandBanPlayer}");
                Console.WriteLine($"Разбанить игрока - нажмите {CommandUnbanPlayer}");
                Console.WriteLine($"Показать всех игроков - нажмите {CommandShowPlayers}");
                Console.WriteLine($"Выход - нажмите {CommandExit}");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddPlayer:
                        database.AddPlayer();
                        break;
                    case CommandRemovePlayer:
                        database.RemovePlayerByNumber();
                        break;

                    case CommandBanPlayer:
                        database.BanPlayerByNumber();
                        break;

                    case CommandUnbanPlayer:
                        database.UnbanPlayerByNumber();
                        break;

                    case CommandShowPlayers:
                        database.ShowAllPlayers();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Неверное значение");
                        break;
                }
            }
        }
    }

    class Player
    {
        public Player(int uniqueNumber, string name, int level, bool isBanned)
        {
            UniqueNumber = uniqueNumber;
            Name = name;
            Level = level;          
            IsBanned = isBanned;       
        }

        public int UniqueNumber { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }

        public void ShowStats()
        {
            Console.Write($"ID:{UniqueNumber} Имя - {Name} Уровень - {Level}");

            if (IsBanned)
            {
                Console.WriteLine(" Состояние - забанен"); 
            }
            else
            {
                Console.WriteLine(" Состояние - разбанен");
            }
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public void ShowAllPlayers()
        {
            foreach (Player player in _players)
            {
                player.ShowStats();
            }
        }

        public void AddPlayer()
        {
            Console.WriteLine("Введите номер игрока");
            int userUniqueNumber = CheckInput();
            
            Console.WriteLine("Введите имя игрока");
            string userName = Console.ReadLine();

            Console.WriteLine("Введите уровень игрока");
            int userLevel = CheckInput();

            bool isBanned = false ;

            Player player = new Player(userUniqueNumber, userName, userLevel, isBanned);

            _players.Add(player);

            Console.WriteLine("Игрок успешно добавлен");
        }

        public void RemovePlayerByNumber()
        {
            Player player = TryGetPlayer(out player);
            _players.Remove(player);
        }

        public void BanPlayerByNumber()
        {
            Player player = TryGetPlayer(out player);
            player.Ban();
        }

        public void UnbanPlayerByNumber()
        {
            Player player = TryGetPlayer(out player);
            player.Unban();
        }

        private int CheckInput()
        {
            int userInput = 0;

            bool isConvertationCorrect = false;

            while (isConvertationCorrect == false)
            {
                isConvertationCorrect = int.TryParse(Console.ReadLine(), out userInput);

                if (isConvertationCorrect == false)
                {
                    Console.WriteLine("Неверный формат");
                }
            }

            isConvertationCorrect = false;

            return userInput;
        }       

        private Player TryGetPlayer(out Player player)
        {
            player = null;

            bool isSearchCorrect = false;

            Console.WriteLine("Введите номер игрока");
            int userUniqueNumber = CheckInput();

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[i].UniqueNumber == userUniqueNumber)
                {
                    isSearchCorrect = true;
                    player = _players[i];
                }
            }

            if (isSearchCorrect == false)
            {
                Console.WriteLine("Игрока с таким номером найти не удалось");
            }

            return player;
        }
    }
}
