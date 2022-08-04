using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.UnitTests
{
    public class CubeOperation : UnaryOperation
    {
        public CubeOperation () : base("cube", OperatorAssociativity.LeftToRight, OperatorPrecedence.Unary)
        {

        }
        public override double Evaluate(double[] operands)
        {
            if(ValidityCheck(operands) == false)
            {
                throw new Exception("Invalid String Error");
            }
            return Math.Pow(operands[0], 3);
        }
    }
    [TestClass]
    public class EvaluatorTests
    {
        [TestMethod]
        public void Evaluate_ValidString_EvaluatedAnswer ()
        {
            CustomCalculator calculator = new CustomCalculator ();

            Assert.AreEqual(17, calculator.Evaluate("5+6*6/3^1") , 0.001 , "Answers does'nt Match");
            Assert.AreEqual(5, calculator.Evaluate("5+log(100 )-2"), 0.001, "Answers does'nt Match");
            Assert.AreEqual(6.73115428913, calculator.Evaluate("ln(4)*ln(5)+recip(2)*9-5/6*5/6^recip(1/9)"), 0.001, "Answers does'nt Match");
            Assert.AreEqual(0.86983311283, calculator.Evaluate("ln(2)^(recip(ln(5)*sqt(8/3)))"), 0.001, "Answers does'nt Match");
            Assert.AreEqual(-5.7016353395, calculator.Evaluate("2+ln(0.5^3/2)*recip(0.36)"), 0.001, "Answers does'nt Match");

        }
        [TestMethod]
        public void Evaluate_ValidStringWithCustomOperations_EvaluatedAnswer()
        {
            Operation cubeOperation = new CubeOperation ();
            CustomCalculator calculator = new CustomCalculator ();
            calculator.RegisterCustomOperation(cubeOperation.OperationSymbol, cubeOperation);

            Assert.AreEqual(8, calculator.Evaluate("cube(2)"), 0.001, "Answer's doesn't match");
            Assert.AreEqual(124, calculator.Evaluate("cube(log(100000))-1"), 0.001, "Answer's doesn't match");
        }
        [TestMethod]
        public void Evaluate_InvalidStrings_Exceptions()
        {
            CustomCalculator calculator = new CustomCalculator();
            Assert.ThrowsException<Exception>(() => { calculator.Evaluate("43+logarithmic(665-2.2.4)"); }, "Answer's doesn't match");
            Assert.ThrowsException<Exception>(() => { calculator.Evaluate("54-(30.32.3)"); }, "Answer's doesn't match");
            Assert.ThrowsException<Exception>(() => { calculator.Evaluate("5 .0 2 + 6*7"); }, "Answer's doesn't match");
            Assert.ThrowsException<Exception>(() => { calculator.Evaluate("log2(5 * 4 2)"); }, "Answer's doesn't match");
            Assert.ThrowsException<Exception>(() => { calculator.Evaluate("1+2. 6 4"); }, "Answer's doesn't match");

        }
    }
}
