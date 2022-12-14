using System;

namespace Calculator
{
    public class PercentageOperation : UnaryOperation
    {
        public PercentageOperation() : base("%", OperatorAssociativity.LeftToRight, OperatorPrecedence.Higher)
        {

        }
        public PercentageOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public PercentageOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return operands[0]/(100.0D);
        }
    }
}