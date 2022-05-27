using System;
using System.Collections.Generic;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Garage
    {
        private Dictionary<Breakdown, SparePart> _breakdownSpareParts;
        private Dictionary<Breakdown, int> _breakdownRepairCosts;
        private Dictionary<SparePart, int> _sparePartsCosts;
        private Random _random = new Random();

        public Garage()
        {
            int minCost = 100;
            int maxCost = 2000;

            foreach (var breakdown in _breakdownSpareParts)
            {
                _breakdownRepairCosts.Add(breakdown.Key, _random.Next(minCost, maxCost));
                _sparePartsCosts.Add(breakdown.Value, _random.Next(minCost, maxCost));
            }

            _breakdownSpareParts = new Dictionary<Breakdown, SparePart>();
            _breakdownSpareParts.Add(new Breakdown("Отвалилось колесо"), new SparePart("Колесо"));
            _breakdownSpareParts.Add(new Breakdown("Перегрев двигателя"), new SparePart("Радиатор"));
            _breakdownSpareParts.Add(new Breakdown("Разрядился аккумулятор"), new SparePart("Генератор"));
            _breakdownSpareParts.Add(new Breakdown("Троит двигатель"), new SparePart("Свечи зажигания"));
            _breakdownSpareParts.Add(new Breakdown("Течет масло"), new SparePart("Коренной сальник"));
        }

        public void Open()
        {

        }

    }

    class SparePartStack
    {
        private Dictionary<SparePart, int> _sparePartsQuantity;

        public SparePartStack(Dictionary<string, SparePart> breakdownSpareParts)
        {
            int initialQuantity = 2;
            _sparePartsQuantity = new Dictionary<SparePart, int>();
            
            foreach(var sparePart in breakdownSpareParts)
                _sparePartsQuantity.Add(sparePart.Value, initialQuantity);
        }
    }

    class SparePart
    {
        private string _name;

        public SparePart(string name)
        {
            _name = name;
        }
    }

    class Car
    {
        private Breakdown _breakdown;
        private Random _random = new Random();

        public string Name { get; private set; }

        public Car(Breakdown breakdown)
        {
            List<string> carNames = new List<string>();

            foreach (var name in Enum.GetNames(typeof(CarName)))
                carNames.Add(name);

            Name = carNames[_random.Next(carNames.Count)];
            _breakdown = breakdown;
        }
    }

    class Breakdown
    {
        private string _name;

        public Breakdown(string name)
        {
            _name = name;
        }
    }

    enum CarName
    {
        Toyota,
        Nissan,
        Mazda,
        Mitsubishi,
        Ford,
        Mercedes,
        Ferrari,
        Infinity,
        Chevrolet,
        Dodge,
        Lamborghini,
        Renault,
        Porshe
    }
}
