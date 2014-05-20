using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    abstract class Route
    {


        protected Queue<Cell> _route;
        
        
        public Route()
        {
            _route = new Queue<Cell>();
        }


        public Cell GetNextCell()
        {
            return _route.Dequeue();
        }

    }

}
