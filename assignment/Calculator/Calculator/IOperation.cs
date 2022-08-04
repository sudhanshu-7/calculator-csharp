using System;

namespace Calculator
{
    public interface IOperation
    {
        double Evaluate(double[] operands);
    }
}