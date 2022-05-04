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
            int userInputNumber;

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
                        userInputNumber = Convert.ToInt32(userInput);

                        for (int i = 0; i < array.Length; i++)
                        {
                            if (i != 0)
                            {
                                incrementArray[i] = array[i];
                                sum += array[i];
                            }
                            else
                            {
                                array[i] = userInputNumber;
                                incrementArray[i] = array[i];
                                sum += array[i];
                            }
                }
                        //incrementArray[incrementArray.Length - lastIndexDecrement] = userInputNumber;
                        array = incrementArray;
                        break;
                }
            }
        }
    }
}

/*1. Массивы изначально должны быть пустыми. 
 * 2. incrementArray[incrementArray.Length - lastIndexDecrement] = Convert.ToInt32(userInput); - зачем это в цикле? 
 * 3. В целом достаточно своеобразно реализовано расширение массива, посмотрите еще раз пример в лекциях. 
 * 4. сумма будет выводиться неправильно. Вы тестировали программу перед тем как отправить? 
 * Не надо, пожалуйста, отправлять заведомо нерабочий код, если есть вопросы, то на платформе есть чат, где Вы можете их задать.
*/