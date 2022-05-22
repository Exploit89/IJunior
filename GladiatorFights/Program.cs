using System;
using System.Collections.Generic;

namespace GladiatorFights
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coliseum coliseum = new Coliseum();
            coliseum.Open();
        }
    }

    class Coliseum
    {
        private List<Fighter> _fighters = new List<Fighter>();

        public void Open()
        {
            bool isOpen = true;
            int fightersCount = 0;

            while (isOpen)
            {

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    default:
                        break;
                }
            }
        }
    }

    class Fighter
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;

        public string ClassName { get; protected set; }

        public Fighter()
        {
            List<string> names = new List<string>();
            Random random = new Random();
            int minHealth = 100;
            int maxHealth = 300;
            int minDamage = 10;
            int maxDamage = 30;
            int minDefense = 0;
            int maxDefense = 10;

            foreach (var name in Enum.GetNames(typeof(FighterName)))
            {
                names.Add(name);
            }

            _name = names[random.Next(names.Count)];
            _health = random.Next(minHealth, maxHealth);
            _damage = random.Next(minDamage, maxDamage);
            _defense = random.Next(minDefense, maxDefense);
        }

        public void ShowStats()
        {
            Console.WriteLine($"{_name} - HP: {_health} - DMG: {_damage} - DEF: {_defense}");
        }

        public void TakeDamage(float damage)
        {
            _health -= damage - _defense;
        }

        private void CreateStats()
        {

        }
    }

    class MothersFriendSon : Fighter
    {
        public MothersFriendSon() : base()
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.MothersFriendSon);
        }
    }

    class BattleMage : Fighter
    {
        private int _mana;

        public BattleMage()
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.BattleMage);
        }

        public void CastFireball()
        {

        }
    }

    class Boxer : Fighter
    {
        public Boxer() : base()
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Boxer);
        }
    }

    class Mermaid : Fighter
    {
        public Mermaid() : base()
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Mermaid);
        }
    }

    class Bum : Fighter
    {
        private int _alcoLevel;

        public Bum() : base()
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Bum);
        }
    }

    enum FighterName
    {
        Amanda,
        Greg,
        Terminator,
        Goga,
        Ivan,
        Chuma,
        Bobik
    }

    enum FighterClassName
    {
        MothersFriendSon,
        BattleMage,
        Boxer,
        Mermaid,
        Bum
    }
}
