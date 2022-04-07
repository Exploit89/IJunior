using System;
using System.Globalization;

namespace StringsTask
{
    internal class StringsTask
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, input your name: ");
            string userName = Console.ReadLine();

            Console.WriteLine("How old are you?");
            byte userAge = byte.Parse(Console.ReadLine());

            Console.WriteLine("Which color do you like?");
            string userFavouriteColor = Console.ReadLine();

            Console.WriteLine("Who are you (gender)?");
            string userGender = Console.ReadLine();

            Console.WriteLine("What is your Height in meters?");
            float userHeight = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("As we see... Your name is " + userName +
                ", and you are " + userAge + " years old. Also you are " +
                userGender + ". And your height = " + userHeight + 'm' +
                "\n oh... of course your favourite color is " + userFavouriteColor);
        }
    }
}
