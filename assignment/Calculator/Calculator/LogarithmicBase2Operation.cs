using System;

namespace Calculator
{
    public class LogarithmicBase2Operation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if(ValidityCheck(operands) == false)
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Log(operands[0],2);
        }
    }
}