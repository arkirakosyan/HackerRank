using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.DynamicProgramming
{
    public class LCS : _ProblemBase
    {
        public override void MainRun()
        {
            //PrintLine(LCSLength("ABB", "BB"));
            //PrintLine(LCSLength("BDCABA", "ABCBDAB"));


            PrintLine(SCSlength("BDCABA", "ABCBDAB"));
        }

        public int LCSLength(string m, string n)
        {
            //return LCSRecursion(m, n, m.Length - 1, n.Length - 1);

            //return LCSRecursionTopDown(m, n, m.Length - 1, n.Length - 1, new Dictionary<string, int>());
            return LCSLength(new string[] { m, n });
            //return LCSDynamicBottomUp(m, n);

        }
        private int LCSRecursion(string m, string n, int i, int j)
        {
            if (i < 0 || j < 0) return 0;

            if (m[i] == n[j])
            {
                return LCSRecursion(m, n, i - 1, j - 1) + 1;
            }
            else
            {
                return Math.Max(LCSRecursion(m, n, i, j - 1), LCSRecursion(m, n, i - 1, j));
            }
        }

        private int LCSRecursionTopDown(string m, string n, int i, int j, IDictionary<string, int> memo)
        {
            if (i < 0 || j < 0) return 0;

            string memoKey = $"{i}_{j}";

            if (!memo.ContainsKey(memoKey))
            {
                if (m[i] == n[j])
                {
                    memo.Add(memoKey, LCSRecursion(m, n, i - 1, j - 1) + 1);
                }
                else
                {
                    memo.Add(memoKey, Math.Max(LCSRecursion(m, n, i, j - 1), LCSRecursion(m, n, i - 1, j)));
                }
            }

            return memo[memoKey];
        }

        private int LCSDynamicBottomUp(string m, string n)
        {
            int[,] table = new int[m.Length + 1, n.Length + 1];


            for (int i = 0; i < m.Length; i++)
            {
                for (int j = 0; j < n.Length; j++)
                {
                    if (m[i] == n[j])
                    {
                        table[i + 1, j + 1] = table[i, j] + 1;
                    }
                    else
                    {
                        table[i + 1, j + 1] = Math.Max(table[i, j + 1], table[i + 1, j]);
                    }
                }
            }



            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Print(table[i, j]);
                }
                Console.WriteLine();
            }

            return table[m.Length, n.Length];
        }


        private int LCSLength(string[] strs)
        {
            int[] indeces = new int[strs.Length];

            for (int i = 0; i < strs.Length; i++)
            {
                indeces[i] = strs[i].Length - 1;
            }

            return LCSLengthRecursionTopDown(strs, indeces, new Dictionary<string, int>());
        }

        private int LCSLengthRecursionTopDown(string[] strs, int[] indeces, IDictionary<string, int> memo)
        {
            StringBuilder keyBuilder = new StringBuilder();

            for (int i = 0; i < indeces.Length; i++)
            {
                if (indeces[i] == 0) return 0;

                keyBuilder.Append(indeces[i] + "-");
            }

            string key = keyBuilder.ToString().Substring(0, keyBuilder.Length - 1);

            if (!memo.ContainsKey(key))
            {
                int[] newIndeces = new int[indeces.Length];

                if (AllStringsHasEqualCharAtPosition(strs, indeces))
                {
                    for (int i = 0; i < newIndeces.Length; i++)
                    {
                        newIndeces[i] = indeces[i] - 1;
                    }

                    memo.Add(key, LCSLengthRecursionTopDown(strs, newIndeces, memo));
                }
                else
                {
                    int maxLCS = 0;

                    for (int i = 0; i < strs.Length; i++)
                    {
                        newIndeces = new int[indeces.Length];

                        for (int j = 0; j < newIndeces.Length; j++)
                        {
                            newIndeces[j] = indeces[j];
                        }
                        newIndeces[i] = indeces[i] - 1;

                        int tempMax = LCSLengthRecursionTopDown(strs, newIndeces, memo);

                        if (tempMax > maxLCS)
                        {
                            maxLCS = tempMax;
                        }
                    }

                    memo.Add(key, maxLCS);
                }
            }

            return memo[key];
        }

        private bool AllStringsHasEqualCharAtPosition(string[] strs, int[] positions)
        {
            char firstChar = strs[0][positions[0]];
            for (int i = 1; i < strs.Length; i++)
            {
                if (strs[i][positions[i]] != firstChar)
                {
                    return false;
                }
            }
            return true;
        }



        private int SCSlength(string m, string n)
        {
            //return SCSLengthRecursia(m, n, m.Length - 1, n.Length - 1);

            return SCSBottomUp(m, n);
        }


        private int SCSLengthRecursia(string m, string n, int i, int j)
        {
            if (i < 0 || j < 0) return 0;

            if (m[i] == n[j])
            {
                return SCSLengthRecursia(m, n, i - 1, j - 1) + 1;
            }
            else
            {
                return Math.Min(SCSLengthRecursia(m, n, i, j - 1), SCSLengthRecursia(m, n, i - 1, j)) + 1;
            }
        }

        private int SCSBottomUp(string m, string n)
        {
            int[,] table = new int[m.Length + 1, n.Length + 1];

            int[] arrUp = new int[n.Length + 1];
            int[] arr = new int[n.Length + 1];

            for (int p = 0; p < arrUp.Length; p++)
            {
                arrUp[p] = p;
            }


            for (int i = 0; i < m.Length; i++)
            {
                table[i + 1, 0] = i + 1;
                for (int j = 0; j < n.Length; j++)
                {
                    table[0, j + 1] = j + 1;
                    table[i + 1, j + 1] = (m[i] == n[j]) ? table[i, j] + 1 : Math.Min(table[i + 1, j], table[i, j + 1]) + 1;

                    arr[j + 1] = (m[i] == n[j]) ? arrUp[j] + 1 : Math.Min(arr[j], arrUp[j + 1]) + 1;
                }

                arrUp = arr;
                if(i == m.Length - 1)
                arr = new int[n.Length + 1];
            }

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Print(table[i, j]);
                }
                Console.WriteLine();
            }

            return table[m.Length, n.Length];
        }
    }
}
