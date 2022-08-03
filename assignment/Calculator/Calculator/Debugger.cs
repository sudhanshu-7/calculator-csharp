using System;
using System.Collections.Generic;


namespace Calculator
{
    internal static class Debugger
    {
        public static void debug(List<string> array)
        {
            foreach(string obj in array)
            {
                Console.Write(obj + " -> ");
            }
            Console.WriteLine(" X ");
        }
    }
}
