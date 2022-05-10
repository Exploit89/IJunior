using System;
using System.Collections.Generic;

namespace Dictionary
{
    internal class Dictionary
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> irregularVerbs = new Dictionary<string, string>();
            irregularVerbs.Add("begin", "began - begun");
            irregularVerbs.Add("bite", "bit - bitten");
            irregularVerbs.Add("blow", "blew - blown");
            irregularVerbs.Add("forget", "forgot - forgotten");
            irregularVerbs.Add("see", "saw - seen");

            bool isWorking = true;

            Console.WriteLine("Таблица неправильных глаголов английского языка");

            while (isWorking)
            {
                Console.WriteLine("Введите первую форму глагола:" +
                    "\n(слова для проверки: see, forget, blow, bite, begin" +
                    "\nВведите 'exit' для выхода");
                string userInput = Console.ReadLine();

                if (irregularVerbs.ContainsKey(userInput))
                {
                    Console.WriteLine($"Ваш результат: {userInput} - {irregularVerbs[userInput]}\n");
                }
                else if(userInput == "exit")
                {
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine("Такого глагола в словаре нет. Попробуйте еще раз.\n");
                }
            }
        }
    }
}
