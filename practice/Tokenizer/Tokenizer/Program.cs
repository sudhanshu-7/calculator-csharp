using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Tokenizer
{
    internal class Program
    {
        static Boolean CheckForParanthesis(string c)
        {
            return (c == "(" || c == ")");
        }
        static Boolean CheckForOperator(string c)
        {
            return (c == "+" || c == "-" || c == "*" || c == "/" || c == "^");
        }
        static Boolean PrecedenceCheck(string operatorA, string operatorB)
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
        static List<Object> ToPostFix(List<Object> tokens)
        {
            Stack<String> operatorStack = new Stack<String>();
            List<Object> postFixExpression = new List<Object>();
            foreach (Object token in tokens)
            {
                if(token.ToString() == "(")
                {
                    operatorStack.Push("(");
                }
                else if(token.ToString() == ")")
                {
                    while(operatorStack.Count > 0 && operatorStack.Peek()!="(")
                    {
                        postFixExpression.Add(operatorStack.Pop());
                    }
                    if(operatorStack.Count > 0) operatorStack.Pop();
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
            while(operatorStack.Count > 0) postFixExpression.Add(operatorStack.Pop());
            return postFixExpression;
        }
        static string CleanString(string expressionString)
        {
            //return expressionString;
            if (expressionString == null || expressionString.Length == 0) return expressionString;
            string cleanedString = "";
            //Checking for Multiple Operators
            for (int i = 1; i < expressionString.Length; i++)
            {
                if (CheckForOperator(expressionString[i].ToString()) && CheckForOperator(expressionString[i - 1].ToString())) {
                    throw new Exception(StringResources.InvalidStringWarning);
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
                throw new Exception(StringResources.InvalidStringWarning);
            }
            return cleanedString;
        }
        static List<Object> Tokenizer(string expression)
        {
            if (expression.Length == 0) throw new ArgumentException(StringResources.EmptyStringWarning);
            expression = CleanString(expression);
            List<Object> result = new List<Object>();
            int stringPointer = 0, sizeOfExpression = expression.Length; 

            while(stringPointer < sizeOfExpression)
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
                    while(numberPointer < sizeOfExpression && !CheckForOperator(expression[numberPointer].ToString()) && !CheckForParanthesis(expression[numberPointer].ToString()))
                    {
                        NumberToken += expression[numberPointer];
                        numberPointer++;
                    }
                    Console.WriteLine(NumberToken);
                    Double.Parse(NumberToken);
                    result.Add(NumberToken);
                    stringPointer = numberPointer;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(StringResources.PromptInput);
            string input = Console.ReadLine();
            Console.WriteLine(input);

            List<Object> result = Tokenizer(input);
            foreach(Object obj in result)
            {
                Console.WriteLine(obj.ToString());
            }
            result = ToPostFix(result);
            foreach (Object obj in result)
            {
                Console.Write(obj.ToString() + " ");
            }
            Console.ReadKey();
        }
    }
}
