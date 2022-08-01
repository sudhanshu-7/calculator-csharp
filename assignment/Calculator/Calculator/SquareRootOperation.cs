using System;

namespace Calculator
{
    public class SquareRootOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return Math.Sqrt(operands[0]);
        }
    }
}