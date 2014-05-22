using System;
using System.Linq;
using System.Text;

namespace FerraraGame
{
    internal class BasicRoute : Route
    {
        public BasicRoute(Cell start, Cell target)
        {
            GenerateRoute(start, target);
        }

        private void GenerateRoute(Cell currentCell, Cell targetCell)
        {
            if (currentCell.Equals(targetCell))
            {
                Path.Enqueue(currentCell);
                return;
            }

            if (currentCell.NeighborCells.Count == 0)
            {
                throw new Exception();
            }
            var minCell = currentCell.NeighborCells.First();
            var minDistance = minCell.ManhattanDistanceToCell(targetCell);


            foreach (var c in currentCell.NeighborCells)
            {
                if (c.ManhattanDistanceToCell(targetCell) < minDistance)
                {
                    minDistance = c.ManhattanDistanceToCell(targetCell);
                    minCell = c;
                }
            }
            Path.Enqueue(minCell);
            GenerateRoute(minCell, targetCell);
        }

        public override string ToString()
        {
            var b = new StringBuilder();
            foreach (var c in Path)
            {
                b.Append(c);
            }
            return b.ToString();
        }
    }
}