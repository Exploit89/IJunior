using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class BattleField
    {
        private Squad _firstSquad;
        private Squad _secondSquad;
        private Random _random = new Random();
    }

    class Squad
    {
        private List<Fighter> _fighters;
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
    }

    class Swordsman : Fighter
    {
        public Swordsman(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Swordsman);
        }
    }

    class Archer : Fighter
    {
        public Archer(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Archer);
        }
    }

    class Ninja : Fighter
    {
        public Ninja(Random random) : base(random)
        {
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Ninja);
        }
    }

    class Mechwarrior : Fighter
    {
        public Mechwarrior(Random random) : base(random)
        { 
            ClassName = Enum.GetName(typeof(FighterClassName), FighterClassName.Mechwarrior);
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
