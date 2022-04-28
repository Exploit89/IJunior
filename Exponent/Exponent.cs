using System;

namespace Exponent
{
    internal class Exponent
    {
        static void Main(string[] args)
        {
            int minRandomNumber = 10;
            int maxRandomNumber = 500;
            int exponentCount = 1;
            int exponentResult = 1;
            int exponintiableNumber = 2;

            Random randomNumber = new Random();
            int givenNumber = randomNumber.Next(minRandomNumber, maxRandomNumber);

            for(int i = exponintiableNumber; i <= givenNumber; i*=exponintiableNumber)
            {
                exponentCount++;
            }

            for(int i = 0; i < exponentCount; i++)
            {
                exponentResult *= exponintiableNumber;
            }

            Console.WriteLine("Выбранное число: " + givenNumber);
            Console.WriteLine("Степень числа: " + exponentCount);
            Console.WriteLine($"Двойка в степени {exponentCount} равна {exponentResult}");
            Console.WriteLine($"{givenNumber} < {exponentResult}");
        }
    }
}
