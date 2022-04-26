using System;

namespace Shop
{
    internal class Shop
    {
        static void Main(string[] args)
        {
            int crystallEachCost = 3;
            Console.WriteLine("Сколько у вас золота?");
            int userGold = int.Parse(Console.ReadLine());

            Console.WriteLine($"Стоимость одного кристалла = { crystallEachCost } золота");
            Console.WriteLine("Сколько кристаллов вы хотите приобрести?");
            int crystallsOrder = int.Parse(Console.ReadLine());

            userGold -= crystallsOrder * crystallEachCost;
            Console.WriteLine($"Вы приобрели { crystallsOrder } кристалл(ов).");
            Console.WriteLine($"У вас осталось { userGold } золота.");
        }
    }
}
