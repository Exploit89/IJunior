using System;

namespace DynamicArray
{
    internal class DynamicArray
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            int[] incrementArray = new int[array.Length + 1];
            int lastIndexDecrement = 1;
            int sum = 0;
            int userInputNumber;
            string userInput = "";
            int stepCount = 0;

            Console.WriteLine("Команда для суммирования введеных чисел - sum\nКоманда для выхода - exit");
            Console.WriteLine("Введите число для сохранения в массив или команду: ");

            while (userInput != "exit")
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "sum":
                        for (int i = 0; i < array.Length; i++)
                        {
                            sum += array[i];
                        }
                        Console.WriteLine("Сумма значений массива = " + sum);
                        stepCount--;
                        sum = 0;
                        break;
                    default:
                        userInputNumber = Convert.ToInt32(userInput);

                        if(stepCount != 0)
                        {
                            for(int i = 0; i < stepCount; i++)
                            {
                                incrementArray[i] = array[i];
                            }
                            incrementArray[stepCount] = userInputNumber;
                            array = incrementArray;
                        }
                        else
                        {
                            incrementArray[incrementArray.Length - lastIndexDecrement] = userInputNumber;
                            array = incrementArray;
                        }
                        incrementArray = new int[array.Length + 1];
                        break;
                }
                stepCount++;
            }
        }
    }
}
