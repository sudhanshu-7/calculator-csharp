using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise
{
    public partial class Form1 : Form
    {
        long _operandOne = 0, _operandTwo = 0;
        bool _isOperand = false, _lastOperand = false;
        private void shiftAndAdd(int add)
        {
            _lastOperand = false;
            _operandOne *= 10;
            _operandOne += add;
            textBox1.Text = _operandOne.ToString();
        }
        private long evaluate()
        {
            switch (currentOperand)
            {
                case Operands.Add: return _operandOne + _operandTwo;
                case Operands.Subtract: return _operandTwo - _operandOne;
                case Operands.Multiply: return _operandOne * _operandTwo;
                default: return 0;
            }
        }
        enum Operands { Add, Multiply ,Subtract};
        Operands currentOperand = Operands.Add;
        private void handleOperands(Operands o)
        {
            System.Diagnostics.Debug.WriteLine(_operandOne + " " + _operandTwo);
            if (_lastOperand == true)
            {
                System.Diagnostics.Debug.WriteLine(" I");

                currentOperand = o;
                return;
            }
            _lastOperand = true;
            if(_isOperand == true)
            {
                System.Diagnostics.Debug.WriteLine(" II");
                long ans = evaluate();
                textBox1.Text = ans.ToString();
                _operandTwo = ans;
                _operandOne = 0;
                currentOperand = o;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(" III");
                _operandTwo = _operandOne;
                _operandOne = 0;
                currentOperand = o;
                _isOperand = true;
            }

        }

        private void handleEvaluate()
        {
            if(_isOperand == true)
            {
                long ans = evaluate();
                textBox1.Text = ans.ToString();
                _operandTwo = ans;
                _operandOne = 0;
                _isOperand = false;
            }
            else
            {
                textBox1.Text = _operandOne.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            shiftAndAdd(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shiftAndAdd(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shiftAndAdd(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            shiftAndAdd(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shiftAndAdd(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            shiftAndAdd(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            shiftAndAdd(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            shiftAndAdd(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            shiftAndAdd(9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            handleOperands(Operands.Subtract);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            handleOperands(Operands.Multiply);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            handleEvaluate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            handleOperands(Operands.Add);
        }

        public Form1()
        {
            InitializeComponent();
        }


    }
}
