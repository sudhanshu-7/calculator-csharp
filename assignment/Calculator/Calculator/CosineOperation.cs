using System;
using System.Collections.Generic;

namespace Calculator
{
    public class CosineOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Cos(operands[0]);
        }
    }
}