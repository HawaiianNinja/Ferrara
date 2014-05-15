using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class PlayerBase : GameEntity
    {

        public PlayerBase(Position p, int posx) : base(p, posx) { }

        public override void Update(GameEntity[][] board)
        {
        }
    }
}
