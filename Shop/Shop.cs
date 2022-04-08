using System;

namespace Shop
{
    internal class Shop
    {
        static void Main(string[] args)
        {
            int exchangeRate = 3;
            Console.WriteLine("Сколько денег ты принёс?");
            int goldWallet = int.Parse(Console.ReadLine());

            Console.WriteLine("Курс 1 к " + exchangeRate);
            Console.WriteLine("Сколько кристаллов вы хотите приобрести?");
            int crystallsWallet = int.Parse(Console.ReadLine());

            int goldBalance = crystallsWallet * exchangeRate;
            goldWallet = goldWallet - goldBalance;
            Console.WriteLine("Вы приобрели " + crystallsWallet + "кристаллов.");
            Console.WriteLine("У вас осталось " + goldWallet + " золота.");
        }
    }
}
