using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace Calculator
{
    public class CustomCalculator : IExpressionEvaluator , IMemoryHandler
    {
        #region Private Fields
        private Dictionary<string, Operation> _operatorMapping;

        private readonly Stack<double> _memory;
        #endregion

        public CustomCalculator()
        {
            _operatorMapping = GetBaseDictionary();
            _memory = new Stack<double>();
        }

        #region Memory Functions
        public double[] Memory { get => _memory.ToArray(); }

        public void MemorySave(double value)
        {
            _memory.Push(value);
        }
        public void MemoryClear()
        {
            _memory.Clear();
        }

        public double MemoryRecall()
        {
            return _memory.Peek();
        }

        public void MemoryModification(double value)
        {
            if (_memory.Count == 0)
            {
                _memory.Push(value);
            }
            else
            {
                _memory.Push(_memory.Pop() + value);
            }
        }
        #endregion

        #region Evaluate Functions
        public bool CheckForOperator(string operatorSymbol)
        {
            return _operatorMapping.ContainsKey(operatorSymbol);
        }
        public List<string> GetNonArithmeticOperators()
        {
            List<string> result = new List<string>();
            foreach (string operatorSymbol in _operatorMapping.Keys)
            {
                if (!(_operatorMapping[operatorSymbol] is BinaryOperation))
                {
                    result.Add(operatorSymbol);
                }
            }
            return result;
        }
        public List<string> GetTokens()
        {
            List<string> result = new List<string>();
            foreach (string key in _operatorMapping.Keys)
            {
                result.Add(key);
            }
            return result;
        }
        public Operation GetOperation(string symbol)
        {
            return _operatorMapping[symbol];
        }
        public List <string> Testing()
        {
            List <string> result = new List<string>();
            using (StreamReader reader = new StreamReader(ResourceExceptions.PathName))
            {
                string json = reader.ReadToEnd();
                dynamic jsonArray = JsonConvert.DeserializeObject(json);
                //Console.WriteLine(jsonArray.ToString() + " Length : " + jsonArray.Count);
                dynamic jsonObject = jsonArray[0];
                //Console.WriteLine("{0} {1}", jsonObject.Add.Symbol, jsonObject.Add.Precedence);
            }

            return result;
        }

        private Dictionary<string, Operation> GetBaseDictionary()
        {
            try
            {
                using (StreamReader reader = new StreamReader(ResourceExceptions.PathName))
                {
                    string json = reader.ReadToEnd();
                    dynamic jsonArray = JsonConvert.DeserializeObject(json);
                    //Console.WriteLine(jsonArray.ToString() + " Length : " + jsonArray.Count);
                    dynamic jsonObject = jsonArray[0];
                    //Console.WriteLine("Type of ADD : " + jsonObject.Add.GetType());
                    //Console.WriteLine(jsonObject["Subtract"].GetType());
                    return new Dictionary<string, Operation>
            {
                { jsonObject["Add"]["Symbol"].ToString(), new AddOperation(ConverterClass.ConvertToOperatorData(jsonObject["Add"]))},
                { jsonObject["Subtract"]["Symbol"].ToString(), new SubtractOperation(ConverterClass.ConvertToOperatorData(jsonObject["Subtract"])) },
                { jsonObject["Multiply"]["Symbol"].ToString(), new MultiplyOperation(ConverterClass.ConvertToOperatorData(jsonObject["Multiply"])) },
                { jsonObject["Divide"]["Symbol"].ToString(), new DivideOperation(ConverterClass.ConvertToOperatorData(jsonObject["Divide"])) },
                { jsonObject["Power"]["Symbol"].ToString(), new ExponentiationOperation(ConverterClass.ConvertToOperatorData(jsonObject["Power"])) },
                { jsonObject["Percentage"]["Symbol"].ToString() , new PercentageOperation(ConverterClass.ConvertToOperatorData(jsonObject["Percentage"])) },
                { jsonObject["SquareRoot"]["Symbol"].ToString(), new SquareRootOperation(ConverterClass.ConvertToOperatorData(jsonObject["SquareRoot"])) },
                { jsonObject["Square"]["Symbol"].ToString() , new SquareOperation(ConverterClass.ConvertToOperatorData(jsonObject["Square"])) },
                { jsonObject["LogE"]["Symbol"].ToString(), new LogarithmicOperation(ConverterClass.ConvertToOperatorData(jsonObject["LogE"])) },
                { jsonObject["Log10"]["Symbol"].ToString(), new LogarithmicBase10Operation(ConverterClass.ConvertToOperatorData(jsonObject["Log10"])) },
                { jsonObject["Log2"]["Symbol"].ToString(), new LogarithmicBase2Operation(ConverterClass.ConvertToOperatorData(jsonObject["Log2"])) },
                { jsonObject["Reciprocal"]["Symbol"].ToString(), new ReciprocalOperation(ConverterClass.ConvertToOperatorData(jsonObject["Reciprocal"])) },
                { jsonObject["Sine"]["Symbol"].ToString() , new SineOperation(ConverterClass.ConvertToOperatorData(jsonObject["Sine"])) },
                { jsonObject["Cosine"]["Symbol"].ToString() , new CosineOperation(ConverterClass.ConvertToOperatorData(jsonObject["Cosine"])) },
                { jsonObject["Tangent"]["Symbol"].ToString() , new TangentOperation(ConverterClass.ConvertToOperatorData(jsonObject["Tangent"])) },
                { jsonObject["Cosecant"]["Symbol"].ToString() , new CosecantOperation(ConverterClass.ConvertToOperatorData(jsonObject["Cosecant"]))},
                { jsonObject["Secant"]["Symbol"].ToString() , new SecantOperation(ConverterClass.ConvertToOperatorData(jsonObject["Secant"]))},
                { jsonObject["Cotangent"]["Symbol"].ToString() , new CotangentOperation(ConverterClass.ConvertToOperatorData(jsonObject["Cotangent"]))},
                { jsonObject["ArcSine"]["Symbol"].ToString() , new ArcSineOperation(ConverterClass.ConvertToOperatorData(jsonObject["ArcSine"]))},
                { jsonObject["ArcCosine"]["Symbol"].ToString() , new ArcCosineOperation(ConverterClass.ConvertToOperatorData(jsonObject["ArcCosine"]))},
                { jsonObject["ArcTangent"]["Symbol"].ToString() , new ArcTangentOperation(ConverterClass.ConvertToOperatorData(jsonObject["ArcTangent"]))}
            };
                }
            }
            catch (Exception)
            {
                return new Dictionary<string, Operation>();
            }
            }
        public void ClearCustomOperations()
        {
            _operatorMapping = GetBaseDictionary();
        }

        public double Evaluate(string expressionString)
        {
            List<Token> tokens = ExpressionConverter.ToPostfix(this, expressionString);
            Debugger.Debug(tokens);
            //Postfix Evaluation Logic
            Stack<double> evaluatorStack = new Stack<double>();
            foreach(Token token in tokens)
            {
                if(token.TokenCategory == TokenType.Operand)
                {
                    evaluatorStack.Push(((Operand)token).Value);
                }
                else
                {
                    Operation operation = (Operation)token;
                    if(operation.OperandCount > evaluatorStack.Count)
                    {
                        throw new Exception(ResourceExceptions.InvalidArgumentError);
                    }
                    double [] operands = new double [operation.OperandCount];
                    for(int operandIndex = operation.OperandCount - 1; operandIndex >= 0; operandIndex--)
                    {
                        operands[operandIndex] = evaluatorStack.Pop();
                    }
                    evaluatorStack.Push(operation.Evaluate(operands));
                }
            }
            if(evaluatorStack.Count > 1)
            {
                throw new Exception(ResourceExceptions.InvalidArgumentError);
            }
            return evaluatorStack.Pop();
            //Stack<double> tokenStack = new Stack<double>();
            //foreach (string token in tokens)
            //{
            //    if (CheckForOperator(token))
            //    {
            //        Operation operationObject = _operatorMapping[token];
            //        int operandCount = operationObject.OperandCount;
            //        if (operandCount > tokenStack.Count)
            //        {
            //            throw new Exception(ResourceExceptions.InvalidArgumentError);
            //        }
            //        double[] operands = new double[operandCount];
            //        for (int operandIndex = operandCount - 1; operandIndex >= 0; operandIndex--)
            //        {
            //            operands[operandIndex] = tokenStack.Pop();
            //        }
            //        tokenStack.Push(operationObject.Evaluate(operands));
            //    }
            //    else
            //    {
            //        tokenStack.Push(Double.Parse(token));
            //    }
            //}
            //if (tokenStack.Count > 1)
            //{
            //    throw new Exception(ResourceExceptions.InvalidStringError);
            //}
            //return tokenStack.Pop();
            //return 1.0D;
        }
        public void RegisterCustomOperation(string operationSymbol, Operation customOperation)
        {
            if (CheckForOperator(operationSymbol))
            {
                throw new InvalidOperationException(ResourceExceptions.InvalidOperatorError);
            }
            _operatorMapping.Add(operationSymbol, customOperation);
        }
        #endregion
    }
}