using System;

namespace Calculator
{
    public class TangentOperation : UnaryOperation
    {
        public TangentOperation() : base("tan", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public TangentOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public TangentOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
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