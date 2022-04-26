using System;

namespace Pictures
{
    internal class Pictures
    {
        static void Main(string[] args)
        {
            byte album = 52;
            byte imagesAtRow = 3;
            int filledRows = album / imagesAtRow;
            int images = filledRows * imagesAtRow;
            int remainder = album % imagesAtRow;
            Console.WriteLine("Рядов: " + filledRows);
            Console.WriteLine("Осталось картинок: " + remainder);
            Console.ReadKey();
        }
    }
}
