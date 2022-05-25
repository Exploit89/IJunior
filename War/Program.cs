using System;
using System.Collections.Generic;

namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleField battlefield = new BattleField();
            battlefield.Fight();
        }
    }

    class BattleField
    {
        private Squad _firstSquad;
        private Squad _secondSquad;
        private Random _random = new Random();

        public BattleField()
        {
            _firstSquad = new Squad("Взвод_1", _random);
            _secondSquad = new Squad("Взвод_2", _random);
        }

        public void Fight()
        {
            _firstSquad.ShowSquad();
            _secondSquad.ShowSquad();
            Console.WriteLine("Бой начинается. Нажмите любую клавишу!");
            Console.ReadKey();

            while (_firstSquad.GetAllFighters().Count > 0 && _secondSquad.GetAllFighters().Count > 0)
            {
                Console.Clear();
                _firstSquad.ShowSquad();
                _secondSquad.ShowSquad();

                int firstIndex = _random.Next(0, _firstSquad.GetAllFighters().Count);
                int secondIndex = _random.Next(0, _secondSquad.GetAllFighters().Count);
                int target;

                target = _firstSquad.GetRandomTarget(_random, _secondSquad);
                _firstSquad.GetFighter(firstIndex).DoAction(target, _secondSquad);

                target = _secondSquad.GetRandomTarget(_random, _secondSquad);
                _secondSquad.GetFighter(secondIndex).DoAction(target, _firstSquad);

                RemoveFighter(_firstSquad, firstIndex);
                RemoveFighter(_secondSquad, secondIndex);
                Console.ReadKey();
            }

            if (_firstSquad.GetAllFighters().Count == 0 && _secondSquad.GetAllFighters().Count == 0)
                Console.WriteLine("\nНичья! Взводы поубивали друг-друга.");
            else if (_firstSquad.GetAllFighters().Count == 0)
                Console.WriteLine($"\nПобеда досталась {_secondSquad.Name}");
            else
                Console.WriteLine($"\nПобеда досталась {_firstSquad.Name}");
        }

        private void RemoveFighter(Squad squad, int index)
        {
            if (squad.GetFighter(index).Health == 0)
                squad.RemoveFighter(index);
        }
    }

    class Squad
    {
        private List<Fighter> _fighters;

        public string Name { get; private set; }

        public Squad(string name, Random random)
        {
            Name = name;
            _fighters = new List<Fighter>();
            _fighters.Add(new Swordsman(random));
            _fighters.Add(new Archer(random));
            _fighters.Add(new Ninja(random));
            _fighters.Add(new Mechwarrior(random));
        }

        public void ShowSquad()
        {
            Console.WriteLine($"{Name}:");

            foreach (var fighter in _fighters)
                Console.WriteLine($"{fighter.Name} - {fighter.ClassName} - {fighter.Damage} - {fighter.Health}");

            Console.WriteLine();
        }

        public Fighter GetFighter(int index)
        {
            List<Fighter> fighters = new List<Fighter>();

            foreach (var fighter in _fighters)
                fighters.Add(fighter);

            return fighters[index];
        }

        public List<Fighter> GetAllFighters()
        {
            List<Fighter> fighters = new List<Fighter>();

            foreach (var fighter in _fighters)
                fighters.Add(fighter);

            return fighters;
        }

        public int GetRandomTarget(Random random, Squad squad)
        {
            return random.Next(squad.GetAllFighters().Count);
        }

        public void RemoveFighter(int index)
        {
            _fighters.RemoveAt(index);
        }
    }

    class Fighter
    {
        public string Name { get; private set; }
        public string ClassName { get; protected set; }
        public float Damage { get; protected set; }
        public float Health { get; protected set; }

        public Fighter(Random random)
        {
            List<string> names = new List<string>();
            int minHealth = 100;
            int maxHealth = 300;
            int minDamage = 10;
            int maxDamage = 25;

            foreach (var name in Enum.GetNames(typeof(FighterName)))
                names.Add(name);

            Name = names[random.Next(names.Count)];
            Damage = random.Next(minDamage, maxDamage);
            Health = random.Next(minHealth, maxHealth);
        }

        public void TakeDamage(float damage)
        {
            if (Health < damage)
            {
                Health = 0;
                Console.WriteLine($"{Name}, {ClassName} погибает.");
            }
            else
            {
                Health -= damage;
                Console.WriteLine($"{Name}, {ClassName} получил {damage} урона.");
            }
        }

        public virtual void DoAction(int index, Squad squad)
        {
            squad.GetFighter(index).TakeDamage(Damage);
        }
    }

    class Swordsman : Fighter
    {
        public Swordsman(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Swordsman);
        }

        public override void DoAction(int index, Squad squad)
        {
            int tooLowHealth = 50;
            if (Health < tooLowHealth)
                Slash(index, squad);
            else
                base.DoAction(index, squad);
        }

        private void Slash(int index, Squad squad)
        {
            int slashDamage = 20;
            Damage += slashDamage;
            Console.WriteLine($"{Name} отрубает конечность {squad.GetFighter(index).Name}'у.");
            squad.GetFighter(index).TakeDamage(Damage);
            Damage -= slashDamage;
        }
    }

    class Archer : Fighter
    {
        private int _attackCount = 0;

        public Archer(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Archer);
        }

        public override void DoAction(int index, Squad squad)
        {
            _attackCount++;

            if (_attackCount % 3 == 0)
                SpeedUp(index, squad);
            else
                base.DoAction(index, squad);
        }

        private void SpeedUp(int index, Squad squad)
        {
            int boostNumber = 10;
            Damage += boostNumber;
            Health += boostNumber;
            Console.WriteLine($"{Name} пьёт энергетик и ускоряется. Увеличился урон и здоровье.");
            squad.GetFighter(index).TakeDamage(Damage);
        }
    }

    class Ninja : Fighter
    {
        public Ninja(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Ninja);
        }

        public override void DoAction(int index, Squad squad)
        {
            if (squad.GetFighter(index).ClassName == Enum.GetName(typeof(FighterClassName), FighterClassName.Archer))
                Assassinate(index, squad);
            else
                base.DoAction(index, squad);
        }

        private void Assassinate(int index, Squad squad)
        {
            int boostNumber = 1000;
            Damage += boostNumber;
            Console.WriteLine($"{Name} перерезает горло лучнику {squad.GetFighter(index).Name}.");
            squad.GetFighter(index).TakeDamage(Damage);
            Damage -= boostNumber;
        }
    }

    class Mechwarrior : Fighter
    {
        private int _actionCount = 0;

        public Mechwarrior(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Mechwarrior);
        }

        public override void DoAction(int index, Squad squad)
        {
            _actionCount++;
            int dangerActionCount = 5;

            if (squad.GetAllFighters().Count > 2 && _actionCount == dangerActionCount)
                Overload(index, squad);
            else
                base.DoAction(index, squad);
        }

        private void Overload(int index, Squad squad)
        {
            int boostHealth = 100;
            int boostDamage = 30;
            Health += boostHealth;
            Damage += boostDamage;
            Console.WriteLine($"{Name} активирует перегрузку. Восстановление и усиление обшивки корпуса и урона.");
            squad.GetFighter(index).TakeDamage(Damage);
        }
    }

    enum FighterName
    {
        Alpha,
        Bravo,
        Charlie,
        Delta,
        Ibragim,
        Gamma,
        Theta,
        Sigma,
        Kappa,
        Omega,
        Upsilon,
        Zeta,
        Eta,
        Kotleta
    }

    enum FighterClassName
    {
        Swordsman,
        Archer,
        Ninja,
        Mechwarrior
    }
}
