using System;

namespace WorkingWIthProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            Console.WriteLine(player.PositionX);
            Console.WriteLine(player.PositionY);
            player.DrawPlayer();
        }
    }

    class Player
    {
        public Player()
        {
            PositionX = 5;
            PositionY = 3;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public void DrawPlayer(char playerCharacter = '@')
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.WriteLine(playerCharacter);
        }
    }
}
