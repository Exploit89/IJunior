using System;

namespace Split
{
    internal class Split
    {
        static void Main(string[] args)
        {
            string someString = "Тестовая строка с текстом, которую надо бы распилить по словам.\n";
            Console.WriteLine(someString);
            string[] dividedString = someString.Split(' ');

            foreach(string word in dividedString)
            {
                Console.WriteLine(word);
            }
        }
    }
}
