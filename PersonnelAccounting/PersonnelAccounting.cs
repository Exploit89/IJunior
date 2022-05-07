using System;

namespace PersonnelAccounting
{
    internal class PersonnelAccounting
    {
        static void Main(string[] args)
        {
            string[] fullNames = new string[0];
            string[] positions = new string[0];
            bool isWorking = true;

            Console.WriteLine("Добро пожаловать в программу кадрового учёта!");

            while (isWorking)
            {
                int userInput;

                Console.WriteLine("Введите номер команды:\n" +
                    "1 - Добавить досье\n" +
                    "2 - Вывести все досье\n" +
                    "3 - Удалить досье\n" +
                    "4 - Поиск по фамилии\n" +
                    "5 - Выход\n");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddDossier(ref fullNames, ref positions);
                        break;
                    case 2:
                        ShowAllDossiers(fullNames, positions);
                        break;
                    case 3:
                        DeleteDossier(ref fullNames, ref positions);
                        break;
                    case 4:
                        SearchBySurname(ref fullNames, positions);
                        break;
                    case 5:
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует.");
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullNames, ref string[] positions)
        {
            Console.WriteLine("Введите ФИО через пробел:");
            AddToArrayAndIncrement(ref fullNames);
            Console.WriteLine("Введите должность:\n");
            AddToArrayAndIncrement(ref positions);
        }

        static void ShowAllDossiers(string[] fullNames, string[] positions)
        {
            Console.WriteLine("Полный список кадров:\n");

            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.Write($"{i + 1} - {fullNames[i]} - {positions[i]}\n");
            }

            Console.WriteLine();
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] positions)
        {
            Console.WriteLine("Укажите номер досье для удаления:");
            int dossierNumberInput = Convert.ToInt32(Console.ReadLine());

            if (fullNames.Length == 0)
            {
                Console.WriteLine("Список пуст");
            }
            else if (dossierNumberInput < 1 || dossierNumberInput > fullNames.Length)
            {
                Console.WriteLine($"Досье под номером {dossierNumberInput} не существует.");
            }
            else
            {
                RemoveFromArrayAndReduce(ref fullNames, dossierNumberInput);
                RemoveFromArrayAndReduce(ref positions, dossierNumberInput);
            }
        }

        static void SearchBySurname(ref string[] fullNames, string[] positions)
        {
            Console.WriteLine("Введите фамилию для поиска:");
            string surnameInput = Console.ReadLine();
            string[] dividedString = new string[3];
            string fullnameString;
            string[] surnameString = new string[fullNames.Length];

            for (int i = 0; i < fullNames.Length; i++)
            {
                fullnameString = Convert.ToString(fullNames[i]);
                dividedString = fullnameString.Split(' ');
                surnameString[i] = dividedString[0];
            }

            for(int i = 0; i < surnameString.Length; i++)
            {
                if(surnameString[i] == surnameInput)
                {
                    Console.WriteLine($"{i + 1} - {fullNames[i]} - {positions[i]}\n");
                }
            }
        }

        static void AddToArrayAndIncrement(ref string[] expandArray)
        {
            string expandInput = Console.ReadLine();
            string[] incrementArray = new string[expandArray.Length + 1];

            for (int i = 0; i < expandArray.Length; i++)
            {
                incrementArray[i] = expandArray[i];
            }

            incrementArray[expandArray.Length] = expandInput;
            expandArray = incrementArray;
        }

        static void RemoveFromArrayAndReduce(ref string[] reduceArray, int dossierNumberInput)
        {
            string[] decrementArray = new string[reduceArray.Length - 1];

            for (int i = 0; i < dossierNumberInput - 1; i++)
            {
                decrementArray[i] = reduceArray[i];
            }

            for (int i = dossierNumberInput - 1; i < reduceArray.Length - 1; i++)
            {
                decrementArray[i] = reduceArray[i + 1];
            }

            reduceArray = decrementArray;
        }
    }
}
