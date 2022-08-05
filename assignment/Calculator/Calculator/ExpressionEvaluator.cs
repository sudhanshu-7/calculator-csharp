using System;
using System.Collections.Generic;

namespace Calculator
{
    public interface IExpressionEvaluator
    {
        bool CheckForOperator(string operatorSymbol);
        void ClearCustomOperations();
        double Evaluate(string expressionString);
        void RegisterCustomOperation(string operationSymbol, Operation customOperation);
    }
}