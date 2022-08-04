using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Token
    {
        public Token() : this(TokenType.Operand)
        {
            
        }
        public Token(TokenType tokenCategory)
        {
            TokenCategory = tokenCategory;
        }

        public TokenType TokenCategory { get; }
    }
}
