using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class LongestCommonPrefix : _ProblemBase
    {
        public override void MainRun()
        {
            Print(LCP(new string[] { "flower", "flow", "flight" }));
        }

        public string LCP(string[] strs)
        {
            if (strs.Length == 0) return "";
            int shortestWordIndex = 0;
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i].Length < strs[shortestWordIndex].Length)
                {
                    shortestWordIndex = i;
                }
            }
            bool prefixFound = false;

            string shortesWord = strs[shortestWordIndex];

            while (shortesWord.Length > 0)
            {
                int i = 0;
                for (i = 0; i < strs.Length; i++)
                {
                    if (!strs[i].StartsWith(shortesWord))
                    {
                        break;
                    }
                }
                if (i == strs.Length)
                {
                    return shortesWord;
                }
                shortesWord = shortesWord.Substring(0,shortesWord.Length - 1);
            }
            return "";
        }
    }
}
