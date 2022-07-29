using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiag2
{
    public class SquareRootOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException();
            return Math.Sqrt(operands[0]);
        }
    }
}