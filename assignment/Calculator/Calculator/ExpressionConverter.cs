using System;
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
        //public static bool PrecedenceCheck(string operatorToBePlaced, string operatorOnStackTop)
        //{
        //    if (operatorOnStackTop == "(") return true;
        //    if (operatorToBePlaced == "^")
        //    {
        //        if (operatorOnStackTop == "^" || operatorOnStackTop == "+" || operatorOnStackTop == "-" || operatorOnStackTop == "/" || operatorOnStackTop == "*") return true;
        //        return false;
        //    }
        //    if (operatorToBePlaced == "*" || operatorToBePlaced == "/")
        //    {
        //        if (operatorOnStackTop == "+" || operatorOnStackTop == "-") return true;
        //        return false;
        //    }
        //    if (operatorToBePlaced == "+" || operatorToBePlaced == "-") return false;

        //    return true;
        //}
        public static bool PrecedenceCheck(Token operatorToBePlaced, Token operatorOnStackTop)
        {
            if (operatorOnStackTop is Paranthesis)
            {
                return true;
            }
            Operation placingOperation = (Operation)operatorToBePlaced;
            Operation stackTopOperation = (Operation)operatorOnStackTop;
            Console.WriteLine("Here for {1} ({3}) & {2} Associativity {0}!",(placingOperation.OperatorAssociativity),placingOperation.ToString(),stackTopOperation.ToString() , placingOperation.OperatorAssociativity);

            if (placingOperation.OperatorPrecedence > stackTopOperation.OperatorPrecedence)
            {
                Console.WriteLine(" > returing true");
                return true;
            }else if(placingOperation.OperatorPrecedence < stackTopOperation.OperatorPrecedence)
            {
                Console.WriteLine(" < returing true");
                return false;
            }else if(placingOperation.OperatorPrecedence == stackTopOperation.OperatorPrecedence)
            {
                Console.WriteLine("== for {1} ({3}) & {2} Returning {0}!",(placingOperation.OperatorAssociativity == OperatorAssociativity.RightToLeft),placingOperation.ToString(),stackTopOperation.ToString() , placingOperation.OperatorAssociativity);
                return placingOperation.OperatorAssociativity == OperatorAssociativity.RightToLeft;
            }else return true;
        }
        //public static List<string> ToPostfix(IExpressionEvaluator expressionEvaluatorObject , string expressionString)
        //{
        //    List<string> tokens = Tokenize(expressionEvaluatorObject , expressionString);
        //    Stack<string> operatorStack = new Stack<string>();
        //    List<string> postFixExpression = new List<string>();
        //    foreach (string token in tokens)
        //    {
        //        if (token == "(")
        //        {
        //            operatorStack.Push("(");
        //        }
        //        else if (token == ")")
        //        {
        //            while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
        //            {
        //                postFixExpression.Add(operatorStack.Pop());
        //            }
        //            if (operatorStack.Count > 0) operatorStack.Pop();
        //            else
        //            {
        //                throw new Exception(ResourceExceptions.InvalidArgumentError);
        //            }
        //        }
        //        else if (expressionEvaluatorObject.CheckForOperator(token))
        //        {
        //            if (operatorStack.Count == 0)
        //            {
        //                operatorStack.Push(token);
        //                continue;
        //            }
        //            string tokenString = token;
        //            while (operatorStack.Count > 0 && !PrecedenceCheck(tokenString, operatorStack.Peek()))
        //            {
        //                postFixExpression.Add(operatorStack.Pop());
        //            }
        //            operatorStack.Push(tokenString);
        //        }
        //        else
        //        {
        //            postFixExpression.Add(token);
        //        }
        //    }
        //    while (operatorStack.Count > 0)
        //    {
        //        if (operatorStack.Peek() == "(")
        //        {
        //            throw new Exception(ResourceExceptions.InvalidArgumentError);
        //        }
        //        postFixExpression.Add(operatorStack.Pop());
        //    }
        //    return postFixExpression;
        //}
        public static List <Token> ToPostfix(IExpressionEvaluator expressionEvaluatorObject, string expressionString)
        {
            List<Token> tokens = Tokenize(expressionEvaluatorObject , expressionString);
            Debugger.Debug(tokens);
            Stack <Token> stack = new Stack<Token>();
            List<Token> PostFixTokens = new List<Token>();
            foreach(Token token in tokens)
            {
                if (token.TokenCategory == TokenType.Operator)
                {
                    if (token is Paranthesis)
                    {
                        Paranthesis paranthesis = (Paranthesis)token;
                        if (paranthesis.paranthesisType == ParanthesisType.Opening)
                        {
                            stack.Push(paranthesis);
                        }
                        else
                        {

                            while (stack.Count > 0 && !(stack.Peek() is Paranthesis))
                            {
                                PostFixTokens.Add(stack.Pop());
                            }
                            if (stack.Count > 0)
                            {
                                stack.Pop();
                            }
                            else
                            {
                                throw new Exception(ResourceExceptions.InvalidStringError);
                            }
                        }
                    }
                    else
                    {
                        while (stack.Count > 0 && !PrecedenceCheck(token, stack.Peek()))
                        {
                            PostFixTokens.Add(stack.Pop());
                        }
                        stack.Push(token);
                    }
                }
                else
                {
                    PostFixTokens.Add(token);
                }
            }
            while(stack.Count > 0)
            {
                if(stack.Peek() is Paranthesis)
                {
                    throw new Exception(ResourceExceptions.InvalidStringError);
                }
                PostFixTokens.Add(stack.Pop());
            }
            return PostFixTokens;
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
        public static List<Token> Tokenize(IExpressionEvaluator expressionEvaluatorObject, string expression)
        {
            List<Token> tokens = new List<Token>();
            string currentParsed = "";
            foreach(char currentCharacter in expression)
            {
                if (currentCharacter == '(' || currentCharacter == ')')
                {
                    if (currentParsed != "")
                    {
                        double operandValue;
                        try
                        {
                            operandValue = Double.Parse(currentParsed);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Exception Because of Parsing: "+  currentParsed);
                            throw new Exception(ResourceExceptions.InvalidStringError);
                        }
                        tokens.Add(new Operand(operandValue));
                    }
                    tokens.Add(new Paranthesis(currentCharacter.ToString()));
                    currentParsed = "";
                }
                else if (expressionEvaluatorObject.CheckForOperator(currentCharacter.ToString()))
                {
                    if (currentParsed != "")
                    {
                        double operandValue;
                        try
                        {
                            operandValue = Double.Parse(currentParsed);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Exception Because of Parsing: "+ currentParsed);
                            throw new Exception(ResourceExceptions.InvalidStringError);
                        }
                        tokens.Add(new Operand(operandValue));
                    }
                    tokens.Add(((CustomCalculator)expressionEvaluatorObject).GetOperation(currentCharacter.ToString()));
                    currentParsed = "";
                }
                else
                {
                    currentParsed += currentCharacter;
                    if (expressionEvaluatorObject.CheckForOperator(currentParsed))
                    {
                        tokens.Add(((CustomCalculator)expressionEvaluatorObject).GetOperation(currentParsed));
                        currentParsed = "";
                    }
                }
            }
            if (currentParsed != "")
            {
                double operandValue;
                try
                {
                    operandValue = Double.Parse(currentParsed);
                }
                catch (Exception)
                {

                    Console.WriteLine("Exception Because of Parsing: "+ currentParsed);
                    throw new Exception(ResourceExceptions.InvalidStringError);
                }
                tokens.Add(new Operand(operandValue));
            }
            return tokens;
        }

    }
}