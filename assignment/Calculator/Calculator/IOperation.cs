using System;
namespace Calculator
{
    public interface IOperation
    {
        int OperandCount{get;}
        bool ValidityCheck(double[] operands);
        double Evaluate(double[] operands);
    }
}