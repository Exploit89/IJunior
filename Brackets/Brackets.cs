using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int nestingLevel = 1;

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
                        if(bracketString[i] == bracketString[i+1])
                        {
                            bracketsCounter++;
                            nestingLevel++;
                        }
                        else
                        {
                            bracketsCounter++;
                        }   
                    }
                    else
                    {
                        bracketsCounter--;
                    }
                }
                Console.WriteLine(bracketsCounter);
                Console.WriteLine(nestingLevel);
            }
        }
    }
}
