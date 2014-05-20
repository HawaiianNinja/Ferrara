using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            GameBoard b = new GameBoard();
            Console.WriteLine(b);
            b.Update();
            Console.WriteLine("===================================================================================\n");
            Console.WriteLine(b);
            Console.ReadLine();*/

            Game game = new Game(10, 10);

            Console.WriteLine(game.ToString());
            game.AddLeftSoilder();
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
