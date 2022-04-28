using System;

namespace Brackets
{
    internal class Brackets
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите скобочную последовательность из символов \"(\" и \")\" ");
            string bracketString = Console.ReadLine();
            int bracketsCounter = 0;
            int stringLength = bracketString.Length;
            int nestingLevel = 0;

            if (bracketString[0] == ')' || bracketString[stringLength - 1] == '(')
            {
                Console.WriteLine("Последовательность неправильная");
            }
            else
            {
                for (int i = 0; i < stringLength; i++)
                {
                    if (bracketString[i] == '(')
                    {
                        bracketsCounter++;
                        if (nestingLevel > bracketsCounter)
                        {
                            continue;
                        }
                        else
                        {
                            nestingLevel = bracketsCounter;
                        }
                    }
                    else
                    {
                        bracketsCounter--;
                    }
                }

                if (bracketsCounter == 0)
                {
                    Console.WriteLine("Глубина скобок: " + nestingLevel);
                }
                else
                {
                    Console.WriteLine("Последовательность неправильная");
                }
            }
        }
    }
}
