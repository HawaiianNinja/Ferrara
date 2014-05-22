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

        public int NumDiagNeighbors
        {
            get
            {
                int i = 0;
                foreach (Cell c in NeighborCells)
                {
                    if (IsDiagonalNeighbor(c))
                    {
                        i++;
                    }
                }
                return i;
            }
            set
            {

            }
        }
 


        public bool Transversable { get; set; }


        public Cell(Position p)
        {
            this.Position = p;
            Transversable = true;

        }

        public override string ToString()
        {
            //return CellsWithinRadius(this, 1).Count.ToString();
            //return NeighborCells.Count.ToString();

            //return NumDiagNeighbors.ToString();

            if (Transversable)
            {
                if (GameEntities.Count > 0)
                {
                    string toRetrun = "";
                    foreach (var gameEntity in GameEntities)
                    {
                        toRetrun += gameEntity.ToString() + ":";
                    }
                    return toRetrun;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "¿";
            }

        }


        public Cell CellAtPosition(Position p)
        {

            if (this.Position.Equals(p))
            {
                return this;
            }

            if (this.NeighborCells.Count == 0)
            {
                throw new Exception();
            }

            int minDistance = NeighborCells.First<Cell>().Position.ManhattanDistanceToPosition(p);
            var minCell = NeighborCells.First<Cell>();

            foreach (Cell c in NeighborCells)
            {
                if (c.Position.ManhattanDistanceToPosition(p) < minDistance)
                {
                    minDistance = c.Position.ManhattanDistanceToPosition(p);
                    minCell = c;
                }
            }


            return minCell.CellAtPosition(p);

        }

        public Collection<Cell> CellsWithinRadius(Cell centerCell, int r)
        {
            var cc = new Collection<Cell>();
            CellsWithinRadiusHelper(centerCell, cc, r);
            return cc;
        }

        private void CellsWithinRadiusHelper(Cell centerCell, Collection<Cell> cc, int r)
        {
            foreach (Cell c in NeighborCells)
            {
                if (centerCell.ManhattanDistanceToCell(c) <= r && !cc.Contains(c))
                {
                    cc.Add(c);
                    c.CellsWithinRadiusHelper(centerCell, cc, r);
                }

            }
        }


        public bool IsDiagonalNeighbor(Cell c)
        {
            return (NeighborCells.Contains(c) && ManhattanDistanceToCell(c) == 2);
        }

        public bool IsNeighbor(Cell c)
        {
            return NeighborCells.Contains(c);
        }


        public int ManhattanDistanceToCell(Cell c)
        {
            return this.Position.ManhattanDistanceToPosition(c.Position);
        }

        public float StraightLineDistanceToCell(Cell c)
        {
            return this.Position.StraightLineDistanceToPosition(c.Position);
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
