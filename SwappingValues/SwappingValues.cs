using System;

namespace SwappingValues
{
    internal class SwappingValues
    {
        static void Main(string[] args)
        {
            string name = "Khu";
            string surname = "Aleks";

            Console.WriteLine("Исходные данные");
            Console.WriteLine($"Имя: { name } \nФамилия: { surname } \n");

            (name, surname) = (surname, name);
            Console.WriteLine("Поменяли местами");
            Console.WriteLine($"Имя: { name } \nФамилия: { surname } \n");
        }
    }
}
