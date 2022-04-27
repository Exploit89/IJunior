using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameOutput
{
    internal class NameOutput
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string userName = Console.ReadLine();
            Console.Write("Введите любой символ: ");
            char userSymbol = Convert.ToChar(Console.ReadLine());
            int userNameLength = userName.Length;


        }
    }
}
