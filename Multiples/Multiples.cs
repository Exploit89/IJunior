using System;

namespace Multiples
{
    internal class Multiples
    {
        static void Main(string[] args)
        {
            int minRandomNumber = 1;
            int maxRandomNumber = 28;
            int minThreeDigitNumber = 100;
            int maxMultiplicityRange = 999;
            int minMultiplicityRange = 0;
            int multiplicityCount = 0;

            Random randomNumber = new Random();
            int givenNumber = randomNumber.Next(minRandomNumber, maxRandomNumber);

            for(int i = 0; i <= minThreeDigitNumber; i+= givenNumber)
            {
                minMultiplicityRange += givenNumber;
            }

            for (int i = minMultiplicityRange; i <= maxMultiplicityRange; i += givenNumber)
            {
                multiplicityCount++;
            }

            Console.WriteLine("Выбранное число: " + givenNumber);
            Console.WriteLine("Количество трехзначных натуральных чисел," +
                $" кратных {givenNumber} равно {multiplicityCount}");
        }
    }
}
