using System;
using System.Collections.Generic;


namespace Calculator
{

    public static class ExpressionConverter
    {
        public static bool CheckForParanthesis(string query)
        {
            return (query == "(" || query == ")");
        }
        public static bool PrecedenceCheck(string operatorToBePlaced, string operatorOnStackTop)
        {
            if (operatorOnStackTop == "(") return true;
            if (operatorToBePlaced == "^")
            {
                if (operatorOnStackTop == "^" || operatorOnStackTop == "+" || operatorOnStackTop == "-" || operatorOnStackTop == "/" || operatorOnStackTop == "*") return true;
                return false;
            }
            if (operatorToBePlaced == "*" || operatorToBePlaced == "/")
            {
                if (operatorOnStackTop == "+" || operatorOnStackTop == "-") return true;
                return false;
            }
            if (operatorToBePlaced == "+" || operatorToBePlaced == "-") return false;

            return true;
        }
        public static List<string> ToPostfix(ExpressionEvaluator expressionEvaluatorObject , string expressionString)
        {
            List<string> tokens = Tokenize(expressionEvaluatorObject , expressionString);
            Stack<string> operatorStack = new Stack<string>();
            List<string> postFixExpression = new List<string>();
            foreach (string token in tokens)
            {
                if (token == "(")
                {
                    operatorStack.Push("(");
                }
                else if (token == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        postFixExpression.Add(operatorStack.Pop());
                    }
                    if (operatorStack.Count > 0) operatorStack.Pop();
                    else
                    {
                        throw new Exception(ResourceExceptions.InvalidArgumentError);
                    }
                }
                else if (expressionEvaluatorObject.CheckForOperator(token))
                {
                    if (operatorStack.Count == 0)
                    {
                        operatorStack.Push(token);
                        continue;
                    }
                    string tokenString = token;
                    while (operatorStack.Count > 0 && !PrecedenceCheck(tokenString, operatorStack.Peek()))
                    {
                        postFixExpression.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(tokenString);
                }
                else
                {
                    postFixExpression.Add(token);
                }
            }
            while (operatorStack.Count > 0)
            {
                if (operatorStack.Peek() == "(")
                {
                    throw new Exception(ResourceExceptions.InvalidArgumentError);
                }
                postFixExpression.Add(operatorStack.Pop());
            }
            return postFixExpression;
        }
        public static List<string> Tokenize(ExpressionEvaluator expressionEvaluatorObject, string expression)
        {
            List<string> expressionsArray = new List<string>(expression.Split(' '));
            List<string> tokens = new List<string>();
            HashSet<string> unaryOperatorsSymbols = new HashSet<string>(expressionEvaluatorObject.GetUnaryOperators()) ;
            for (int index = 0; index < expressionsArray.Count; index++)
            {
                string token = expressionsArray[index];
                if (unaryOperatorsSymbols.Contains(token))
                {
                    tokens.Add("(");
                    int count = 0;
                    int closingIndex = index + 1;
                    do
                    {
                        if (CheckForParanthesis(expressionsArray[closingIndex]))
                        {
                            count += (expressionsArray[closingIndex] == "(" ? 1 : -1);
                        }
                        closingIndex++;

                    } while (closingIndex < expressionsArray.Count && count != 0);

                    if (closingIndex == expressionsArray.Count)
                    {
                        expressionsArray.Add(")");
                    }
                    else
                    {
                        expressionsArray.Insert(closingIndex, ")");
                    }

                }
                tokens.Add(token);
            }
            return tokens;
        }

    }
}