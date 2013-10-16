using System.Drawing;

namespace TwoVariablesGraph
{
    public delegate void MaxMinHandler(float val);
    public delegate void ShowAxisesHandler(bool val);
    public delegate void ModeHandler(DrawModeEnum val);
    public delegate void BlendedHandler(bool val);
    public delegate void ColorHandler(Color val);
    public delegate void LineWidthHandler(float val);
}