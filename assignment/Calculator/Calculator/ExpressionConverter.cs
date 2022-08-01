using System;
using System.Collections.Generic;


namespace Calculator
{

    public class ExpressionConverter
    {
        private HashSet<string> _operatorList;
        public ExpressionConverter()
        {
            _operatorList = new HashSet<string>();
        }
        public void AddOperator(string operatorItem)
        {
            _operatorList.Add(operatorItem);
        }
        public void AddOperator(List <String> operatorList)
        {
            _operatorList = new HashSet<string> (operatorList);
        }
        public Boolean CheckForOperator(string operatorItem)
        {
            return _operatorList.Contains(operatorItem);
        }
        public Boolean CheckForParanthesis(string query)
        {
            return (query == "(" || query == ")");
        }
        public Boolean PrecedenceCheck(string operatorA, string operatorB)
        {
            if (operatorB == "(") return true;
            if (operatorA == "^")
            {
                if (operatorB == "^" || operatorB == "+" || operatorB == "-" || operatorB == "/" || operatorB == "*") return true;
                return false;
            }
            if (operatorA == "*" || operatorA == "/")
            {
                if (operatorB == "+" || operatorB == "-") return true;
                return false;
            }
            if (operatorA == "+" || operatorA == "-") return false;

            return true;
        }
        public List<String> ToPostfix(List<String> tokens)
        {
            Stack<String> operatorStack = new Stack<String>();
            List<String> postFixExpression = new List<String>();
            foreach (String token in tokens)
            {
                if (token.ToString() == "(")
                {
                    operatorStack.Push("(");
                }
                else if (token.ToString() == ")")
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
                else if (CheckForOperator(token))
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
        public List<String> Tokenizer(string expression)
        {
            List<String> expressionsArray = new List<String>(expression.Split(' '));
            List<String> tokens = new List<String>();
            HashSet<String> unaryOperatorsSymbols = new HashSet<string>() { "sqrt", "log", "recip" };
            for (int index = 0; index < expressionsArray.Count; index++)
            {
                String token = expressionsArray[index];
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