using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.DynamicProgramming
{
    public class SubsetSum : _ProblemBase
    {
        public override void MainRun()
        {
            int[] arr = new int[] { 1, 3, 7, 4 };
            Print(IsSubsteBottomUp(arr, 9));
        }

        private bool IsSubset(int[] arr, int n, int sum)
        {
            if (n == 0) return arr[0] == sum;
            return IsSubset(arr, n - 1, sum) || IsSubset(arr, n - 1, sum - arr[n]);
        }

        private bool IsSubsteBottomUp(int[] arr, int sum)
        {
            bool[,] t = new bool[arr.Length + 1, sum + 1];

            for (int i = 1; i <= arr.Length; i++)
            {
                if (arr[i - 1] <= sum) t[i, arr[i - 1]] = true;

                for (int j = 1; j <= sum; j++)
                {
                    t[i, j] = t[i, j] || t[i - 1, j] || j > arr[i - 1] && t[i - 1, j - arr[i - 1]];
                }
            }

            return t[arr.Length, sum];
        }
    }
}
