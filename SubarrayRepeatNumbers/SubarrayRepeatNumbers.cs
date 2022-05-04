using System;

namespace SubarrayRepeatNumbers
{
    internal class SubarrayRepeatNumbers
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[30];
            int minRandomNumber = 1;
            int maxRandomNumber = 10;
            int arrayIndexIncrement = 1;
            int repeatingNumber = 0;
            int repeatCount = 1;
            int startCount = 1;
            int maxRepeatCount = 0;

            Console.WriteLine("Состав массива: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            for(int i = startCount; i < array.Length; i++)
            {
                if(array[i] == array[i - arrayIndexIncrement])
                {
                    repeatingNumber = array[i];
                    repeatCount++;
                    maxRepeatCount = repeatCount;
                }
                else
                {
                    repeatCount = 1;
                }
            }

            if(repeatingNumber == 0)
            {
                Console.WriteLine("Нет повторяющихся чисел");
            }
            else
            {
                Console.WriteLine($"Число {repeatingNumber} повторяется чаще других, всего {maxRepeatCount} раз(а)");
            }
        }
    }
}
