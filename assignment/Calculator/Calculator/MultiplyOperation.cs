﻿using System;

namespace Calculator
{
    public class MultiplyOperation : BinaryOperation
    {
        public MultiplyOperation(): base(){
        }
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false)
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return operands[0] * operands[1];
        }

    }
}