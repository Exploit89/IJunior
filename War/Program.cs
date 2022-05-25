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
    }

    class Squad
    {
        private List<Fighter> _fighters;
    }

    class Fighter
    {

    }

    class Swordsman : Fighter
    {

    }

    class Archer : Fighter
    {

    }

    class Ninja : Fighter
    {

    }

    class Mechwarrior : Fighter
    {

    }
}
