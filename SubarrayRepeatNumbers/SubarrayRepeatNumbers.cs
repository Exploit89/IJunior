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
            int repeatingNumber = 0;
            int repeatCount = 1;
            int maxRepeatCount = 0;

            Console.WriteLine("Состав массива: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1)
                {
                    if (array[i] == array[i + 1])
                    {
                        repeatCount++;

                        if (maxRepeatCount < repeatCount)
                        {
                            repeatingNumber = array[i];
                            maxRepeatCount = repeatCount;
                        }
                    }
                    else
                    {
                        repeatCount = 1;
                    }
                }
            }

            if (maxRepeatCount == 0)
            {
                Console.WriteLine("Нет подряд повторяющихся чисел");
            }
            else
            {
                Console.WriteLine($"Число {repeatingNumber} повторяется чаще других, всего {maxRepeatCount} раз(а)");
            }
        }
    }
}
