namespace TwoVariablesGraph
{
    internal enum PointLocation
    {
        LEFT,
        RIGHT,
        BEYOND,
        BEHIND,
        BETWEEN,
        ORIGIN,
        DESTINATION
    } ;

    public class Point3d
    {
        public Point3d()
        {
            
        }

        public Point3d(float x, float y, float z, int index)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            Index = index;
        }

        public Point3d(Point3d p)
        {
            this.X = p.X;
            this.Y = p.Y;
            this.Z = p.Z;
            Index = p.Index;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public int Index { get; set; }

        public static bool operator ==(Point3d p1, Point3d p2)
        {
            return (p1.X == p2.X && p1.Y == p2.Y);
        }

        public static bool operator !=(Point3d p1, Point3d p2)
        {
            return !(p1 == p2);
        }

        public static bool operator > (Point3d p1, Point3d p2)
        {
            //if (p1.X < p2.X)
              //  return false;
           // return p1.Y > p2.Y;
            return p1.Index > p2.Index;
        }

        public static bool operator < (Point3d p1, Point3d p2)
        {
            return p1.X < p2.X || p1.Y < p2.Y;
        }

        public static Point3d operator -(Point3d p1, Point3d p2)
        {
            return new Point3d(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z, 0);
        }
    }
}
