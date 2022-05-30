using System;
using System.Collections.Generic;
using System.Linq;

namespace TopServerPlayers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Open();
        }
    }

    class Server
    {
        private List<Player> _players;
        private Random _random = new Random();

        public Server()
        {
            int maxLevel = 101;
            int maxPower = 300;
            _players = new List<Player>();
            _players.Add(new Player("Balalaka", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("Pes", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("Drudnik", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("artyRus", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("God19218", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("_killer2012", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("invalid", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("groomBox", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("qwerty123", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("TaokaNomakami", _random.Next(maxLevel), _random.Next(maxPower)));
            _players.Add(new Player("kasjdfnas", _random.Next(maxLevel), _random.Next(maxPower)));
        }

        public void Open()
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine(" \nМеню:" +
                    " \n1. Топ-3 по уровню" +
                    " \n2. Топ-3 по силе" +
                    " \n3. Все игроки" +
                    " \n4. Выход\n");
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.D1:
                        ShowTopByLevel();
                        break;
                    case ConsoleKey.D2:
                        ShowTopByPower();
                        break;
                    case ConsoleKey.D3:
                        ShowAllPlayers();
                        break;
                    case ConsoleKey.D4:
                        isOpen = false;
                        break;
                    default:
                        ShowDefaultMessage();
                        break;
                }
            }
        }

        private void ShowTopByLevel()
        {
            Console.Clear();
            Console.WriteLine("Топ-3 по уровню: ");
            var sortedPlayers = _players.OrderByDescending(player => player.Level).Take(3);

            foreach (var player in sortedPlayers)
                Console.WriteLine($"{player.Name}. Уровень: {player.Level}. Сила: {player.Power}");
        }

        private void ShowTopByPower()
        {
            Console.Clear();
            Console.WriteLine("Топ-3 по силе: ");
            var sortedPlayers = _players.OrderByDescending(player => player.Power).Take(3);

            foreach (var player in sortedPlayers)
                Console.WriteLine($"{player.Name}. Уровень: {player.Level}. Сила: {player.Power}");
        }

        private void ShowAllPlayers()
        {
            Console.Clear();
            Console.WriteLine("Все игроки: ");

            foreach (var player in _players)
                Console.WriteLine($"{player.Name}. Уровень: {player.Level}. Сила: {player.Power}");
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды не существует.");
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }
    }
}
