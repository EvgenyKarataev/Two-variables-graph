using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows;
using Tao.Platform.Windows;

namespace TwoVariablesGraph
{
    public delegate void RePainHandler();
    
    public partial class ucGLPanel : OpenGLControl
    {
        public event RePainHandler RePaint;
        
        public ucGLPanel()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(ucGLPanel_MouseWheel);
            
        }

        private readonly Gdi.GLYPHMETRICSFLOAT[] gmf = new Gdi.GLYPHMETRICSFLOAT[256];	// Storage For Information About Our Outline Font Characters
        private uint firstIndex;				// Base Display List For The Font Set

        #region Overridables
        public float[] MaterialColor = {0.1f, 0.0f, 1.0f, 0.5f};
        protected override void OnInitScene()
        {
            glShadeModel(GL_SMOOTH);
            glEnable(GL_LIGHTING);
            glEnable(GL_LIGHT0);
         //   glEnable(GL_COLOR_MATERIAL);
            glMaterialfv(GL_FRONT, GL_AMBIENT_AND_DIFFUSE, MaterialColor);
           // glLightModeli(GL_LIGHT_MODEL_TWO_SIDE, 1);

            glEnable(GL_DEPTH_TEST);
        //  glEnable(GL_AUTO_NORMAL);
            glEnable(GL_NORMALIZE);

            BuildFont();	

        }
        #endregion

        #region Drawing

        readonly float[][] v = new float[][] {
										 new float [] {-1, 1, -1},
										 new float [] {1,  1, -1},
										 new float [] {1, -1, -1},
										 new float [] {-1, -1, -1},
										 new float [] {-1, 1, 1},
										 new float [] {-1, -1, 1},
										 new float [] {1, -1, 1},
										 new float [] {1, 1, 1}
									 };

        readonly double[][] norm = new double[][] {
											   new double [] {0,  0, -1},
											   new double [] {0,  0,  1},
											   new double [] {-1, 0,  0},
											   new double [] {1,  0,  0},
											   new double [] {0,  1,  0},
											   new double [] {0, -1,  0}
										   };

        readonly uint[,] id = new uint[6, 4] 
		{
			{0, 1, 2, 3},
			{4, 5, 6, 7},
			{0, 3, 5, 4},
			{7, 6, 2, 1},
			{0, 4, 7, 1},
			{5, 3, 2, 6},
		};


        private Point _ptCursorPos = new Point();
        private float _fTransZ = -6;
        private float _scale = 1.0f;

        private const int _devisionsCount = 6;
        private const int _l = 3;
        private const float _lAxis = 1.9f;
        private const float _riskHeight = 0.05f;


        private float _fAngleX = 30;
        public float AngleX
        {
            get { return _fAngleX; }
            set
            {
                _fAngleX = value;
                Invalidate();
            }
        }

        private float _fAngleY = 30;
        public float AngleY
        {
            get { return _fAngleY; }
            set
            {
                _fAngleY = value;
                Invalidate();
            }
        }

        private float _fAngleZ = 30;
        public float AngleZ
        {
            get { return _fAngleZ; }
            set
            {
                _fAngleZ = value;
                Invalidate();
            }
        }

        private bool _showAxes = true;
        public bool ShowAxes
        {
            get { return _showAxes; }
            set
            {
                _showAxes = value;
                Invalidate();
            }
        }

