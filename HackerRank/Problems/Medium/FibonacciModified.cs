//**************** Max Score *****************//
//******************* 45 ********************//
//*******************************************//

using System;
using System.Numerics;

namespace HackerRank.Problems
{
    /// <summary>
    /// Fibonacci Modified
    /// </summary>
    public class FibonacciModified : _ProblemBase
    {
        public static void MainRun(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            string[] ttt = Console.ReadLine().Split(' ');

            t1 = Convert.ToInt32(ttt[0]);
            t2 = Convert.ToInt32(ttt[1]);
            n = Convert.ToInt32(ttt[2]);

            Console.WriteLine(CustomFibonachi(n));
        }

        private static int t1, t2, n;

        private static BigInteger CustomFibonachi(int i)
        {
            if (i == 1) return t1;
            if (i == 2) return t2;

            if (i < 1) throw new ArgumentException();

            BigInteger ti = CustomFibonachi(--i);
            BigInteger tj = CustomFibonachi(--i);

            return ti * ti + tj;
        }

        
    }
}
