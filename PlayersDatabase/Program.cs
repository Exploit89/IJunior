using System;
using System.Collections.Generic;

namespace PlayersDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nicknameInput = "";
            int levelInput = 0;
            PlayersDatabase playersDatabase = new PlayersDatabase();
            Player player = new Player(nicknameInput, levelInput);

            Console.WriteLine("Введите имя");
            nicknameInput = Console.ReadLine();
            Console.WriteLine("Введите уровень");
            levelInput = Convert.ToInt32(Console.ReadLine());

            player = new Player(nicknameInput, levelInput);
            playersDatabase.AddPlayer(player);

            Console.WriteLine("Введите имя");
            nicknameInput = Console.ReadLine();
            Console.WriteLine("Введите уровень");
            levelInput = Convert.ToInt32(Console.ReadLine());

            player = new Player(nicknameInput, levelInput);
            playersDatabase.AddPlayer(player);

            //AddPlayerToDatabase(playersDatabase);
            //AddPlayerToDatabase(playersDatabase);

            playersDatabase.ShowAllPlayers(player.GetPlayerID());
            

        }

        static void AddPlayerToDatabase(PlayersDatabase playersDatabase)
        {

        }
    }

    class PlayersDatabase
    {
        private List<Player> _players;

        public PlayersDatabase()
        {
            _players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void DeletePlayer(Player player)
        {
            _players.Remove(player);
        }

        public void ShowAllPlayers(List<string> playerID)
        {
            for(int i = 0; i < _players.Count; i++)
            {
                Console.Write($"ID: {playerID[i]} - {_players[i].Nickname} - {_players[i].Level} - {_players[i].IsBanned}");
            }
        }
    }

    class Player
    {
        private List<string> _playersID;

        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public Player(string nickname, int level)
        {
            _playersID = new List<string>();
            _playersID.Add(CreatePlayerID(_playersID));
            Nickname = nickname;
            Level = level;
            IsBanned = false;
        }
        
        private string CreatePlayerID(List<string> PlayersID)
        {
            string playerID = "";
            bool isChecking = true;
            Random random = new Random();

            while (isChecking)
            {
                playerID = Convert.ToString(random.Next(0, 5000));

                if (CheckPlayerIDAvaliable(playerID, PlayersID))
                    isChecking = false;
            }

            return playerID;
        }

        private bool CheckPlayerIDAvaliable(string playerID, List<string> PlayersID)
        {
            while (PlayersID.Contains(playerID))
            {
                return false;
            }
            return true;
        }

        public List<string> GetPlayerID()
        {
            List<string> playerIDs = _playersID;
            return playerIDs;
        }
    }
}
