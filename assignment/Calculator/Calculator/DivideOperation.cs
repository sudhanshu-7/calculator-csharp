using System;

namespace Calculator
{
    public class DivideOperation : BinaryOperation
    {
        public DivideOperation() : base("/", OperatorAssociativity.LeftToRight, OperatorPrecedence.Higher)
        {

        }
        public DivideOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public DivideOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return operands[0] / operands[1];
        }
    }
}