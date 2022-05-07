using System;

namespace UIElement
{
    internal class UIElement
    {
        static void Main(string[] args)
        {
            bool isWorking = true;
            int fillingPercentage = 0;
            string userInput;

            while (isWorking == true)
            {
                DrawBar(fillingPercentage);
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Введите процент заполнения полосы здоровья " +
                    "\nИли команду exit для выхода");
                Console.SetCursorPosition(0, 5);
                userInput = Console.ReadLine();

                if (userInput == "exit")
                {
                    isWorking = false;
                }
                else
                {
                    fillingPercentage = Convert.ToInt32(userInput);
                }

                if (fillingPercentage >= 0 && fillingPercentage <= 100)
                {
                    DrawBar(fillingPercentage);
                }
                else
                {
                    Console.WriteLine("Введено неверное значение. Должно быть от 0 до 100" +
                        "\nДля продолжения нажмите любую клавишу");
                    fillingPercentage = 0;
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }

        static void DrawBar(int value)
        {
            char fillSymbol = '#';
            char emptySymbol = '_';
            float maxHealth = 20;
            float health = maxHealth / 100 * value;
            string bar = "";

            for(int i = 0; i < health; i++)
            {
                bar += fillSymbol;
            }

            Console.SetCursorPosition(0, 0);
            Console.Write('[');
            Console.Write(bar);
            bar = "";

            for (float i = health; i < maxHealth; i++)
            {
                bar += emptySymbol;
            }

            Console.Write(bar + ']');
        }
    }
}
