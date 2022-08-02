using System;

namespace Calculator
{
    public class TangentOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Tan(operands[0]);
        }
    }
}