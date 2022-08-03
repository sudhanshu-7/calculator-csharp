using System;

namespace Calculator
{
    public class CosineOperation : UnaryOperation
    {
        public CosineOperation() : base("cos", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Cos(operands[0]);
        }
    }
}