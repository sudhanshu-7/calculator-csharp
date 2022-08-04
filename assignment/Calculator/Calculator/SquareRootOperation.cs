using System;

namespace Calculator
{
    public class SquareRootOperation : UnaryOperation
    {
        public SquareRootOperation() : base("sqt", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public SquareRootOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public SquareRootOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return Math.Sqrt(operands[0]);
        }
    }
}