using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiagram
{
    public abstract class BinaryOperation : Operations
    {
        protected BinaryOperation()
        {
            OperandCount = 2;
        }
        public abstract double Evaluate(double firstOperand, double secondOperand);
    }
}