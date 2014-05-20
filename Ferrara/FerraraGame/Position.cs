using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerraraGame
{
    class Position : IEquatable<Position>
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

       

        public int ManhattanDistanceToPosition(Position p)
        {
            return Math.Abs(this.X - p.X) + Math.Abs(this.Y - p.Y);
        }

        public float StraightLineDistanceToPosition(Position p)
        {

            return (float)Math.Sqrt((this.X - p.X) * (this.X - p.X) + (this.Y - p.Y) * (this.Y - p.Y));

        }


        public override bool Equals(object obj)
        {
            Position p = obj as Position;

            return (p.X == X) && (p.Y == Y);
        }

        public bool Equals(Position p)
        {
            return (p.X == X) && (p.Y == Y);
        }



        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }

    }
}
