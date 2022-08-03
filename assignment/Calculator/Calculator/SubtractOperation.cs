using System;

namespace Calculator
{
    public class SubtractOperation : BinaryOperation
    {
        public SubtractOperation() : base("-", OperatorAssociativity.LeftToRight, OperatorPrecedence.Lower)
        {

        }
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return operands[0] - operands[1];
        }
    }
}