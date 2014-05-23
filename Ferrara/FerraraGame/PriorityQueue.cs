using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FerraraGame
{
    internal class PriorityQueue
    {
        private readonly SortedDictionary<int, Queue<AStarCell>> _list = new SortedDictionary<int, Queue<AStarCell>>();
        private Dictionary<Cell, AStarCell> _dictionary = new Dictionary<Cell, AStarCell>(); 

        public bool IsEmpty
        {
            get { return !_list.Any(); }
        }

        public void Enqueue(int priority, AStarCell value)
        {
            Queue<AStarCell> q;
            if (!_list.TryGetValue(priority, out q))
            {
                q = new Queue<AStarCell>();
                _list.Add(priority, q);
            }
            q.Enqueue(value);
            _dictionary.Add(value.Cell, value);
        }

        public AStarCell Dequeue()
        {
            // will throw if there isn’t any first element!
            var pair = _list.First();
            var v = pair.Value.Dequeue();
            if (pair.Value.Count == 0)
            {
                // nothing left of the top priority.
                _list.Remove(pair.Key);
            }
            _dictionary.Remove(v.Cell);
            return v;
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
//            return _list.Values.Any(queue => queue.Contains(value));
        }

        public bool Contains(Cell value)
        {
            AStarCell toReturn;
            _dictionary.TryGetValue(value, out toReturn);
            return toReturn != null;
        }
    }
}