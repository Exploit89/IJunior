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
                {'#','X','#','X',' ',' ','#',' ','#',' ','#',' ','#',' ','#',' ',' ','#',' ',' ',' ',' ','#',' ',' ','#',' ',' ','%','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}
            };
            char[] bag = new char[0];
            int totalChestCount = 9;
            int userX = 1;
            int userY = 1;
            bool isGaming = true;

            Console.CursorVisible = false;

            while (isGaming)
            {
                DrawMap(map);
                Console.SetCursorPosition(31, 0);
                Console.WriteLine("Соберите все сундуки 'X' и доберитесь до выхода '%'");
                Console.SetCursorPosition(31, 1);
                Console.Write("Сумка: ");

                for(int i = 0; i < bag.Length; i++)
                {
                    Console.Write(bag[i] + " ");
                }

                Console.SetCursorPosition(userX, userY);
                Console.Write('@');
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveUp(map, ref userX, ref userY);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown(map, ref userX, ref userY);
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveLeft(map, ref userX, ref userY);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight(map, ref userX, ref userY);
                        break;
                }

                PickupItem(map, ref bag, userX, userY);
                GameOver(map, bag, userX, userY, totalChestCount, ref isGaming);
                Console.Clear();
            }
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
        
        static void MoveUp(char[,] map, ref int userX, ref int userY)
        {
            if (map[userY - 1, userX] != '#')
            {
                userY--;
            }
        }

        static void MoveDown(char[,] map, ref int userX, ref int userY)
        {
            if (map[userY + 1, userX] != '#')
            {
                userY++;
            }
        }

        static void MoveLeft(char[,] map, ref int userX, ref int userY)
        {
            if (map[userY, userX - 1] != '#')
            {
                userX--;
            }
        }

        static void MoveRight(char[,] map, ref int userX, ref int userY)
        {
            if (map[userY, userX + 1] != '#')
            {
                userX++;
            }
        }

        static void PickupItem(char[,] map, ref char[] bag, int userX, int userY)
        {
            if (map[userY, userX] == 'X')
            {
                map[userY, userX] = 'o';
                char[] tempBag = new char[bag.Length + 1];

                for (int i = 0; i < bag.Length; i++)
                {
                    tempBag[i] = bag[i];
                }
                tempBag[tempBag.Length - 1] = 'X';
                bag = tempBag;
            }
        }

        static void GameOver(char[,] map, char[] bag, int userX, int userY, int totalChestCount, ref bool isGaming)
        {
            if (map[userY, userX] == '%' && bag.Length == totalChestCount)
            {
                Console.SetCursorPosition(31, 2);
                Console.WriteLine("Поздравляем! Вы выиграли!");
                isGaming = false;
            }
        }
    }
}
