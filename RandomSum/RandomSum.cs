using System;

namespace RandomSum
{
    internal class RandomSum
    {
        static void Main(string[] args)
        {
            int firstDivider = 3;
            int secondDivider = 5;
            int maxNumber = 101;
            Random random = new Random();
            int randomNumber = random.Next(0, maxNumber);
            Console.WriteLine("Выбранное число: " + randomNumber);
            int result = 0;

            for (int i = 0; i <= randomNumber; i++)
            {
                if (i % firstDivider == 0 || i % secondDivider == 0)
                {
                    result += i;
                }
            }
            Console.WriteLine($"Сумма чисел до выбранного включительно, кратных {firstDivider} и {secondDivider}: {result}");
        }
    }
}
