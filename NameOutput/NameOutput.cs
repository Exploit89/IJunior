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
            int userNameLength = userName.Length + 1;
            string userSymbolString = "";

            for(int i = 0; i <= userNameLength; i++)
            {
                userSymbolString += userSymbol;
            }
            Console.WriteLine(userSymbolString);
            Console.WriteLine(userSymbol + userName + userSymbol);
            Console.WriteLine(userSymbolString);
            Console.WriteLine("\n");
        }
    }
}
