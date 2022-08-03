using System;

namespace Calculator
{
    public class TangentOperation : UnaryOperation
    {
        public TangentOperation() : base("tan", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
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