using System;

namespace FerraraGame
{
    internal class AStarCell : IEquatable<AStarCell>
    {
        public readonly Cell Cell;
        private readonly Cell _destinationCell;

        public AStarCell(Cell currentCell, Cell targetCell, AStarCell parentCell, int gVal)
        {
            Cell = currentCell;
            _destinationCell = targetCell;
            ParentCell = parentCell;
            GVal = gVal;
        }

        public AStarCell ParentCell { get; set; }
        public int GVal { get; set; }

        public bool Equals(AStarCell c)
        {
            return Cell.Equals(c.Cell);
        }


        public int F()
        {
            return GVal + H();
        }

        private int H()
        {
            return 10*Cell.ManhattanDistanceToCell(_destinationCell);
        }

        public override bool Equals(object obj)
        {
            var c = obj as AStarCell;
            return c != null && Cell.Equals(c.Cell);
        }

        public override string ToString()
        {
            return "(" + Cell.Position.X + "," + Cell.Position.Y + ")[G: " + GVal + " H: " + H() + " F: " + F() +
                   "]";
        }
    }
}