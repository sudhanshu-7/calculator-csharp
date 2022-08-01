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

            operatorMapping = new Dictionary<string, IOperation>
            {
                { "+", new AddOperation() },
                { "-", new SubtractOperation() },
                { "*", new MultiplyOperation() },
                { "/", new DivideOperation() },
                { "^", new ExponentiationOperation() },
                { "sqrt", new SquareRootOperation() },
                { "log", new LogarithmicOperation() },
                { "recip", new ReciprocalOperation() }
            };

            Dictionary<String, IOperation>.KeyCollection operatorKeys = operatorMapping.Keys;
            List<String> operatorKeysList = new List<String>();
            foreach (String operatorKey in operatorKeys)
            {
                operatorKeysList.Add(operatorKey);
            }
            converter.AddOperator(operatorKeysList);
        }
        public void ClearCustomOperations()
        {
            operatorMapping = new Dictionary<string, IOperation>
            {
                { "+", new AddOperation() },
                { "-", new SubtractOperation() },
                { "*", new MultiplyOperation() },
                { "/", new DivideOperation() },
                { "^", new ExponentiationOperation() },
                { "sqrt", new SquareRootOperation() },
                { "log", new LogarithmicOperation() },
                { "recip", new ReciprocalOperation() }
            };
            converter = new ExpressionConverter();
        }

        public double Evaluate(string expressionString)
        {
            List<String> tokens = converter.ToPostfix(converter.Tokenizer(expressionString));
            Stack <Double> tokenStack = new Stack<Double>();
            foreach(String token in tokens)
            {
                if(converter.CheckForOperator(token))
                {
                    IOperation operationObject = operatorMapping[token];
                    int operandCount = operationObject.OperandCount;
                    if(operandCount > tokenStack.Count)
                    {
                        throw new Exception(ResourceExceptions.InvalidArgumentError);
                    }
                    double[] operands = new double[operandCount];
                    for (int i = operandCount - 1; i >= 0; i--)
                    {
                        operands[i] = tokenStack.Pop();
                    }
                    tokenStack.Push(operationObject.Evaluate(operands));
                }
                else
                {
                    tokenStack.Push(Double.Parse(token));
                }
            }
            if(tokenStack.Count > 1)
            {
                throw new Exception(ResourceExceptions.InvalidStringError);
            }
            return tokenStack.Pop();
        }
        public void RegisterCustomOperations(string operationSymbol, IOperation customOperation)
        {
            if (operatorMapping.ContainsKey(operationSymbol))
            {
                throw new InvalidOperationException(ResourceExceptions.InvalidOperatorError);
            }
            operatorMapping.Add(operationSymbol, customOperation);
            converter.AddOperator(operationSymbol);
        }
    }
}