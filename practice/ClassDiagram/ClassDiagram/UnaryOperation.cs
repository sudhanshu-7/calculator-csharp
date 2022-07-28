using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiagram
{
    public abstract class UnaryOperation : Operations
    {
        protected UnaryOperation()
        {
            OperandCount = 1;
        }
        public abstract double Evaluate(double operand);
    }
}