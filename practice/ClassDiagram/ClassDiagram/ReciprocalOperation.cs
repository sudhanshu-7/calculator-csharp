using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDiagram
{
    public class ReciprocalOperation : UnaryOperation
    {
        public override double Evaluate(double operand)
        {
            return 1d / operand;
        }

    }
}