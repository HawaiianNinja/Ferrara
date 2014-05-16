using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Cell
    {


        public Position Position;

        public Collection<Cell> NeighborCells = new Collection<Cell>();

        public Collection<GameEntity> GameEntities = new Collection<GameEntity>();



        public Cell(Position p)
        {
            this.Position = p;

        }

        public override string ToString()
        {
            return CellsWithinRadius(this, 1).Count.ToString();
            //return GameEntities.Count.ToString();
        }


        public Cell CellAtPosition(Position p)
        {

            if (this.Position.CompareTo(p) == 0)
            {
                return this;
            }

            if (this.NeighborCells.Count == 0)
            {
                throw new Exception();
            }

            int minDistance = NeighborCells.First<Cell>().DistanceToPosition(p);
            var minCell = NeighborCells.First<Cell>();

            foreach (Cell c in NeighborCells)
            {
                if (c.DistanceToPosition(p) < minDistance)
                {
                    minDistance = c.DistanceToPosition(p);
                    minCell = c;
                }
            }


            return minCell.CellAtPosition(p);

        }

        public Collection<Cell> CellsWithinRadius(Cell centerCell, int r)
        {
            var cc = new Collection<Cell>();
            CellsWithinRadiusHelper(centerCell, cc, r);
            cc.Remove(this);
            return cc;
        }

        private void CellsWithinRadiusHelper(Cell centerCell, Collection<Cell> cc, int r)
        {
            foreach (Cell c in NeighborCells)
            {
                if (centerCell.DistanceToPosition(c.Position) <= r && !cc.Contains(c))
                {
                    cc.Add(c);
                    c.CellsWithinRadiusHelper(centerCell, cc, r);
                }

            }
        }



        public int DistanceToPosition(Position p)
        {
            return Math.Abs(this.Position.X - p.X) + Math.Abs(this.Position.Y - p.Y);
        }


    }
}
