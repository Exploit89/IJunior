using System;

namespace SwappingValues
{
    internal class SwappingValues
    {
        static void Main(string[] args)
        {
            string name = "Khu";
            string surName = "Aleks";

            Console.WriteLine("Initial values");
            Console.WriteLine("Name: " + name + "\nSurname: " + surName + "\n");

            (name, surName) = (surName, name);
            Console.WriteLine("After swapping");
            Console.WriteLine("Name: " + name + "\nSurname: " + surName + "\n");
        }
    }
}
