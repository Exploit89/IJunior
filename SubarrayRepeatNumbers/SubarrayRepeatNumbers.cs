using System;

namespace SubarrayRepeatNumbers
{
    internal class SubarrayRepeatNumbers
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[20];
            int minRandomNumber = 1;
            int maxRandomNumber = 9;
            int arrayIndexIncrement = 1;
            int repeatingNumber = 0;
            int repeatCount = 1;
            int maxRepeatCount = 0;
            int severalMaxRepeatCount = 0;
            int zeroingSeveralMaxRepeatCount = 0;

            Console.WriteLine("Состав массива: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                if ((i + arrayIndexIncrement) < array.Length)
                {
                    if (array[i] == array[i + arrayIndexIncrement])
                    {
                        repeatCount++;

                        if (maxRepeatCount < repeatCount)
                        {
                            repeatingNumber = array[i];
                            maxRepeatCount = repeatCount;
                            severalMaxRepeatCount = zeroingSeveralMaxRepeatCount;
                        }
                        else if (maxRepeatCount == repeatCount && array[i] != repeatingNumber)
                        {
                            severalMaxRepeatCount += repeatCount;
                        }
                    }
                    else
                    {
                        repeatCount = 1;
                    }
                }
            }

            if (repeatingNumber == 0)
            {
                Console.WriteLine("Нет подряд повторяющихся чисел");
            }
            else if (severalMaxRepeatCount > 0 && maxRepeatCount <= severalMaxRepeatCount)
            {
                Console.WriteLine("В массиве нет единого наибольшего числа повторений подряд");
            }
            else
            {
                Console.WriteLine($"Число {repeatingNumber} повторяется чаще других, всего {maxRepeatCount} раз(а)");
            }
        }
    }
}
