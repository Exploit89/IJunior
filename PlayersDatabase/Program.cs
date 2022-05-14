using System;
using System.Collections.Generic;

namespace PlayersDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayersDatabase playersDatabase = new PlayersDatabase();
            playersDatabase.WorkingDatabase(playersDatabase);
        }
    }

    class PlayersDatabase
    {
        private Dictionary<string, Player> _playersIDs = new Dictionary<string, Player>();

        public void WorkingDatabase(PlayersDatabase playersDatabase)
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

                if (CheckNumberInput(userAnyInput))
                    userInput = Convert.ToInt32(userAnyInput);

                switch (userInput)
                {
                    case 1:
                        playersDatabase.AddPlayer();
                        break;
                    case 2:
                        playersDatabase.DeletePlayer();
                        break;
                    case 3:
                        playersDatabase.BanPlayer();
                        break;
                    case 4:
                        playersDatabase.UnbanPlayer();
                        break;
                    case 5:
                        playersDatabase.ShowAllPlayers();
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

        private bool CheckNumberInput(string userInput)
        {
            if (int.TryParse(userInput, out int number) && number >= 0 && number <= 100)
                return true;
            else
                return false;
        }

        public void AddPlayer()
        {
            int levelNumber;
            Console.Write("Введите никнейм игрока: ");
            string inputNickname = Console.ReadLine();
            Console.Write("Введите уровень игрока: ");
            string inputLevel = Console.ReadLine();

            if (CheckLevelInput(inputLevel))
            {
                levelNumber = Convert.ToInt32(inputLevel);
                Player player = new Player(inputNickname, levelNumber);
                _playersIDs.Add(player.PlayerID, player);
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

        public void DeletePlayer()
        {
            Console.Write("Введите ID игрока, которого хотите удалить: ");
            string playerID = Console.ReadLine();

            if (CheckContainsID(playerID))
            {
                _playersIDs.Remove(playerID);
                Console.Clear();
                Console.WriteLine($"Игрок с ID {playerID} успешно удалён.\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такого ID игрока не существует\n");
            }
        }

        public void BanPlayer()
        {
            Console.Write("Введите ID игрока, которого хотите забанить: ");
            string playerID = Console.ReadLine();

            if (CheckContainsID(playerID))
            {
                _playersIDs[playerID].SetBanned();
                Console.Clear();
                Console.WriteLine($"Игрок с ID {playerID} успешно забанен.\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Такого ID игрока не существует\n");
            }
        }

        public void UnbanPlayer()
        {
            Console.Write("Введите ID игрока, которого хотите разбанить: ");
            string playerID = Console.ReadLine();

            if (CheckContainsID(playerID))
            {
                _playersIDs[playerID].SetUnbanned();
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
            if (_playersIDs.ContainsKey(playerID))
                return true;
            else
                return false;
        }

        public void ShowAllPlayers()
        {
            Console.Clear();

            foreach (var item in _playersIDs)
            {
                if (item.Value.IsBanned)
                    Console.WriteLine($"ID:{item.Key} - Никнейм: {item.Value.Nickname} - Уровень: {item.Value.Level} - Статус: Забанен");
                else
                    Console.WriteLine($"ID:{item.Key} - Никнейм: {item.Value.Nickname} - Уровень: {item.Value.Level} - Статус: Активен");
            }

            Console.WriteLine();
        }
    }

    class Player
    {
        private List<string> _playersIDs = new List<string>();

        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public string PlayerID { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string nickname, int level)
        {
            Nickname = nickname;
            Level = level;
            PlayerID = CreatePlayerID();
            IsBanned = false;
        }

        private string CreatePlayerID()
        {
            string playerID = "";
            bool isChecking = true;
            Random random = new Random();

            while (isChecking)
            {
                playerID = Convert.ToString(random.Next(0, 5000));

                if (CheckPlayerIDAvaliable(playerID))
                    isChecking = false;
            }

            _playersIDs.Add(playerID);
            return playerID;
        }

        private bool CheckPlayerIDAvaliable(string playerID)
        {
            while (_playersIDs.Contains(playerID))
            {
                return false;
            }
            return true;
        }

        public void SetBanned()
        {
            IsBanned = true;
        }

        public void SetUnbanned()
        {
            IsBanned = false;
        }
    }
}
