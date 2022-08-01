using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
namespace BetaOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpressionEvaluator ev = new ExpressionEvaluator();
            Console.WriteLine("Enter a Evaluation String: ");
            String s = Console.ReadLine();
            Object ans;
            try
            {
                ans = ev.Evaluate(s);
            }catch(Exception ex)
            {
                ans = ("Exception : " + ex.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Answer : " + ans);
            Console.ReadKey();
        }
    }
}
