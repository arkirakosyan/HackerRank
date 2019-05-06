using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.DynamicProgramming
{
    public class LIS : _ProblemBase
    {
        public override void MainRun()
        {
            // PrintArr(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0);

                //int[] arr = new int[] { 3, 4, 7, 5, 6, 1, 2, 3, 8 };
            int[] arr = new int[] {1,2,3 };

            Print(LISLength(arr));
            //PrintArrHorizontal(lis.ToArray());
        }

        private int LISLength(int[] arr)
        {
            return LISRecursion(arr, arr.Length - 1, 0);
        }

        List<int> lis = new List<int>();
        IDictionary<int, int> memo = new Dictionary<int, int>();

        private int LISRecursion(int[] arr, int i, int max)
        {
            //https://www.techiedelight.com/longest-increasing-subsequence-using-dynamic-programming/
            //string memo
            if (memo.ContainsKey(i))
            {
                return memo[i];
            }

            if (i == 0)
            {
                memo[i] = 1;
            }
            else
            {

                int maxExcludeCurrent = LISRecursion(arr, i - 1, max);
                int maxIncludeCurrent = 0;

                if (arr[i] > max)
                {
                    maxIncludeCurrent = LISRecursion(arr, i - 1, arr[i]) + 1;
                }

                memo.Add(i, Math.Max(maxIncludeCurrent, maxExcludeCurrent));
            }
            //if (maxIncludeCurrent > maxExcludeCurrent && )
            //{
            //    lis.Add(arr[i]);
            //}
            return memo[i];
        }

    }


}
