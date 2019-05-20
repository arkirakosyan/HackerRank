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

                int[] arr = new int[] { 3,9, 4, 7, 5, 6, 1, 2, 3,8 };
            //int[] arr = new int[] {1,2,3 };

            Print(LISBottomUp(arr));
            //PrintArrHorizontal(lis.ToArray());
        }

        private int LISLength(int[] arr)
        {
            return LISRecursion(arr, 0, int.MinValue);
        }

        List<int> lis = new List<int>();
        IDictionary<int, int> memo = new Dictionary<int, int>();

        private int LISRecursion(int[] arr, int i, int max)
        {
            //https://www.techiedelight.com/longest-increasing-subsequence-using-dynamic-programming/

            if (i == arr.Length)
            {
                return 0;
            }
            else
            {

                int maxExcludeCurrent = LISRecursion(arr, i + 1, max);
                int maxIncludeCurrent = 0;

                if (arr[i] > max)
                {
                    maxIncludeCurrent = LISRecursion(arr, i + 1, arr[i]) + 1;
                }
                return Math.Max(maxIncludeCurrent, maxExcludeCurrent);
            }
        }

        private int LISBottomUp(int[] arr)
        {
            int maxLis = 1;
            int[] lis = new int[arr.Length];

            lis[0] = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] < arr[i] && lis[i] < lis[j])
                    {
                        lis[i] = lis[j];
                    }

                }
                lis[i]++;

                if (lis[i] > maxLis) maxLis = lis[i];
            }
            return maxLis;
        }

    }


}
