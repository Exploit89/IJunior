using System;
using System.Collections.Generic;
using System.Linq;

namespace CriminalSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CriminalDatabase database = new CriminalDatabase();
            database.Open();
        }
    }

    class CriminalDatabase
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public CriminalDatabase()
        {
            _criminals.Add(new Criminal("Иванов Иван Иванович", false, 185, 110, "Русский"));
            _criminals.Add(new Criminal("Петров Петр Петрович", false, 185, 95, "Поляк"));
            _criminals.Add(new Criminal("Коршун Виктор Алексеевич", false, 160, 95, "Русский"));
            _criminals.Add(new Criminal("Сидоров Алексей Сергеевич", false, 175, 85, "Русский"));
            _criminals.Add(new Criminal("Иванов Максим Иванович", true, 175, 85, "Русский"));
            _criminals.Add(new Criminal("Шишкин Сергей Иванович", false, 195, 95, "Русский"));
            _criminals.Add(new Criminal("Толстой Дмитрий Сидорович", true, 155, 75, "Белорус"));
        }

        public void Open()
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine("Введите номер команды:\n" +
                    "1. Поиск в базе данных.\n" +
                    "2. Выход.\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Search();
                        break;
                    case "2":
                        isOpen = false;
                        break;
                    default:
                        ShowDefaultMessage();
                        break;
                }
            }
        }

        private void Search()
        {
            Console.Write("Введите Рост: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите Вес: ");
            int weight = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите Национальнотсь: ");
            string nationality = Console.ReadLine();

            var searchResults = from Criminal criminal in _criminals
                                where criminal.Height == height
                                where criminal.Weight == weight
                                where criminal.Nationality == nationality
                                where criminal.IsPrisoner == false
                                select criminal;

            Console.Clear();
            Console.WriteLine("Результат поиска:");

            foreach (var criminal in searchResults)
                Console.WriteLine($"{criminal.FullName}, {criminal.Nationality}, {criminal.Height} см. {criminal.Weight} кг.");

            Console.WriteLine("Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды не существует.");
        }
    }

    class Criminal
    {
        public string FullName { get; private set; }
        public bool IsPrisoner { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Criminal(string fullname, bool isPrisoner, int height, int weight, string nationality)
        {
            FullName = fullname;
            IsPrisoner = isPrisoner;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }
    }
}
