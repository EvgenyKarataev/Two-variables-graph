namespace TwoVariablesGraph
{
    partial class fmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemEnterFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hsbHorPosition = new System.Windows.Forms.HScrollBar();
            this.vsbVertPosition = new System.Windows.Forms.VScrollBar();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.epErorrDotsCount = new System.Windows.Forms.ErrorProvider(this.components);
            this.ucGLPanel1 = new ucGLPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epErorrDotsCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemEnterFunction,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemEnterFunction
            // 
            this.ToolStripMenuItemEnterFunction.Name = "ToolStripMenuItemEnterFunction";
            this.ToolStripMenuItemEnterFunction.Size = new System.Drawing.Size(109, 20);
            this.ToolStripMenuItemEnterFunction.Text = "Задание функции";
            this.ToolStripMenuItemEnterFunction.Click += new System.EventHandler(this.ToolStripMenuItemEnterFunction_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // hsbHorPosition
            // 
            this.hsbHorPosition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hsbHorPosition.Location = new System.Drawing.Point(0, 444);
            this.hsbHorPosition.Name = "hsbHorPosition";
            this.hsbHorPosition.Size = new System.Drawing.Size(903, 13);
            this.hsbHorPosition.TabIndex = 46;
            this.hsbHorPosition.Value = 45;
            this.hsbHorPosition.ValueChanged += new System.EventHandler(this.hsbHorPosition_ValueChanged);
            // 
            // vsbVertPosition
            // 
            this.vsbVertPosition.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsbVertPosition.Location = new System.Drawing.Point(891, 24);
            this.vsbVertPosition.Name = "vsbVertPosition";
            this.vsbVertPosition.Size = new System.Drawing.Size(12, 420);
            this.vsbVertPosition.TabIndex = 47;
            this.vsbVertPosition.Value = 45;
            this.vsbVertPosition.ValueChanged += new System.EventHandler(this.vsbVertPosition_ValueChanged);
            // 
            // epErorrDotsCount
            // 
            this.epErorrDotsCount.ContainerControl = this;
            // 
            // ucGLPanel1
            // 
            this.ucGLPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucGLPanel1.AngleX = 30F;
            this.ucGLPanel1.AngleY = -35F;
            this.ucGLPanel1.AngleZ = 0F;
            this.ucGLPanel1.AutoZ = true;
            this.ucGLPanel1.Blended = false;
            this.ucGLPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucGLPanel1.fTransX = 0F;
            this.ucGLPanel1.fTransY = 0F;
            this.ucGLPanel1.LineWidth = 1F;
            this.ucGLPanel1.Location = new System.Drawing.Point(0, 27);
            this.ucGLPanel1.Mode = DrawModeEnum.GL_FILL;
            this.ucGLPanel1.Name = "ucGLPanel1";
            this.ucGLPanel1.PaintColor = System.Drawing.Color.Blue;
            this.ucGLPanel1.ShowAxes = true;
            this.ucGLPanel1.Size = new System.Drawing.Size(891, 414);
            this.ucGLPanel1.TabIndex = 4;
            this.ucGLPanel1.XMax = 1F;
            this.ucGLPanel1.XMin = -1F;
            this.ucGLPanel1.YMax = 1F;
            this.ucGLPanel1.YMin = -1F;
            this.ucGLPanel1.ZMax = 1F;
            this.ucGLPanel1.ZMin = -1F;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 457);
            this.Controls.Add(this.vsbVertPosition);
            this.Controls.Add(this.hsbHorPosition);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ucGLPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fmMain";
            this.Text = "График функции двух переменных на основе триангуляции";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epErorrDotsCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucGLPanel ucGLPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.HScrollBar hsbHorPosition;
        private System.Windows.Forms.VScrollBar vsbVertPosition;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.ErrorProvider epErorrDotsCount;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEnterFunction;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    }
}

