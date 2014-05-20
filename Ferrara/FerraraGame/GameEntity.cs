using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    abstract class GameEntity
    {
        public Cell CurrentCell;
        protected Cell _targetCell;
        protected int _attackRadius;
        protected Route _route;

        private Player _owner;

        public GameEntity(Cell startCell, Cell targetCell, Player owner)
        {
            _owner = owner;
            CurrentCell = startCell;
            _targetCell = targetCell;

            startCell.GameEntities.Add(this);
        }


        public void MoveEntity(Cell targetCell)
        {
            CurrentCell.GameEntities.Remove(this);
            targetCell.GameEntities.Add(this);
            CurrentCell = targetCell;
        }


        abstract public void Update();
        public override String  ToString()
        {
            return "1";
        }
    }
}
