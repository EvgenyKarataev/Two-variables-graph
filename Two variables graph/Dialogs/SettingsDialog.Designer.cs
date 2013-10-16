namespace TwoVariablesGraph
{
    partial class SettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxAppearence = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonFillMode = new System.Windows.Forms.RadioButton();
            this.radioButtonLineMode = new System.Windows.Forms.RadioButton();
            this.radioButtonDotMode = new System.Windows.Forms.RadioButton();
            this.textBoxLineWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialogColor = new System.Windows.Forms.ColorDialog();
            this.groupBoxAxes = new System.Windows.Forms.GroupBox();
            this.groupBoxZ = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoZ = new System.Windows.Forms.CheckBox();
            this.textBoxZMin = new System.Windows.Forms.TextBox();
            this.labelZMin = new System.Windows.Forms.Label();
            this.textBoxZMax = new System.Windows.Forms.TextBox();
            this.labelZMax = new System.Windows.Forms.Label();
            this.groupBoxY = new System.Windows.Forms.GroupBox();
            this.textBoxYMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxYMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxX = new System.Windows.Forms.GroupBox();
            this.textBoxXMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxXMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxAppearence.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxAxes.SuspendLayout();
            this.groupBoxZ.SuspendLayout();
            this.groupBoxY.SuspendLayout();
            this.groupBoxX.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAppearence
            // 
            this.groupBoxAppearence.Controls.Add(this.groupBox1);
            this.groupBoxAppearence.Controls.Add(this.textBoxLineWidth);
            this.groupBoxAppearence.Controls.Add(this.label3);
            this.groupBoxAppearence.Controls.Add(this.buttonColor);
            this.groupBoxAppearence.Controls.Add(this.label1);
            this.groupBoxAppearence.Location = new System.Drawing.Point(5, 121);
            this.groupBoxAppearence.Name = "groupBoxAppearence";
            this.groupBoxAppearence.Size = new System.Drawing.Size(348, 104);
            this.groupBoxAppearence.TabIndex = 0;
            this.groupBoxAppearence.TabStop = false;
            this.groupBoxAppearence.Text = "Отображение";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonFillMode);
            this.groupBox1.Controls.Add(this.radioButtonLineMode);
            this.groupBox1.Controls.Add(this.radioButtonDotMode);
            this.groupBox1.Location = new System.Drawing.Point(13, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 48);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим:";
            // 
            // radioButtonFillMode
            // 
            this.radioButtonFillMode.AutoSize = true;
            this.radioButtonFillMode.Location = new System.Drawing.Point(12, 19);
            this.radioButtonFillMode.Name = "radioButtonFillMode";
            this.radioButtonFillMode.Size = new System.Drawing.Size(102, 17);
            this.radioButtonFillMode.TabIndex = 7;
            this.radioButtonFillMode.TabStop = true;
            this.radioButtonFillMode.Text = "с заполнением";
            this.radioButtonFillMode.UseVisualStyleBackColor = true;
            // 
            // radioButtonLineMode
            // 
            this.radioButtonLineMode.AutoSize = true;
            this.radioButtonLineMode.Location = new System.Drawing.Point(200, 19);
            this.radioButtonLineMode.Name = "radioButtonLineMode";
            this.radioButtonLineMode.Size = new System.Drawing.Size(55, 17);
            this.radioButtonLineMode.TabIndex = 6;
            this.radioButtonLineMode.TabStop = true;
            this.radioButtonLineMode.Text = "линии";
            this.radioButtonLineMode.UseVisualStyleBackColor = true;
            // 
            // radioButtonDotMode
            // 
            this.radioButtonDotMode.AutoSize = true;
            this.radioButtonDotMode.Location = new System.Drawing.Point(132, 19);
            this.radioButtonDotMode.Name = "radioButtonDotMode";
            this.radioButtonDotMode.Size = new System.Drawing.Size(53, 17);
            this.radioButtonDotMode.TabIndex = 5;
            this.radioButtonDotMode.TabStop = true;
            this.radioButtonDotMode.Text = "точки";
            this.radioButtonDotMode.UseVisualStyleBackColor = true;
            // 
            // textBoxLineWidth
            // 
            this.textBoxLineWidth.Location = new System.Drawing.Point(262, 22);
            this.textBoxLineWidth.Name = "textBoxLineWidth";
            this.textBoxLineWidth.Size = new System.Drawing.Size(73, 20);
            this.textBoxLineWidth.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Толщина линий:";
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(96, 20);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(31, 23);
            this.buttonColor.TabIndex = 1;
            this.buttonColor.Text = " ";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Цвет заливки:";
            // 
            // groupBoxAxes
            // 
            this.groupBoxAxes.Controls.Add(this.groupBoxZ);
            this.groupBoxAxes.Controls.Add(this.groupBoxY);
            this.groupBoxAxes.Controls.Add(this.groupBoxX);
            this.groupBoxAxes.Location = new System.Drawing.Point(5, 2);
            this.groupBoxAxes.Name = "groupBoxAxes";
            this.groupBoxAxes.Size = new System.Drawing.Size(348, 113);
            this.groupBoxAxes.TabIndex = 1;
            this.groupBoxAxes.TabStop = false;
            this.groupBoxAxes.Text = "Оси координат";
            // 
            // groupBoxZ
            // 
            this.groupBoxZ.Controls.Add(this.checkBoxAutoZ);
            this.groupBoxZ.Controls.Add(this.textBoxZMin);
            this.groupBoxZ.Controls.Add(this.labelZMin);
            this.groupBoxZ.Controls.Add(this.textBoxZMax);
            this.groupBoxZ.Controls.Add(this.labelZMax);
            this.groupBoxZ.Location = new System.Drawing.Point(232, 19);
            this.groupBoxZ.Name = "groupBoxZ";
            this.groupBoxZ.Size = new System.Drawing.Size(107, 88);
            this.groupBoxZ.TabIndex = 3;
            this.groupBoxZ.TabStop = false;
            this.groupBoxZ.Text = "Z:";
            // 
            // checkBoxAutoZ
            // 
            this.checkBoxAutoZ.AutoSize = true;
            this.checkBoxAutoZ.Location = new System.Drawing.Point(9, 68);
            this.checkBoxAutoZ.Name = "checkBoxAutoZ";
            this.checkBoxAutoZ.Size = new System.Drawing.Size(47, 17);
            this.checkBoxAutoZ.TabIndex = 12;
            this.checkBoxAutoZ.Text = "auto";
            this.checkBoxAutoZ.UseVisualStyleBackColor = true;
            this.checkBoxAutoZ.CheckedChanged += new System.EventHandler(this.checkBoxAutoZ_CheckedChanged);
            // 
            // textBoxZMin
            // 
            this.textBoxZMin.Location = new System.Drawing.Point(45, 42);
            this.textBoxZMin.Name = "textBoxZMin";
            this.textBoxZMin.Size = new System.Drawing.Size(51, 20);
            this.textBoxZMin.TabIndex = 10;
            // 
            // labelZMin
            // 
            this.labelZMin.AutoSize = true;
            this.labelZMin.Location = new System.Drawing.Point(6, 45);
            this.labelZMin.Name = "labelZMin";
            this.labelZMin.Size = new System.Drawing.Size(27, 13);
            this.labelZMin.TabIndex = 9;
            this.labelZMin.Text = "Min:";
            // 
            // textBoxZMax
            // 
            this.textBoxZMax.Location = new System.Drawing.Point(45, 16);
            this.textBoxZMax.Name = "textBoxZMax";
            this.textBoxZMax.Size = new System.Drawing.Size(51, 20);
            this.textBoxZMax.TabIndex = 8;
            // 
            // labelZMax
            // 
            this.labelZMax.AutoSize = true;
            this.labelZMax.Location = new System.Drawing.Point(6, 19);
            this.labelZMax.Name = "labelZMax";
            this.labelZMax.Size = new System.Drawing.Size(30, 13);
            this.labelZMax.TabIndex = 7;
            this.labelZMax.Text = "Max:";
            // 
            // groupBoxY
            // 
            this.groupBoxY.Controls.Add(this.textBoxYMin);
            this.groupBoxY.Controls.Add(this.label6);
            this.groupBoxY.Controls.Add(this.textBoxYMax);
            this.groupBoxY.Controls.Add(this.label7);
            this.groupBoxY.Location = new System.Drawing.Point(119, 19);
            this.groupBoxY.Name = "groupBoxY";
            this.groupBoxY.Size = new System.Drawing.Size(107, 67);
            this.groupBoxY.TabIndex = 2;
            this.groupBoxY.TabStop = false;
            this.groupBoxY.Text = "Y:";
            // 
            // textBoxYMin
            // 
            this.textBoxYMin.Location = new System.Drawing.Point(45, 39);
            this.textBoxYMin.Name = "textBoxYMin";
            this.textBoxYMin.Size = new System.Drawing.Size(51, 20);
            this.textBoxYMin.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Min:";
            // 
            // textBoxYMax
            // 
            this.textBoxYMax.Location = new System.Drawing.Point(45, 13);
            this.textBoxYMax.Name = "textBoxYMax";
            this.textBoxYMax.Size = new System.Drawing.Size(51, 20);
            this.textBoxYMax.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Max:";
            // 
            // groupBoxX
            // 
            this.groupBoxX.Controls.Add(this.textBoxXMin);
            this.groupBoxX.Controls.Add(this.label5);
            this.groupBoxX.Controls.Add(this.textBoxXMax);
            this.groupBoxX.Controls.Add(this.label4);
            this.groupBoxX.Location = new System.Drawing.Point(9, 19);
            this.groupBoxX.Name = "groupBoxX";
            this.groupBoxX.Size = new System.Drawing.Size(107, 67);
            this.groupBoxX.TabIndex = 1;
            this.groupBoxX.TabStop = false;
            this.groupBoxX.Text = "Х:";
            // 
            // textBoxXMin
            // 
            this.textBoxXMin.Location = new System.Drawing.Point(45, 39);
            this.textBoxXMin.Name = "textBoxXMin";
            this.textBoxXMin.Size = new System.Drawing.Size(51, 20);
            this.textBoxXMin.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Min:";
            // 
            // textBoxXMax
            // 
            this.textBoxXMax.Location = new System.Drawing.Point(45, 13);
            this.textBoxXMax.Name = "textBoxXMax";
            this.textBoxXMax.Size = new System.Drawing.Size(51, 20);
            this.textBoxXMax.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max:";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(205, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(282, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 259);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxAxes);
            this.Controls.Add(this.groupBoxAppearence);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Shown += new System.EventHandler(this.SettingsDialog_Shown);
            this.groupBoxAppearence.ResumeLayout(false);
            this.groupBoxAppearence.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxAxes.ResumeLayout(false);
            this.groupBoxZ.ResumeLayout(false);
            this.groupBoxZ.PerformLayout();
            this.groupBoxY.ResumeLayout(false);
            this.groupBoxY.PerformLayout();
            this.groupBoxX.ResumeLayout(false);
            this.groupBoxX.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAppearence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialogColor;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.GroupBox groupBoxAxes;
        private System.Windows.Forms.GroupBox groupBoxZ;
        private System.Windows.Forms.TextBox textBoxZMin;
        private System.Windows.Forms.Label labelZMin;
        private System.Windows.Forms.TextBox textBoxZMax;
        private System.Windows.Forms.Label labelZMax;
        private System.Windows.Forms.GroupBox groupBoxY;
        private System.Windows.Forms.TextBox textBoxYMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxYMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBoxX;
        private System.Windows.Forms.TextBox textBoxXMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxXMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxAutoZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonFillMode;
        private System.Windows.Forms.RadioButton radioButtonLineMode;
        private System.Windows.Forms.RadioButton radioButtonDotMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxLineWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}