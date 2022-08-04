using System;

namespace Calculator
{
    public class ArcSineOperation : UnaryOperation
    {
        public ArcSineOperation() : base("asin", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {
        }
        public ArcSineOperation(OperatorData operationData):this(operationData.Symbol , operationData.OperatorAssociativity, operationData.OperatorPrecedence)
        {

        }
        public ArcSineOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, operatorAssociativity, operatorPrecedence)
        {
        }

        public override bool ValidityCheck(double[] operands)
        {
            return base.ValidityCheck(operands) && Math.Abs(operands[0]) <= 1;
        }
        public override double Evaluate(double[] operands)
        {
            if(ValidityCheck(operands) == false)
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Asin(operands[0]);
        }
    }
}