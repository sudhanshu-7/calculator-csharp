using System;
namespace Calculator
{
    public class AddOperation : BinaryOperation
    {
        public AddOperation(): base(){

        }
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false) throw new Exception(ResourceExceptions.InvalidArgumentError);
            return operands[0] + operands[1];
        }
    }
}