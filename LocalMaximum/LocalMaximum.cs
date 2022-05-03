using System;

namespace LocalMaximum
{
    internal class LocalMaximum
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            Random random = new Random();
            int minRandomNumber = 1;
            int maxRandomNumber = 10;
            int leftNeigborIndex = -1;
            int rightNeigborIndex = 1;
            int arrayIndexIncrement = 1;
            int arrayLastIndex = array.Length - 1;
            int arrayPreviousLastIndex = array.Length - 2;

            Console.WriteLine("Состав массива:");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nЛокальные максимумы: ");

            if (array[0] > array[1])
            {
                Console.Write(array[0] + " ");
            }

            for (int i = arrayIndexIncrement; i < arrayLastIndex; i++)
            {
                if(array[i] > array[i + leftNeigborIndex] && array[i] > array[i + rightNeigborIndex])
                {
                    Console.Write(array[i] + " ");
                }
            }

            if (array[arrayLastIndex] > array[arrayPreviousLastIndex])
            {
                Console.Write(array[arrayLastIndex] + " ");
            }
            Console.WriteLine();
        }
    }
}
