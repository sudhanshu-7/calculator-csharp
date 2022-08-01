using System;

namespace Calculator
{
    public class ReciprocalOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return 1.0D / operands[0];
        }
    }
}