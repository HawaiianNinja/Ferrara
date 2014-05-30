using System;

namespace WinClient
{
    internal class Position : IEquatable<Position>
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position p)
        {
            return (p.X == X) && (p.Y == Y);
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
            return Math.Abs(X - p.X) + Math.Abs(Y - p.Y);
        }

        public float StraightLineDistanceToPosition(Position p)
        {
            return (float)Math.Sqrt((X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y));
        }


        public override bool Equals(object obj)
        {
            var p = obj as Position;

            return p != null && (p.X == X && (p.Y == Y));
        }


        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }
    }
}