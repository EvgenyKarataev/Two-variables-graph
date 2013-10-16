using System.Collections.Generic;

namespace TwoVariablesGraph
{
    public class Triangles
    {
        private readonly List<Triangle> _trianles;

        public Triangles()
        {
            _trianles = new List<Triangle>();
        }

        public void Add(Triangle tr)
        {
            _trianles.Add(tr);
        }

        public int Count()
        {
            return _trianles.Count;
        }

        public float Min { get; private set; }
        public float Max { get; private set; }

        public void SolveMaxMin()
        {
            if (_trianles == null || _trianles.Count == 0) return;
            float min = _trianles[0].A.Z;
            float max = _trianles[0].A.Z;
            for (int i = 1; i < _trianles.Count; i++)
            {
                if (_trianles[i].A.Z < min)
                    min = _trianles[i].A.Z;
                else if (_trianles[i].A.Z > max)
                    max = _trianles[i].A.Z;

                if (_trianles[i].B.Z < min)
                    min = _trianles[i].B.Z;
                else if (_trianles[i].B.Z > max)
                    max = _trianles[i].B.Z;

                if (_trianles[i].C.Z < min)
                    min = _trianles[i].C.Z;
                else if (_trianles[i].C.Z > max)
                    max = _trianles[i].C.Z;
            }
            Min = min;
            Max = max;
        }

        public bool ifHas(Triangle triangle)
        {
            foreach (Triangle _trianle in _trianles)
            {
                if (_trianle == triangle)
                    return true;
            }
            return false;
        }

        public Triangle this[int index]
        {
            get { return _trianles[index]; }
            set { _trianles[index] = value; }
        }
    }
}
