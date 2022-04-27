using System;

namespace Sequence
{
    internal class Sequence
    {
        static void Main(string[] args)
        {
            int incrementNumber = 7;
            int startNumber = 5;
            int endNumber = 100;

            for (int i = startNumber; i < endNumber; i += incrementNumber)
                Console.Write(i + " ");
        }
    }
}
