using System;

namespace Calculator
{
    public class LogarithmicOperation : UnaryOperation
    {
        public LogarithmicOperation() : base("ln", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return Math.Log(operands[0]);
        }
    }
}