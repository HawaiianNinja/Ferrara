using System;

namespace FerraraGame
{
    internal class AStarCell : IEquatable<AStarCell>
    {
        public readonly Cell Cell;
        private readonly Cell _destinationCell;

        public AStarCell(Cell currentCell, Cell targetCell, AStarCell parentCell, int pathCost)
        {
            Cell = currentCell;
            _destinationCell = targetCell;
            ParentCell = parentCell;
            PathCost = pathCost;
        }

        public AStarCell ParentCell { get; set; }
        public int PathCost { get; set; }

        public bool Equals(AStarCell c)
        {
            return Cell.Equals(c.Cell);
        }


        public int FullCost()
        {
            return PathCost + HeuristicCost();
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
            return "(" + Cell.Position.X + "," + Cell.Position.Y + ")[G: " + PathCost + " H: " + HeuristicCost() + " F: " + FullCost() +
                   "]";
        }
    }
}