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
        private List<Fighter> _chosenFighters = new List<Fighter>();
        private Random _random = new Random();

        public Coliseum()
        {
            _fighters.Add(new Mermaid(_random));
            _fighters.Add(new Bum(_random));
            _fighters.Add(new Boxer(_random));
            _fighters.Add(new BattleMage(_random));
            _fighters.Add(new MothersFriendSon(_random));
        }

        public void Open()
        {
            ChooseFighters();
            StartFight();
        }

        private void ShowAllFighters()
        {
            Console.Clear();

            foreach(var fighter in _fighters)
            {
                Console.Write($"{_fighters.IndexOf(fighter) + 1}. ");
                fighter.ShowStats();
            }

            Console.WriteLine();
        }

        private void ChooseFighters()
        {
            Console.CursorVisible = false;
            int maxChosenFighters = 2;
            bool isChoosing = true;
            int choosingCount = 0;

            while (isChoosing)
            {
                choosingCount++;
                Console.Clear();
                ShowAllFighters();
                Console.WriteLine("6. Выход.\n");

                if (choosingCount > maxChosenFighters)
                {
                    Console.Clear();
                    isChoosing = false;
                }
                else
                {
                    if (choosingCount == 1)
                        Console.WriteLine("Выберите первого бойца:");
                    else if (choosingCount == 2)
                        Console.WriteLine("Выберите второго бойца:");

                    Console.WriteLine();
                    string userInput = Console.ReadLine();
                    int.TryParse(userInput, out int number);

                    if(number < 1 || number > _fighters.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("Такого бойца нет в списке.\n Нажмите любую клавишу.");
                        Console.ReadKey();
                        choosingCount--;
                    }
                    else
                        _chosenFighters.Add(_fighters[number - 1]);
                }
            }
        }

        private void StartFight()
        {
            Fighter _firstFighter = _chosenFighters[0];
            Fighter _secondFighter = _chosenFighters[1];
            int roundsCount = 0;
            Console.WriteLine($"{_firstFighter.Name} = {_firstFighter.Health} здоровья.");
            Console.WriteLine($"{_secondFighter.Name} = {_secondFighter.Health} здоровья.\n");

            while (_firstFighter.Health > 0 && _secondFighter.Health > 0)
            {
                roundsCount++;
                _firstFighter.DoAction(roundsCount, _secondFighter);
                _secondFighter.DoAction(roundsCount, _firstFighter);
                Console.WriteLine($"{_firstFighter.Name} наносит {_secondFighter.Name} {_firstFighter.Damage - _secondFighter.Defense} урона.");
                Console.WriteLine($"{_secondFighter.Name} наносит {_firstFighter.Name} {_secondFighter.Damage - _firstFighter.Defense} урона.");
                Console.WriteLine($"У {_firstFighter.Name} осталось {_firstFighter.Health} здоровья.");
                Console.WriteLine($"У {_secondFighter.Name} осталось {_secondFighter.Health} здоровья.");
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }

    class Fighter
    {
        public float Defense { get; private set; }
        public float Damage { get; protected set; }
        public float Health { get; protected set; }
        public string ClassName { get; protected set; }
        public string Name { get; private set; }

        public Fighter(Random random)
        {
            List<string> names = new List<string>();
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

            Name = names[random.Next(names.Count)];
            Damage = random.Next(minDamage, maxDamage);
            Defense = random.Next(minDefense, maxDefense);
            Health = random.Next(minHealth, maxHealth);
        }

        public void ShowStats()
        {
            Console.WriteLine($"{ClassName} - {Name} - HP: {Health} - DMG: {Damage} - DEF: {Defense}");
        }

        public virtual void DoAction(int roundsCount, Fighter enemy)
        {
            TakeDamage(enemy.Damage);
        }

        public void TakeDamage(float damage)
        {
            Health -= damage - Defense;
        }

        public void TakeDoubleDamage(float damage)
        {
            Health -= (damage - Defense) * 2;
            Console.WriteLine($"{Name} получает двойной урон - {damage * 2}");
        }

        public void DropDefense()
        {
            Defense = 0;
        }
    }

    class MothersFriendSon : Fighter
    {
        public MothersFriendSon(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.MothersFriendSon);
        }

        override public void DoAction(int roundsCount, Fighter enemy)
        {
            if (roundsCount % 3 == 0)
            {
                CastMotherCall();
            }

            TakeDamage(enemy.Damage);
        }

        public void CastMotherCall()
        {
            Console.WriteLine($"{Name} позвонил мамочке и нажаловался. Получил подзатыльник и увеличил свой урон.");
            Damage += 15;
            Health -= 15;
        }
    }

    class BattleMage : Fighter
    {
        private int _mana = 150;

        public BattleMage(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.BattleMage);
        }

        override public void DoAction(int roundsCount, Fighter enemy)
        {
            Random random = new Random();
            int fireballCost = 50;
            int fireballMaxChance = 100;
            int fireballAllowNumber = 60;
            int firebalPossibility = random.Next(fireballMaxChance);

            if(firebalPossibility > fireballAllowNumber && _mana >= fireballCost)
            {
                _mana -= fireballCost;
                CastFireball(enemy);
            }

            TakeDamage(enemy.Damage);
        }

        public void CastFireball(Fighter enemy)
        {
            Console.WriteLine($"{Name} кастует огненный шар!");
            enemy.TakeDoubleDamage(Damage);
            Console.WriteLine($"Осталось {_mana} маны.");
        }
    }

    class Boxer : Fighter
    {
        public Boxer(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Boxer);
        }

        override public void DoAction(int roundsCount, Fighter enemy)
        {
            TakeDamage(enemy.Damage);
        }

        public void CastCyberPunch()
        {
            //TODO
        }
    }

    class Mermaid : Fighter
    {
        public Mermaid(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Mermaid);
        }

        override public void DoAction(int roundsCount, Fighter enemy)
        {
            TakeDamage(enemy.Damage);
        }

        public void CastTailSlap()
        {
            //TODO
        }
    }

    class Bum : Fighter
    {
        private int _alcoLevel = 0;

        public Bum(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Bum);
        }

        override public void DoAction(int roundsCount, Fighter enemy)
        {
            TakeDamage(enemy.Damage);
        }

        public void CastBottleHit()
        {
            //TODO
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
