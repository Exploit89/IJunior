using System;

namespace CurrencyConverter
{
    internal class CurrencyConverter
    {
        static void Main(string[] args)
        {
            float rubToUsd = 70f;
            float rubToJpy = 20f;
            float usdToRub = 0.65f;
            float usdToJpy = 0.15f;
            float jpyToUsd = 17f;
            float jpyToRub = 0.22f;
            float currencyCount;
            string userInput = "0";

            Console.Write("Введите баланс долларов: ");
            float usd = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс рублей: ");
            float rub = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите баланс йен: ");
            float jpy = Convert.ToSingle(Console.ReadLine());

            while (userInput != "7")
            {
                Console.WriteLine("Выберите опцию для обмена:" +
                "\n1 - Обмен рублей на доллары" +
                "\n2 - Обмен рублей на йены" +
                "\n3 - Обмен долларов на рубли" +
                "\n4 - Обмен долларов на йены" +
                "\n5 - Обмен йен на доллары" +
                "\n6 - Обмен йен на рубли" +
                "\n7 - завершить операцию");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Обмен рублей на доллары.");
                        Console.WriteLine("Сколько рублей вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            usd += currencyCount / rubToUsd;
                            Console.WriteLine($"Ваш баланс: {rub} рублей, {usd} долларов, {jpy} йен.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во рублей\n");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Обмен рублей на йены.");
                        Console.WriteLine("Сколько рублей вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rub >= currencyCount)
                        {
                            rub -= currencyCount;
                            jpy += currencyCount / rubToJpy;
                            Console.WriteLine($"Ваш баланс: {rub} рублей, {usd} долларов, {jpy} йен.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во рублей\n");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Обмен долларов на рубли.");
                        Console.WriteLine("Сколько долларов вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            rub += currencyCount / usdToRub;
                            Console.WriteLine($"Ваш баланс: {rub} рублей, {usd} долларов, {jpy} йен.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во долларов\n");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Обмен долларов на йены.");
                        Console.WriteLine("Сколько долларов вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            jpy += currencyCount / usdToJpy;
                            Console.WriteLine($"Ваш баланс: {rub} рублей, {usd} долларов, {jpy} йен.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во долларов\n");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Обмен йен на доллары.");
                        Console.WriteLine("Сколько йен вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (jpy >= currencyCount)
                        {
                            jpy -= currencyCount;
                            usd += currencyCount / jpyToUsd;
                            Console.WriteLine($"Ваш баланс: {rub} рублей, {usd} долларов, {jpy} йен.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во йен\n");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Обмен йен на рубли.");
                        Console.WriteLine("Сколько йен вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (jpy >= currencyCount)
                        {
                            jpy -= currencyCount;
                            rub += currencyCount / jpyToRub;
                            Console.WriteLine($"Ваш баланс: {rub} рублей, {usd} долларов, {jpy} йен.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во йен\n");
                        }
                        break;
                    case "7":
                        userInput = "7";
                        break;
                }
            }
        }
    }
}
