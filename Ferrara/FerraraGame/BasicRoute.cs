using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class BasicRoute : Route
    {


        public BasicRoute(Cell start, Cell target) : base()
        {

            GenerateRoute(start, target);

        }

        private void GenerateRoute(Cell currentCell, Cell targetCell)
        {
            if (currentCell.Position.CompareTo(targetCell.Position) == 0)
            {
                _route.Enqueue(currentCell);
                return;
            }

            if (currentCell.NeighborCells.Count == 0)
            {
                throw new Exception();
            }
            var minCell = currentCell.NeighborCells.First<Cell>();
            int minDistance = minCell.ManhattanDistancetoPosition(targetCell.Position);
            

            foreach (Cell c in currentCell.NeighborCells)
            {
                if (c.ManhattanDistancetoPosition(targetCell.Position) < minDistance)
                {
                    minDistance = c.ManhattanDistancetoPosition(targetCell.Position);
                    minCell = c;
                }
            }
            _route.Enqueue(minCell);
            GenerateRoute(minCell, targetCell);
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (Cell c in _route)
            {
                b.Append(c);
            }
            return b.ToString();
        }



    }
}
