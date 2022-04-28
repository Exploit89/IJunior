using System;

namespace Password
{
    internal class Password
    {
        static void Main(string[] args)
        {
            string password = "abracadabra";
            int tryCount = 2;
            int tryEnd = 0;
            Console.Write("Введите пароль: ");
            string userInput = Console.ReadLine();
            string secretMessage = "Верно! Доступ открыт.";

            for (int i = tryCount; i > tryEnd; --i)
            {
                if(userInput == password)
                {
                    Console.WriteLine(secretMessage);
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверно! У вас осталось {i} попыток. Попробуйте снова");
                    userInput = Console.ReadLine();
                }
            }

            if (userInput != password)
                Console.WriteLine("Вы исчерпали все попытки. Доступ заблокирован.");
        }
    }
}
