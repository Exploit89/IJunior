using System;

namespace BiggestElement
{
    internal class BiggestElement
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] array = new int[10, 10];
            int minRandomNumber = 1;
            int maxRandomNumber = 50;
            int rowsIndex = 0;
            int columnsIndex = 1;
            int biggestNumber = 0;
            int numberReplaceBiggestNumbers = 0;
            Console.WriteLine("Исходный массив:");

            for (int i = 0; i < array.GetLength(rowsIndex); i++)
            {
                for (int j = 0; j < array.GetLength(columnsIndex); j++)
                {
                    array[i, j] = random.Next(minRandomNumber, maxRandomNumber);

                    if (array[i, j] > biggestNumber)
                        biggestNumber = array[i, j];
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nНаибольшее число в массиве: " + biggestNumber);
            Console.WriteLine("\nНовый массив:");

            for (int i = 0; i < array.GetLength(rowsIndex); i++)
            {
                for (int j = 0; j < array.GetLength(columnsIndex); j++)
                {
                    if (array[i, j] == biggestNumber)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        array[i, j] = numberReplaceBiggestNumbers;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if(array[i, j] == numberReplaceBiggestNumbers)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
