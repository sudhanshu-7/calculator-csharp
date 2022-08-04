using System;

namespace Calculator
{
    public class CosineOperation : UnaryOperation
    {
        public CosineOperation() : base("cos", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public CosineOperation (OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public CosineOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
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