using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiagram
{
    public class SquareRootOperation : UnaryOperation
    {
        public override double Evaluate(double operand)
        {
            return Math.Sqrt(operand);
        }

    }
}