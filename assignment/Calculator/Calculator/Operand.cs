using System;
using System.Collections.Generic;
namespace Calculator
{
    public class Operand : Token
    {
        public double Value { get; set; }
        public Operand(double value) : base(TokenType.Operand)
        {
            Value = value;
        }
    }
}
