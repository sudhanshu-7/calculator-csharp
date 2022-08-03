using System;

namespace Calculator
{
    public abstract class UnaryOperation : Operation
    {
        public UnaryOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, 1 ,  operatorAssociativity, operatorPrecedence)
        {
        }
        public override abstract double Evaluate(double[] operands);

    }
}