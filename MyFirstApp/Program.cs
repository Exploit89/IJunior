using System;

namespace MyFirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bag = new int[0];
            int[] tempBag = new int[bag.Length + 1];
            for(int i = 0; i < bag.Length; i++)
            {
                tempBag[i] = bag[i];
            }
            tempBag[tempBag.Length - 1] = Convert.ToInt32(Console.ReadLine());
            bag = tempBag;
            Console.WriteLine(bag.Length);
        }
    }
}
