using System;

namespace Calculator
{
    public class ExponentiationOperation : BinaryOperation
    {
        public ExponentiationOperation() : base("^", OperatorAssociativity.RightToLeft, OperatorPrecedence.Highest)
        {

        }
        public ExponentiationOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public ExponentiationOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return Math.Pow(operands[0], operands[1]);
        }
    }
}