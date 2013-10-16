using System;
using System.Drawing;
using System.Windows.Forms;

namespace TwoVariablesGraph
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        public float XMax { get; set; }
        public float XMin { get; set; }

        public float YMax { get; set; }
        public float YMin { get; set; }

        public float ZMax { get; set; }
        public float ZMin { get; set; }
        public bool AutoZ { get; set; }

        public float LineWidth { get; set; }
        public DrawModeEnum DrawMode { get; set; }
        public Color Color { get; set; }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialogColor.ShowDialog();
            buttonColor.BackColor = colorDialogColor.Color;
        }

        private void SettingsDialog_Shown(object sender, EventArgs e)
        {
            textBoxXMax.Text = XMax.ToString();
            textBoxXMin.Text = XMin.ToString();

            textBoxYMax.Text = YMax.ToString();
            textBoxYMin.Text = YMin.ToString();

            textBoxZMax.Text = ZMax.ToString();
            textBoxZMin.Text = ZMin.ToString();

            checkBoxAutoZ.Checked = AutoZ;

            buttonColor.BackColor = Color;

            switch (DrawMode)
            {
                case DrawModeEnum.GL_POINT:
                    radioButtonDotMode.Checked = true;
                    break;
                case DrawModeEnum.GL_LINE:
                    radioButtonLineMode.Checked = true;
                    break;
                case DrawModeEnum.GL_FILL:
                    radioButtonFillMode.Checked = true;
                    break;
            }

            textBoxLineWidth.Text = LineWidth.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XMax = (float)Convert.ToDouble(textBoxXMax.Text);
            XMin = (float)Convert.ToDouble(textBoxXMin.Text);

            YMax = (float)Convert.ToDouble(textBoxYMax.Text);
            YMin = (float)Convert.ToDouble(textBoxYMin.Text);

            ZMax = (float)Convert.ToDouble(textBoxZMax.Text);
            ZMin = (float)Convert.ToDouble(textBoxZMin.Text);

            AutoZ = checkBoxAutoZ.Checked;
            Color = buttonColor.BackColor;

            if (radioButtonDotMode.Checked)
                DrawMode = DrawModeEnum.GL_POINT;
            else if (radioButtonLineMode.Checked)
                DrawMode = DrawModeEnum.GL_LINE;
            else
                DrawMode = DrawModeEnum.GL_FILL;

            LineWidth = (float)Convert.ToDouble(textBoxLineWidth.Text);
        }

        private void checkBoxAutoZ_CheckedChanged(object sender, EventArgs e)
        {
            labelZMax.Enabled = labelZMin.Enabled = textBoxZMax.Enabled = textBoxZMin.Enabled = !checkBoxAutoZ.Checked;
        }
    }
}
