using System;
using System.Collections.Generic;

namespace PlayersDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class PlayersDatabase
    {
        private List<Player> _players;

        public PlayersDatabase(List<Player> players)
        {
            _players = players;
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public void DeletePlayer(Player player)
        {
            _players.Remove(player);
        }
    }

    class Player
    {
        private List<string> _playersID;
        private string _nickname;
        private int _level;
        private bool _isBanned;

        public Player(string nickname, int level, bool isBanned)
        {
            _playersID.Add(CreatePlayerID(_playersID));
            _nickname = nickname;
            _level = level;
            _isBanned = isBanned;
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

        public Player GetPlayer(string playerID, List<string> playersID, Player player)
        {
            for(int i = 0; i < playersID.Count; i++)
            {
                if (playersID[i] == playerID)
                {
                    return player[i];
                }
            }
        }
    }
}
