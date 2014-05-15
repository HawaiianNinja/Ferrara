using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Soldier : GameEntity
    {

        public Soldier(Position p, int posX) : base(p, posX) { }
        public override void Update(GameEntity[][] board)
        {
            if (board[CurrentPostion.X + PosX][CurrentPostion.Y] == null)
            {
                board[CurrentPostion.X][CurrentPostion.Y] = null;
                CurrentPostion.UpdatePosition(new Position(PosX, 0));
                board[CurrentPostion.X][CurrentPostion.Y] = this;
            }
        }
    }

    
}
