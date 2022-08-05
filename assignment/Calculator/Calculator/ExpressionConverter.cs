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
        
        public static bool PrecedenceCheck(Token operatorToBePlaced, Token operatorOnStackTop)
        {
            if (operatorOnStackTop is Paranthesis)
            {
                return true;
            }
            Operation placingOperation = (Operation)operatorToBePlaced;
            Operation stackTopOperation = (Operation)operatorOnStackTop;

            if (placingOperation.OperatorPrecedence > stackTopOperation.OperatorPrecedence)
            {
                return true;
            }else if(placingOperation.OperatorPrecedence < stackTopOperation.OperatorPrecedence)
            {
                return false;
            }else if(placingOperation.OperatorPrecedence == stackTopOperation.OperatorPrecedence)
            {
                return placingOperation.OperatorAssociativity == OperatorAssociativity.RightToLeft;
            }else return true;
        }
        public static List <Token> ToPostfix(IExpressionEvaluator expressionEvaluatorObject, string expressionString)
        {
            List<Token> tokens = Tokenize(expressionEvaluatorObject , expressionString);
            Stack <Token> stack = new Stack<Token>();
            List<Token> PostFixTokens = new List<Token>();
            foreach(Token token in tokens)
            {
                if (token.TokenCategory == TokenType.Operator)
                {
                    if (token is Paranthesis paranthesis)
                    {
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

                            //Console.WriteLine("Exception Because of Parsing: "+ currentParsed);
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

                    // Console.WriteLine("Exception Because of Parsing: "+ currentParsed);
                    throw new Exception(ResourceExceptions.InvalidStringError);
                }
                tokens.Add(new Operand(operandValue));
            }
            return tokens;
        }

    }
}