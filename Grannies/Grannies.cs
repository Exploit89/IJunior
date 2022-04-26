using System;

namespace Grannies
{
    internal class Grannies
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько старушек в очереди?");
            int granniesQueue = int.Parse(Console.ReadLine());
            int minutesPerEachGranny = 10;
            int minutesInHour = 60;
            int totalQueueTime = minutesPerEachGranny * granniesQueue;
            int waitingHours = totalQueueTime / minutesInHour;
            int waitingMinutes = totalQueueTime % minutesInHour;
            Console.WriteLine($"Вы должны ждать в очереди { waitingHours } часа(ов) и { waitingMinutes } минут");
        }
    }
}
