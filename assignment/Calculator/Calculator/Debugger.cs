using System;
using System.Collections.Generic;


namespace Calculator
{
    internal static class Debugger
    {

        public static void Debug<T>(List<T> array)
        {
            foreach (T obj in array)
            {
                if (obj is Operand)
                {
                    Operand operand = obj as Operand;
                    Console.Write($"({operand.Value}) ");
                }
                Console.Write(obj.ToString() + " -> ");
            }
            Console.WriteLine(" X ");
        }
    }
}
