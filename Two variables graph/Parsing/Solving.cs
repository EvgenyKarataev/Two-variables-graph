using System;
using System.Collections.Generic;

namespace TwoVariablesGraph
{
    class Solving
    {
        public Solving(int pointsCount, float xUpLimit, float xDownLimit, float yUpLimit, float yDownLimit)
        {
            PointsCount = pointsCount;
            XUpLimit = xUpLimit;
            XDownLimit = xDownLimit;
            YUpLimit = yUpLimit;
            YDownLimit = yDownLimit;
        }

        public int PointsCount { get; set; }
        public float XUpLimit { get; set; }
        public float XDownLimit { get; set; }
        public float YUpLimit { get; set; }
        public float YDownLimit { get; set; }

        private static Point3d SolveByXY(Parser parser, float x, float y, int index)
        {
            int position = -1;
            var postfixclone = new List<PostfixItem>();
            for (int i = 0; i < parser.Count; i++)
                postfixclone.Add(new PostfixItem(parser[i]));

            while (postfixclone.Count > 1)
            {
                position++;
                if (postfixclone[position].state != State.Const)
                {
                    switch (postfixclone[position].state)
                    {
                        case State.Function:
                            switch (postfixclone[position].functions)
                            {
                                case Functions.ArcCos:
                                    postfixclone[position - 1].constant = (float)
                                        Math.Acos(Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.ArcSin:
                                    postfixclone[position - 1].constant = (float)
                                        Math.Asin(Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.ArcTg:
                                    postfixclone[position - 1].constant = (float)
                                        Math.Atan(Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.ArcCtg:
                                    postfixclone[position - 1].constant = (float)
                                        (1/ Math.Atan(Constants.GetConst(postfixclone[position - 1])));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Cos:
                                    postfixclone[position - 1].constant = (float)
                                        Math.Cos(Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Ctg:
                                    postfixclone[position - 1].constant = (float) (1 /
                                                                          Math.Tan(
                                                                              Constants.GetConst(
                                                                                  postfixclone[position - 1])));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Difference:
                                    postfixclone[position - 2].constant = Constants.GetConst(
                                                                              postfixclone[position - 2])
                                                                          -
                                                                          Constants.GetConst(
                                                                              postfixclone[position - 1]);
                                    postfixclone.RemoveAt(position - 1);
                                    postfixclone.RemoveAt(position - 1);
                                    position -= 2;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Division:
                                    postfixclone[position - 2].constant = Constants.GetConst(
                                                                              postfixclone[position - 2])
                                                                          /
                                                                          Constants.GetConst(
                                                                              postfixclone[position - 1]);
                                    postfixclone.RemoveAt(position - 1);
                                    postfixclone.RemoveAt(position - 1);
                                    position -= 2;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Lg:
                                    postfixclone[position - 1].constant = (float)
                                        Math.Log10(Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Ln:
                                    postfixclone[position - 1].constant = (float)
                                        Math.Log(Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Multiplication:
                                    postfixclone[position - 2].constant = Constants.GetConst(
                                                                              postfixclone[position - 2])
                                                                          *
                                                                          Constants.GetConst(
                                                                              postfixclone[position - 1]);
                                    postfixclone.RemoveAt(position - 1);
                                    postfixclone.RemoveAt(position - 1);
                                    position -= 2;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Power:
                                    postfixclone[position - 2].constant = (float)
                                        Math.Pow(Constants.GetConst(postfixclone[position - 2]),
                                                 Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position - 1);
                                    postfixclone.RemoveAt(position - 1);
                                    position -= 2;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Sin:
                                    postfixclone[position - 1].constant = (float)
                                        Math.Sin(Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Sum:
                                    postfixclone[position - 2].constant = Constants.GetConst(
                                                                              postfixclone[position - 2])
                                                                          +
                                                                          Constants.GetConst(
                                                                              postfixclone[position - 1]);
                                    postfixclone.RemoveAt(position - 1);
                                    postfixclone.RemoveAt(position - 1);
                                    position -= 2;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Functions.Tg:
                                    postfixclone[position - 1].constant = (float)
                                        Math.Tan(Constants.GetConst(postfixclone[position - 1]));
                                    postfixclone.RemoveAt(position);
                                    position -= 1;
                                    postfixclone[position].state = State.Const;
                                    break;
                            }
                            break;
                        case State.Vars:
                            switch (postfixclone[position].vars)
                            {
                                case Vars.X:
                                    postfixclone[position].constant = x;
                                    postfixclone[position].state = State.Const;
                                    break;
                                case Vars.Y:
                                    postfixclone[position].constant = y;
                                    postfixclone[position].state = State.Const;
                                    break;
                            }
                            break;

                    }
                }

            }/////////////////////////////////Urat'4
            return new Point3d(x, y, postfixclone[0].constant, index); 
        }

        public List<Point3d> SolveRandom(Parser parser)
        {
            var random = new Random(~unchecked((int)DateTime.Now.Ticks)); 
            var result = new List<Point3d>();
            var listOfIndexUsed = new List<Point3d>();

            int index = 0;

            /*
            //точки по оси ОY x = 0. 
            for (double j = -PointsCount / 8.0; j <= PointsCount / 8.0; j++)
            {
                const float x = 0f;
                float y = (float) (j * YLimit * 4 / PointsCount);
                if (listOfIndexUsed.IndexOf(new Point3d(x, y, 0, -1)) > -1)
                    continue;
                listOfIndexUsed.Add(new Point3d(x, y, 0, -1));
                result.Add(SolveByXY(parser, x, y, index++));
            }

            //точки по оси ОX y = 0. 
            for (double j = -PointsCount / 8.0; j <= PointsCount / 8.0; j++)
            {
                float x = (float)(j * XLimit * 4 / PointsCount);
                const float y = 0f;
                if (listOfIndexUsed.IndexOf(new Point3d(x, y, 0, -1)) > -1)
                    continue;
                listOfIndexUsed.Add(new Point3d(x, y, 0, -1));
                result.Add(SolveByXY(parser, x, y, index++));
            }

            //точки по оси ОY x = XLimit. 
            for (double j = -PointsCount / 8.0; j <= PointsCount / 8.0; j++)
            {
                float x = XLimit;
                float y = (float)(j * YLimit * 4 / PointsCount);
                if (listOfIndexUsed.IndexOf(new Point3d(x, y, 0, -1)) > -1)
                    continue;
                listOfIndexUsed.Add(new Point3d(x, y, 0, -1));
                result.Add(SolveByXY(parser, x, y, index++));
            }

            //точки по оси ОX y = YLimit. 
            for (double j = -PointsCount / 8.0; j <= PointsCount / 8.0; j++)
            {
                float x = (float)(j * XLimit * 4 / PointsCount);
                float y = (float)YLimit;
                if (listOfIndexUsed.IndexOf(new Point3d(x, y, 0, -1)) > -1)
                    continue;
                listOfIndexUsed.Add(new Point3d(x, y, 0, -1));
                result.Add(SolveByXY(parser, x, y, index++));
            } 

            for (int k = 1; k < PointsCount; k++)
            {
                float x = (float)(random.NextDouble() * XLimit - XLimit / 2);
                float y = (float) (random.NextDouble() * YLimit - YLimit / 2);

                if (listOfIndexUsed.IndexOf(new Point3d(x, y, 0, -1)) > -1)
                {
                    k--;
                    continue;
                }
                listOfIndexUsed.Add(new Point3d(x, y, 0, -1));

                result.Add(SolveByXY(parser, x, y, index++));
            }  */
            return result;
        }

        public List<Point3d> Solve(Parser parser)
        {
            var result = new List<Point3d>();

            int index = -1;
            float stepX = (XUpLimit - XDownLimit)/(PointsCount - 1);
            float stepY = (YUpLimit - YDownLimit) / (PointsCount - 1);
            for (int i = 0; i < PointsCount; i++)
                for (int j = 0; j < PointsCount; j++)
                {
                    index++;
                    float x = (i * stepX + XDownLimit);//(i * XLimit * 4 / PointsCount);
                    float y = (j * stepY + YDownLimit);//(j * YLimit * 4 / PointsCount);
                    result.Add(SolveByXY(parser, x, y, index));
                }

            return result;
        }
    }
}
