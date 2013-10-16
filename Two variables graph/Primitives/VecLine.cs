using System;

namespace TwoVariablesGraph
{
    class VecLine
    {
        public VecLine(Point3d start, Point3d end)
        {
            Start = start;
            End = end;
        }

        public Point3d Start { get; set; }
        public Point3d End { get; set; }

        public float Angle()
        {
            return (float) Math.Atan((End.Y - Start.Y) / (End.X - Start.X));
        }

        public float Length()
        {
            return (float)Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2));
        }
    }
}
