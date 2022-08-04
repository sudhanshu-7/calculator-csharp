using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum TokenType
    {
        Operand , Operator
    }
    public enum OperatorAssociativity
    {
        LeftToRight , RightToLeft
    }
    public enum OperatorPrecedence
    {
        Lowest , Lower , Higher , Highest , Unary
    }
    public enum ParanthesisType
    {
        Opening, Closing
    }
}
