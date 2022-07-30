using System;

namespace Calculator
{
    public abstract class BinaryOperation : IOperation
    {
        public Boolean ValidityCheck(double[] operands)
        {
            if (operands == null || operands.Length < 2) return false;
            return true;
        }
        int _operandCount;
        public BinaryOperation()
        {
            _operandCount = 2;
        }
        public int OperandCount
        {
            get => _operandCount;
            set => _operandCount = 2;
        }
        public abstract double Evaluate(double[] operands);
    }
}