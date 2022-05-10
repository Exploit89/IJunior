using System;
using System.Collections.Generic;

namespace StoreQueue
{
    internal class StoreQueue
    {
        static void Main(string[] args)
        {
            Queue<int> customersCash = new Queue<int>();
            customersCash.Enqueue(100);
            customersCash.Enqueue(1350);
            customersCash.Enqueue(800);
            customersCash.Enqueue(2000);
            customersCash.Enqueue(3999);

            int cashierAccount = 0;
            int currentQueueCount = customersCash.Count;

            for (int i = 0; i < currentQueueCount; i++)
            {
                Console.WriteLine($"{i + 1}й покупатель. Сумма покупки: {customersCash.Peek()}");
                cashierAccount += customersCash.Dequeue();
                Console.WriteLine($"Счёт кассира: {cashierAccount}");
                Console.ReadKey(true);
                Console.Clear();
            }

            Console.WriteLine($"Очередь пуста. Счёт кассира: {cashierAccount}");
        }
    }
}
