using System;

namespace Calculator
{
    public class ArcTangentOperation : UnaryOperation
    {
        public ArcTangentOperation(): base("atan" , OperatorAssociativity.LeftToRight , OperatorPrecedence.Unary)
        {

        }
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