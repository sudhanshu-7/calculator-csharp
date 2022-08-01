using System;

namespace Calculator
{
    public abstract class UnaryOperation : IOperation
    {
        public int OperandCount { get; }
        public UnaryOperation()
        {
            OperandCount = 1;
        }

        public virtual bool ValidityCheck(double[] operands)
        {
            if (operands == null || operands.Length == 0) return false;
            return true;
        }
        public abstract double Evaluate(double[] operands);

    }
}