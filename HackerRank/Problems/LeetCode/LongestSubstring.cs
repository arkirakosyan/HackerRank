using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class LongestSubstring : _ProblemBase
    {
        public override void MainRun()
        {
            Print(FindLengthLongestSubstring("au"));
        }

        private string FindLongestSubstring(string str)
        {
            IDictionary<char, int> substr = new Dictionary<char, int>();
            int maxLength = 1;
            int maxSubstrIndex = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (substr.ContainsKey(str[i]))
                {
                    if (substr.Count > maxLength)
                    {
                        maxLength = substr.Count;
                        maxSubstrIndex = substr.First().Value;
                    }
                    i = substr[str[i]];
                    substr = new Dictionary<char, int>();
                }
                else
                {
                    substr[str[i]] = i;
                }
            }

            return str.Substring(maxSubstrIndex, maxLength);
        }

        private int FindLengthLongestSubstring(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            IDictionary<char, int> substr = new Dictionary<char, int>();
            int maxLength = 1;

            for (int i = 0; i < str.Length; i++)
            {
                if (substr.ContainsKey(str[i]))
                {
                    i = substr[str[i]];
                    substr = new Dictionary<char, int>();
                }
                else
                {
                    substr[str[i]] = i;
                }

                maxLength = Math.Max(maxLength, substr.Count);
            }

            return maxLength;
        }
    }
}
