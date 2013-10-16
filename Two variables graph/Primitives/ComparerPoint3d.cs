using System.Collections;
using System.Collections.Generic;

namespace TwoVariablesGraph
{
    class ComparerPoint3d: IComparer<Edge>
    {
        public int Compare(object x, object y)
        {
            Point3d p1 = (Point3d) x;
            Point3d p2 = (Point3d) y;
       //     return p1 < p2 ? -1 : (p1 > p2 ? 1 : 0);
            return 0;
        }

        public int Compare(Edge x, Edge y)
        {
            throw new System.NotImplementedException();
        } 
    }
}
