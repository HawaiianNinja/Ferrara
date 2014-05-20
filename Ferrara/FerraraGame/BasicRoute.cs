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
            if (currentCell.Equals(targetCell))
            {
                _route.Enqueue(currentCell);
                return;
            }

            if (currentCell.NeighborCells.Count == 0)
            {
                throw new Exception();
            }
            var minCell = currentCell.NeighborCells.First<Cell>();
            int minDistance = minCell.ManhattanDistanceToCell(targetCell);
            

            foreach (Cell c in currentCell.NeighborCells)
            {
                if (c.ManhattanDistanceToCell(targetCell) < minDistance)
                {
                    minDistance = c.ManhattanDistanceToCell(targetCell);
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
