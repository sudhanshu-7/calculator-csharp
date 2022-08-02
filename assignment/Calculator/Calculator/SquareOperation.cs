using System;

namespace Calculator
{
    public class SquareOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return operands[0] * operands[0];
        }
    }
}