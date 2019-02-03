using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class LongestPolindrom : _ProblemBase
    {
        int runCount = 0;
        public override void MainRun()
        {
            Print(FindPolindrom("abb"));
            Print(runCount);
        }

        private string FindPolindrom(string s)
        {
            if (string.IsNullOrEmpty(s))
            { return s; }

            int centerIndex = s.Length / 2;
            string longPolindrom = "";

            for (int i = 0; i <= centerIndex && longPolindrom.Length <= 2 * (centerIndex - i) + s.Length % 2; i++)
            {
                string leftMax = FindBiggestPolindorm(s, centerIndex - i);
                string rightMax = FindBiggestPolindorm(s, centerIndex + i);
                if (longPolindrom.Length < Math.Max(leftMax.Length, rightMax.Length))
                {
                    longPolindrom = leftMax.Length > rightMax.Length ? leftMax : rightMax;
                }
            }

            return longPolindrom;
        }

        private string FindBiggestPolindorm(string s, int center)
        {
            int max = 1;
            int start = center;
            int end = center;
            string polindrom = s[center].ToString();

            while (start >= 0 && end < s.Length && s[start] == s[end])
            {
                start--;
                end++;
            }

            max = end - start - 1;
            polindrom = s.Substring(start + 1, max);

            start = center - 1;
            end = center;

            while (start >= 0 && end < s.Length && s[start] == s[end])
            {
                start--;
                end++;
            }

            if (end - start - 1 > max)
            {
                max = end - start - 1;
                polindrom = s.Substring(start + 1, max);
            }

            return polindrom;
        }
    }
}
