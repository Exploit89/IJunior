using System;

namespace ArrayShift
{
    internal class ArrayShift
    {
        static void Main(string[] args)
        {
            int[] array = { 8, 6, 7, 5, 3, 0, 9 };
            int firstNumber;

            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Введите число, на которое необходимо сдвинуть значения массива влево");
            int userInput = Convert.ToInt32(Console.ReadLine());

            for(int i=0; i < userInput; i++)
            {
                firstNumber = array[0];

                for(int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = firstNumber;
            }

            Console.WriteLine("Новый массив: ");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
