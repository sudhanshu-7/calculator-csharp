using System;

namespace Calculator
{
    public class AddOperation : BinaryOperation
    {
        public AddOperation() : base("+", OperatorAssociativity.LeftToRight, OperatorPrecedence.Lower)
        {
        }
        public AddOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public AddOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new Exception(ResourceExceptions.InvalidArgumentError);
            return operands[0] + operands[1];
        }
    }
}