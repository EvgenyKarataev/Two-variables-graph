namespace TwoVariablesGraph
{
    public class Triangle
    {
        public Triangle(Point3d a, Point3d b, Point3d c)
        {
            A = new Point3d(a);
            B = new Point3d(b);
            C = new Point3d(c);
        }
        
        public Point3d A { get; set; }
        public Point3d B { get; set; }
        public Point3d C { get; set; }

        public static void MakeTriandle(ref Triangle tr)
        {
            if (tr.B.Index < tr.A.Index)
            {
                var temp = new Point3d(tr.A);
                tr.A = tr.B;
                tr.B = temp;
            }
            if (tr.C.Index < tr.A.Index)
            {
                var temp = new Point3d(tr.A);
                tr.A = tr.C;
                tr.C = temp;
            }

            if (tr.B.Index > tr.C.Index)
            {
                var temp = new Point3d(tr.C);
                tr.C = tr.B;
                tr.B = temp;
            }

            /*
            Point3d max = new Point3d(tr.A);
            if (tr.B > max)
                max = new Point3d(tr.B);
            else if (tr.C > max)
                max = new Point3d(tr.C);

            Point3d av = new Point3d(tr.A);
            if (tr.A > min && tr.A < max)
                av = new Point3d(tr.A);
            if (tr.B > min && tr.B < max)
                av = new Point3d(tr.B);
            else if (tr.C > min && tr.C < max)
                min = new Point3d(tr.C);

            tr.A = min;
            tr.B = av;
            tr.C = max; 

            /*if (tr.B > tr.A)
            {
                if (tr.B > tr.C)
                {
                    var temp = new Point3d(tr.C);
                    tr.C = tr.B;
                    tr.B = temp;
                }
                return;
            }
            else if (tr.A > tr.B)
            {
                var temp = new Point3d(tr.A);
                tr.A = tr.B;
                tr.B = temp;

                if (tr.B > tr.C)
                {
                    temp = new Point3d(tr.C);
                    tr.C = tr.B;
                    tr.B = temp;
                }
                return;
            }
            else if (tr.A > tr.C)
            {
                var temp = new Point3d(tr.A);
                tr.A = tr.C;
                tr.C = temp;

                if (tr.B > tr.C)
                {
                    temp = new Point3d(tr.B);
                    tr.B = tr.C;
                    tr.C = temp;
                }
                else
                {
                    if (tr.A > tr.B)
                    {
                        temp = new Point3d(tr.A);
                        tr.A = tr.B;
                        tr.B = temp;
                    }
                }
            }*/
           /* int min = tr.A.Index;
            if (tr.B.Index < min)
            {
                min = tr.B.Index;
                var temp = new Point3d(tr.A);
                tr.A = tr.B;
                tr.B = temp;
            }
            if (tr.C.Index < min)
            {
                min = tr.C.Index;
                var temp = new Point3d(tr.A);
                tr.A = tr.C;
                tr.C = temp;
            }

            int max = tr.C.Index;
            if (tr.B.Index > max)
            {
                max = tr.B.Index;
                var temp = new Point3d(tr.C);
                tr.C = tr.B;
                tr.B = temp;
            }*/
           
        }

        //**************************************************************
        //  CrossType
        //  типы пересечения прямых
        //**************************************************************
        public enum enumCrossType
        {
            ctParallel,    // отрезки лежат на параллельных прямых
            ctSameLine,    // отрезки лежат на одной прямой
            ctOnBounds,    // прямые пересекаются в конечных точках отрезков
            ctInBounds,    // прямые пересекаются в   пределах отрезков
            ctOutBounds    // прямые пересекаются вне пределов отрезков
        };
        //**************************************************************
        //  CrossResultRec
        //  результат проверки пересечения прямых
        //**************************************************************
        public struct CrossResultRec
        {
            public enumCrossType type;  // тип пересечения
            public Point3d pt;    // точка пересечения
        };

        //**************************************************************
        //  Crossing()
        //  проверка пересечения двух отрезков
        //**************************************************************
        public static CrossResultRec Crossing(
            Point3d p11, Point3d p12,   // координаты первого отрезка
            Point3d p21, Point3d p22)  // координаты второго отрезка
        {
            CrossResultRec result = new CrossResultRec();

            // знаменатель
            float Z = (p12.Y - p11.Y) * (p21.X - p22.X) - (p21.X - p22.X) * (p12.X - p11.X);
            // числитель 1
            float Ca = (p12.Y - p11.Y) * (p21.X - p11.X) - (p21.Y - p11.Y) * (p12.X - p11.X);
            // числитель 2
            float Cb = (p21.Y - p11.Y) * (p21.X - p22.X) - (p21.Y - p22.Y) * (p21.X - p11.X);

            // если числители и знаменатель = 0, прямые совпадают
            if ((Z == 0) && (Ca == 0) && (Cb == 0))
            {
                result.type = enumCrossType.ctSameLine;
                return result;
            }

            // если знаменатель = 0, прямые параллельны
            if (Z == 0)
            {
                result.type = enumCrossType.ctParallel;
                return result;
            }

            float Ua = Ca / Z;
            float Ub = Cb / Z;

            result.pt = new Point3d();

            result.pt.X = (float)(p11.X + (p12.X - p11.X) * Ub);
            result.pt.Y = (float)(p11.Y + (p12.Y - p11.Y) * Ub);

            // если 0<=Ua<=1 и 0<=Ub<=1, точка пересечения в пределах отрезков
            if ((0 <= Ua) && (Ua <= 1) && (0 <= Ub) && (Ub <= 1))
            {
                result.type = ((Ua == 0) || (Ua == 1) || (Ub == 0) || (Ub == 1)) ?
                     enumCrossType.ctOnBounds :
                     enumCrossType.ctInBounds;
            }
            // иначе точка пересечения за пределами отрезков
            else
            {
                result.type = enumCrossType.ctOutBounds;
            }

            return result;
        }

        public static void RotateTrianlePoints(ref Triangle tr)
        {
            var tempA = new Point3d(tr.A);
            var tempB = new Point3d(tr.B);
            tr.A = tr.C;
            tr.B = tempA;
            tr.C = tempB;
        }

        public static void SwitchPointsBC(ref Triangle tr)
        {
            var tempB = new Point3d(tr.B);
            tr.B = tr.C;
            tr.C = tempB;
        }

        public static void SwitchPointsAC(ref Triangle tr)
        {
            var tempA = new Point3d(tr.A);
            tr.A = tr.C;
            tr.C = tempA;
        }

        public static bool FindTwoPoints(Triangle tr1, Triangle tr2, ref Point3d a, ref Point3d b, 
            ref Point3d c1, ref Point3d c2)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tr1.A == tr2.A)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (tr1.B == tr2.B)
                        {
                            a = tr1.A;
                            b = tr1.B;
                            c1 = tr1.C;
                            c2 = tr2.C;
                            return true;
                        }
                        if (tr1.C == tr2.C)
                        {
                            a = tr1.A;
                            b = tr1.C;
                            c1 = tr1.B;
                            c2 = tr2.B;
                            return true;
                        }
                        SwitchPointsBC(ref tr2);
                    }
                }
                else if (tr1.B == tr2.B)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (tr1.C == tr2.C)
                        {
                            a = tr1.B;
                            b = tr1.C;
                            c1 = tr1.A;
                            c2 = tr2.A;
                            return true;
                        }
                        SwitchPointsAC(ref tr2);
                    }
                }
                RotateTrianlePoints(ref tr2);
            }

            return false; 
        }

        public static void MovePoints(ref Point3d a, ref Point3d b, ref Point3d c1, ref Point3d c2)
        {
            float dx = a.X;
            
            if (a.Y < dx)
                dx = a.Y;
            if (b.X < dx)
                dx = b.X;
            if (b.Y < dx)
                dx = b.Y;
            if (c1.X < dx)
                dx = c1.X;
            if (c1.Y < dx)
                dx = c1.Y;
            if (c2.X < dx)
                dx = c2.X;
            if (c2.Y < dx)
                dx = c2.Y;

            MyMath.Transform(ref a, dx, dx);
            MyMath.Transform(ref b, dx, dx);
            MyMath.Transform(ref c1, dx, dx);
            MyMath.Transform(ref c2, dx, dx);
        }

        // { геометрические алгоритмы: Пересекаются ли 2 отрезка?                     }
        //{ ------------------------------------------------------------------------ }
        //{ Определяет пересечение отрезков A(ax1,ay1,ax2,ay2) и B (bx1,by1,bx2,by2),}
        //{ функция возвращает TRUE - если отрезки пересекаются, а если пересекаются }
        //{ в концах или вовсе не пересекаются, возвращается FALSE (ложь)            }
        //{ ------------------------------------------------------------------------ }
        public static bool Intersection(Point3d a1, Point3d a2, Point3d b1, Point3d b2)
        {
            float v1;
            float v2;
            float v3;
            float v4;
            
            v1 = (b2.X - b1.X)*(a1.Y - b1.Y) - (b2.Y - b1.Y)*(a1.X - b1.X);
            v2 = (b2.X - b1.X)*(a2.Y - b1.Y) - (b2.Y - b1.Y)*(a2.X - b1.X);
            v3 = (a2.X - a1.X)*(b1.Y - a1.Y) - (a2.Y - a1.Y)*(b1.X - a1.X);
            v4 = (a1.X - a1.X)*(b2.Y - a1.Y) - (a2.Y - a1.Y)*(b2.X - a1.X);
            return (v1*v2 < 0) && (v3*v4 < 0);
        }

        public static bool operator == (Triangle tr1, Triangle tr2)
        {
            MakeTriandle(ref tr1);
            MakeTriandle(ref tr2);

            var a = new Point3d();
            var b = new Point3d();
            var c1 = new Point3d();
            var c2 = new Point3d();

            if (FindTwoPoints(tr1, tr2, ref a, ref b, ref c1, ref c2))
            {
                if (c1 == c2)
                    return true;
              //  var res = Crossing(c1, a, a, c2);
              //  if (res.type == enumCrossType.ctInBounds)
               //     if (res.pt != a)
               //         return true;
              //  MovePoints(ref a, ref b, ref c1, ref c2);
             //   var res = Crossing(c1, b, c2, a);
              //  if (res.type == enumCrossType.ctInBounds)
              //      return true;

            //    var res = Crossing(c1, a, c2, b);
              //  if (res.type == enumCrossType.ctInBounds)
                //    return true;

                if (Intersection(c1, a, a, c2))
                    return true;

                if (Intersection(c1, a, c2, a))
                    return true;
                //------------------------------
                
                if (Intersection(c1, a, c2, b))
                    return true;

                if (Intersection(c1, a, b, c2))
                    return true;
                //-------------------------------

                if (Intersection(a, c1, a, c2))
                    return true;

                if (Intersection(a, c1, c2, a))
                    return true;
                //-------------------------------

                if (Intersection(a, c1, b, c2))
                    return true;

                if (Intersection(a, c1, c2, b))
                    return true;
                //-------------------------------

                if (Intersection(c1, b, c2, b))
                    return true;

                if (Intersection(c1, b, b, c2))
                    return true;
                //-------------------------------

                if (Intersection(c1, b, c2, a))
                    return true;

                if (Intersection(c1, b, a, c2))
                    return true;
                //------------------------------

                if (Intersection(b, c1, c2, b))
                    return true;

                if (Intersection(b, c1, b, c2))
                    return true;
                //-------------------------------

                if (Intersection(b, c1, c2, a))
                    return true;

                if (Intersection(b, c1, a, c2))
                    return true;
                //------------------------------

             /*   res = Crossing(c1, a, b, c2);
                if (res.type == enumCrossType.ctInBounds)
                    return true;

                res = Crossing(a, c1, b, c2);
                if (res.type == enumCrossType.ctInBounds)
                    return true;

                res = Crossing(a, c1, c2, b);
                if (res.type == enumCrossType.ctInBounds)
                    return true;
               // res = Crossing(c1, b, c2, b);
               // if (res.type == enumCrossType.ctInBounds)
                //    if (res.pt != b)
                  //      return true;
                */
            } 

            return false;
        }

        public static bool operator !=(Triangle tr1, Triangle tr2)
        {
            return !(tr1 == tr2);
        }
    }
}
