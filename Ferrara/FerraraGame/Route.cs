using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Route
    {
        Queue<Cell> route = new Queue<Cell>();


        public Route(Cell start, Cell target)
        {
            GenerateRoute(start, target);

        }

        public void GenerateRoute(Cell currentCell, Cell targetCell)
        {
            if (currentCell.Position.CompareTo(targetCell.Position) == 0)
            {
                route.Enqueue(currentCell);
                return;
            }

            if (currentCell.NeighborCells.Count == 0)
            {
                throw new Exception();
            }
            var minCell = currentCell.NeighborCells.First<Cell>();
            int minDistance = minCell.DistanceToPosition(targetCell.Position);
            

            foreach (Cell c in currentCell.NeighborCells)
            {
                if (c.DistanceToPosition(targetCell.Position) < minDistance)
                {
                    minDistance = c.DistanceToPosition(targetCell.Position);
                    minCell = c;
                }
            }
            route.Enqueue(minCell);
            GenerateRoute(minCell, targetCell);
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (Cell c in route)
            {
                b.Append(c);
            }
            return b.ToString();
        }

        public Cell GetNextCell()
        {
            return route.Dequeue();
        }
    }
}
