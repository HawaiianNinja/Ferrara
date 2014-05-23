using System;

namespace FerraraGame
{
    internal class Program
    {
        private static void Main()
        {
            var game = new Game(1000, 1000);

            for (int i = 0; i < 900; i++)
            {
                game.MakeWall(new Position(500, i));
                game.MakeWall(new Position(510, 999-i));

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
