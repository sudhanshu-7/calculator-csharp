using System;

namespace Calculator
{
    public class LogarithmicBase10Operation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Log10(operands[0]);
        }
    }
}