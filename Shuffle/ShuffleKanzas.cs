using System;

namespace Shuffle
{
    internal class ShuffleKanzas
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minValue = 0;
            int maxValue = 10;
            int[] sourceArray = new int[15];
            Console.WriteLine("Исходный случайный массив: ");

            for(int i = 0; i < sourceArray.Length; i++)
            {
                sourceArray[i] = random.Next(minValue, maxValue);
                Console.Write(sourceArray[i] + " ");
            }
            Console.WriteLine();

            Shuffle(ref sourceArray);
            Console.WriteLine("Перемешанный массив: ");

            for (int i = 0; i < sourceArray.Length; i++)
            {
                Console.Write(sourceArray[i] + " ");
            }
            Console.WriteLine();
        }

        static void Shuffle(ref int[] sourceArray)
        {
            for(int i = sourceArray.Length - 1; i >= 1; i--)
            {
                Random randomIndex = new Random();
                int replacementIndex = randomIndex.Next(i + 1);
                int changedNumber = sourceArray[replacementIndex];
                sourceArray[replacementIndex] = sourceArray[i];
                sourceArray[i] = changedNumber;
            }
        }
    }
}
