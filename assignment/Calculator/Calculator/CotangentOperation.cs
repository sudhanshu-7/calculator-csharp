using System;

namespace Calculator
{
    public class CotangentOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return 1.0d / Math.Tan(operands[0]);
        }
    }
}