using System;

namespace Readint
{
    internal class Readint
    {
        static void Main(string[] args)
        {
            int number = ReadInt();
            Console.WriteLine($"Успешно преобразовано в число: {number}");
        }

        static int ReadInt()
        {
            bool isNumber = false;
            int number = 0;

            while (isNumber == false)
            {
                Console.WriteLine("Введите число для конвертации в тип int");
                string userInput = Console.ReadLine();
                isNumber = int.TryParse(userInput, out number);

                if (isNumber == false)
                {
                    Console.WriteLine("Не удалось сконвертировать в int. Попробуйте снова");
                }
                else
                {
                    isNumber = true;
                }
            }

            return number;
        }
    }
}
