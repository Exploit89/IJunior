using System;
using System.Collections.Generic;

namespace PlayersDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayersDatabase playersDatabase = new PlayersDatabase();
            playersDatabase.Work();
        }
    }

    class PlayersDatabase
    {
        private Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public void Work()
        {
            bool isWorking = true;
            string userAnyInput;
            int userInput = 0;

            while (isWorking)
            {
                Console.WriteLine("База данных игроков\n\n" +
                    "Меню:\n" +
                    "1 - Добавить игрока\n" +
                    "2 - Удалить игрока\n" +
                    "3 - Забанить игрока\n" +
                    "4 - Разбанить игрока\n" +
                    "5 - Показать всех игроков\n" +
                    "6 - Выход");
                userAnyInput = Console.ReadLine();

                if (isNumber(userAnyInput))
                    userInput = Convert.ToInt32(userAnyInput);

                switch (userInput)
                {
                    case 1:
                        AddPlayer();
                        break;
                    case 2:
                        DeletePlayer();
                        break;
                    case 3:
                        BanPlayer();
                        break;
                    case 4:
                        UnbanPlayer();
                        break;
                    case 5:
                        ShowAllPlayers();
                        break;
                    case 6:
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует. Попробуйте снова.\n");
                        break;
                }
            }
        }

        private bool isNumber(string userInput)
        {
            int maximumLevel = 100;
            return int.TryParse(userInput, out int number) && number >= 0 && number <= maximumLevel;
        }

        private void AddPlayer()
        {
            int levelNumber;
            Console.Write("Введите никнейм игрока: ");
            string inputNickname = Console.ReadLine();
            Console.Write("Введите уровень игрока: ");
            string inputLevel = Console.ReadLine();

            if (CheckLevelInput(inputLevel))
            {
                levelNumber = Convert.ToInt32(inputLevel);
                string playerID = CreatePlayerID();
                Player player = new Player(inputNickname, levelNumber, playerID);
                _players.Add(player.PlayerID, player);
                Console.Clear();
                Console.WriteLine($"Игрок {inputNickname} {inputLevel} уровня успешно добавлен.\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Введен некорректный уровень\n" +
                    "Требуется ввести целое число от 0 до 100\n");
            }
        }

        private bool CheckLevelInput(string inputLevel)
        {
            if (int.TryParse(inputLevel, out int number) && number >= 0 && number <= 100)
                return true;
            else
                return false;
        }

        private void DeletePlayer()
        {
            Console.Write("Введите ID игрока, которого хотите удалить: ");
            string playerID = Console.ReadLine();

            if (CheckContainsID(playerID))
            {
                _players.Remove(playerID);
                Console.Clear();
                Console.WriteLine($"Игрок с ID {playerID} успешно удалён.\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такого ID игрока не существует\n");
            }
        }

        private void BanPlayer()
        {
            Console.Write("Введите ID игрока, которого хотите забанить: ");
            string playerID = Console.ReadLine();

            if (CheckContainsID(playerID))
            {
                _players[playerID].Ban();
                Console.Clear();
                Console.WriteLine($"Игрок с ID {playerID} успешно забанен.\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такого ID игрока не существует\n");
            }
        }

        private void UnbanPlayer()
        {
            Console.Write("Введите ID игрока, которого хотите разбанить: ");
            string playerID = Console.ReadLine();

            if (CheckContainsID(playerID))
            {
                _players[playerID].Unban();
                Console.Clear();
                Console.WriteLine($"Игрок с ID {playerID} успешно разбанен.\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такого ID игрока не существует\n");
            }
        }

        private bool CheckContainsID(string playerID)
        {
            if (_players.ContainsKey(playerID))
                return true;
            else
                return false;
        }

        private void ShowAllPlayers()
        {
            Console.Clear();

            foreach (var item in _players)
            {
                if (item.Value.IsBanned)
                    Console.WriteLine($"ID:{item.Key} - Никнейм: {item.Value.Nickname} - Уровень: {item.Value.Level} - Статус: Забанен");
                else
                    Console.WriteLine($"ID:{item.Key} - Никнейм: {item.Value.Nickname} - Уровень: {item.Value.Level} - Статус: Активен");
            }

            Console.WriteLine();
        }

        private string CreatePlayerID()
        {
            string playerID = "";
            bool isChecking = true;
            Random random = new Random();

            while (isChecking)
            {
                playerID = Convert.ToString(random.Next(0, 5000));

                if (IsPlayerIDAvaliable(playerID))
                    isChecking = false;
            }

            return playerID;
        }

        private bool IsPlayerIDAvaliable(string playerID)
        {
            while (_players.ContainsKey(playerID))
            {
                return false;
            }
            return true;
        }
    }

    class Player
    {
        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public string PlayerID { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string nickname, int level, string playerID)
        {
            Nickname = nickname;
            Level = level;
            PlayerID = playerID;
            IsBanned = false;
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
}
