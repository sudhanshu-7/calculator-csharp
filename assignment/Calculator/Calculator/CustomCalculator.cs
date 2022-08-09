using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace Calculator
{
    public class CustomCalculator : IExpressionEvaluator , IMemoryHandler
    {
        #region Private Fields
        private readonly Dictionary<string, Operation> _operatorMapping;
        private readonly Newtonsoft.Json.Linq.JObject _basicOperatorsJSON;
        private readonly Stack<double> _memory;
        #endregion

        public CustomCalculator()
        {
            _operatorMapping = new Dictionary<string,Operation> ();
            _memory = new Stack<double>();
            _basicOperatorsJSON = GetBasicOperationsFromJSON(ResourceExceptions.PathName);
            GenerateBaseDictionary();
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
            return _memory.Count>0? _memory.Peek() : 0;
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
        private Newtonsoft.Json.Linq.JObject GetBasicOperationsFromJSON(string pathName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathName))
                {
                    // Console.WriteLine("Inside GetBasicOperationsFromJSON");
                    string json = reader.ReadToEnd();
                    dynamic jsonArray = JsonConvert.DeserializeObject(json);
                    var jsonObject = jsonArray[0];
                    return jsonArray[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public bool CheckForOperator(string operatorSymbol)
        {
            return _operatorMapping.ContainsKey(operatorSymbol);
        }
        public Operation GetOperation(string symbol)
        {
            return _operatorMapping[symbol];
        }
        private void AddBasicOperationsToDictionary(Operation operationObject)
        {
            string key = operationObject.GetType().Name;
            try
            {
                operationObject.SetOperator(ConverterClass.ConvertToOperatorData((Newtonsoft.Json.Linq.JObject)_basicOperatorsJSON[key]), operationObject.OperandCount);
                _operatorMapping[operationObject.OperationSymbol] = operationObject;
                // Console.WriteLine("Successfully Added : " + key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Console.WriteLine("Unsuccessful in adding : " + key);
            }

        }
        private void GenerateBaseDictionary()
        {
            AddBasicOperationsToDictionary(new AddOperation());
            AddBasicOperationsToDictionary(new MultiplyOperation());
            AddBasicOperationsToDictionary(new DivideOperation());
            AddBasicOperationsToDictionary(new SubtractOperation());
            AddBasicOperationsToDictionary(new ExponentiationOperation());
            AddBasicOperationsToDictionary(new PercentageOperation());
            AddBasicOperationsToDictionary(new LogarithmicBase2Operation());
            AddBasicOperationsToDictionary(new LogarithmicBase10Operation());
            AddBasicOperationsToDictionary(new LogarithmicOperation());
            AddBasicOperationsToDictionary(new SineOperation());
            AddBasicOperationsToDictionary(new CosineOperation());
            AddBasicOperationsToDictionary(new TangentOperation());
            AddBasicOperationsToDictionary(new CotangentOperation());
            AddBasicOperationsToDictionary(new SecantOperation());
            AddBasicOperationsToDictionary(new CosecantOperation());
            AddBasicOperationsToDictionary(new SquareOperation());
            AddBasicOperationsToDictionary(new SquareRootOperation());
            AddBasicOperationsToDictionary(new ReciprocalOperation());
            AddBasicOperationsToDictionary(new ArcSineOperation());
            AddBasicOperationsToDictionary(new ArcCosineOperation());
            AddBasicOperationsToDictionary(new ArcTangentOperation());
             
        }
        public void ClearCustomOperations()
        {
            _operatorMapping.Clear();
            GenerateBaseDictionary();
        }

        public double Evaluate(string expressionString)
        {
            if(expressionString!="" && expressionString[0] == '-')
            {
                expressionString = "0" + expressionString;
            }
            expressionString = expressionString.Replace("(-" , "(0-");
            List<Token> tokens = ExpressionConverter.ToPostfix(this, expressionString);

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