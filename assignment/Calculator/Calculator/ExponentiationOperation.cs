using System;

namespace Calculator
{
    public class ExponentiationOperation : BinaryOperation
    {
        public ExponentiationOperation() : base()
        {

        }
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            double answer = 1.0d;
            for(int i = 0; i < operands[1]; i++)
            {
                answer *= operands[0];
            }
            return answer;
        }
    }
}