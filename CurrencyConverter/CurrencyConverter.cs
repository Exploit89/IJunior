using System;

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

            while (true)
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
                            Console.WriteLine($"Ваш баланс: {rur} рублей и {usd} долларов.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во рублей\n");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Обмен рублей на йены.");
                        Console.Write("Введите баланс рублей: ");
                        rur = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Введите баланс йен: ");
                        jpy = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Сколько рублей вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (rur >= currencyCount)
                        {
                            rur -= currencyCount;
                            jpy += currencyCount / rurToJpy;
                            Console.WriteLine($"Ваш баланс: {rur} рублей и {jpy} йен.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во рублей\n");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Обмен долларов на рубли.");
                        Console.Write("Введите баланс долларов: ");
                        usd = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Введите баланс рублей: ");
                        rur = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Сколько рублей вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            rur += currencyCount / usdToRur;
                            Console.WriteLine($"Ваш баланс: {usd} долларов и {rur} рублей.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во долларов\n");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Обмен долларов на йены.");
                        Console.Write("Введите баланс долларов: ");
                        usd = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Введите баланс йен: ");
                        jpy = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Сколько долларов вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (usd >= currencyCount)
                        {
                            usd -= currencyCount;
                            jpy += currencyCount / usdToJpy;
                            Console.WriteLine($"Ваш баланс: {usd} долларов и {jpy} йен.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во долларов\n");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Обмен йен на доллары.");
                        Console.Write("Введите баланс йен: ");
                        jpy = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Введите баланс долларов: ");
                        usd = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Сколько йен вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (jpy >= currencyCount)
                        {
                            jpy -= currencyCount;
                            usd += currencyCount / jpyToUsd;
                            Console.WriteLine($"Ваш баланс: {jpy} йен и {usd} долларов.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во йен\n");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Обмен йен на рубли.");
                        Console.Write("Введите баланс йен: ");
                        jpy = Convert.ToSingle(Console.ReadLine());
                        Console.Write("Введите баланс рублей: ");
                        rur = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Сколько йен вы хотите обменять?");
                        currencyCount = Convert.ToSingle(Console.ReadLine());
                        if (jpy >= currencyCount)
                        {
                            jpy -= currencyCount;
                            rur += currencyCount / jpyToRur;
                            Console.WriteLine($"Ваш баланс: {jpy} йен и {rur} рублей.\n");
                        }
                        else
                        {
                            Console.WriteLine("Недопустимое кол-во йен\n");
                        }
                        break;
                    case "0":
                        return;
                }
            }
        }
    }
}
