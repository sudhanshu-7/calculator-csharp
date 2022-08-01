using System;
namespace Calculator
{
    public class ArcCosineOperation : UnaryOperation
    {
        public override bool ValidityCheck(double[] operands)
        {
            return base.ValidityCheck(operands) && Math.Abs(operands[0]) <= 1;
        }
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false)
            {
                throw new ArgumentException(ResourceExceptions.InvalidArgumentError);
            }
            return Math.Acos(operands[0]);
        }
    }
}