using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TwoVariablesGraph
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
            ucGLPanel1.RePaint += Points;
            ucGLPanel1.RePaint += TriangOut;
           
        }

        private readonly Parser _parser = new Parser();
        private List<Point3d> _points = new List<Point3d>();
        private Triangles _triangles = new Triangles();
        private string _function = "";
 
        private const float l = 1.9f;
        private float mashtabX = 1;
        private float mashtabY = 1;
        private float mashtabZ = 1;

        private EnterFunctionDialog _enterFunctionDialog = new EnterFunctionDialog();
        private SettingsDialog _settingsDialog = new SettingsDialog();

        private void FindMashtabZ(bool isAuto)
        {
            if (isAuto)
            {
                if (_points.Count > 0)
                {
                    var zMax = _points[0].Z;
                    var zMin = _points[0].Z;
                    for (int i = 1; i < _points.Count; i++)
                        if (_points[i].Z > zMax)
                            zMax = Math.Abs(_points[i].Z);
                        else if (_points[i].Z < zMin)
                            zMin = _points[i].Z;

                    mashtabZ = zMax - zMin != 0 ? l / (zMax - zMin) : 1;
                    ucGLPanel1.ZMax = zMax;
                    ucGLPanel1.ZMin = zMin;
                }
            }
            else
            {
                mashtabZ = l / (ucGLPanel1.ZMax - ucGLPanel1.ZMin);
                ucGLPanel1.ZMax = ucGLPanel1.ZMax;
                ucGLPanel1.ZMin = ucGLPanel1.ZMin;
            }
            
        }

        private bool Solve()
        {
            if (_enterFunctionDialog.GetPointsCount() == string.Empty)
                return false;

            var solving = new Solving(Convert.ToInt32(_enterFunctionDialog.GetPointsCount()), 
                ucGLPanel1.XMax, ucGLPanel1.XMin, ucGLPanel1.YMax, ucGLPanel1.YMin);
            mashtabX = ucGLPanel1.XMax - ucGLPanel1.XMin != 0 ? l / (ucGLPanel1.XMax - ucGLPanel1.XMin) : 1;
            mashtabY = ucGLPanel1.YMax - ucGLPanel1.YMin != 0 ? l / (ucGLPanel1.YMax - ucGLPanel1.YMin) : 1;

            _points = solving.Solve(_parser);

            FindMashtabZ(ucGLPanel1.AutoZ);

            return _points.Count > 0;
        }

        private void Points()
        {
            OpenGLControl.glPointSize(2);
            OpenGLControl.glBegin(OpenGLControl.GL_POINTS);
            for (int i = 0; i < _points.Count; i++ )
                OpenGLControl.glVertex3f(_points[i].Y * mashtabY, _points[i].Z * mashtabZ,
                    _points[i].X * mashtabX );
            OpenGLControl.glEnd();
        }

        private void TriangOut()
        {
            //Convert.ToInt32(textBox1.Text) _triangles.Count()
            for (int i = 0; i < _triangles.Count(); i++)
            {
                var normal = MyMath.Normal(_triangles[i].A - _triangles[i].B,
                                           _triangles[i].C - _triangles[i].B);
                if (normal.Z < 0)
                    normal = MyMath.Normal(_triangles[i].C - _triangles[i].B,
                                           _triangles[i].A - _triangles[i].B);
                OpenGLControl.glNormal3f(normal.X, normal.Y, normal.Z);
                OpenGLControl.glBegin(OpenGLControl.GL_TRIANGLES);
                {
                    OpenGLControl.glVertex3f(_triangles[i].A.Y*mashtabY, _triangles[i].A.Z*mashtabZ,
                                             _triangles[i].A.X*mashtabX);

                    OpenGLControl.glVertex3f(_triangles[i].B.Y*mashtabY, _triangles[i].B.Z*mashtabZ,
                                             _triangles[i].B.X*mashtabX);

                    OpenGLControl.glVertex3f(_triangles[i].C.Y*mashtabY, _triangles[i].C.Z*mashtabZ,
                                             _triangles[i].C.X*mashtabX);
                }
                OpenGLControl.glEnd();
            }
        }

        /// <summary>
        /// Строит триангуляцию заданного набора точек.
        /// </summary>
        /// <param name="points"> Заданный набор точек. </param>
        /// <returns> Результат триангуляции. </returns>
        public Triangles Triangulation(List<Point3d> points)
        {
            var triangles = new Triangles();

            // Первоначальное задание точек P1, P2, P3.
            var p1 = new Point3d(points[0].X, points[0].Y, points[0].Z, 0);
            var p2 = new Point3d(points[1].X, points[1].Y, points[1].Z, 1);
            var p3 = new Point3d(points[0].X - 2, points[0].Y, 0, -1);

            // Создание стека.
            var stack = new Stack<Point3d>();

            // Помещаем точки в стек.
            stack.Push(p3);
            stack.Push(p2);
            stack.Push(p1);

            while (stack.Count > 0) // Пока стек не пуст.
            {
                // Снимаем точки со стека.
                p1 = stack.Pop();
                p2 = stack.Pop();
                p3 = stack.Pop();
                int index;

                // Получаем массив точек.
                var tempPoints = new List<Point3d>();
                for (int i = 0; i < points.Count; i++ )
                    tempPoints.Add(new Point3d(points[i]));

                // Начальная и конечная точки линии P1 P2
                Point3d tempPS;
                Point3d tempPE;

                if (p2 > p1)    // Конец должен быть дальше начала.
                {
                    tempPS = new Point3d(p1);
                    tempPE = new Point3d(p2);
                }
                else
                {
                    tempPS = new Point3d(p2);
                    tempPE = new Point3d(p1);
                }

                // Если точка с другой стороны прямой найдена, то про возваращается ее индекс > -1
                if ((index = MyMath.FindPointAcrossLine(new Point3d(p3),
                        new VecLine(new Point3d(tempPS), new Point3d(tempPE)), tempPoints)) > -1)
                    {
                        // Создаем триугольник с найднной точкой.
                        var tempTriangle = new Triangle(tempPE, tempPS, points[index]);
                        if (!triangles.ifHas(tempTriangle)) // Если в списке триугольников еще нет этого
                        {
                            // то добавляем его в списко триугольников
                            triangles.Add(new Triangle(tempPE, tempPS, points[index]));
                            // Добавляем вершины в стек.
                            stack.Push(p1);
                            stack.Push(points[index]);
                            stack.Push(p2);

                            stack.Push(p2);
                            stack.Push(points[index]);
                            stack.Push(p1);
                        }
                    
                    }
            }
            triangles.SolveMaxMin(); // Рассчитывает максимальное и минимальное значение вершины Z.
            return triangles; // Возвращает список треугольников.
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucGLPanel1.KillFont();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
           // pgProperties.SelectedObject = _settings;
        }

        private void hsbHorPosition_ValueChanged(object sender, EventArgs e)
        {
            ucGLPanel1.fTransX = (float)(45 - hsbHorPosition.Value)/10;
        }

        private void vsbVertPosition_ValueChanged(object sender, EventArgs e)
        {
            ucGLPanel1.fTransY = (float)(vsbVertPosition.Value - 45) / 10;
        }

        private void tsmiSaveImage_Click(object sender, EventArgs e)
        {
           
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripMenuItemEnterFunction_Click(object sender, EventArgs e)
        {
            _enterFunctionDialog.SetFunction(_function);
            _enterFunctionDialog.ShowDialog();
            if (_enterFunctionDialog.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                _function = _enterFunctionDialog.GetFunction();

                Cursor = Cursors.WaitCursor;
                if (_parser.Parse(_function.ToLower()))
                    if (Solve())
                    {
                        _triangles = Triangulation(_points);
                        ucGLPanel1.Invalidate();
                    }
                Cursor = Cursors.Default;
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settingsDialog.XMax = ucGLPanel1.XMax;
            _settingsDialog.XMin = ucGLPanel1.XMin;
            _settingsDialog.YMax = ucGLPanel1.YMax;
            _settingsDialog.YMin = ucGLPanel1.YMin;
            _settingsDialog.ZMax = ucGLPanel1.ZMax;
            _settingsDialog.ZMin = ucGLPanel1.ZMin;
            _settingsDialog.AutoZ = ucGLPanel1.AutoZ;
            
            _settingsDialog.DrawMode = ucGLPanel1.Mode;
            _settingsDialog.Color = ucGLPanel1.PaintColor;
            _settingsDialog.LineWidth = ucGLPanel1.LineWidth;

            _settingsDialog.ShowDialog();

            if (_settingsDialog.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
               ucGLPanel1.XMax = _settingsDialog.XMax;
               ucGLPanel1.XMin = _settingsDialog.XMin;
               ucGLPanel1.YMax = _settingsDialog.YMax;
               ucGLPanel1.YMin = _settingsDialog.YMin;
               ucGLPanel1.ZMax = _settingsDialog.ZMax;
               ucGLPanel1.ZMin = _settingsDialog.ZMin;
               ucGLPanel1.AutoZ = _settingsDialog.AutoZ;

               ucGLPanel1.Mode = _settingsDialog.DrawMode;
               ucGLPanel1.PaintColor = _settingsDialog.Color;
               ucGLPanel1.LineWidth = _settingsDialog.LineWidth;
                
                if (Solve())
                    _triangles = Triangulation(_points);
            }
        }
    }
        
}
