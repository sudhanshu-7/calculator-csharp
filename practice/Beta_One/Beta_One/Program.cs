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
        static void PrintMemory(CustomCalculator mem)
        {
            double[] items = mem.Memory;
            foreach (double item in items)
            {
                Console.Write(item + " -> ");
            }
            Console.WriteLine(" X ");
        }
        static void Main()
        {
            Object ans;
            CustomCalculator calculator = new CustomCalculator();
            try
            {
                calculator.RegisterCustomOperation("$", new DollarOperation());
                calculator.RegisterCustomOperation("#", new CustomOperation());
                Console.WriteLine("Enter a Evaluation String: ");
                String s = Console.ReadLine();
                ans = calculator.Evaluate(s);
            }
            catch (Exception exception)
            {
                ans = ("Exception : " + exception.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Answer : " + ans);
            calculator.MemoryModification(-5.64);
            calculator.MemoryModification(6);
            calculator.MemorySave(45);
            calculator.MemorySave(56);
            calculator.MemoryModification(-50);
            //PrintMemory(calculator);
            Console.ReadKey();
            //string inputString  = Console.ReadLine();
            //List <string> tokens = ExpressionConverter.RegexTokenize(new CustomCalculator(), inputString);
            //foreach(string token in tokens)
            //{
            //    Console.WriteLine($"Token : {token} Length : {token.Length}");
            //}
            //Console.ReadKey();
        }
    }
}
