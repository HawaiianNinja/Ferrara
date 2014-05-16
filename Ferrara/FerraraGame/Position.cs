using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Position : IComparable
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Add(Position position)
        {
            return new Position(position.X + X, position.Y + Y);
        }

        public void UpdatePosition(Position p)
        {
            X += p.X;
            Y += p.Y;
        }

        public int CompareTo(Object o)
        {
            if (o == null)
            {
                return 1;
            }

            Position p = o as Position;

            
            if(p.X == X && p.Y == Y)
            {
                return 0;
            }

            return 1;

        }


        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }

    }
}
