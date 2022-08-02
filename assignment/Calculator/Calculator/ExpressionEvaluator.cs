using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculator
{
    public class ExpressionEvaluator
    {
        private Dictionary<string, IOperation> _operatorMapping;
        public ExpressionEvaluator()
        {
            _operatorMapping = GetBaseDictionary();
        }
        public bool CheckForOperator(string operatorSymbol)
        {
            return _operatorMapping.ContainsKey(operatorSymbol);
        }
        public List <string> GetNonArithmeticOperators()
        {
            List <string> result = new List <string>();
            foreach(string operatorSymbol in _operatorMapping.Keys)
            {
                if(!(_operatorMapping[operatorSymbol] is BinaryOperation))
                {
                    result.Add(operatorSymbol);
                }
            }
            return result;
        }
        private Dictionary<string, IOperation> GetBaseDictionary()
        {
            return new Dictionary<string, IOperation>
            {
                { "+", new AddOperation() },
                { "-", new SubtractOperation() },
                { "*", new MultiplyOperation() },
                { "/", new DivideOperation() },
                { "^", new ExponentiationOperation() },
                { "%" , new PercentageOperation() },
                { "sqrt", new SquareRootOperation() },
                { "ln", new LogarithmicOperation() },
                { "log", new LogarithmicBase10Operation() },
                { "log2", new LogarithmicBase2Operation() },
                { "recip", new ReciprocalOperation() },
                { "sin" , new SineOperation() },
                { "cos" , new CosineOperation() },
                { "tan" , new TangentOperation() },
                { "cosec" , new CosecantOperation()},
                { "sec" , new SecantOperation()},
                { "cot" , new CotangentOperation()},
                { "asin" , new ArcSineOperation()},
                { "acos" , new ArcCosineOperation()},
                { "atan" , new ArcTangentOperation()}
            };
        }
        public void ClearCustomOperations()
        {
            _operatorMapping = GetBaseDictionary();
        }

        public double Evaluate(string expressionString)
        {
            List<string> tokens = ExpressionConverter.ToPostfix(this,expressionString);
            
            //Postfix Evaluation Logic
            Stack <double> tokenStack = new Stack<double>();
            foreach(string token in tokens)
            {
                if(CheckForOperator(token))
                {
                    IOperation operationObject = _operatorMapping[token];
                    int operandCount = operationObject.OperandCount;
                    if(operandCount > tokenStack.Count)
                    {
                        throw new Exception(ResourceExceptions.InvalidArgumentError);
                    }
                    double[] operands = new double[operandCount];
                    for (int operandIndex = operandCount - 1; operandIndex >= 0; operandIndex--)
                    {
                        operands[operandIndex] = tokenStack.Pop();
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
        public void RegisterCustomOperation(string operationSymbol, IOperation customOperation)
        {
            if (CheckForOperator(operationSymbol))
            {
                throw new InvalidOperationException(ResourceExceptions.InvalidOperatorError);
            }
            _operatorMapping.Add(operationSymbol, customOperation);
        }
    }
}