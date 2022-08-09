using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;
namespace CalculatorUI
{
    public partial class Calculator : Form
    {
        string currentText;
        string previousText;
        CustomCalculator calculator;
        public Calculator()
        {
            InitializeComponent();
            currentText = "0";
            previousText = "0";
            calculator = new CustomCalculator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NumpadButton_Click(object sender, EventArgs e)
        {
            double value;
            try
            {
                value = Double.Parse(currentText);
            }catch (Exception)
            {

            }
        }
        private void FocusOnTextBox(object sender , EventArgs e)
        {
            inputBox.Focus();
        }
        private void Calculator_Shown(object sender, EventArgs e)
        {
            inputBox.Focus();
        }

        private void NumpadButton9_Click(object sender, EventArgs e)
        {
            inputBox.Focus();
            inputBox.Text += ((Button)sender).Text;
            inputBox.Select(inputBox.Text.Length, 0);
        }

        private void NumpadButton2_Click(object sender, EventArgs e)
        {

        }
        private void NormalClick(object sender , EventArgs e)
        {
            Console.WriteLine("Inside Normal Click");
        }
        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Inside Mouse Click");
        }
    }
}
