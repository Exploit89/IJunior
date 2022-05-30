using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAnarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Open();
        }
    }

    class Hospital
    {
        private List<Patient> _patients;
        private List<string> _patientNames;
        private List<string> _diseases;
        private Random _random = new Random();

        public Hospital()
        {
            _patients = new List<Patient>();
            _patientNames = new List<string>();
            _diseases = new List<string>();
            int maxAge = 100;

            _patientNames.Add("Попов Игнат Богуславович");
            _patientNames.Add("Елисеев Емельян Геннадьевич");
            _patientNames.Add("Андреев Кирилл Рубенович");
            _patientNames.Add("Ефремов Иннокентий Макарович");
            _patientNames.Add("Блинов Евдоким Пантелеймонович");
            _patientNames.Add("Титов Гарри Иринеевич");
            _patientNames.Add("Зайцев Нинель Куприянович");
            _patientNames.Add("Белоусова Ирэн Оскаровна");
            _patientNames.Add("Ситникова Эмбер Рубеновна");
            _patientNames.Add("Якушева Елизавета Серапионовна");
            _patientNames.Add("Анисимова Азалия Лаврентьевна");
            _patientNames.Add("Хохлова Властилина Филипповна");
            _patientNames.Add("Баранова Сима Владиславовна");
            _patientNames.Add("Дроздова Радмила Сергеевна");
            _patientNames.Add("Иванов Иван Иванович");

            _diseases.Add("Ветрянка");
            _diseases.Add("Оспа");
            _diseases.Add("Туберкулез");
            _diseases.Add("Геморрой");
            _diseases.Add("Панкреотит");
            _diseases.Add("Пневмония");
            _diseases.Add("ОРВИ");
            _diseases.Add("Перелом");

            foreach (var name in _patientNames)
                _patients.Add(new Patient(name, _random.Next(maxAge), _diseases[_random.Next(_diseases.Count)]));
        }

        public void Open()
        {
            bool isOpen = true;

            while (isOpen)
            {
                Console.WriteLine(" \nМеню:" +
                    " \n1. Сортировать по ФИО" +
                    " \n2. Сортировать по возрасту" +
                    " \n3. Показать пациентов с диагнозом..." +
                    " \n4. Выход\n");
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.D1:
                        SortPatientsByName();
                        break;
                    case ConsoleKey.D2:
                        SortPatientsByAge();
                        break;
                    case ConsoleKey.D3:
                        ShowPatientsWith();
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

        private void SortPatientsByName()
        {
            Console.Clear();
            Console.WriteLine("Отсортировано по ФИО: ");
            var sortedPatients = _patients.OrderBy(patient => patient.FullName);

            foreach (var patient in sortedPatients)
                Console.WriteLine($"{patient.FullName}, {patient.Age} лет. Диагноз: {patient.Disease}");
        }

        private void SortPatientsByAge()
        {
            Console.Clear();
            Console.WriteLine("Отсортировано по возрасту: ");
            var sortedPatients = _patients.OrderBy(patient => patient.Age);

            foreach (var patient in sortedPatients)
                Console.WriteLine($"{patient.FullName}, {patient.Age} лет. Диагноз: {patient.Disease}");
        }

        private void ShowPatientsWith()
        {
            Console.Clear();
            Console.Write("Введите диагноз: ");
            string userInput = Console.ReadLine();

            if (_diseases.Contains(userInput))
            {
                var filteredPatients = _patients.Where(patient => patient.Disease == userInput);

                foreach (var patient in filteredPatients)
                    Console.WriteLine($"{patient.FullName}, {patient.Age} лет. Диагноз: {patient.Disease}");
            }
            else
                Console.WriteLine("\nТакого диагноза нет в списках.");
        }

        private void ShowDefaultMessage()
        {
            Console.Clear();
            Console.WriteLine("Такой команды не существует.");
        }
    }

    class Patient
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string name, int age, string disease)
        {
            FullName = name;
            Age = age;
            Disease = disease;
        }
    }
}
