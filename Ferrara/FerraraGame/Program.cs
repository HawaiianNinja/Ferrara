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


            Game game = new Game(10, 10);


            game.AddLeftSoilder();
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
            game.Update();
            Console.WriteLine(game.ToString());
            Console.ReadLine();
        }
    }
}
