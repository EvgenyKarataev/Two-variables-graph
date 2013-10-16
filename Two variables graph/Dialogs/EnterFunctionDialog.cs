using System;
using System.Windows.Forms;

namespace TwoVariablesGraph
{
    public partial class EnterFunctionDialog : Form
    {
        private string _function = "";
        private int _leftBracketsCount;
        private int _rightBracketsCount;

        public EnterFunctionDialog()
        {
            InitializeComponent();
        }

        private void bPlus_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("+");
            tbFunction.Focus();
        }

        private void bMinus_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("-");
            tbFunction.Focus();
        }

        private void bMult_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("*");
            tbFunction.Focus();
        }

        private void bDiv_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("/");
            tbFunction.Focus();
        }

        private void bPow_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("^");
            tbFunction.Focus();
        }

        private void bLeftBracket_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("(");
            tbFunction.Focus();
        }

        private void bRightBracket_Click(object sender, EventArgs e)
        {
            tbFunction.Paste(")");
            tbFunction.Focus();
        }

        private void tbFunction_TextChanged(object sender, EventArgs e)
        {
            if (tbFunction.Text.Length > _function.Length &&
                tbFunction.Text[tbFunction.Text.Length - 1] == '(')
                _leftBracketsCount++;
            else if (_function.Length > tbFunction.Text.Length &&
                _function[_function.Length - 1] == '(')
                _leftBracketsCount--;

            if (tbFunction.Text.Length > _function.Length &&
                tbFunction.Text[tbFunction.Text.Length - 1] == ')')
                _rightBracketsCount++;
            else if (_function.Length > tbFunction.Text.Length &&
                _function[_function.Length - 1] == ')')
                _rightBracketsCount--;

            _function = tbFunction.Text;
            //if (_rightBracketsCount - _leftBracketsCount < 0)
            {
            //    lbBrackets.Text = (_leftBracketsCount - _rightBracketsCount).ToString();
            //    lbBrackets.Visible = true;
            }
           // else
           //     lbBrackets.Visible = false;
        }

        private void bE_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("e");
            tbFunction.Focus();
        }

        private void bPi_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("pi");
            tbFunction.Focus();
        }

        private void bX_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("x");
            tbFunction.Focus();
        }

        private void bY_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("y");
            tbFunction.Focus();
        }

        private void bSin_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("sin");
            tbFunction.Focus();
        }

        private void bCos_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("cos");
            tbFunction.Focus();
        }

        private void tTg_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("tg");
            tbFunction.Focus();
        }

        private void bCtg_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("ctg");
            tbFunction.Focus();
        }

        private void bArcSin_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("arcsin");
            tbFunction.Focus();
        }

        private void bArcCos_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("arccos");
            tbFunction.Focus();
        }

        private void bArcTg_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("arctg");
            tbFunction.Focus();
        }

        private void bArcCtg_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("arcctg");
            tbFunction.Focus();
        }

        private void bLg_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("lg");
            tbFunction.Focus();
        }

        private void bLn_Click(object sender, EventArgs e)
        {
            tbFunction.Paste("ln");
            tbFunction.Focus();
        }

        private void bGo_Click(object sender, EventArgs e)
        {
            //Close();
        }

        public string GetFunction()
        {
            return tbFunction.Text;
        }

        public void SetFunction(string function)
        {
            tbFunction.Text = function;
        }

        public string GetPointsCount()
        {
            return tbPointsCount.Text;
        }
    }
}
