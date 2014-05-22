using System;

namespace FerraraGame
{
    internal class Program
    {
        private static void Main()
        {
            var game = new Game(5, 5);


            game.AddLeftSoilder();
            game.AddRightSoilder();
            game.AddLeftSoilder();
            Console.WriteLine(game.ToString());
            game.Update();
            game.AddRightSoilder();
            Console.WriteLine(game.ToString());
            game.Update();
            Console.WriteLine(game.ToString());
            game.Update();
            Console.WriteLine(game.ToString());
            game.Update();
            Console.WriteLine(game.ToString());
            game.Update();
            Console.WriteLine(game.ToString());
            game.Update();
            Console.WriteLine(game.ToString());
            game.Update();
            Console.WriteLine(game.ToString());
            Console.ReadLine();
        }
    }
}