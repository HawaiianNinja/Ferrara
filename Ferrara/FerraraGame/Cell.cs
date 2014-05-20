using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Cell : IEquatable<Cell>
    {


        public Position Position;

        public Collection<Cell> NeighborCells = new Collection<Cell>();

        public Collection<GameEntity> GameEntities = new Collection<GameEntity>();

        public bool Transversable { get; set; }


        public Cell(Position p)
        {
            this.Position = p;
            Transversable = true;

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

            int minDistance = NeighborCells.First<Cell>().ManhattanDistancetoPosition(p);
            var minCell = NeighborCells.First<Cell>();

            foreach (Cell c in NeighborCells)
            {
                if (c.ManhattanDistancetoPosition(p) < minDistance)
                {
                    minDistance = c.ManhattanDistancetoPosition(p);
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
                if (centerCell.ManhattanDistancetoPosition(c.Position) <= r && !cc.Contains(c))
                {
                    cc.Add(c);
                    c.CellsWithinRadiusHelper(centerCell, cc, r);
                }

            }
        }



        public int ManhattanDistancetoPosition(Position p)
        {
            return Math.Abs(this.Position.X - p.X) + Math.Abs(this.Position.Y - p.Y);
        }

        public int ManhattanDistanceToCell(Cell c)
        {
            return Math.Abs(this.Position.X - c.Position.X) + Math.Abs(this.Position.Y - c.Position.Y);
        }


        public override bool Equals(object obj)
        {
            Cell c = obj as Cell;
            return this.Position.Equals(c.Position);
        }


        public bool Equals(Cell c)
        {
            return this.Position.Equals(c.Position);
        }

    }
}
