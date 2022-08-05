using System;
using System.Collections.Generic;

namespace Calculator
{
    public abstract class Operation : Token , IOperation
    {
        public Operation(string symbol , int operandCount, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence) : base(TokenType.Operator)
        {
            OperationSymbol = symbol;
            OperandCount = operandCount;
            OperatorAssociativity = operatorAssociativity;
            OperatorPrecedence = operatorPrecedence;
        }
        public string OperationSymbol { get; private set; }
        public int OperandCount { get; private set; }
        
        public OperatorAssociativity OperatorAssociativity { get; private set; }
        
        public OperatorPrecedence OperatorPrecedence { get; private set; }

        public void SetOperator(string symbol, int operandCount, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence)
        {
            OperationSymbol = symbol;
            OperandCount= operandCount;
            OperatorAssociativity= operatorAssociativity;
            OperatorPrecedence= operatorPrecedence;
        }
        public virtual void SetOperator(OperatorData operatorDataObject , int operandCount)
        {
            SetOperator(operatorDataObject.Symbol, operandCount, operatorDataObject.OperatorAssociativity, operatorDataObject.OperatorPrecedence);
        }
        public virtual bool ValidityCheck(double[] operands)
        {
            return operands.Length == OperandCount;
        }
        public abstract double Evaluate(double[] operands);
    }
}
