using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorFrontEnd
{
    enum ButtonType
    {
        OperatorButton,
        NumpadButton
    }
    public partial class Form1 : Form
    {
        private UIButton[] CalculatorButtons;
        private System.Windows.Forms.TextBox CalculatorText;
        public Form1()
        {
            InitializeComponent();

            this.CalculatorText.BorderStyle = BorderStyle.None;
            this.CalculatorText.Dock = DockStyle.Fill;
            this.CalculatorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalculatorText.TextAlign = HorizontalAlignment.Right;

            this.ResultsLabel.AutoSize = false;
            this.ResultsLabel.BorderStyle = BorderStyle.None;
            this.ResultsLabel.Dock = DockStyle.Fill;
            this.ResultsLabel.Font = this.CalculatorText.Font;
            this.ResultsLabel.TextAlign = ContentAlignment.MiddleRight;


            CalculatorButtons[0] = new UIButton("Percentage","%", 0, 0, ButtonType.OperatorButton);
            CalculatorButtons[1] = new UIButton("Clear Entry", "CE", 0, 1, ButtonType.OperatorButton);
            CalculatorButtons[2] = new UIButton("Clear", "C", 0, 2, ButtonType.OperatorButton);
            CalculatorButtons[3] = new UIButton("Backspace", "<-", 0, 3, ButtonType.OperatorButton);
            CalculatorButtons[4] = new UIButton("Reciprocal", "1/x", 1, 0, ButtonType.OperatorButton);
            CalculatorButtons[5] = new UIButton("Square", "x^2", 1, 1, ButtonType.OperatorButton);
            CalculatorButtons[6] = new UIButton("Square Root", "√x", 1, 2, ButtonType.OperatorButton);
            CalculatorButtons[7] = new UIButton("Divide", "÷", 1, 3, ButtonType.OperatorButton);
            CalculatorButtons[8] = new UIButton("Seven", "7", 2, 0, ButtonType.NumpadButton);
            CalculatorButtons[9] = new UIButton("Eight", "8", 2, 1, ButtonType.NumpadButton);
            CalculatorButtons[10] = new UIButton("Nine", "9", 2, 2, ButtonType.NumpadButton);
            CalculatorButtons[11] = new UIButton("Multiply", "*", 2, 3, ButtonType.OperatorButton);
            CalculatorButtons[12] = new UIButton("Four", "4", 3, 0, ButtonType.NumpadButton);
            CalculatorButtons[13] = new UIButton("Five", "5", 3, 1, ButtonType.NumpadButton);
            CalculatorButtons[14] = new UIButton("Six", "6", 3, 2, ButtonType.NumpadButton);
            CalculatorButtons[15] = new UIButton("Subtract", "-", 3, 3, ButtonType.OperatorButton);
            CalculatorButtons[16] = new UIButton("One", "1", 4, 0, ButtonType.NumpadButton);
            CalculatorButtons[17] = new UIButton("Two", "2", 4, 1, ButtonType.NumpadButton);
            CalculatorButtons[18] = new UIButton("Three", "3", 4, 2, ButtonType.NumpadButton);
            CalculatorButtons[19] = new UIButton("Addition", "+", 4, 3, ButtonType.OperatorButton);
            CalculatorButtons[20] = new UIButton("Negate", "+/-", 5, 0, ButtonType.NumpadButton);
            CalculatorButtons[21] = new UIButton("Zero", "0", 5, 1, ButtonType.NumpadButton);
            CalculatorButtons[22] = new UIButton("Decimal", ".", 5, 2, ButtonType.NumpadButton);
            CalculatorButtons[23] = new UIButton("Equate", "=", 5, 3, ButtonType.OperatorButton);
            
            this.buttonsTableLayout.Size = new System.Drawing.Size(534, 322);
            this.buttonsTableLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsTableLayout.Location = new System.Drawing.Point(0, 166);
            this.buttonsTableLayout.RowCount = 6;
            this.buttonsTableLayout.ColumnCount = 4;
            for(int column = 0; column < this.buttonsTableLayout.ColumnCount; column++)
            {
                this.buttonsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }
            for(int row = 0; row < this.buttonsTableLayout.RowCount; row++)
            {
                this.buttonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            }
            this.displayLayout.AutoSize = true;
            this.displayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayLayout.RowCount = 2;
            this.displayLayout.ColumnCount = 1;

            this.displayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            for(int row = 0; row < this.buttonsTableLayout.RowCount; ++row)
            {
                this.buttonsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.CalculatorText;
            for(int index = 0; index < CalculatorButtons.Length; index++)
            {
                this.buttonsTableLayout.Controls.Add(CalculatorButtons[index],CalculatorButtons[index].Column,CalculatorButtons[index].Row);
            }
        }
    }
}
