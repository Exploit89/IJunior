using System;

namespace SortingNumbers
{
    internal class SortingNumbers
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[10];
            int minRandomNumber = 1;
            int maxRandomNumber = 10;
            int arrayIndexIncrement = 1;
            int bufferNumber;

            Console.WriteLine("Состав исходного массива: ");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minRandomNumber, maxRandomNumber);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for(int i = 0; i < array.Length; i++)
            {
                for(int j = i + arrayIndexIncrement; j < array.Length; j++)
                {
                    if(array[i] > array[j])
                    {
                        bufferNumber = array[i];
                        array[i] = array[j];
                        array[j] = bufferNumber;
                    }
                }
            }

            Console.WriteLine("Числа отсортированы от меньшего к большему: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
