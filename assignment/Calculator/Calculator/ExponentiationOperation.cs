using System;

namespace Calculator
{
    public class ExponentiationOperation : BinaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return Math.Pow(operands[0], operands[1]);
        }
    }
}