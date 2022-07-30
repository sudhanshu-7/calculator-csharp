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
        public List<Object> ToPostfix(List<Object> tokens)
        {
            Stack<String> operatorStack = new Stack<String>();
            List<Object> postFixExpression = new List<Object>();
            foreach (Object token in tokens)
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
                else if (CheckForOperator(token.ToString()))
                {
                    if (operatorStack.Count == 0)
                    {
                        operatorStack.Push(token.ToString());
                        continue;
                    }
                    string tokenString = token.ToString();
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
                if(operatorStack.Peek() == "(")
                {
                    throw new Exception(ResourceExceptions.InvalidArgumentError);
                }
                postFixExpression.Add(operatorStack.Pop());
            }
            return postFixExpression;
        }
        private string CleanExpressionString(string expressionString)
        {
            if (expressionString == null || expressionString.Length == 0) return expressionString;
            string cleanedString = "";
            //Checking for Multiple Operators
            for (int i = 1; i < expressionString.Length; i++)
            {
                if (CheckForOperator(expressionString[i].ToString()) && CheckForOperator(expressionString[i - 1].ToString()))
                {
                    throw new Exception(ResourceExceptions.InvalidStringError);
                }
            }
            //Removing WhiteSpaces
            for (int i = 0; i < expressionString.Length; i++)
            {
                if (expressionString[i] == ' ') continue;
                cleanedString += expressionString[i];
            }
            if (cleanedString.Length > 0 && (CheckForOperator(cleanedString[0].ToString()) || CheckForOperator(cleanedString[cleanedString.Length - 1].ToString())))
            {
                throw new Exception(ResourceExceptions.InvalidStringError);
            }
            return cleanedString;
        }
        public List<Object> Tokenizer(string expression)
        {
            if (expression.Length == 0) throw new ArgumentException(ResourceExceptions.EmptyStringError);
            expression = CleanExpressionString(expression);
            List<Object> result = new List<Object>();
            int stringPointer = 0, sizeOfExpression = expression.Length;

            while (stringPointer < sizeOfExpression)
            {
                //Console.WriteLine(stringPointer);
                if (CheckForOperator(expression[stringPointer].ToString()))
                {
                    result.Add(expression[stringPointer]);
                    stringPointer++;
                }
                else if (CheckForParanthesis(expression[stringPointer].ToString()))
                {
                    result.Add(expression[stringPointer]);
                    stringPointer++;
                }
                else
                {
                    string NumberToken = "";
                    int numberPointer = stringPointer;
                    while (numberPointer < sizeOfExpression && !CheckForOperator(expression[numberPointer].ToString()) && !CheckForParanthesis(expression[numberPointer].ToString()))
                    {
                        NumberToken += expression[numberPointer];
                        numberPointer++;
                    }
                    result.Add(Double.Parse(NumberToken));
                    stringPointer = numberPointer;
                }
            }
            return result;
        }

    }
}