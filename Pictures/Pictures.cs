using System;

namespace Pictures
{
    internal class Pictures
    {
        static void Main(string[] args)
        {
            byte album = 52;
            byte imagesAtRow = 3;
            int integerPart = album / imagesAtRow;
            int images = integerPart * imagesAtRow;
            int remainder = album % imagesAtRow;
            Console.WriteLine("Картинок: " + integerPart);
            Console.WriteLine("Осталось: " + remainder);
        }
    }
}
