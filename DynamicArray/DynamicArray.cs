using System;

namespace DynamicArray
{
    internal class DynamicArray
    {
        static void Main(string[] args)
        {
            int[] array = new int[1];
            int[] incrementArray = new int[array.Length + 1];
            int lastIndexDecrement = 1;
            int sum = 0;

            Console.WriteLine("Команда для суммирования введеных чисел - sum\nКоманда для выхода - exit");
            Console.WriteLine("Введите число для сохранения в массив или команду: ");
            string userInput = Console.ReadLine();

            while (userInput != "exit")
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        break;
                    case "sum":
                        Console.WriteLine("Сумма значений массива = " + sum);
                        break;
                    default:
                        for (int i = 0; i < array.Length; i++)
                        {
                            incrementArray[i] = array[i];
                            incrementArray[incrementArray.Length - lastIndexDecrement] = Convert.ToInt32(userInput);
                            array = incrementArray;
                            sum += array[i];
                        }
                        incrementArray = new int[array.Length + 1];
                        break;
                }
            }
        }
    }
}
