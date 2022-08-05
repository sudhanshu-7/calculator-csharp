using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class OperatorData
    {
        public string Symbol { get; set; }
        public OperatorPrecedence OperatorPrecedence { get; set; }

        public OperatorAssociativity OperatorAssociativity { get; set; }

        public OperatorData(string symbol, OperatorAssociativity operatorAssociativity, OperatorPrecedence operatorPrecedence)
        {
            Symbol = symbol;
            OperatorPrecedence = operatorPrecedence;
            OperatorAssociativity = operatorAssociativity;
        }
        public OperatorData() : this("NaN", OperatorAssociativity.LeftToRight, OperatorPrecedence.Lowest)
        {

        }

    }
    public static class ConverterClass
    {
        public static T GetEnumFromString<T>(string associativity)
        {
            return (T)Enum.Parse(typeof(T), associativity, true);
        }
        public static OperatorData ConvertToOperatorData(Newtonsoft.Json.Linq.JObject obj)
        {
            if(obj == null) throw new ArgumentNullException(nameof(obj));
            return new OperatorData(obj["Symbol"].ToString(), GetEnumFromString<OperatorAssociativity>(obj["Associativity"].ToString()), GetEnumFromString<OperatorPrecedence>(obj["Precedence"].ToString()));
        }
    }
}
