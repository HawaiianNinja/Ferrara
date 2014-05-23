using System;

namespace FerraraGame
{
    internal class Program
    {
        private static void Main()
        {
            var game = new Game(100, 100);

            for (int i = 0; i < 90; i++)
            {
                game.MakeWall(new Position(50, i));

            }
            var start = DateTime.Now;
            Console.WriteLine(start);
            for (int i = 0; i < 1; i++)
            {

                game.AddLeftSoilder();
                game.AddRightSoilder();
                game.Update();


            }
            var endtime = DateTime.Now;
            Console.WriteLine(endtime);
            Console.WriteLine((endtime.Subtract(start)));
            Console.ReadLine();

//            game.AddLeftSoilder();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            game.Update();
//            Console.WriteLine(game.ToString());
//            Console.ReadLine();
        }
    }
}
