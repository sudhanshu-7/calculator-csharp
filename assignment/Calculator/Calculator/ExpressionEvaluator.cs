using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculator
{
    public interface IExpressionEvaluator
    {
        bool CheckForOperator(string operatorSymbol);
        List<string> GetNonArithmeticOperators();
        void ClearCustomOperations();
        double Evaluate(string expressionString);
        void RegisterCustomOperation(string operationSymbol, IOperation customOperation);
    }
}