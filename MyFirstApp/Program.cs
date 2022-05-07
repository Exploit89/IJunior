using System;

namespace MyFirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DrawBar(40);
        }

        static void DrawBar(int value)
        {
            char fillSymbol = '#';
            char emptySymbol = '_';
            int maxHealth = 20;
            float health = maxHealth / 100 * value;
            string bar = "";

            for (int i = 0; i < health; i++)
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
