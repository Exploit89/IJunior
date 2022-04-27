using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    internal class CurrencyConverter
    {
        static void Main(string[] args)
        {
            int rurToUsd = 70;
            int rurToJpy = 20;
            int usdToRur = 65;
            int usdToJpy = 15;
            int jpyToUsd = 17;
            int jpyToRur = 22;

            float usd;
            float rur;
            float jpy;
            float currencyCount;

            while (userInput != "0")
            {
                Console.WriteLine("Выберите опцию для обмена:" +
                "\n1 - Обмен рублей на доллары" +
                "\n2 - покупка йен за рубли" +
                "\n3 - покупка рублей за доллары" +
                "\n4 - покупка йен за доллары" +
                "\n5 - покупка долларов за йены" +
                "\n6 - покупка рублей за йены" +
                "\n0 - завершить операцию");
                string userInput = Console.ReadLine();


                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Обмен рублей на доллары.");
                        Console.Write("Введите баланс рублей: ");
                        rur = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Введите баланс долларов: ");
                        usd = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Сколько рублей вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rur >= currencyCount)
                        {
                            rur -= currencyCount;
                            usd += currencyCount / rurToUsd;
                            Console.WriteLine($"Ваш баланс: {rur} рублей и {usd} долларов.");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во рублей");
                        }
                        break;
                }
            }
        }
    }
}
