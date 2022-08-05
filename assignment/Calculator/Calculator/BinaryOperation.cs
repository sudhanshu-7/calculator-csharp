using System;

namespace Calculator
{
    public abstract class BinaryOperation : Operation
    {
        public BinaryOperation(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(symbol, 2, operatorAssociativity, operatorPrecedence)
        {
        }
        public override void SetOperator(OperatorData operatorDataObject,int operandCount = 2)
        {
            base.SetOperator(operatorDataObject, operandCount);
        }
        public override abstract double Evaluate(double[] operands);

    }
}