using System;
using System.Collections.Generic;

namespace CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            garage.Open();
        }
    }

    class Garage
    {
        private int _money;
        private Dictionary<Breakdown, SparePart> _breakdownSpareParts;
        private Dictionary<Breakdown, int> _breakdownRepairCosts;
        private Dictionary<SparePart, int> _sparePartsCosts;
        private Random _random = new Random();
        private SparePartStack _sparePartStack;
        private Car _currentCar;

        public Garage()
        {
            _breakdownRepairCosts = new Dictionary<Breakdown, int>();
            _sparePartsCosts = new Dictionary<SparePart, int>();
            _breakdownSpareParts = new Dictionary<Breakdown, SparePart>();
            int minCost = 100;
            int maxCost = 2000;

            _breakdownSpareParts.Add(new Breakdown("Отвалилось колесо"), new SparePart("Колесо"));
            _breakdownSpareParts.Add(new Breakdown("Перегрев двигателя"), new SparePart("Радиатор"));
            _breakdownSpareParts.Add(new Breakdown("Разрядился аккумулятор"), new SparePart("Генератор"));
            _breakdownSpareParts.Add(new Breakdown("Троит двигатель"), new SparePart("Свечи зажигания"));
            _breakdownSpareParts.Add(new Breakdown("Течет масло"), new SparePart("Коренной сальник"));

            foreach (var breakdown in _breakdownSpareParts)
            {
                _breakdownRepairCosts.Add(breakdown.Key, _random.Next(minCost, maxCost));
                _sparePartsCosts.Add(breakdown.Value, _random.Next(minCost, maxCost));
            }

            _sparePartStack = new SparePartStack(_breakdownSpareParts);
        }

        public void Open()
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine($"Баланс автосервиса: {_money}\n");

                Console.WriteLine("Меню:\n" +
                    "1. Принять автомобиль.\n" +
                    "2. Выбрать рем-комплект.\n" +
                    "3. Отказать.\n" +
                    "4. Выход.\n");
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.D1:
                        TakeCar();
                        break;
                    case ConsoleKey.D2:
                        ChooseSparePart();
                        break;
                    case ConsoleKey.D3:
                        DeclineCar();
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

        private List<Breakdown> GetBreakdowns()
        {
            List<Breakdown> breakdowns = new List<Breakdown>();
            foreach (var breakdown in _breakdownSpareParts)
                breakdowns.Add(breakdown.Key);

            return breakdowns;
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды нет.");
        }

        private void TakeCar()
        {
            if (_currentCar == null)
            {
                _currentCar = CreateCar(GetBreakdowns());
                Console.Clear();
                Console.WriteLine($"К вам заехал новый клиент на {_currentCar.Name} с поломкой {_currentCar.Breakdown.Name}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"У вас в боксе необслуженный клиент {_currentCar.Name} с поломкой {_currentCar.Breakdown.Name}.");
            }
        }

        private Car CreateCar(List<Breakdown> breakdowns)
        {
            Car car = new Car(breakdowns);
            return car;
        }

        private void TakeMoney(int money)
        {
            _money += money;
        }

        private void GiveMoney(int money)
        {
            _money -= money;
        }

        private void DeclineCar()
        {
            if (_currentCar != null)
            {
                int penalty = 500;
                GiveMoney(penalty);
                Console.Clear();
                Console.WriteLine("Вы отказали клиенту и получаете штраф.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("В боксе нет машин.");
            }
        }

        private void ChooseSparePart()
        {
            if (_currentCar == null)
            {
                Console.Clear();
                Console.WriteLine("В боксе нет машин.");
            }
            else
            {
                int sparePartNumber = 0;
                SparePart chosenSparePart = null;
                Console.Clear();
                Console.WriteLine();
                List<SparePart> sparePartTemp = new List<SparePart>();

                foreach (var sparePart in _sparePartStack.GetSpareParts())
                {
                    sparePartNumber++;
                    Console.WriteLine($"{sparePartNumber}. {sparePart.Key.Name} - {sparePart.Value} шт.");
                    sparePartTemp.Add(sparePart.Key);
                }

                Console.WriteLine("Выберите номер запчасти для замены.");
                string userInput = Console.ReadLine();

                if (IsNumber(userInput))
                {
                    int.TryParse(userInput, out int number);
                    int userIndex = number - 1;
                    chosenSparePart = sparePartTemp[userIndex];

                    if (userIndex >= 0 && userIndex < _sparePartStack.GetSpareParts().Count && _sparePartStack.GetSpareParts()[chosenSparePart] > 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Вы заменили {chosenSparePart.Name}");
                        _sparePartStack.DecreaseSparePart(chosenSparePart);
                        GetRepairResult(chosenSparePart);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Запчасти под таким номером нет.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Некорректный ввод.");
                }
            }
        }

        private bool IsNumber(string userInput)
        {
            return int.TryParse(userInput, out int number);
        }

        private void GetRepairResult(SparePart chosenSparePart)
        {
            if (_breakdownSpareParts[_currentCar.Breakdown].Name == chosenSparePart.Name)
            {
                TakeMoney(_sparePartsCosts[chosenSparePart]);
                TakeMoney(_breakdownRepairCosts[_currentCar.Breakdown]);
                Console.Clear();
                Console.WriteLine("Ремонт прошел успешно!");
            }
            else
            {
                GiveMoney(_sparePartsCosts[chosenSparePart]);
                GiveMoney(_breakdownRepairCosts[_currentCar.Breakdown]);
                DeclineCar();
                Console.Clear();
                Console.WriteLine("Вы заменили не ту деталь! Ущерб возмещен кленту.");
            }

            _currentCar = null;
        }
    }

    class SparePartStack
    {
        private Dictionary<SparePart, int> _sparePartsQuantity;

        public SparePartStack(Dictionary<Breakdown, SparePart> breakdownSpareParts)
        {
            int initialQuantity = 5;
            _sparePartsQuantity = new Dictionary<SparePart, int>();

            foreach (var sparePart in breakdownSpareParts)
                _sparePartsQuantity.Add(sparePart.Value, initialQuantity);
        }

        public Dictionary<SparePart, int> GetSpareParts()
        {
            Dictionary<SparePart, int> sparePartsQuantity = new Dictionary<SparePart, int>();

            foreach (var sparePart in _sparePartsQuantity)
                sparePartsQuantity.Add(sparePart.Key, sparePart.Value);

            return sparePartsQuantity;
        }

        public void DecreaseSparePart(SparePart sparePart)
        {
            if (_sparePartsQuantity[sparePart] > 0)
                _sparePartsQuantity[sparePart]--;
            else
                Console.WriteLine("Этой запчасти больше нет в наличии.");
        }
    }

    class SparePart
    {
        public string Name { get; private set; }

        public SparePart(string name)
        {
            Name = name;
        }
    }

    class Car
    {
        private Random _random = new Random();

        public Breakdown Breakdown { get; private set; }
        public string Name { get; private set; }

        public Car(List<Breakdown> breakdowns)
        {
            List<string> carNames = new List<string>();

            foreach (var name in Enum.GetNames(typeof(CarName)))
                carNames.Add(name);

            Name = carNames[_random.Next(carNames.Count)];
            Breakdown = breakdowns[_random.Next(breakdowns.Count)];
        }
    }

    class Breakdown
    {
        public string Name { get; private set; }

        public Breakdown(string name)
        {
            Name = name;
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
