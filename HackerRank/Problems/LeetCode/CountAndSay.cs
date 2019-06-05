using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class CountAndSayProblem : _ProblemBase
    {
        public override void MainRun()
        {
            CountAndSay(4);
        }

        public string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }

            string prevRes = CountAndSay(n - 1);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < prevRes.Length; i++)
            {
                char c = prevRes[i];
                int count = 1;
                while (i + 1 < prevRes.Length && prevRes[i + 1] == c)
                {
                    count++;
                    i++;
                }
                result.Append($"{count}{c}");
            }
            return result.ToString();
        }
    }
}
