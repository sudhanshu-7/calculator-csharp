using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiag2
{
    public class AddOperation : BinaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new Exception(); 
            return operands[0] + operands[1];
        }
    }
}