using System;
using System.Collections.Generic;
using System.Linq;

namespace FerraraGame
{
    internal class AStarRoute : Route
    {
        private const int _straightCost = 10;
        private const int _diagCost = 14;


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
                    var gv = (minCell.Cell.IsDiagonalNeighbor(c)) ? _diagCost : _straightCost;

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


        private Queue<Cell> buildRoute(AStarCell lastCell)
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


        private class AStarCell : IEquatable<AStarCell>
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


        private class PriorityQueue<TP, TV>
        {
            private readonly SortedDictionary<TP, Queue<TV>> _list = new SortedDictionary<TP, Queue<TV>>();

            public bool IsEmpty
            {
                get { return !_list.Any(); }
            }

            public void Enqueue(TP priority, TV value)
            {
                Queue<TV> q;
                if (!_list.TryGetValue(priority, out q))
                {
                    q = new Queue<TV>();
                    _list.Add(priority, q);
                }
                q.Enqueue(value);
            }

            public TV Dequeue()
            {
                // will throw if there isn’t any first element!
                var pair = _list.First();
                var v = pair.Value.Dequeue();
                if (pair.Value.Count == 0) // nothing left of the top priority.
                    _list.Remove(pair.Key);
                return v;
            }


            public TV GetReferenceByValue(TV value)
            {
                foreach (var queue in _list.Values)
                {
                    foreach (var item in queue)
                    {
                        if (item.Equals(value))
                        {
                            return item;
                        }
                    }
                }

                return default(TV);
            }


            public bool Contains(TV value)
            {
                return _list.Values.Any(queue => queue.Contains(value));
            }
        }
    }
}