using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinClient
{
    abstract class GameEntity
    {

        public Position Position { get; set; }
        public int Health { get; set; }

        public int Width { get; set; }
        public int Heith { get; set; }
        
        
        

    }
}
