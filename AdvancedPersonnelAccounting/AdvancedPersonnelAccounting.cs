using System;
using System.Collections.Generic;

namespace AdvancedPersonnelAccounting
{
    internal class AdvancedPersonnelAccounting
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> persons = new Dictionary<string, string>();
            bool isWorking = true;

            Console.WriteLine("Добро пожаловать в программу кадрового учёта!");

            while (isWorking)
            {
                int userInput;

                Console.WriteLine("\nВведите номер команды:\n" +
                    "1 - Добавить досье\n" +
                    "2 - Вывести все досье\n" +
                    "3 - Удалить досье\n" +
                    "4 - Выход\n");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddDossier(persons);
                        break;
                    case 2:
                        ShowAllDossiers(persons);
                        break;
                    case 3:
                        DeleteDossier(persons);
                        break;
                    case 4:
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует.");
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, string> persons)
        {
            Console.WriteLine("Введите ФИО:");
            string inputFullName = Console.ReadLine();
            Console.WriteLine("Введите должность:");
            string inputPosition = Console.ReadLine();
            persons.Add(inputFullName, inputPosition);
        }

        static void ShowAllDossiers(Dictionary<string, string> persons)
        {
            Console.WriteLine("Полный список кадров:");
            int number = 0;

            foreach(var item in persons)
            {
                number++;
                Console.Write($"{number}. {item.Key} - {item.Value}\n");
            }
        }

        static void DeleteDossier(Dictionary<string, string> persons)
        {
            Console.WriteLine("Укажите ФИО для удаления досье:");
            string dossierKeyInput = Console.ReadLine();

            if(persons.ContainsKey(dossierKeyInput))
                persons.Remove(dossierKeyInput);
        }
    }
}
