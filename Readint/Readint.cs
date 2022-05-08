using System;

namespace Readint
{
    internal class Readint
    {
        static void Main(string[] args)
        {
            bool successParse = false;

            while (successParse == false)
            {
                Console.WriteLine("Введите число для конвертации в тип int");
                string userInput = Console.ReadLine();
                ParseToInt(userInput, ref successParse);
            }
        }

        static void ParseToInt(string userInput, ref bool successParse)
        {
            int number;
            bool result = int.TryParse(userInput, out number);

            if (result == false)
            {
                Console.WriteLine("Не удалось сконвертировать в int. Попробуйте снова");
            }
            else
            {
                Console.WriteLine($"Успешно преобразовано в число: {number}");
                successParse = true;
            }
        }
    }
}
