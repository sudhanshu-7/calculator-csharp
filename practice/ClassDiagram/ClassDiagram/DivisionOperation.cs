using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiagram
{
    public class DivisionOperation : BinaryOperation
    {
        public override double Evaluate(double firstOperand, double secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}