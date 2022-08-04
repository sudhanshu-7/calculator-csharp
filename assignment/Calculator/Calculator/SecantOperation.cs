using System;

namespace Calculator
{
    public class SecantOperation : UnaryOperation
    {
        public SecantOperation() : base("sec", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public SecantOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public SecantOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return 1.0d/Math.Cos(operands[0]);
        }
    }
}