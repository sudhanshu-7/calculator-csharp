using System;

namespace Calculator
{
    public class CosecantOperation : UnaryOperation
    {
        public CosecantOperation() : base("cosec", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return 1.0d / Math.Sin(operands[0]);
        }
    }
}