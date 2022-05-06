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
                        Console.WriteLine("Введите ФИО через пробел:");
                        string fullNameInput = Console.ReadLine();
                        Console.WriteLine("Введите должность:\n");
                        string positionInput = Console.ReadLine();
                        AddDossier(ref fullName, ref position, fullNameInput, positionInput);
                        break;
                    case 2:
                        Console.WriteLine("Полный список кадров:\n");
                        ShowAllDossiers(ref fullName, ref position);
                        break;
                    case 3:
                        Console.WriteLine("Укажите номер досье для удаления:");
                        int dossierNumberInput = Convert.ToInt32(Console.ReadLine());
                        DeleteDossier(ref fullName, ref position, dossierNumberInput);
                        break;
                    case 4:
                        Console.WriteLine("Введите фамилию для поиска:");
                        string surnameInput = Console.ReadLine();
                        SearchBySurname(ref fullName, ref position, surnameInput);
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

        static void AddDossier(ref string[] fullName, ref string[] position, string fullNameInput, string positionInput)
        {
            string[] incrementFullNameArray = new string[fullName.Length + 1];
            string[] incrementPositionArray = new string[position.Length + 1];

            for (int i = 0; i < fullName.Length; i++)
            {
                incrementFullNameArray[i] = fullName[i];
            }

            for(int i = 0; i < position.Length; i++)
            {
                incrementPositionArray[i] = position[i];
            }

            incrementFullNameArray[fullName.Length] = fullNameInput;
            fullName = incrementFullNameArray;
            incrementPositionArray[position.Length] = positionInput;
            position = incrementPositionArray;
        }

        static void ShowAllDossiers(ref string[] fullName, ref string[] position)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                Console.Write($"{i + 1} - {fullName[i]} - {position[i]}\n");
            }

            Console.WriteLine();
        }

        static void DeleteDossier(ref string[] fullName, ref string[] position, int dossierNumberInput)
        {
            if(fullName.Length == 0)
            {
                Console.WriteLine("Список пуст");
            }
            else if(dossierNumberInput < 1 || dossierNumberInput > fullName.Length)
            {
                Console.WriteLine($"Досье под номером {dossierNumberInput} не существует.");
            }
            else
            {
                string[] decrementFullNameArray = new string[fullName.Length - 1];
                string[] decrementPositionArray = new string[position.Length - 1];

                for (int i = 0; i < dossierNumberInput - 1; i++)
                {
                    decrementFullNameArray[i] = fullName[i];
                    decrementPositionArray[i] = position[i];
                }

                for (int i = dossierNumberInput - 1; i < fullName.Length; i++)
                {
                    if (i < fullName.Length - 1)
                    {
                        fullName[i] = fullName[i + 1];
                        position[i] = position[i + 1];
                        decrementFullNameArray[i] = fullName[i];
                        decrementPositionArray[i] = position[i];
                    }
                }

                fullName = decrementFullNameArray;
                position = decrementPositionArray;
            }
        }

        static void SearchBySurname(ref string[] fullName, ref string[] position, string surnameInput)
        {
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
    }
}
