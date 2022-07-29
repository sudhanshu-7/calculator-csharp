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
        static Boolean CheckForOperator(char c)
        {
            return !(c >= '0' && c <= '9');
        }
        static List<Object> InfixToPostfixConvertor(List<Object> expression)
        {
            //Precedence : * / , +  
        }
        static string CleanString(string expressionString)
        {
            //return expressionString;
            if(expressionString == null || expressionString.Length == 0) return expressionString;
            string cleanedString = "";
            //Checking for Multiple Operators
            for(int i = 1; i < expressionString.Length; i++)
            {
              if(CheckForOperator(expressionString[i]) && CheckForOperator(expressionString[i - 1])){
                     throw new Exception(StringResources.InvalidStringWarning);
                }   
            }
            //Removing WhiteSpaces
            for(int i = 0; i < expressionString.Length; i++)
            {
                if(expressionString[i] == ' ') continue;
                cleanedString += expressionString[i];
            }
            if(cleanedString.Length > 0 && CheckForOperator(cleanedString[0]) && CheckForOperator(cleanedString[cleanedString.Length - 1]))
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
                if (CheckForOperator(expression[stringPointer]))
                {
                    result.Add(expression[stringPointer]);
                    stringPointer++;
                }
                else
                {
                    int value = 0;
                    int numberPointer = stringPointer;
                    while(numberPointer < sizeOfExpression && !CheckForOperator(expression[numberPointer]))
                    {
                        value *= 10; //Future Task : Check for Overflow and Throw Out-Of-Limit Error
                        value += (int)(expression[numberPointer] - '0');
                        numberPointer++;
                    }
                    result.Add(value);
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
            Console.ReadKey();
        }
    }
}
