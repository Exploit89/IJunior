using System;

namespace PersonnelAccounting
{
    internal class PersonnelAccounting
    {
        static void Main(string[] args)
        {
            string[] fullName = new string[0];
            string[] position = new string[0];
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
                        AddDossier(ref fullName, ref position);
                        break;
                    case 2:
                        ShowAllDossiers(ref fullName, ref position);
                        break;
                    case 3:
                        DeleteDossier(ref fullName, ref position);
                        break;
                    case 4:
                        SearchBySurname(ref fullName, ref position);
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

        static void AddDossier(ref string[] fullName, ref string[] position)
        {
            Console.WriteLine("Введите ФИО через пробел:");
            ExpandArray(ref fullName);
            Console.WriteLine("Введите должность:\n");
            ExpandArray(ref position);
        }

        static void ShowAllDossiers(ref string[] fullName, ref string[] position)
        {
            Console.WriteLine("Полный список кадров:\n");

            for (int i = 0; i < fullName.Length; i++)
            {
                Console.Write($"{i + 1} - {fullName[i]} - {position[i]}\n");
            }

            Console.WriteLine();
        }

        static void DeleteDossier(ref string[] fullName, ref string[] position)
        {
            Console.WriteLine("Укажите номер досье для удаления:");
            int dossierNumberInput = Convert.ToInt32(Console.ReadLine());
            ReduceArray(ref fullName, ref dossierNumberInput);
            ReduceArray(ref position, ref dossierNumberInput);
        }

        static void SearchBySurname(ref string[] fullName, ref string[] position)
        {
            Console.WriteLine("Введите фамилию для поиска:");
            string surnameInput = Console.ReadLine();
            string[] dividedString = new string[3];
            string fullnameString;
            string[] surnameString = new string[fullName.Length];

            for (int i = 0; i < fullName.Length; i++)
            {
                fullnameString = Convert.ToString(fullName[i]);
                dividedString = fullnameString.Split(' ');
                surnameString[i] = dividedString[0];
            }

            for(int i = 0; i < surnameString.Length; i++)
            {
                if(surnameString[i] == surnameInput)
                {
                    Console.WriteLine($"{i + 1} - {fullName[i]} - {position[i]}\n");
                }
            }
        }

        static void ExpandArray(ref string[] expandArray)
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

        static void ReduceArray(ref string[] reduceArray, ref int dossierNumberInput)
        {
            if (reduceArray.Length == 0)
            {
                Console.WriteLine("Список пуст");
            }
            else if (dossierNumberInput < 1 || dossierNumberInput > reduceArray.Length)
            {
                Console.WriteLine($"Досье под номером {dossierNumberInput} не существует.");
            }
            else
            {
                string[] decrementArray = new string[reduceArray.Length - 1];

                for (int i = 0; i < dossierNumberInput - 1; i++)
                {
                    decrementArray[i] = reduceArray[i];
                }

                for (int i = dossierNumberInput - 1; i < reduceArray.Length; i++)
                {
                    if (i < reduceArray.Length - 1)
                    {
                        reduceArray[i] = reduceArray[i + 1];
                        decrementArray[i] = reduceArray[i];
                    }
                }

                reduceArray = decrementArray;
            }
        }
    }
}
