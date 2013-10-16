using System.ComponentModel;
using System.Drawing;

namespace TwoVariablesGraph
{
    public class OutViewSettings
    {
        //public enum DrawModeEnum
        //{
        //    GL_POINT	= 0x1B00,
        //    GL_LINE     = 0x1B01,
        //    GL_FILL     = 0x1B02
        //} ;
        
        public OutViewSettings(float xMax, float xMin, float yMax, float yMin, float zMax, 
            float zMin, bool showAxises, bool autoZ,
            DrawModeEnum mode, bool blended, Color color, float lineWidth)
        {
            XMax = xMax;
            XMin = xMin;
            YMax = yMax;
            YMin = yMin;
            ZMax = zMax;
            ZMin = zMin;
            ShowAxises = showAxises;
            AutoZ = autoZ;
            Mode = mode;
            Blended = blended;
            PaintColor = color;
            LineWidth = lineWidth;
        }
        
        private float _xMax;

        /// <summary>
        /// Максимальное по модулю значение Х. 
        /// <remarks> HZ </remarks>
        /// </summary>
        [Description("Максимальное значение Х. "), Category("X")]
        public float XMax 
        {
            get { return _xMax; }
            set 
            { 
                _xMax = value;
                FireXMax(_xMax);
            } 
        }

        private float _xMin;

        /// <summary>
        /// Максимальное по модулю значение Х. 
        /// <remarks> HZ </remarks>
        /// </summary>
        [Description("Минимальное значение Х. "), Category("X")]
        public float XMin
        {
            get { return _xMin; }
            set
            {
                _xMin = value;
                FireXMin(_xMin);
            }
        }

        private float _yMax;
        [Description("Максимальное значение Y. "), Category("Y")]
        public float YMax
        {
            get { return _yMax; }
            set
            {
                _yMax = value;
                FireYMax(_yMax);
            }
        }

        private float _yMin;
        [Description("Минимальное значение Y. "), Category("Y")]
        public float YMin
        {
            get { return _yMin; }
            set
            {
                _yMin = value;
                FireYMin(_yMin);
            }
        }

        private float _zMax;
        [Description("Максимальное значение Z. "), Category("Z")]
        public float ZMax
        {
            get { return _zMax; }
            set
            {
                _zMax = value;
                FireZMax(_zMax);
            }
        }

        private float _zMin;
        [Description("Минимальное значение Z. "), Category("Z")]
        public float ZMin
        {
            get { return _zMin; }
            set
            {
                _zMin = value;
                FireZMin(_zMin);
            }
        }

        private bool _showAxises;
        [Description("Отображать оси если истина, иначе не отображать. "), Category("Оси координат")]
        public bool ShowAxises
        {
            get { return _showAxises; }
            set
            {
                _showAxises = value;
                FireShowAxises(_showAxises);
            }
        }

        private bool _autoZ;
        [Description("Отображает максимальное значение функции на оси Z если истина. "), Category("Z")]
        public bool AutoZ
        {
            get { return _autoZ; }
            set
            {
                _autoZ = value;
                FireAutoZ(_autoZ);
            }
        }

        private DrawModeEnum _mode;
        [Description("Режим прорисовки поверхности. GL_FILL - закрашивать поверхность;. " +
            "GL_LINE - выводить только линии; GL_POINTS - выводить точки."), Category ("Отображение")]
        public DrawModeEnum Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                FireMode(_mode);
            }
        }

        private bool _blended;
        [Description("Рисует поверхность прозрачной если истина. "), Category("Отображение")]
        public bool Blended
        {
            get { return _blended; }
            set
            {
                _blended = value;
                FireBlended(_blended);
            }
        }

        private Color _color;
        [Description("Цвет заливки. "), Category("Отображение")]
        public Color PaintColor
        {
            get { return _color; }
            set
            {
                _color = value;
                FireColor(_color);
            }
        }

        private float _lineWidth;
        [Description("Толщина линий. "), Category("Отображение")]
        public float LineWidth
        {
            get { return _lineWidth; }
            set
            {
                _lineWidth = value;
                FireLineWidth(_lineWidth);
            }
        }

        public event MaxMinHandler XMaxHandler;
        private void FireXMax(float val)
        {
            if (XMaxHandler != null)
                XMaxHandler(val);
        }

        public event MaxMinHandler XMinHandler;
        private void FireXMin(float val)
        {
            if (XMinHandler != null)
                XMinHandler(val);
        }


        public event MaxMinHandler YMaxHandler;
        private void FireYMax(float val)
        {
            if (YMaxHandler != null)
                YMaxHandler(val);
        }

        public event MaxMinHandler YMinHandler;
        private void FireYMin(float val)
        {
            if (YMinHandler != null)
                YMinHandler(val);
        }

        public event MaxMinHandler ZMaxHandler;
        private void FireZMax(float val)
        {
            if (ZMaxHandler != null)
                ZMaxHandler(val);
        }

        public event MaxMinHandler ZMinHandler;
        private void FireZMin(float val)
        {
            if (ZMinHandler != null)
                ZMinHandler(val);
        }

        public event ShowAxisesHandler ShowAxisesHandler;
        private void FireShowAxises(bool val)
        {
            if (ShowAxisesHandler != null)
                ShowAxisesHandler(val);
        }

        public event ShowAxisesHandler AutoZHandler;
        private void FireAutoZ(bool val)
        {
            if (AutoZHandler != null)
               AutoZHandler(val);
        }

        public event ModeHandler ModeHandler;
        private void FireMode(DrawModeEnum val)
        {
            if (ModeHandler != null)
                ModeHandler(val);
        }

        public event BlendedHandler BlendedHandler;
        private void FireBlended(bool val)
        {
            if (BlendedHandler != null)
                BlendedHandler(val);
        }

        public event ColorHandler ColorHandler;
        private void FireColor(Color val)
        {
            if (ColorHandler != null)
                ColorHandler(val);
        }

        public event LineWidthHandler LineWidthHandler;
        private void FireLineWidth(float val)
        {
            if (LineWidthHandler != null)
                LineWidthHandler(val);
        }
    }
}
