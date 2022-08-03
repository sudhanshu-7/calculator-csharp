using System;

namespace Calculator
{
    public class LogarithmicBase2Operation : UnaryOperation
    {
        public LogarithmicBase2Operation() : base("log2", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public override double Evaluate(double[] operands)
        {
            if(ValidityCheck(operands) == false)
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Log(operands[0],2);
        }
    }
}