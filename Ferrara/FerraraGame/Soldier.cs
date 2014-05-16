using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Soldier : GameEntity
    {
        
        public Soldier(Cell spawnCell, Cell targetCell, Player _leftPlayer) : base(spawnCell, targetCell, _leftPlayer)
        {
            _attackRadius = 2;
            _route = new Route(spawnCell, targetCell);
        }

        public override void Update(){
            //check for duded

            //if dudes


            //if no dudes
            MoveEntity( _route.GetNextCell());

        }
    }

    
}
