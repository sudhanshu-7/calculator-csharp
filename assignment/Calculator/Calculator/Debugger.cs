using System;
using System.Collections.Generic;


namespace Calculator
{
    internal static class Debugger
    {
        public static void Debug(List<string> array)
        {
            foreach (string obj in array)
            {
                Console.Write(obj + " -> ");
            }
            Console.WriteLine(" X ");
        }
    }
}
