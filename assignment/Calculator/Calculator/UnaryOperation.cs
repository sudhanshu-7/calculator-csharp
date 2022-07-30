using System;

namespace Calculator
{
    public abstract class UnaryOperation : IOperation
    {
        public Boolean ValidityCheck(double[] operands)
        {
            if (operands == null || operands.Length == 0) return false;
            return true;
        }
        int _operandCount;
        public UnaryOperation()
        {
            _operandCount = 1;
        }
        public int OperandCount
        {
            get => _operandCount;
            set => _operandCount = 1;
        }
        public abstract double Evaluate(double[] operands);

    }
}