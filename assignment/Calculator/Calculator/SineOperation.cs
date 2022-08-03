using System;

namespace Calculator
{
    public class SineOperation : UnaryOperation
    {
        public SineOperation() : base("sin", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Sign(operands[0]);
        }
    }
}