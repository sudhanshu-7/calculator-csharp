using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
namespace BetaOne
{
    internal class DollarOperation : BinaryOperation
    {
        public override double Evaluate(double[] operands)
        {
            if (ValidityCheck(operands) == false)
            {
                throw new Exception("InvalidArgumentException : Expected 2 arguments");
            }
            return (operands[0] * operands[1] + operands[0] / operands[1]);
        }
    }
    internal class CustomOperation : IOperation
    {
        public int OperandCount { get; }
        public CustomOperation()
        {
            OperandCount = 4;
        }
        public bool ValidityCheck(double[] operands)
        {
            return (operands.Length == OperandCount);
        }
        public double Evaluate(double [] operands)
        {
            if(!ValidityCheck(operands))
            {
                throw new Exception("InvalidArgumentException : Expected 4 arguments");
            }
            return operands[0] * operands[1] + operands[2] - operands[3];
        }
    }
    internal class Program
    {
        static void Main()
        {
            Object ans;
            try{
            ExpressionEvaluator ev = new ExpressionEvaluator();
            ev.RegisterCustomOperation("$" , new DollarOperation());
            ev.RegisterCustomOperation("#" , new CustomOperation());
            Console.WriteLine("Enter a Evaluation String: ");
            String s = Console.ReadLine();
            ans = ev.Evaluate(s);
            }catch(Exception exception){
                ans = ("Exception : " + exception.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Answer : " + ans);
            Console.ReadKey();
        }
    }
}
