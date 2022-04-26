using System;

namespace CycleExit
{
    internal class CycleExit
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string userText = Console.ReadLine();

            while (userText != "exit")
            {
                string result = userText + userText;
                Console.WriteLine(result);
                Console.WriteLine("Для выхода из программы введите \"exit\"");
                Console.WriteLine("Введите новый текст:");
                userText = Console.ReadLine();
            }
        }
    }
}
