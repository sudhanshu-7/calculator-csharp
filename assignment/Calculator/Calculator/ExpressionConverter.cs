﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        public static List<string> ToPostfix(IExpressionEvaluator expressionEvaluatorObject , string expressionString)
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
        public static string HandleCustomOperations(string expression)
        {
            //Console.WriteLine("InsideHandleOperations! with : " + expression);
            Regex regex = new Regex(@",[^,]*,|[(][^,]*,|,[^,]*[)]");
            List<int[]> bracketIndex = new List<int[]>();
            Match matchResult = regex.Match(expression);
            while (matchResult.Success)
            {
                //Console.WriteLine("'{0}' found in the source code at position {1} with length {2}.", matchResult.Value, matchResult.Index, matchResult.Value.Length);
                bracketIndex.Add(new int[] { matchResult.Index + 1, matchResult.Value.Length - 1 + matchResult.Index });
                matchResult = regex.Match(expression, matchResult.Index + 1);
            }
            string finalString = expression;
            int insertedElements = 0;
            foreach (int[] indexes in bracketIndex)
            {
                finalString = finalString.Insert(indexes[0] + insertedElements++, "(");
                finalString = finalString.Insert(indexes[1] + insertedElements++, ")");
            }
            return finalString;
        }
        public static List <string> RegexTokenize(IExpressionEvaluator expressionEvaluatorObject, string expression)
        {
            expression = Regex.Replace(expression, @"\s+", ""); //Removing Spaces
            expression = Regex.Replace(expression, @"(\(-)","(0-"); // For situations like (-6)
            expression = HandleCustomOperations(expression);
            expression = Regex.Replace(expression, @"[,]", " "); //Removing (Comma),
            //Console.WriteLine(expression);
            string regexPattern = string.Format(@"{0}", ResourceOperatorList.RegexPattern);
            List <string> regexTokens = expressionEvaluatorObject.GetTokens();
            regexTokens.Sort((stringA, stringB) => stringB.Length - stringA.Length);
            foreach(string token in regexTokens)
            {
                regexPattern += string.Format("|{1}{0}{2}", token, token.Length > 1 ? "(" : "[/", token.Length > 1 ? ")" : "]");
                //regexPattern += ("|(" + (token=="^"? "/" : "") + token + ")");
            }
            //Console.WriteLine(regexPattern);
            List <string> tokens = new List<string>();
            Regex regexObject = new Regex(regexPattern);
            Match matchObject = regexObject.Match(expression);
            while(matchObject.Success){
                //Console.WriteLine(matchObject.Value);
                tokens.Add(matchObject.Value);
                matchObject = matchObject.NextMatch();
            }
            return tokens;
        }
        public static List<string> Tokenize(IExpressionEvaluator expressionEvaluatorObject, string expression)
        {
            //expression = RegexTokenize(expressionEvaluatorObject , expression);
            //List<string> expressionsArray = new List<string>(expression.Split(' '));
            List<string> expressionsArray = RegexTokenize(expressionEvaluatorObject, expression);
            List<string> tokens = new List<string>();
            HashSet<string> nonArithmeticOperators = new HashSet<string>(expressionEvaluatorObject.GetNonArithmeticOperators()) ;
            
            for (int index = 0; index < expressionsArray.Count; index++)
            {
                //string token = expressionsArray[index];
                //if(token == "-" && (tokens.Count == 0 || tokens[tokens.Count - 1] == "("))
                //{
                //    tokens.Add("0");
                //} 
                //if (nonArithmeticOperators.Contains(token))
                //{
                //    tokens.Add("(");
                //    int count = 0;
                //    int closingIndex = index + 1;
                //    do
                //    {
                //        if (CheckForParanthesis(expressionsArray[closingIndex]))
                //        {
                //            count += (expressionsArray[closingIndex] == "(" ? 1 : -1);
                //        }
                //        closingIndex++;

                //    } while (closingIndex < expressionsArray.Count && count != 0);

                //    if (closingIndex == expressionsArray.Count)
                //    {
                //        expressionsArray.Add(")");
                //    }
                //    else
                //    {
                //        expressionsArray.Insert(closingIndex, ")");
                //    }

                //}
                //tokens.Add(token);
            }
            return tokens;
        }

    }
}