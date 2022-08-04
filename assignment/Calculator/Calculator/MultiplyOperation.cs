using System;

namespace Calculator
{
    public class MultiplyOperation : BinaryOperation
    {
        public MultiplyOperation() : base("*", OperatorAssociativity.LeftToRight, OperatorPrecedence.Higher)
        {

        }
        public MultiplyOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public MultiplyOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false)
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return operands[0] * operands[1];
        }

    }
}