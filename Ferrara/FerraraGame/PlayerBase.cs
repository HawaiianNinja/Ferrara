using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class PlayerBase : GameEntity
    {
        public PlayerBase(Cell cell1, Cell cell2, Player _leftPlayer)
            : base(cell1, cell2, _leftPlayer)
        {
        }

        public override void Update()
        {


        }
    }
}
