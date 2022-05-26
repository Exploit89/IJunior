using System;
using System.Collections.Generic;

namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            aquarium.Start();
        }
    }

    class Aquarium
    {
        private Random _random = new Random();
        private List<Fish> _fishList;

        public int MaxCapacity { get; private set; }
        public int DayCount { get; private set; }

        public Aquarium()
        {
            DayCount = 0;
            MaxCapacity = 10;
            _fishList = new List<Fish>();
        }

        public void Start()
        {
            bool isActive = true;

            while (isActive)
            {
                ShowAquarium();
                Console.WriteLine("1. Добавить рыбку.\n" +
                    "2. Взять рыбку.\n" +
                    "3. Пропустить день.\n" +
                    "4. Выход.\n");
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.D1:
                        AddFish();
                        break;
                    case ConsoleKey.D2:
                        RemoveFish();
                        break;
                    case ConsoleKey.D3:
                        TurnNextDay();
                        break;
                    case ConsoleKey.D4:
                        isActive = false;
                        break;
                    default:
                        ShowDefaultMessage();
                        break;
                }
            }
        }

        private void ShowAquarium()
        {
            int fishNumber = 0;
            Console.WriteLine($"\nДень: {DayCount}\n" +
                $"Аквариум:\n");

            foreach (var fish in _fishList)
            {
                fishNumber++;
                Console.WriteLine($"{fishNumber}. {fish.Name} - {fish.Health} - {fish.Condition}");
            }

            Console.WriteLine();
        }
        private void TurnNextDay()
        {
            foreach (var fish in _fishList)
            {
                fish.GrowOld();
            }

            DayCount++;
            Console.Clear();
        }

        private void AddFish()
        {
            if(_fishList.Count < MaxCapacity)
            {
                Fish fish = new Fish(_random);
                _fishList.Add(fish);
                Console.Clear();
                Console.WriteLine($"Вы добавили в аквариум рыбку {fish.Name}");
                TurnNextDay();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("В аквариуме максимальное кол-во рыбок. Нельзя добавить больше.");
            }
        }

        private void RemoveFish()
        {
            Console.WriteLine("Какую рыбку вы хотите взять из аквариума?");
            string userInput = Console.ReadLine();

            if (isNumber(userInput))
            {
                int.TryParse(userInput, out int number);
                int userIndex = number - 1;

                if (userIndex >= 0 && userIndex < _fishList.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Вы забрали из аквариума рыбку {_fishList[userIndex].Name}");
                    _fishList.RemoveAt(userIndex);
                    TurnNextDay();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Рыбки под таким номером нет.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Некорректный ввод.");
            }
        }

        private bool isNumber(string userInput)
        {
            return int.TryParse(userInput, out int number);
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды нет.");
        }
    }

    class Fish
    {
        public int Health { get; private set; }
        public string Name { get; private set; }
        public string Condition { get; private set; }

        public Fish(Random random)
        {
            int maxHealth = 12;
            int minHealth = 3;
            int health = random.Next(minHealth, maxHealth);
            List<string> fishNames = new List<string>();

            foreach (var name in Enum.GetNames(typeof(FishName)))
                fishNames.Add(name);

            Name = fishNames[random.Next(fishNames.Count)]; ;
            Health = health;
            Condition = "ЖИВА";
        }

        public void GrowOld()
        {
            Health -= 1;
            if (Health <= 0)
            {
                Health = 0;
                Condition = "СДОХЛА";
            }
        }
    }

    enum FishName
    {
        Bobik,
        Nemo,
        Spade,
        Shark,
        Flint,
        Abracadabra,
        Goldfish,
        Nebraska,
        Brick,
        Pathfinder,
        Yammy,
        Buble,
        Arrrrgh
    }
}
