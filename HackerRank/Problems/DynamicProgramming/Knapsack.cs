using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.DynamicProgramming
{
    public class Knapsack : _ProblemBase
    {
        public override void MainRun()
        {
            int[] weights = new int[] { 1, 2, 3, 8, 7, 4 };
            int[] values = new int[] { 20, 5, 10, 40, 15, 24 };
            int weightLimit = 10;
            //Print(KnapsackRecursive(weights, values, weightLimit, weights.Length - 1));
            //Print($"Recursive count: {count}");
            //count = 0;
            //Print(KnapsackRecursiveMemo(weights, values, weightLimit, weights.Length - 1, new Dictionary<string, int>()));
            //Print($"Memoized count: {count}");

            Print(KnapsackBottomUp(weights, values, weightLimit));

        }

        int count;
        public int KnapsackRecursive(int[] weights, int[] values, int weightLimit, int n)
        {
            count++;
            if (n < 0 || weightLimit == 0)
            {
                return 0;
            }

            int excludingCurrent = KnapsackRecursive(weights, values, weightLimit, n - 1);
            int includingCurrent = 0;

            if (weights[n] <= weightLimit)
            {
                includingCurrent = KnapsackRecursive(weights, values, weightLimit - weights[n], n - 1) + values[n];
            }

            return Math.Max(excludingCurrent, includingCurrent);
        }


        public int KnapsackRecursiveMemo(int[] weights, int[] values, int weightLimit, int n, Dictionary<string,int> memo)
        {
            string key = $"{n}_{weightLimit}";
            count++;

            if (!memo.ContainsKey(key))
            {

                if (n < 0 || weightLimit == 0)
                {
                    memo.Add(key, 0);
                }
                else
                {
                    int excludingCurrent = KnapsackRecursiveMemo(weights, values, weightLimit, n - 1, memo);
                    int includingCurrent = 0;

                    if (weights[n] <= weightLimit)
                    {
                        includingCurrent = KnapsackRecursiveMemo(weights, values, weightLimit - weights[n], n - 1, memo) + values[n];
                    }
                    memo.Add(key, Math.Max(excludingCurrent, includingCurrent));
                }
            }
            return memo[key];
        }

        public int KnapsackBottomUp(int[] weights, int[] values, int weightLimit)
        {
            int[,] table = new int[weights.Length + 1, weightLimit + 1];

            for (int i = 0; i < weights.Length; i++)
            {
                for (int j = 0; j <= weightLimit; j++)
                {
                    if (weights[i] > j)
                    {
                        table[i + 1, j] = table[i, j];
                    }
                    else
                    {
                        table[i + 1, j] = Math.Max(table[i, j], table[i, j - weights[i]] + values[i]);
                    }
                }
            }

            return table[weights.Length, weightLimit];
        }

    }
}
