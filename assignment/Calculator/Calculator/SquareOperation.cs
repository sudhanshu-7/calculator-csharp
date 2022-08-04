using System;

namespace Calculator
{
    public class SquareOperation : UnaryOperation
    {
        public SquareOperation() : base("sqr", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public SquareOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public SquareOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return operands[0] * operands[0];
        }
    }
}