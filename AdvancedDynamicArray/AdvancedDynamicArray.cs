using System;
using System.Collections.Generic;

namespace AdvancedDynamicArray
{
    internal class AdvancedDynamicArray
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string userInput;
            bool isWorking = true;

            Console.WriteLine("Команда для суммирования введеных чисел - sum\nКоманда для выхода - exit");
            Console.WriteLine("Введите число для сохранения в массив или команду: ");

            while (isWorking)
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        isWorking = false;
                        break;
                    case "sum":
                        SumUp(numbers);
                        break;
                    default:
                        AddNumber(userInput, numbers);
                        break;
                }
            }
        }

        static void SumUp(List<int> numbers)
        {
            int sum = 0;

            foreach(int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine("Сумма значений массива = " + sum);
        }

        static void AddNumber(string userInput, List<int> numbers)
        {
            bool userNumber = int.TryParse(userInput, out int number);

            if (userNumber)
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Вы ввели не число. Попробуйте еще раз"); 
            }
        }
    }
}
