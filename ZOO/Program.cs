using System;
using System.Collections.Generic;

namespace ZOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZooGuide zooGuide = new ZooGuide();
            zooGuide.Open();
        }
    }

    class ZooGuide
    {
        private List<Aviary> _aviaries;
        private Random _random = new Random();

        public ZooGuide()
        {
            _aviaries = new List<Aviary>();
            _aviaries.Add(new Aviary(_random));
            _aviaries.Add(new Aviary(_random));
            _aviaries.Add(new Aviary(_random));
            _aviaries.Add(new Aviary(_random));
            _aviaries.Add(new Aviary(_random));
            _aviaries.Add(new Aviary(_random));
            _aviaries.Add(new Aviary(_random));
            _aviaries.Add(new Aviary(_random));
        }

        public void Open()
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Меню:\n");

                for (int i = 0; i < _aviaries.Count; i++)
                    Console.WriteLine($"{i + 1}. - {_aviaries[i].Name} - {_aviaries[i].GetAnimals().Count} животных.");
                Console.WriteLine("0. Выход");

                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number) && number == 0)
                    isOpen = false;
                else if (int.TryParse(userInput, out number) && number > 0)
                    ChooseAviary(number - 1);
                else
                {
                    Console.Clear();
                    Console.WriteLine("Такой команды нет.");
                }
            }
        }

        private void ChooseAviary(int number)
        {
            if (_aviaries.Count > number)
                _aviaries[number].ShowAnimals();
            else
            {
                Console.Clear();
                Console.WriteLine("Введите корректное число.");
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals;

        public string Name { get; private set; }

        public Aviary(Random random)
        {
            int minAnimals = 5;
            int maxAnimals = 10;
            int maxNumber = 99999;
            _animals = new List<Animal>();
            Name = "Вольер № " + random.Next(maxNumber);

            for (int i = 0; i < random.Next(minAnimals, maxAnimals); i++)
                _animals.Add(new Animal(random));
        }

        public List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();

            foreach (var animal in _animals)
            {
                animals.Add(animal);
            }

            return animals;
        }

        public void ShowAnimals()
        {
            Console.Clear();

            for (int i = 0; i < _animals.Count; i++)
                Console.WriteLine($"{_animals[i].Name} - {_animals[i].Noise} - {_animals[i].Gender}");

            Console.WriteLine();
        }
    }

    class Animal
    {
        private Dictionary<string, string> _animals;
        public string Name { get; private set; }
        public string Noise { get; private set; }
        public string Gender { get; private set; }

        public Animal(Random random)
        {
            _animals = new Dictionary<string, string>();
            _animals.Add("Cow", "Moo");
            _animals.Add("Tiger", "Argh");
            _animals.Add("Dog", "Woof");
            _animals.Add("Dove", "Coo");
            _animals.Add("Cat", "Meow");
            _animals.Add("Frog", "Croak");
            _animals.Add("Goat", "Bleat");
            _animals.Add("Jackal", "Howl");
            _animals.Add("Owl", "Hoot");
            _animals.Add("Rat", "Squeak");

            List<string> names = new List<string>();
            List<string> noises = new List<string>();
            List<string> genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");

            foreach (var item in _animals)
            {
                names.Add(item.Key);
                noises.Add(item.Value);
            }

            int index = random.Next(names.Count);
            Name = names[index];
            Noise = noises[index];
            Gender = genders[random.Next(genders.Count)];
        }
    }
}
