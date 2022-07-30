using System;
namespace Calculator
{
    public interface IOperation
    {
        int OperandCount{get;set;}
        Boolean ValidityCheck(double[] operands);
        double Evaluate(double[] operands);
    }
}