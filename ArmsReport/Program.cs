using System;
using System.Collections.Generic;
using System.Linq;

namespace ArmsReport
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
        private List<Soldier> _soldiers;

        public Report()
        {
            _soldiers = new List<Soldier>();
            _soldiers.Add(new Soldier("Попов Игнат Богуславович", "Пулемет", "Рядовой", 5));
            _soldiers.Add(new Soldier("Ефремов Иннокентий Макарович", "Автомат", "Полковник", 47));
            _soldiers.Add(new Soldier("Титов Гарри Иринеевич", "Ракетница", "Капитан", 12));
            _soldiers.Add(new Soldier("Зайцев Василий Куприянович", "Нож", "Сержант", 36));
            _soldiers.Add(new Soldier("Андреев Кирилл Рубенович", "Снайперская винтовка", "Подполковник", 123));
            _soldiers.Add(new Soldier("Анисимова Азалия Лаврентьевна", "Пулемет", "Генерал", 247));
            _soldiers.Add(new Soldier("Блинов Евдоким Пантелеймонович", "Автомат", "Майор", 183));
            _soldiers.Add(new Soldier("Баранова Сима Владиславовна", "Гранаты", "Полковник", 171));
        }

        public void Start()
        {
            ShowInitialList();
            ShowNewList();
        }

        private void ShowInitialList()
        {
            Console.WriteLine("\nИсходный список: ");

            foreach (var soldier in _soldiers)
            {
                int serviceYear = soldier.ServiceTime / 12;
                int serviceMonth = soldier.ServiceTime % 12;
                Console.WriteLine($"{soldier.Name} - {soldier.Weapons}, {soldier.Rank}, {serviceYear} лет {serviceMonth} месяцев.");
            }
        }

        private void ShowNewList()
        {
            Console.WriteLine("\nНовый список: ");

            var newSoldiersList = _soldiers.Select(soldier => new
            {
                soldier.Name,
                soldier.ServiceTime
            });

            foreach (var soldier in newSoldiersList)
            {
                int serviceYear = soldier.ServiceTime / 12;
                int serviceMonth = soldier.ServiceTime % 12;
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
