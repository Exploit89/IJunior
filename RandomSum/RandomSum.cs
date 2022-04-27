using System;

namespace RandomSum
{
    internal class RandomSum
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 101);
            Console.WriteLine("Выбранное число: " + randomNumber);
            int result = 0;

            for (int i = 0; i <= randomNumber; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }
            Console.WriteLine("Сумма чисел до выбранного включительно, кратных 3 и 5: " + result);
        }
    }
}
