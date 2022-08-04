using System;

namespace Calculator
{
    public class SineOperation : UnaryOperation
    {
        public SineOperation() : base("sin", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public SineOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public SineOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
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