using System;

namespace Grannies
{
    internal class Grannies
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько старушек в очереди?");
            int grannies = int.Parse(Console.ReadLine());
            int minutesPerEachGranny = 10;
            int minutesInHour = 60;
            int grannyHours = minutesPerEachGranny * grannies;
            int waitingHours = grannyHours / minutesInHour;
            int waitingMinutes = grannyHours % minutesInHour;
            Console.WriteLine($"Вы должны ждать в очереди { waitingHours } часов и { waitingMinutes } минут");
        }
    }
}
