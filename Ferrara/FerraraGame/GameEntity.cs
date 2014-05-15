using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    abstract class GameEntity
    {
        public Position CurrentPostion;
        public int PosX { get; set; }

        public GameEntity(Position position, int posX)
        {
            CurrentPostion = position;
            PosX = posX;
        }

        abstract public  void Update(GameEntity[][] board);

        public override String  ToString()
        {
            return "1";
        }
    }
}
