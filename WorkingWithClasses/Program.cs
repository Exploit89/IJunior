using System;

namespace WorkingWithClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.ShowStats();
        }
    }

    class Player
    {
        private int _damage;
        private int _armor;
        private string _name;
        private int _health;

        public Player()
        {
            _damage = 50;
            _armor = 20;
            _name = "Player1";
            _health = 100;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Damage = {_damage}\n" +
                $"Armor = {_armor}\n" +
                $"Name = {_name}\n" +
                $"Health = {_health}\n");
        }
    }
}
