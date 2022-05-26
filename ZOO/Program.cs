using System;
using System.Collections.Generic;

namespace ZOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalEncyclopedia animalEncyclopedia = new AnimalEncyclopedia();
            ZooGuide zooGuide = new ZooGuide(animalEncyclopedia.GetAnimalsNoises());
            zooGuide.Open();
        }
    }

    class ZooGuide
    {
        private List<Aviary> _aviaries;
        private Random _random = new Random();

        public ZooGuide(Dictionary<string, string> animalsNoises)
        {
            _aviaries = new List<Aviary>();
            _aviaries.Add(new Aviary(_random, animalsNoises));
            _aviaries.Add(new Aviary(_random, animalsNoises));
            _aviaries.Add(new Aviary(_random, animalsNoises));
            _aviaries.Add(new Aviary(_random, animalsNoises));
            _aviaries.Add(new Aviary(_random, animalsNoises));
            _aviaries.Add(new Aviary(_random, animalsNoises));
            _aviaries.Add(new Aviary(_random, animalsNoises));
            _aviaries.Add(new Aviary(_random, animalsNoises));
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

        public Aviary(Random random, Dictionary<string, string> animalsNoises)
        {
            int minAnimals = 5;
            int maxAnimals = 10;
            int maxNumber = 99999;
            _animals = new List<Animal>();
            Name = "Вольер № " + random.Next(maxNumber);

            for (int i = 0; i < random.Next(minAnimals, maxAnimals); i++)
                _animals.Add(new Animal(random, animalsNoises));
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

    class AnimalEncyclopedia
    {
        private Dictionary<string, string> _animalsNoises;

        public AnimalEncyclopedia()
        {
            _animalsNoises = new Dictionary<string, string>();
            _animalsNoises.Add("Cow", "Moo");
            _animalsNoises.Add("Tiger", "Argh");
            _animalsNoises.Add("Dog", "Woof");
            _animalsNoises.Add("Dove", "Coo");
            _animalsNoises.Add("Cat", "Meow");
            _animalsNoises.Add("Frog", "Croak");
            _animalsNoises.Add("Goat", "Bleat");
            _animalsNoises.Add("Jackal", "Howl");
            _animalsNoises.Add("Owl", "Hoot");
            _animalsNoises.Add("Rat", "Squeak");
        }

        public Dictionary<string, string> GetAnimalsNoises()
        {
            Dictionary<string, string> animalsNoises = new Dictionary<string, string>();

            foreach (var i in _animalsNoises)
                animalsNoises.Add(i.Key, i.Value);

            return animalsNoises;
        }
    }

    class Animal
    {
        public string Name { get; private set; }
        public string Noise { get; private set; }
        public string Gender { get; private set; }

        public Animal(Random random, Dictionary<string, string> animalsNoises)
        {
            List<string> names = new List<string>();
            List<string> noises = new List<string>();
            List<string> genders = new List<string>();
            genders.Add("Male");
            genders.Add("Female");

            foreach (var item in animalsNoises)
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
