using System;
using System.Collections.Generic;

namespace Calculator
{
    public abstract class Operation : Token , IOperation
    {
        public Operation() : base(TokenType.Operator)
        {
        }
        public Operation(string symbol , int operandCount, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : this()
        {
            OperationSymbol = symbol;
            OperandCount = operandCount;
            OperatorAssociativity = operatorAssociativity;
            OperatorPrecedence = operatorPrecedence;
        }
        public string OperationSymbol { get; }
        public int OperandCount { get; }
        
        public OperatorAssociativity OperatorAssociativity { get; }
        
        public OperatorPrecedence OperatorPrecedence { get; }
        public virtual bool ValidityCheck(double[] operands)
        {
            return operands.Length == OperandCount;
        }
        public abstract double Evaluate(double[] operands);
    }
}
