using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerTrainConfigurator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RailwayStation railwayStation = new RailwayStation();
            railwayStation.Open();
        }
    }

    class RailwayStation
    {
        private List<Train> _sentTrains;
        private List<Direction> _directions;
        private Train _currentTrain;

        public RailwayStation()
        {
            _sentTrains = new List<Train>();
            _directions = new List<Direction>();
        }

        public void Open()
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.SetCursorPosition(0,0);
                Console.WriteLine("Отправленные поезда:");
                ShowSentTrains();
                int cursorOffsetY = _sentTrains.Count + 7;
                Console.SetCursorPosition(0, cursorOffsetY);
                Console.WriteLine("Меню:\n" +
                    "1 - Создать направление.\n" +
                    "2 - Продать билеты.\n" +
                    "3 - Создать поезд.\n" +
                    "4 - Отправить поезд.\n" +
                    "5 - Выход.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateDirection();
                        break;
                    case "2":
                        SellTickets();
                        break;
                    case "3":
                        CreateTrain();
                        break;
                    case "4":
                        SendTrain(_currentTrain);
                        break;
                    case "5":
                        isOpen = false;
                        break;
                    default:
                        ShowDefaultMessage();
                        break;
                }
            }
        }

        private void ShowSentTrains()
        {
            if(_sentTrains.Count == 0)
            {
                Console.WriteLine("Нет отправленных поездов.\n");
            }
            else
            {
                foreach (var item in _sentTrains)
                {
                    Console.WriteLine($"{item.Direction} - {item.GetCars().Count} вагонов - {item.SoldTickets} пассажиров.");
                }
            }
        }

        private void CreateDirection()
        {
            Direction direction = new Direction();
            _directions.Add(direction);
            Console.Clear();
            int cursorOffsetY = _sentTrains.Count + 3;
            Console.SetCursorPosition(0, cursorOffsetY);
            Console.WriteLine($"Создано направление {direction.Name}");
        }

        private void SellTickets()
        {
            int lastIndex = _directions.Count - 1;
            _directions[lastIndex].AddSoldTickets();
            Console.Clear();
            int cursorOffsetY = _sentTrains.Count + 3;
            Console.SetCursorPosition(0, cursorOffsetY);
            Console.WriteLine($"Продано {_directions[lastIndex].SoldTickets} билетов.");
        }

        private void CreateTrain()
        {
            int lastIndex = _directions.Count - 1;
            _currentTrain = new Train(_directions[lastIndex], _directions[lastIndex].SoldTickets);
        }

        private void SendTrain(Train train)
        {
            train.FillCars();
            _sentTrains.Add(train);
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды нет.");
        }
    }

    class Train
    {
        private List<Car> _cars = new List<Car>();

        public Direction Direction { get; private set; }
        public int SoldTickets { get; private set; }

        public Train(Direction direction, int soldTickets)
        {
            Direction = direction;
            SoldTickets = soldTickets;
            CreateCars();
        }

        public void FillCars()
        {
            int soldTicketsTemp = SoldTickets;

            foreach(Car car in _cars)
            {
                if(soldTicketsTemp < car.Capacity)
                {
                    car.AddPassengers(car.Capacity - soldTicketsTemp);
                }
                else
                {
                    car.AddPassengers(car.Capacity);
                    soldTicketsTemp -= car.Capacity;
                }
            }
        }

        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            return cars;
        }

        private void CreateCars()
        {
            int occupiedPlaces = 0;

            while (occupiedPlaces < SoldTickets)
            {
                Car car = new Car();

                if (car.Capacity < SoldTickets - occupiedPlaces)
                {
                    occupiedPlaces += car.Capacity;
                    _cars.Add(car);
                }

                occupiedPlaces += car.Capacity;
                _cars.Add(car);
            }
        }
    }

    class Car
    {
        public int Capacity { get; private set; }
        public int Passengers { get; private set; }

        public Car()
        {
            Random random = new Random();
            int minCarCapacity = 10;
            int maxCarCapacity = 50;
            Capacity = random.Next(minCarCapacity, maxCarCapacity);
            Passengers = 0;
        }

        public void AddPassengers(int passengers)
        {
            Passengers += passengers;
        }
    }

    class Direction
    {
        public string Name { get; private set; }
        public int SoldTickets { get; private set; }

        public Direction()
        {
            SoldTickets = 0;
            CreateDirection();
        }

        public void AddSoldTickets()
        {
            int minTickets = 100;
            int maxTickets = 200;
            Random random = new Random();
            SoldTickets = random.Next(minTickets, maxTickets);
        }

        private void CreateDirection()
        {
            Random random = new Random();
            List<string> cityNames = new List<string>();

            foreach (var item in Enum.GetValues(typeof(CityName)))
            {
                cityNames.Add(item.ToString());
            }

            string departureCityName = cityNames[random.Next(cityNames.Count)];
            string arrivalCityName = cityNames[random.Next(cityNames.Count)];

            while (departureCityName == arrivalCityName)
            {
                arrivalCityName = cityNames[random.Next(cityNames.Count)];
            }

            Name = $"{departureCityName} - {arrivalCityName}";
        }
    }

    enum CityName
    {
        SaintPetersburg,
        Vladivostok,
        Novosibirsk,
        Magadan,
        Murmansk,
        Sochi
    }
}
