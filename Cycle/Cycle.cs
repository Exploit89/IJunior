using System;

namespace Cycle
{
    internal class Cycle
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваш текст:");
            string userText = Console.ReadLine();
            Console.WriteLine("Введите число повторений текста");
            int userRepeatCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; userRepeatCount > 0; i++)
            {
                Console.WriteLine(userText);
                userRepeatCount--;
            }
        }
    }
}
