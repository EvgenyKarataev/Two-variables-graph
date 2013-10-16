using System;
using System.Collections.Generic;

namespace TwoVariablesGraph
{
    class MyMath
    {
        public static void Transform(ref Point3d p, float dx, float dy)
        {
            p.X -= dx;
            p.Y -= dy;
        }

        public static void Transform(ref VecLine vec, float dx, float dy)
        {
            vec.Start.X -= dx;
            vec.Start.Y -= dy;
            
            vec.End.X -= dx;
            vec.End.Y -= dy;
        }

        public static void Transform(ref List<Point3d> points, float dx, float dy)
        {
            foreach (Point3d point in points)
            {
                point.X -= dx;
                point.Y -= dy;
            }           
        }

        public static void RotatePoint(ref Point3d p, float angle)
        {
            var x = (float)(p.X * Math.Cos(angle) - p.Y * Math.Sin(angle)); // новая координата по х.
            var y = (float)(p.X * Math.Sin(angle) + p.Y * Math.Cos(angle)); // новая координата по у.

            p.X = x;
            p.Y = y;
        }

        public static void RotatePoint(ref VecLine vec, float angle)
        {
            var x = (float)(vec.Start.X * Math.Cos(angle) - vec.Start.Y * Math.Sin(angle)); // новая координата по х.
            var y = (float)(vec.Start.X * Math.Sin(angle) + vec.Start.Y * Math.Cos(angle)); // новая координата по у.

            vec.Start.X = x;
            vec.Start.Y = y;

            x = (float)(vec.End.X * Math.Cos(angle) - vec.End.Y * Math.Sin(angle)); // новая координата по х.
            y = (float)(vec.End.X * Math.Sin(angle) + vec.End.Y * Math.Cos(angle)); // новая координата по у.

            vec.End.X = x;
            vec.End.Y = y;
        }

        public static void RotatePoint(ref List<Point3d> points, float angle)
        {
            foreach (Point3d point in points)
            {
                var x = (float)(point.X * Math.Cos(angle) - point.Y * Math.Sin(angle)); // новая координата по х.
                var y = (float)(point.X * Math.Sin(angle) + point.Y * Math.Cos(angle)); // новая координата по у.    

                point.X = x;
                point.Y = y;
            }
        }

        public static void MoveCenter(ref Point3d p, ref VecLine vec, ref List<Point3d> points)
        {
            float dx = vec.Start.X;
            float dy = vec.Start.Y;
            float angle = vec.Angle();
            Transform(ref p, dx, dy);
            Transform(ref vec, dx, dy);
            Transform(ref points, dx, dy);
            RotatePoint(ref p, -angle);
            RotatePoint(ref vec, -angle);
            RotatePoint(ref points, -angle);
        }

        public static double Length(Point3d p1, Point3d p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        public static double SolveAngle(VecLine vec, Point3d p)
        {
            double a = Length(p, vec.Start);
            double b = Length(p, vec.End);

            return Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) -
                              Math.Pow(vec.Length(), 2))/(2*a*b));
        }

        /// <summary>
        /// Находит точку, лежащую с противоположной стороны линии, отностильно заданной точки.
        /// </summary>
        /// <param name="p"> Заданная точка. </param>
        /// <param name="vec"> Линия. </param>
        /// <param name="points"> Набор всех точек. </param>
        /// <returns> Индекс найденной точки. </returns>
        public static int FindPointAcrossLine(Point3d p, VecLine vec, List<Point3d> points)
        {
            MoveCenter(ref p, ref vec, ref points); // Смещает  центр координат.

            int indexMaxPoint = -1;
            float maxAngle = 0;

            // Проверка всех точек.
            for (int i = 0; i < points.Count; i++ )
            {
                if (points[i].Y * p.Y < 0)  // Если произведение меньше 0, то значит что точки лежат 
                    // с разных сторон оси Х.
                {
                    var tempAngle = (float) SolveAngle(vec, points[i]); // Вычисляет угол.
                    if (maxAngle < tempAngle && tempAngle > 0.001)  // Если угол больше 0 и больше уже найденнго, то
                    {
                        maxAngle = tempAngle;   // Запоминает найденный угол.
                        indexMaxPoint = i;      // Запоминает индекс точки.
                    }
                    else if (indexMaxPoint >= 0)    // Если точка совпадает с началом или концом отрезка то берем ее.
                        if (maxAngle == tempAngle
                             && (points[i].Z == vec.Start.Z || points[i].Z == vec.End.Z))
                        {
                            indexMaxPoint = i;
                        }
                }
            }
            return indexMaxPoint; // Возвращает индекс найденной точки.
        }

        public static Point3d Normal(Point3d a, Point3d b)
        {
            return new Point3d
                             {
                                 X = (a.Y*b.Z - b.Y*a.Z),
                                 Y = (-(a.Z*b.Z - b.Z*a.Z)),
                                 Z = (a.X*b.Y - b.X*a.Y)
                             };
        }
    }
}
