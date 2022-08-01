using System;

namespace Calculator
{
    public abstract class BinaryOperation : IOperation
    {
        public int OperandCount { get; }
        public BinaryOperation()
        {
            OperandCount = 2;
        }
        public virtual bool ValidityCheck(double[] operands)
        {
            if (operands == null || operands.Length < 2) return false;
            return true;
        }

        public abstract double Evaluate(double[] operands);
    }
}