using System;

namespace ConsoleMenu
{
    internal class ConsoleMenu
    {
        static void Main(string[] args)
        {
            string userInput = "0";
            string userName;
            int manyUserNames = 100;
            int tryToWakeCount = 2;
            int windowHeight = 30;
            int windowWidth = 90;
            int menuXPosition = 30;
            int menuYPosition = 10;

            Console.WriteLine("Разбудите меню! Введите \"wakeup\"");
            userInput = Console.ReadLine();
            for (int i = tryToWakeCount; i > 0 && userInput != "wakeup"; i--)
            {
                Console.WriteLine("Разбудите меню! Введите \"wakeup\"" +
                    $"\n У вас осталось {i} попытки");
                userInput = Console.ReadLine();
            }
            if (userInput == "wakeup")
            {
                Console.WindowHeight = windowHeight;
                Console.WindowWidth = windowWidth;
                Console.SetCursorPosition(menuXPosition, menuYPosition);
                Console.WriteLine("Используйте следующие команды:\n" +
                    "                    exit\n" +
                    "                    clear\n" +
                    "                    magentafgcolor\n" +
                    "                    resetcolor\n" +
                    "                    typemyname\n" +
                    "                    yellowbgcolor\n");
            }
            else
            {
                return;
            }

            while (userInput != "exit")
            {
                Console.WindowHeight = windowHeight;
                Console.WindowWidth = windowWidth;
                Console.SetCursorPosition(menuXPosition, menuYPosition);
                Console.WriteLine("Используйте следующие команды:\n" +
                    "                    exit\n" +
                    "                    clear\n" +
                    "                    magentafgcolor\n" +
                    "                    resetcolor\n" +
                    "                    typemyname\n" +
                    "                    yellowbgcolor\n");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "exit":
                        Console.WriteLine("\nТестирование завершено\n");
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "magentafgcolor":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Clear();
                        break;
                    case "resetcolor":
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case "typemyname":
                        Console.WriteLine("Введите ваше имя: ");
                        userName = Console.ReadLine();
                        Console.Clear();
                        for (int i = 0; i < manyUserNames; i++)
                        {
                            Console.Write(userName);
                        }
                        break;
                    case "yellowbgcolor":
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\nНеизвестная команда! Попробуйте еще раз.");
                        break;
                }
            }
        }
    }
}
