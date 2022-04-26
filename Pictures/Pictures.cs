using System;

namespace Pictures
{
    internal class Pictures
    {
        static void Main(string[] args)
        {
            byte imagesInAlbum = 52;
            byte imagesAtRow = 3;
            int filledRows = imagesInAlbum / imagesAtRow;
            int imagesLeft = imagesInAlbum % imagesAtRow;
            Console.WriteLine("Заполненных рядов: " + filledRows);
            Console.WriteLine("Осталось картинок: " + imagesLeft);
            Console.ReadKey();
        }
    }
}
