using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FerraraGame
{
    internal class PriorityQueue
    {
        private readonly SortedDictionary<int, List<AStarCell>> _list = new SortedDictionary<int, List<AStarCell>>();
        private Dictionary<Cell, AStarCell> _dictionary = new Dictionary<Cell, AStarCell>(); 




        public bool IsEmpty
        {
            get { return !_list.Any(); }
        }

        public void Enqueue(int priority, AStarCell value)
        {
            List<AStarCell> q;
            if (!_list.TryGetValue(priority, out q))
            {
                q = new List<AStarCell>();
                _list.Add(priority, q);
            }
            q.Add(value);
            _dictionary.Add(value.Cell, value);
        }




        public AStarCell Dequeue()
        {
            // will throw if there isn’t any first element!
            var pair = _list.First();

            // will throw if the queue is empty
            var v = pair.Value.First();


            pair.Value.RemoveAt(0);
            _dictionary.Remove(v.Cell);

            if (pair.Value.Count == 0)
            {
                // nothing left of the top priority.
                _list.Remove(pair.Key);
            }
            
            return v;
        }


        public void RemoveElement(int priority, AStarCell cell)
        {

            List<AStarCell> l = _list[priority];

            l.Remove(cell);

            _dictionary.Remove(cell.Cell);

            if(_list[priority].Count == 0)
            {
                _list.Remove(priority);
            }

        }


        public AStarCell GetReferenceByValue(AStarCell value)
        {
            AStarCell toReturn;
            _dictionary.TryGetValue(value.Cell, out toReturn);
            return toReturn;
        }


        public bool Contains(AStarCell value)
        {
            return GetReferenceByValue(value) != null;
        
        }

        public bool Contains(Cell value)
        {
            AStarCell toReturn;
            _dictionary.TryGetValue(value, out toReturn);
            return toReturn != null;
        }
    }
}