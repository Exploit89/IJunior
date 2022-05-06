using System;

namespace PersonnelAccounting
{
    internal class PersonnelAccounting
    {
        static void Main(string[] args)
        {
            string[,] fullName = new string[0,3];
            string[] position = new string[0];
            bool isWorking = true;

            Console.WriteLine("Добро пожаловать в программу кадрового учёта!");

            while (isWorking)
            {
                int userInput;
                userInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите команду:\n" +
                    "1 - Добавить досье\n" +
                    "2 - Вывести все досье\n" +
                    "3 - Удалить досье\n" +
                    "4 - Поиск по фамилии\n" +
                    "5 - Выход\n");

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Введите ФИО через пробел:\n");
                        string fullNameInput = Console.ReadLine();
                        Console.WriteLine("Введите должность:\n");
                        string positionInput = Console.ReadLine();
                        AddDossier(ref fullName, fullNameInput, positionInput);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        isWorking = false;
                        break;
                    default:
                        break;
                }
            }
        }
        static void AddDossier(ref string[,] fullName, string fullNameInput, string positionInput)
        {
            string[] dividedFullName = fullNameInput.Split(' ');
            string[,] incrementArray = new string[fullName.Length + 1, 3];

            for(int i = 0; i < fullName.GetLength(0); i++)
            {
                for(int j = 0; j < fullName.GetLength(1); j++)
                {
                    incrementArray[i, j] = dividedFullName[i];
                }
            }
        }

        static void ShowAllDossiers()
        {

        }

        static void DeleteDossier(int dossierNumber)
        {

        }

        static void SearchBySurname(string surname)
        {

        }
    }
}
