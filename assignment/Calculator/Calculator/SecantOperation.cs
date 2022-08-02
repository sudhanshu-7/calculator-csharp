﻿using System;

namespace Calculator
{
    public class SecantOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (!ValidityCheck(operands))
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return 1.0d/Math.Cos(operands[0]);
        }
    }
}