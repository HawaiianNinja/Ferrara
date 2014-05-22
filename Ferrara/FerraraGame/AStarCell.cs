using System;

namespace FerraraGame
{
    internal class AStarCell : IEquatable<AStarCell>
    {
        public readonly Cell Cell;
        private readonly Cell _destinationCell;

        public AStarCell(Cell currentCell, Cell targetCell, AStarCell parentCell, int pastCost)
        {
            Cell = currentCell;
            _destinationCell = targetCell;
            ParentCell = parentCell;
            PastCost = pastCost;
        }

        public AStarCell ParentCell { get; set; }
        public int PastCost { get; set; }

        public bool Equals(AStarCell c)
        {
            return Cell.Equals(c.Cell);
        }


        public int FullCost()
        {
            return PastCost + HeuristicCost();
        }

        private int HeuristicCost()
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
            return "(" + Cell.Position.X + "," + Cell.Position.Y + ")[G: " + PastCost + " H: " + HeuristicCost() + " F: " + FullCost() +
                   "]";
        }
    }
}