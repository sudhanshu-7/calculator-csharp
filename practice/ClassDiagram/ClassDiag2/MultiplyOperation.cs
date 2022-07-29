using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiag2
{
    public class MultiplyOperation : BinaryOperation    
    {
        public override double Evaluate(double[] operands)
        {
            if(ValidityCheck(operands) == false)
            {
                throw new ArgumentException();
            }
            return operands[0] * operands[1];
        }

    }
}