using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FerraraGame
{
    internal class Cell : IEquatable<Cell>
    {
        public Collection<GameEntity> GameEntities = new Collection<GameEntity>();
        public Collection<Cell> NeighborCells = new Collection<Cell>();
        public Position Position;

        public Cell(Position p)
        {
            Position = p;
            Transversable = true;
        }

        public int NumDiagNeighbors
        {
            get
            {
                return NeighborCells.Count(IsDiagonalNeighbor);
            }
        }


        public bool Transversable { get; set; }

        public bool Equals(Cell c)
        {
            return Position.Equals(c.Position);
        }


        public override string ToString()
        {
            //return CellsWithinRadius(this, 1).Count.ToString();
            //return NeighborCells.Count.ToString();

            //return NumDiagNeighbors.ToString();

            if (Transversable)
            {
                //if (GameEntities.Count > 0)
                //{
                //    return GameEntities.Aggregate("", (current, gameEntity) => current + gameEntity);
                //}
                //return "0";
                return GameEntities.Count.ToString();

            }
            return "¿";
        }


        public Cell CellAtPosition(Position p)
        {
            if (Position.Equals(p))
            {
                return this;
            }

            if (NeighborCells.Count == 0)
            {
                throw new Exception();
            }

            var minDistance = NeighborCells.First().Position.ManhattanDistanceToPosition(p);
            var minCell = NeighborCells.First();

            foreach (var c in NeighborCells.Where(c => c.Position.ManhattanDistanceToPosition(p) < minDistance))
            {
                minDistance = c.Position.ManhattanDistanceToPosition(p);
                minCell = c;
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
            foreach (var c in NeighborCells)
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
            return ManhattanDistanceToCell(c) == 2;
        }

        public bool IsNeighbor(Cell c)
        {
            return NeighborCells.Contains(c);
        }


        public int ManhattanDistanceToCell(Cell c)
        {
            return Position.ManhattanDistanceToPosition(c.Position);
        }

        public float StraightLineDistanceToCell(Cell c)
        {
            return Position.StraightLineDistanceToPosition(c.Position);
        }

        public override bool Equals(object obj)
        {
            var c = obj as Cell;
            return c != null && Position.Equals(c.Position);
        }
    }
}
