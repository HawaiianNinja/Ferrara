using System.Collections.Generic;

namespace FerraraGame
{
    internal abstract class Route
    {
        protected Queue<Cell> Path;


        protected Route()
        {
            Path = new Queue<Cell>();
        }


        public Cell GetNextCell()
        {
            return Path.Dequeue();
        }
    }
}