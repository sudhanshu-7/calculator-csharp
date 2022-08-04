using System;
using System.Collections.Generic;


namespace Calculator
{
    internal static class Debugger
    {

        public static void Debug<T>(List<T> array)
        {
            foreach (var obj in array)
            {
                Console.Write(obj.ToString() + " -> ");
            }
            Console.WriteLine(" X ");
        }
    }
}
