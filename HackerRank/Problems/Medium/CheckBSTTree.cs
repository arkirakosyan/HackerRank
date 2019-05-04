using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Medium
{
    public class CheckBSTTree : _ProblemBase
    {
        public override void MainRun()
        {
            int[] numbers = new[] { 2, 1, 3 };

            Console.WriteLine(IsValidBST(numbers));
        }

        public bool IsValidBST(int[] arr)
        {
            int dangerNodeValue = int.MinValue;
            int current = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < dangerNodeValue) return false;

                if (arr[i] > current)
                {
                    dangerNodeValue = FindNewDangerNode(i - 1, arr);
                }
                current = arr[i];
            }
            return true;
        }
        private int FindNewDangerNode(int endIndex, int[] arr)
        {
            int i = endIndex;
            while (i > 0 && arr[i - 1] > arr[i])
            {
                i--;
            }
            return  arr[Math.Max(i, 0)];
        }
    }
}
