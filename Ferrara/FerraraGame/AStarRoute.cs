using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FerraraGame
{
    internal class AStarRoute : Route
    {
        private const int StraightCost = 10;
        private const int DiagCost = 14;


        //private List<AStarCell> _closedList;
        private PriorityQueue _openList;
        private HashSet<AStarCell> _closedListHS;

        public AStarRoute(Cell start, Cell target)
        {
            GenerateRoute(start, target);
        }


        private void GenerateRoute(Cell currentCell, Cell targetCell)
        {
            var startCell = new AStarCell(currentCell, targetCell, null, 0);

            _openList = new PriorityQueue();
            //_closedList = new List<AStarCell>();
            _closedListHS = new HashSet<AStarCell>();




            //http://blogs.msdn.com/b/ericlippert/archive/2007/10/10/path-finding-using-a-in-c-3-0-part-four.aspx
            //http://www.policyalmanac.org/games/aStarTutorial.htm
            _openList.Enqueue(startCell.FullCost(), startCell);


            var foundPath = false;
            AStarCell lastCell = null;

            do
            {
                var minCell = _openList.Dequeue();

                //_closedList.Add(minCell);

                _closedListHS.Add(minCell);

                foreach (var neighbor in minCell.Cell.NeighborCells)
                {
                    var gv = (minCell.Cell.IsDiagonalNeighbor(neighbor)) ? DiagCost : StraightCost;

                    var newCell = new AStarCell(neighbor, targetCell, minCell, minCell.PathCost + gv);


                    if (!neighbor.Transversable || _closedListHS.Contains(newCell))
                        continue;

                    var oldCell = _openList.GetReferenceByValue(newCell);

                    if (oldCell == null)
                    {
                        _openList.Enqueue(newCell.FullCost(), newCell);
                    }
                    else
                    {
                        if (newCell.PathCost < oldCell.PathCost)
                        {
                            oldCell.PathCost = newCell.PathCost;
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
                Path = new Queue<Cell>(BuildRoute(lastCell).Reverse());

                //throw away frist cell in route because its the cell the dude is already on
                Path.Dequeue();
            }
        }


        private static IEnumerable<Cell> BuildRoute(AStarCell lastCell)
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