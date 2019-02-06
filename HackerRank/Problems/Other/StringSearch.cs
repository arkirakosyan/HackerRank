using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class StringSearchTest : _ProblemBase
    {
        public override void MainRun()
        {
            //string text = Console.ReadLine();
            //string pattern = Console.ReadLine();
            string text = "abcbcglxbcgl";
            string pattern = "bcgl";

            text = "ababbabbbabbbb";
            pattern = "bbb";

            text = "bbbbbbbbbb";
            pattern = "bbb";

            List<int> v = KMPSearch(text, pattern);

            PrintArrHorizontal(v);

            //GetTempKMPArray(pattern);
            //GetTempKMPArray("aababab");

            //GetTempKMPArray("acacabacacabacacac");

            List<int> v1 = SlowSearch(text, pattern);

            PrintArrHorizontal(v1);
        }


        public List<int> SlowSearch(string text, string pattern)
        {
            List<int> matchIndeces = new List<int>();

            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(pattern) || pattern.Length > text.Length)
            {
                return matchIndeces;
            }

            int j = 0;

            int c = 0;

            for (int i = 0; i < text.Length; i++)
            {
                c++;
                if (text[i] == pattern[j])
                {
                    if (++j == pattern.Length)
                    {
                        i -= j - 1;
                        j = 0;
                        matchIndeces.Add(i);
                    }
                }
                else
                {
                    i -= j;
                    j = 0;
                }
            }

            PrintLine("Slow search:" + c);
            return matchIndeces;
        }

        public List<int> KMPSearch(string text, string pattern)
        {
            int c = 0;
            List<int> matchIndeces = new List<int>();

            int[] matchArray = GetTempKMPArray(pattern);

            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == pattern[j])
                {
                    c++;
                    j++;
                }
                else if (j > 0)
                {
                    do
                    {
                        c++;
                        j = matchArray[j - 1];
                    }
                    while (j > 0 && text[i] != matchArray[j]);

                    if (text[i] == pattern[j])
                    {
                        j++;
                    }
                }
                if (j == pattern.Length)
                {
                    matchIndeces.Add(i - j + 1);
                    j--;
                }
            }
            PrintLine("KMP temp: " + c);
            return matchIndeces;
        }

        private int[] GetTempKMPArray(string pattern)
        {
            int c = 0;
            int[] tempArr = new int[pattern.Length];

            int j = 0;
            int i = 1;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    tempArr[i] = tempArr[i - 1] + 1;
                    j++;

                    c++;
                }
                else
                {
                    if (j > 0)
                    {
                        do
                        {
                            j = tempArr[j - 1];
                            c++;
                        }
                        while (j > 0 && pattern[j] != pattern[i]);
                    }

                    if (pattern[j] == pattern[i])
                    {
                        tempArr[i] = j + 1;
                        j++;
                    }
                }

                i++;
            }

            PrintLine("KMP : " + c);

            return tempArr;
        }


    }

}
