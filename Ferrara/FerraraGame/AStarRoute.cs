using System.Collections.Generic;
using System.Linq;

namespace FerraraGame
{
    internal class AStarRoute : Route
    {
        private const int StraightCost = 10;
        private const int DiagCost = 14;


        private List<AStarCell> _closedList;
        private PriorityQueue<int, AStarCell> _openList;


        public AStarRoute(Cell start, Cell target)
        {
            GenerateRoute(start, target);
        }


        private void GenerateRoute(Cell currentCell, Cell targetCell)
        {
            var t = new AStarCell(currentCell, targetCell, null, 0);

            _openList = new PriorityQueue<int, AStarCell>();
            _closedList = new List<AStarCell>();


            //http://blogs.msdn.com/b/ericlippert/archive/2007/10/10/path-finding-using-a-in-c-3-0-part-four.aspx
            //http://www.policyalmanac.org/games/aStarTutorial.htm
            _openList.Enqueue(t.F(), t);


            var foundPath = false;
            AStarCell lastCell = null;

            do
            {
                var minCell = _openList.Dequeue();

                _closedList.Add(minCell);

                foreach (var c in minCell.Cell.NeighborCells)
                {
                    var gv = (minCell.Cell.IsDiagonalNeighbor(c)) ? DiagCost : StraightCost;

                    var newCell = new AStarCell(c, targetCell, minCell, minCell.GVal + gv);


                    if (!c.Transversable || _closedList.Contains(newCell))
                        continue;

                    if (!_openList.Contains(newCell))
                    {
                        _openList.Enqueue(newCell.F(), newCell);
                    }
                    else
                    {
                        var oldCell = _openList.GetReferenceByValue(newCell);

                        if (newCell.GVal < oldCell.GVal)
                        {
                            oldCell.GVal = newCell.GVal;
                            oldCell.ParentCell = minCell;
                            newCell = oldCell;
                        }
                    }

                    if (newCell.Cell.Equals(targetCell))
                    {
                        foundPath = true;
                        lastCell = newCell;
                    }
                }
            } while (!_openList.IsEmpty && !foundPath);


            if (foundPath)
            {
                Path = new Queue<Cell>(buildRoute(lastCell).Reverse());

                //throw away frist cell in route because its the cell the dude is already on
                Path.Dequeue();
            }
        }


        private IEnumerable<Cell> buildRoute(AStarCell lastCell)
        {
            var queue = new Queue<Cell>();

            var tCell = lastCell;

            while (tCell != null)
            {
                queue.Enqueue(tCell.Cell);
                tCell = tCell.ParentCell;
            }

            return queue;
        }
    }
}