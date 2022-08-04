using System;

namespace Calculator
{
    public class LogarithmicOperation : UnaryOperation
    {
        public LogarithmicOperation() : base("ln", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public LogarithmicOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public LogarithmicOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            return Math.Log(operands[0]);
        }
    }
}