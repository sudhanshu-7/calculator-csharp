using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiag2
{
    public interface IOperation
    {
        Boolean ValidityCheck(double[] operands);
        double Evaluate(double[] operands);
        int OperandCount { get; set; }
    }
}