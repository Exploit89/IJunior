using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();
            Console.WriteLine("Исходный список: ");
            prison.ShowPrisoners();
            prison.DoAmnesty();
            Console.WriteLine("После амнистии: ");
            prison.ShowPrisoners();
        }
    }

    class Prison
    {
        private List<Prisoner> _prisoners;

        public Prison()
        {
            _prisoners = new List<Prisoner>();
            _prisoners.Add(new Prisoner("Иванов Иван Иванович", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Петров Петр Петрович", "Убийство"));
            _prisoners.Add(new Prisoner("Коршун Виктор Алексеевич", "Мошенничество"));
            _prisoners.Add(new Prisoner("Сидоров Алексей Сергеевич", "Убийство"));
            _prisoners.Add(new Prisoner("Иванов Максим Иванович", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Шишкин Сергей Иванович", "Мошенничество"));
            _prisoners.Add(new Prisoner("Толстой Дмитрий Сидорович", "Антиправительственное"));
        }

        public void DoAmnesty()
        {
            var newPrisoners = _prisoners.Where(prisoner => prisoner.Crime != "Антиправительственное");
            _prisoners = newPrisoners.ToList();
        }

        public void ShowPrisoners()
        {
            foreach (var prisoner in _prisoners)
                Console.WriteLine($"{prisoner.FullName} - {prisoner.Crime}");

            Console.WriteLine();
        }
    }

    class Prisoner
    {
        public string FullName { get; private set; }
        public string Crime { get; private set; }

        public Prisoner(string fullName, string crime)
        {
            FullName = fullName;
            Crime = crime;
        }
    }
}
