using System;

namespace Calculator
{
    public class SquareRootOperation : UnaryOperation
    {
        public SquareRootOperation() : base("sqt", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return Math.Sqrt(operands[0]);
        }
    }
}