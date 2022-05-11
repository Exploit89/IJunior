using System;
using System.Collections.Generic;

namespace MergingCollections
{
    internal class MergingCollections
    {
        static void Main(string[] args)
        {
            string[] firstArray = { "1", "2", "5", "7" };
            string[] secondArray = { "2", "8", "9", "5" };
            List<string> list = new List<string>();

            list.AddRange(firstArray);
            list.AddRange(secondArray);
            RemoveEqualValues(list);
            list.Sort();

            Console.Write($"Первый массив строк: ");
            WriteComposition(firstArray);
            Console.Write($"Второй массив строк: ");
            WriteComposition(secondArray);
            Console.Write("Итоговая коллекция: ");
            WriteComposition(list);
        }

        static void WriteComposition(string[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void WriteComposition(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        static void RemoveEqualValues(List<string> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                for(int j = 0; j < list.Count; j++)
                {
                    if(list[i] == list[j] && i != j)
                    list.Remove(list[i]);
                }
            }
        }
    }
}
