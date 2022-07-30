using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculator
{
    public class ExpressionEvaluator
    {
        private Dictionary<string, IOperation> operatorMapping;
        private ExpressionConverter converter;
        public ExpressionEvaluator()
        {
            converter = new ExpressionConverter();
            operatorMapping = new Dictionary<string, IOperation>();
            operatorMapping.Add("+", new AddOperation());
            operatorMapping.Add("-", new SubtractOperation());
            operatorMapping.Add("*", new MultiplyOperation());
            operatorMapping.Add("/", new DivideOperation());
            operatorMapping.Add("^", new ExponentiationOperation());
        }
        public double Evaluate(string expressionString)
        {
            List <Object> tokens = converter.Tokenizer(expressionString);
            tokens = converter.ToPostfix(tokens);
            return 1.0D;
        }
        public void RegisterCustomOperations(string operationSymbol , IOperation customOperation)
        {
            if(operatorMapping.ContainsKey(operationSymbol))
            {
                throw new InvalidOperationException(ResourceExceptions.InvalidOperatorError);
            }
            operatorMapping.Add(operationSymbol, customOperation);
            converter.AddOperator(operationSymbol);
        }
    }
}