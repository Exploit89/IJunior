using System;

namespace DynamicArray
{
    internal class DynamicArray
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            string userInput = "";

            Console.WriteLine("Команда для суммирования введеных чисел - sum\nКоманда для выхода - exit");
            Console.WriteLine("Введите число для сохранения в массив или команду: ");

            while (userInput != "exit")
            {
                userInput = Console.ReadLine();
                int sum = 0;
                int userInputNumber;

                switch (userInput)
                {
                    case "exit":
                        Console.WriteLine("Выход из приложения");
                        break;
                    case "sum":
                        for (int i = 0; i < array.Length; i++)
                        {
                            sum += array[i];
                        }
                        Console.WriteLine("Сумма значений массива = " + sum);
                        break;
                    default:
                        userInputNumber = Convert.ToInt32(userInput);
                        int[] incrementArray = new int[array.Length + 1];
                        for (int i = 0; i < array.Length; i++)
                        {
                            incrementArray[i] = array[i];
                        }

                        incrementArray[array.Length] = userInputNumber;
                        array = incrementArray;
                        break;
                }
            }
        }
    }
}
