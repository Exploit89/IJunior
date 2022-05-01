using System;

namespace Array
{
    internal class Array
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] array = new int[4, 5];
            int minRandomNumber = 1;
            int maxRandomNumber = 10;
            int rowsIndex = 0;
            int columnsIndex = 1;
            int secondRowIndex = 1;
            int secondRowSum = 0;
            int firstColumnIndex = 0;
            int firstColumnProduct = 1;
            Console.WriteLine("Состав массива:");

            for (int i = 0; i < array.GetLength(rowsIndex); i++)
            {
                for(int j = 0; j < array.GetLength(columnsIndex); j++)
                {
                    array[i, j] = random.Next(minRandomNumber, maxRandomNumber);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            for(int i = 0; i < array.GetLength(secondRowIndex); i++)
            {
                secondRowSum += array[secondRowIndex, i];
            }
            Console.WriteLine("\nСумма второй строки: " + secondRowSum);

            for(int i = 0; i < array.GetLength(firstColumnIndex); i++)
            {
                firstColumnProduct *= array[i, firstColumnIndex];
            }
            Console.WriteLine($"\nПроизведение первого столбца: { firstColumnProduct} \n");
        }
    }
}
