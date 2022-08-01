using System;
namespace Calculator
{
    public class ArcTangentOperation : UnaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false)
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Atan(operands[0]);
        }
    }
}