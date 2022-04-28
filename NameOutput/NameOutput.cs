using System;

namespace NameOutput
{
    internal class NameOutput
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string userName = Console.ReadLine();
            Console.Write("Введите любой символ: ");
            char userSymbol = Convert.ToChar(Console.ReadLine());
            int userNameLength = userName.Length;
            for(int i = -1; i <= userNameLength; i++)
            {
                Console.Write(userSymbol);
            }
            Console.WriteLine("\n" + userSymbol + userName + userSymbol);
            for (int i = -1; i <= userNameLength; i++)
            {
                Console.Write(userSymbol);
            }
            Console.WriteLine("\n");
        }
    }
}
