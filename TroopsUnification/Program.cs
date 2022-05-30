using System;
using System.Collections.Generic;
using System.Linq;

namespace TroopsUnification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();
            report.Start();
        }
    }

    class Report
    {
        private List<Soldier> _firstSoldiers;
        private List<Soldier> _secondSoldiers;

        public Report()
        {
            _firstSoldiers = new List<Soldier>();
            _firstSoldiers.Add(new Soldier("Бобов Игнат Богуславович", "Пулемет", "Рядовой", 5));
            _firstSoldiers.Add(new Soldier("Ефремов Иннокентий Макарович", "Автомат", "Полковник", 47));
            _firstSoldiers.Add(new Soldier("Титов Гарри Иринеевич", "Ракетница", "Капитан", 12));
            _firstSoldiers.Add(new Soldier("Байцев Василий Куприянович", "Нож", "Сержант", 36));
            _firstSoldiers.Add(new Soldier("Андреев Кирилл Рубенович", "Снайперская винтовка", "Подполковник", 123));
            _firstSoldiers.Add(new Soldier("Анисимова Азалия Лаврентьевна", "Пулемет", "Генерал", 247));
            _firstSoldiers.Add(new Soldier("Блинов Евдоким Пантелеймонович", "Автомат", "Майор", 183));
            _firstSoldiers.Add(new Soldier("Гандамова Сима Владиславовна", "Гранаты", "Полковник", 171));

            _secondSoldiers = new List<Soldier>();
        }

        public void Start()
        {
            ShowFirstList();
            MoveSoldiersToSecond();
            Console.WriteLine();
            Console.WriteLine("Состав списков после перемещения солдат.\n");
            ShowFirstList();
            ShowSecondList();
        }

        private void ShowFirstList()
        {
            Console.WriteLine("\nПервый список: ");

            foreach (var soldier in _firstSoldiers)
            {
                int monthsInYear = 12;
                int serviceYear = soldier.ServiceTime / monthsInYear;
                int serviceMonth = soldier.ServiceTime % monthsInYear;
                Console.WriteLine($"{soldier.Name} - {soldier.Weapons}, {soldier.Rank}, {serviceYear} лет {serviceMonth} месяцев.");
            }
        }

        public void MoveSoldiersToSecond()
        {
            var newSoldiersList = _firstSoldiers.OrderBy(soldier => soldier.Name).Where(soldier => soldier.Name.StartsWith("Б"));
            _secondSoldiers = (_firstSoldiers.Where(soldier => soldier.Name.StartsWith("Б"))).ToList();
            _firstSoldiers = (_firstSoldiers.Except(_secondSoldiers)).ToList();
        }

        private void ShowSecondList()
        {
            Console.WriteLine("\nВторой список: ");

            foreach (var soldier in _secondSoldiers)
            {
                int monthsInYear = 12;
                int serviceYear = soldier.ServiceTime / monthsInYear;
                int serviceMonth = soldier.ServiceTime % monthsInYear;
                Console.WriteLine($"{soldier.Name} - {serviceYear} лет {serviceMonth} месяцев.");
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Weapons { get; private set; }
        public string Rank { get; private set; }
        public int ServiceTime { get; private set; }

        public Soldier(string name, string weapons, string rank, int serviceTime)
        {
            Name = name;
            Weapons = weapons;
            Rank = rank;
            ServiceTime = serviceTime;
        }
    }
}
