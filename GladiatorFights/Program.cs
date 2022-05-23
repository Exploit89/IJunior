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

        public Coliseum()
        {
            _fighters.Add(new Mermaid());
            _fighters.Add(new Bum());
            _fighters.Add(new Boxer());
            _fighters.Add(new BattleMage());
            _fighters.Add(new MothersFriendSon());
        }

        public void Open()
        {
            bool isOpen = true;
            int fightersCount = 0;

            while (isOpen)
            {
                Console.WriteLine("Меню:\n" +
                    "1. Показать бойцов.\n" +
                    "2. Выбрать бойцов для арены.\n" +
                    "3. Начать бой.\n" +
                    "4. Выход.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllFighters();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        isOpen = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShowAllFighters()
        {
            foreach(var fighter in _fighters)
            {
                fighter.ShowStats();
            }
        }
    }

    class Fighter
    {
        private string _name;
        private float _damage;
        private float _defense;

        public float Health { get; private set; }
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
            _damage = random.Next(minDamage, maxDamage);
            _defense = random.Next(minDefense, maxDefense);
            Health = random.Next(minHealth, maxHealth);
        }

        public void ShowStats()
        {
            Console.WriteLine($"{ClassName} - {_name} - HP: {Health} - DMG: {_damage} - DEF: {_defense}");
        }

        public void TakeDamage(float damage)
        {
            Health -= damage - _defense;
        }
    }

    class MothersFriendSon : Fighter
    {
        public MothersFriendSon() : base()
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.MothersFriendSon);
        }

        public void CastMotherCall()
        {

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

        public void CastCyberPunch()
        {

        }
    }

    class Mermaid : Fighter
    {
        public Mermaid() : base()
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Mermaid);
        }

        public void CastTailSlap()
        {

        }
    }

    class Bum : Fighter
    {
        private int _alcoLevel;

        public Bum() : base()
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Bum);
        }

        public void CastBottleHit()
        {

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
