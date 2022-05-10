using System;

namespace BraveNewWorld
{
    internal class BraveNewWorld
    {
        static void Main(string[] args)
        {
            char[,] map = new char[,]
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#',' ','#',' ',' ',' ',' ',' ',' ','#','X',' ','#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ','#',' ','#'},
                {'#',' ','#',' ',' ','#','#','#',' ','#','#',' ','#',' ',' ','#',' ','#','#','#','#','#',' ','#',' ','#',' ',' ',' ','#'},
                {'#',' ','#',' ',' ','#',' ','#',' ','#',' ',' ','#',' ','#','#',' ','#',' ',' ',' ',' ',' ','#',' ','#','#','#',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ',' ',' ','#','X',' ',' ','#'},
                {'#',' ','#','#','#','#','#','#',' ','#','#','#',' ','#',' ',' ',' ','#',' ',' ','#','#','#','#',' ','#','#','#','#','#'},
                {'#',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#','#','#',' ','#','#',' ','#',' ','#','#','#',' ','#','X','#',' ',' ',' ',' ',' ','#','#','#',' ','#'},
                {'#','X','#',' ','#',' ','#','#','#',' ',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ',' ','#',' ','#','#',' ',' ',' ','#'},
                {'#','#','#',' ','#',' ',' ',' ','#',' ',' ','#',' ','#','X','#',' ','#',' ','#',' ','#','#',' ',' ','#',' ','#',' ','#'},
                {'#',' ',' ',' ','#',' ','#',' ','#',' ',' ','#','#','#','#','#',' ','#',' ','#',' ',' ','#','#',' ',' ',' ','#',' ','#'},
                {'#',' ','#',' ','#',' ','#',' ','#',' ','#','#',' ','#',' ',' ',' ','#','X','#',' ',' ','#',' ',' ','#',' ','#',' ','#'},
                {'#',' ','#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#','#','#',' ',' ','#',' ','#','#',' ','#',' ','#'},
                {'#',' ',' ','#','#',' ','#',' ','#',' ',' ',' ','#',' ','#',' ',' ',' ',' ',' ',' ',' ','#',' ','X','#',' ','#','#','#'},
                {'#','X','#','X',' ',' ','#',' ','#',' ','#',' ','#',' ','#',' ',' ','#',' ',' ',' ',' ','#',' ',' ','#',' ',' ',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
            };
            char[] bag = new char[0];
            int totalChestCount = 9;
            bool isGaming = true;
            int userX = 1;
            int userY = 1;
            int userDirectionX = 0;
            int userDirectionY = 0;


            Console.CursorVisible = false;

            DrawMap(map);

            while (isGaming)
            {
                Console.SetCursorPosition(31, 0);
                Console.WriteLine("Соберите все сундуки 'X'");
                Console.SetCursorPosition(31, 1);
                Console.Write("Сумка: ");

                for(int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo charKey = Console.ReadKey(true);
                    ChangeDirection(charKey, userDirectionX, userDirectionY, map, ref userX, ref userY, ref bag);

                    if (bag.Length == totalChestCount)
                    {
                        isGaming = false;
                    }
                }
            }

            GameOver();
        }

        static void DrawMap(char[,] map)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void GameOver()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Поздравляем! Вы выиграли!");
        }

        static void PickUpItem(char[,] map, int userX, int userY, ref char[] bag)
        {
            if (map[userX, userY] == 'X')
            {
                map[userX, userY] = ' ';
                char[] tempBag = new char[bag.Length + 1];

                for (int i = 0; i < bag.Length; i++)
                {
                    tempBag[i] = bag[i];
                }
                tempBag[tempBag.Length - 1] = 'X';
                bag = tempBag;
            }
        }

        static void ChangeDirection(ConsoleKeyInfo charKey, int userDirectionX, int userDirectionY, char[,] map, ref int userX, ref int userY, ref char[] bag)
        {
            switch (charKey.Key)
            {
                case ConsoleKey.UpArrow:
                    userDirectionX = -1;
                    userDirectionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    userDirectionX = 1;
                    userDirectionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    userDirectionX = 0;
                    userDirectionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    userDirectionX = 0;
                    userDirectionY = 1;
                    break;
            }

            if (map[userX + userDirectionX, userY + userDirectionY] != '#')
            {
                Console.SetCursorPosition(userY, userX);
                Console.Write(" ");

                userX += userDirectionX;
                userY += userDirectionY;

                PickUpItem(map, userX, userY, ref bag);

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');
            }
        }
    }
}
