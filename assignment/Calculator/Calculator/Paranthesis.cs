using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Paranthesis : Token
    {
        public ParanthesisType paranthesisType;
        public Paranthesis() : this("(" , TokenType.Operator)
        {

        }
        public Paranthesis(string token) : this(token, TokenType.Operator) { }
        public Paranthesis(string token , TokenType tokenType) : base(tokenType)
        {
            if (token == "(") paranthesisType = ParanthesisType.Opening;
            else paranthesisType= ParanthesisType.Closing;
        }
    }
}
