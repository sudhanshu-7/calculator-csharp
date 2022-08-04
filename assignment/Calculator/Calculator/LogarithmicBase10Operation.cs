using System;

namespace Calculator
{
    public class LogarithmicBase10Operation : UnaryOperation
    {
        public LogarithmicBase10Operation() : base("log", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public LogarithmicBase10Operation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public LogarithmicBase10Operation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Log10(operands[0]);
        }
    }
}