        private DrawModeEnum _mode = DrawModeEnum.GL_FILL;
        public DrawModeEnum Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                Invalidate();
            }
        }

        private void ucGLPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                _scale += 0.01f;
            else
                _scale -= 0.01f;
            Invalidate();
        }

        private void BuildFont()
        {
       //     firstIndex = glGenLists(256);								// Storage For 256 Characters

            var font = CreateFont(-12,							// Height Of Font
                        0,								// Width Of Font
                        0,								// Angle Of Escapement
                        0,								// Orientation Angle
                        (int) FontWeight.FW_BLACK,						// Font Weight
                        0,							// Italic
                        0,							// Underline
                        0,							// Strikeout
                        (uint) CharSet.ANSI_CHARSET,					// Character Set Identifier
                        (uint) OutputPrecision.OUT_TT_ONLY_PRECIS,					// Output Precision
                        (uint) ClipPrecision.CLIP_DEFAULT_PRECIS,			// Clipping Precision
                        (uint) Quality.ANTIALIASED_QUALITY,			// Output Quality
                        (uint) PitchAndFamily.DEFAULT_PITCH,		// Family And Pitch
                        "Times New Roman");				// Font Name

            SelectObject(_hDC, font);

            Wgl.wglUseFontOutlinesW(_hDC, // Select The Current DC
                                    0, // Starting Character
                                    255, // Number Of Display Lists To Build
                                    (int)GLF_START_LIST, // Starting Display Lists
                                    0.0f, // Deviation From The True Outlines
                                    0.05f, // Font Thickness In The Z Direction
                                    Wgl.WGL_FONT_POLYGONS, // Use Polygons, Not Lines
                                    gmf);

          /*  wglUseFontOutlines(Handle,							// Select The Current DC
                        0,								// Starting Character
                        255,							// Number Of Display Lists To Build
                        GLF_START_LIST,							// Starting Display Lists
                        0.0f,							// Deviation From The True Outlines
                        0.2f,							// Font Thickness In The Z Direction
                        WGL_FONT_POLYGONS,				// Use Polygons, Not Lines
                        gmf);							// Address Of Buffer To Recieve Data
           * */
        }

        public void KillFont()									// Delete The Font
        {
            glDeleteLists(GLF_START_LIST, 256); // Delete All 256 Characters
        }

        private static void Print(char[] text)
        {
            glPushMatrix();
            glPushAttrib(GL_LIST_BIT);							// Pushes The Display List Bits
            glListBase(GLF_START_LIST);									// Sets The Base Character to 0
            glCallLists(text.Length, GL_UNSIGNED_BYTE, text);	// Draws The Display List Text
            glPopAttrib();										// Pops The Display List Bits
            glPopMatrix();
        }

        private float _xMax = 1;
        public float XMax
        {
            get { return _xMax; }
            set
            {
                _xMax = value;
                Invalidate();
            }
        }

        private float _xMin = -1;
        public float XMin
        {
            get { return _xMin; }
            set
            {
                _xMin = value;
                Invalidate();
            }
        }

        private float _yMax = 1;
        public float YMax
        {
            get { return _yMax; }
            set
            {
                _yMax = value;
                Invalidate();
            }
        }

        private float _yMin = -1;
        public float YMin
        {
            get { return _yMin; }
            set
            {
                _yMin = value;
                Invalidate();
            }
        }

        private float _zMax = 1;
        public float ZMax
        {
            get { return _zMax; }
            set
            {
                _zMax = value;
                Invalidate();
            }
        }

        private float _zMin = -1;
        public float ZMin
        {
            get { return _zMin; }
            set
            {
                _zMin = value;
                Invalidate();
            }
        }

        private bool _autoZ = true;
        public bool AutoZ
        {
            get { return _autoZ; }
            set
            {
                _autoZ = value;
                Invalidate();
            }
        }

        private float _fTransX;
        public float fTransX
        {
            get { return _fTransX; }
            set
            {
                _fTransX = value;
                Invalidate();
            }
        }

        private float _fTransY;
        public float fTransY
        {
            get { return _fTransY; }
            set
            {
                _fTransY = value;
                Invalidate();
            }
        }

        private bool _blended = false;
        public bool Blended
        {
            get { return _blended; }
            set
            {
                _blended = value;
                Invalidate();
            }
        }

        private Color _color = Color.Blue;
        public Color PaintColor
        {
            get { return _color; }
            set
            {
                _color = value;
                Invalidate();
            }
        }

        private float _lineWidth = 1f;
        public float LineWidth
        {
            get { return _lineWidth; }
            set
            {
                _lineWidth = value;
                Invalidate();
            }
        }
        

        private float GetStringLength(char[] text)
        {
            float result = 0;
            for (int i = 0; i < text.Length; i++)//Цикл поиска размера строки
            {
                result += gmf[text[i]].gmfCellIncX;
                // Увеличение размера на ширину символа
            }
            return result;
        }

        private float GetStringHeight(char[] text)
        {
            var max = gmf[text[0]].gmfBlackBoxY;
            for (int i = 0; i < text.Length; i++)
                if (gmf[text[i]].gmfBlackBoxY > max)
                    max = gmf[text[i]].gmfBlackBoxY;
            return max;
        }

        private float _yOffSet;

        private void DrawYMarkingOut()
        {
            glPushMatrix();
                
                var stepMarkingOut = _lAxis / _devisionsCount;
                var stepValue = (YMax - YMin) / _devisionsCount;
                _yOffSet = YMin / stepValue * stepMarkingOut;
                glTranslatef(-stepMarkingOut, 0, 0);
                for (int i = 0; i <= _devisionsCount; i++)
                {
                    glTranslatef(stepMarkingOut, 0, 0);
                    glBegin(GL_LINES);
                    {
                        glVertex3f(0, -_riskHeight, 0);
                        glVertex3f(0, _riskHeight, 0);
                    }
                    glEnd();
                    glPushMatrix();
                    {
                        if (_scale < 1)
                          glScalef(_scale * 0.16f, _scale * 0.16f, _scale * 0.16f);
                        else
                          glScalef(0.16f,0.16f, 0.16f);
                        glRotatef(-_fAngleY, 0, 1, 0);
                        glRotatef(-_fAngleX, 1, 0, 0);
                        var textOut = (YMin + stepValue * (i));
                        var textOutC = Math.Abs(textOut) > 999
                                           ? textOut.ToString("0.######E+0").ToCharArray()
                                           : textOut.ToString("##0.##").ToCharArray();

                        glTranslatef(-GetStringLength(textOutC) / 2, -GetStringHeight(textOutC) - 0.1f, 0);
                        Print(textOutC);
                    }
                    glPopMatrix();
                }
            glPopMatrix();
        }

        private void DrawY()
        {
            glBegin(GL_LINES);
            {
                // X
                glVertex3f(0, 0, 0);
                glVertex3f(2, 0, 0);
            }
            glEnd();

            glPushMatrix();
            {
                var x = new char[1];
                x[0] = 'Y';

                glTranslatef(2.1f, 0, 0);
                glScalef(_scale * 0.2f, _scale * 0.2f, _scale * 0.2f);
                glTranslatef(0, -gmf[x[0]].gmfBlackBoxY / 2, 0);
                glRotatef(-_fAngleX, 1, 0, 0);
                Print(x);
            }
            glPopMatrix();

            DrawYMarkingOut();
        }

        private float _zOffSet;

        private void DrawZMarkingOut()
        {
            glPushMatrix();
            {
                var stepMarkingOut = _lAxis / _devisionsCount;
                var stepValue = (ZMax - ZMin) / _devisionsCount;
                _zOffSet = ZMin / stepValue * stepMarkingOut;

                glRotatef(-_fAngleY, 0, 1, 0);
                glTranslatef(0, -stepMarkingOut, 0);
                for (int i = 0; i <= _devisionsCount; i++)
                {
                    glTranslatef(0, stepMarkingOut, 0);
                    glBegin(GL_LINES);
                    {
                        glVertex3f(-_riskHeight, 0, 0);
                        glVertex3f(_riskHeight, 0, 0);
                    }
                    glEnd();
                    glPushMatrix();
                    {
                        if (_scale < 1)
                            glScalef(_scale * 0.16f, _scale * 0.16f, _scale * 0.16f);
                        else
                            glScalef(0.16f, 0.16f, 0.16f);
                        
                        glRotatef(-_fAngleX, 1, 0, 0);
                        var textOut = (ZMin + stepValue*(i ));
                        var textOutC = Math.Abs(textOut) > 999
                                           ? textOut.ToString("0.######E+0").ToCharArray()
                                           : textOut.ToString("##0.##").ToCharArray();

                        if (i == 0)
                            glTranslatef(-GetStringLength(textOutC) - 0.3f, GetStringHeight(textOutC) / 2, 0);
                        else
                            glTranslatef(-GetStringLength(textOutC) - 0.3f, -GetStringHeight(textOutC) / 2, 0);
                        Print(textOutC);
                    }
                    glPopMatrix();
                }
            }
            glPopMatrix();
        }

        private void DrawZ()
        {
            glBegin(GL_LINES);
            {
                // Z
                glVertex3f(0, 0, 0);
                glVertex3f(0, 2, 0);
            }
            glEnd();

            glPushMatrix();
            glRotatef(-_fAngleY, 0, 1, 0);
            var y = new char[1];
            y[0] = 'Z';
            glTranslatef(0, 2.1f, 0);
            glScalef(_scale * 0.2f, _scale * 0.2f, _scale * 0.2f);
            glTranslatef(-gmf[y[0]].gmfBlackBoxX / 2, 0, 0);
            Print(y);
            glPopMatrix();

            DrawZMarkingOut();
        }

        private float _xOffSet;

        private void DrawXMarkingOut()
        {
            glPushMatrix();
            var stepMarkingOut = _lAxis / _devisionsCount;
            var stepValue = (XMax - XMin) / _devisionsCount;
            _xOffSet = XMin / stepValue * stepMarkingOut;
            glTranslatef(0, 0, -stepMarkingOut);
            for (int i = 0; i <= _devisionsCount; i++)
            {
                glTranslatef(0, 0, stepMarkingOut);
                glBegin(GL_LINES);
                {
                    glVertex3f(-_riskHeight, 0, 0);
                    glVertex3f(_riskHeight, 0, 0);
                }
                glEnd();
                glPushMatrix();
                {
                    if (_scale < 1)
                        glScalef(_scale * 0.16f, _scale * 0.16f, _scale * 0.16f);
                    else
                        glScalef(0.16f, 0.16f, 0.16f);

                    
                    var textOut = (XMin + stepValue * (i));
                    var textOutC = Math.Abs(textOut) > 999
                                       ? textOut.ToString("0.######E+0").ToCharArray()
                                       : textOut.ToString("##0.##").ToCharArray();

                    glTranslatef((-GetStringLength(textOutC) - 0.3f) / 2, -GetStringHeight(textOutC) / 2, 0);
                    glRotatef(-_fAngleY, 0, 1, 0);
                    glRotatef(-_fAngleX, 1, 0, 0);
                    glTranslatef((-GetStringLength(textOutC) - 0.3f) / 2, 0, 0);
                    if (i == 0)
                        glTranslatef(0, -GetStringHeight(textOutC) / 2, 0);
                    Print(textOutC);
                }
                glPopMatrix();
            }
            glPopMatrix();
        }

        private void DrawX()
        {
            glBegin(GL_LINES);
            {
                // 
                glVertex3f(0, 0, 0);
                glVertex3f(0, 0, 2);
            }
            glEnd();

            glPushMatrix();
            {
                var z = new char[1];
                z[0] = 'X';

                glTranslatef(0, 0, 2.1f);
                glScalef(_scale*0.2f, _scale*0.2f, _scale*0.2f);
                glTranslatef(-gmf[z[0]].gmfBlackBoxX/2, -gmf[z[0]].gmfBlackBoxY/2, 0);
                glRotatef(-_fAngleY, 0, 1, 0);
                Print(z);
            }
            glPopMatrix();

            DrawXMarkingOut();
        }

        private void DrawCoordinateSystem()
        {
            glPushMatrix();
            glPushAttrib(GL_ALL_ATTRIB_BITS);
            float[] MaterialColorAxes = { 0.0f, 0.0f, 0.0f, 0.8f};
            glScalef(1, 1, 1);
            glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT_AND_DIFFUSE, MaterialColorAxes);
            DrawX();
            DrawY();
            DrawZ();
            glPopAttrib();
            glPopMatrix();
        }
        #endregion

        private void ucGLPanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // Активируем контекст OpenGL
                ActivateContext();

                // Цвет фона - используем свойство BackColor, унаследованное от Control
                glClearColor((float)BackColor.R / 255, (float)BackColor.G / 255, (float)BackColor.B / 255,
                             1f);//(float) BackColor.A/255);

                glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

                glMatrixMode(GL_MODELVIEW);
                glLoadIdentity();

                glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);

                glTranslated(_fTransX, _fTransY, _fTransZ);
                
                glRotated(_fAngleX, 1, 0, 0);
                glRotated(_fAngleY, 0, 1, 0);
                glRotated(_fAngleZ, 0, 0, 1);
                
                glScalef(_scale, _scale, _scale);
                
                // Цвет системы координат - используем свойство ForeColor, унаследованное от Control
                glColor3ub(ForeColor.R, ForeColor.G, ForeColor.B);
                //glMaterialfv(GL_FRONT, GL_AMBIENT_AND_DIFFUSE, MaterialColor);
                if (_showAxes)
                    DrawCoordinateSystem();


                glTranslatef(-_yOffSet, -_zOffSet, -_xOffSet);
                
                glPolygonMode(GL_FRONT_AND_BACK, (uint)Mode);
                glPushAttrib(GL_ALL_ATTRIB_BITS);
                {

                    glLineWidth(LineWidth);

                    MaterialColor[0] = (float)PaintColor.R / 255;
                    MaterialColor[1] = (float)PaintColor.G / 255;
                    MaterialColor[2] = (float)PaintColor.B / 255;
                    glMaterialfv(GL_FRONT, GL_AMBIENT_AND_DIFFUSE, MaterialColor);
                    
                    if (Blended)                                        //Вкл прозрачности
                    {
                        glEnable(GL_ALPHA_TEST);
                        glEnable(GL_BLEND);
                        glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
                    }
                    else
                    {
                        //Выкл прозрачности
                        glDisable(GL_BLEND);
                        glDisable(GL_ALPHA_TEST);
                    }

                    if (RePaint != null)
                        RePaint();
                }
                glPopAttrib();

                // Переключаем буфера и деактивируем контекст OpenGL
                SwapBuffers();
                // Деактивируем контекст OpenGL
                DeactivateContext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Mouse Up
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            _ptCursorPos.X = e.X;
            _ptCursorPos.Y = e.Y;
        }

        // MouseMove
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (MouseButtons != MouseButtons.Left)
                return;

            float _fShiftDY = (e.Y - _ptCursorPos.Y) / 4f;
            float _fShiftDX = (e.X - _ptCursorPos.X) / 4f;

            // Изменяем углы поворота
            float a = Math.Abs(_fAngleX);
            if (90f < a && a < 270f)
                _fShiftDX = -_fShiftDX;

            _fAngleX += _fShiftDY;
            _fAngleY += _fShiftDX;

            _ptCursorPos.X = e.X;
            _ptCursorPos.Y = e.Y;

            Invalidate();
        }
        public Bitmap ToBitmapFile()
        {
            return ToBitmap();
        }

        public Bitmap ToBitmapFile(System.Drawing.Imaging.PixelFormat pf)
        {
            return ToBitmap(pf);
        }
    }
}
