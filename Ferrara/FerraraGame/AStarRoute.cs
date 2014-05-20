using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class AStarRoute : Route
    {


        private const int _straightCost = 10;
        private const int _diagCost = 14;

        
        private PriorityQueue<int, AStarCell> _openList;
        private List<AStarCell> _closedList;



        public AStarRoute(Cell start, Cell target) : base()
        {

            GenerateRoute(start, target);

        }


        private void GenerateRoute(Cell currentCell, Cell targetCell)
        {
            AStarCell t = new AStarCell(currentCell, targetCell, null, 0);

            _openList = new PriorityQueue<int, AStarCell>();
            _closedList = new List<AStarCell>();


            //http://blogs.msdn.com/b/ericlippert/archive/2007/10/10/path-finding-using-a-in-c-3-0-part-four.aspx
            //http://www.policyalmanac.org/games/aStarTutorial.htm
            _openList.Enqueue(t.F(), t);


            bool foundPath = false;
            AStarCell lastCell = null;

            do
            {

                AStarCell minCell = _openList.Dequeue();

                _closedList.Add(minCell);

                foreach (Cell c in minCell.Cell.NeighborCells)
                {

                    int gv = (minCell.Cell.IsDiagonalNeighbor(c)) ? _diagCost : _straightCost;

                    AStarCell newCell = new AStarCell(c, targetCell, minCell, minCell.GVal + gv);


                    if (!c.Transversable || _closedList.Contains(newCell)) 
                        continue;


                    if (!_openList.Contains(newCell))
                    {
                        _openList.Enqueue(newCell.F(), newCell);
                    }
                    else
                    {
                        AStarCell oldCell = _openList.GetReferenceByValue(newCell);

                        if (oldCell.F() < newCell.F())
                        {
                            oldCell.GVal = newCell.GVal;
                            oldCell.ParentCell = newCell.ParentCell;
                            newCell = oldCell;
                        }

                    }

                    if(newCell.Cell.Equals(targetCell))
                    {
                        foundPath=true;
                        lastCell = newCell;
                    }


                }


            } while (!_openList.IsEmpty && !foundPath);
            


            if(foundPath)
            {
                Queue<Cell> route = buildRoute(lastCell);
                _route = new Queue<Cell>(buildRoute(lastCell).Reverse());

                //throw away frist cell in route because its the cell the dude is already on
                _route.Dequeue();

            }

        }


        private Queue<Cell> buildRoute(AStarCell lastCell)
        {
            Queue<Cell> queue = new Queue<Cell>();

            AStarCell tCell = lastCell;

            while(tCell != null)
            {
                Console.WriteLine(tCell.ToString());
                queue.Enqueue(tCell.Cell);
                tCell = tCell.ParentCell;
            }

            return queue; 

        }



        private class AStarCell : IEquatable<AStarCell>
        {
            public Cell Cell;
            private Cell _destinationCell;

            public AStarCell ParentCell { get; set; }
            public int GVal { get; set; }


            public AStarCell(Cell currentCell, Cell targetCell, AStarCell parentCell, int gVal)
            {
                this.Cell = currentCell;
                this._destinationCell = targetCell;
                this.ParentCell = parentCell;
                this.GVal = gVal;
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
                AStarCell c = obj as AStarCell;
                return Cell.Equals(c.Cell);
            }

            public bool Equals(AStarCell c)
            {
                return Cell.Equals(c.Cell);
            }

            public override string ToString()
            {
                return "(" + Cell.Position.X + "," + Cell.Position.Y + ")[G: " + GVal.ToString() + " H: " + H().ToString() + " F: " + F().ToString() + "]";
            }

        }





        private class PriorityQueue<P, V>
        {
            private SortedDictionary<P, Queue<V>> list = new SortedDictionary<P, Queue<V>>();
            public void Enqueue(P priority, V value)
            {
                Queue<V> q;
                if (!list.TryGetValue(priority, out q))
                {
                    q = new Queue<V>();
                    list.Add(priority, q);
                }
                q.Enqueue(value);
            }
            public V Dequeue()
            {
                // will throw if there isn’t any first element!
                var pair = list.First();
                var v = pair.Value.Dequeue();
                if (pair.Value.Count == 0) // nothing left of the top priority.
                    list.Remove(pair.Key);
                return v;
            }


            public bool IsEmpty
            {
                get { return !list.Any(); }
            }

            public V GetReferenceByValue(V value)
            {

                foreach (Queue<V> queue in list.Values)
                {
                    foreach(V item in queue)
                    {
                        if (item.Equals(value))
                        {
                            return item;
                        }
                    }

                }

                return default(V);
            }


            public bool Contains(V value)
            {

                foreach (Queue<V> queue in list.Values)
                {
                    if (queue.Contains(value))
                        return true;

                }
                return false;


            }

        }






    }
}
