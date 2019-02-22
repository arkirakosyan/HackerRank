using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Medium
{
    public class MinimumSwap2 : _ProblemBase
    {
        public override void MainRun()
        {

            //int[] arr = new int[] { 4,3,1,2 };
            int[] arr = new int[] { 7, 1, 3, 2, 4, 5, 6 };

            Print(minimumSwaps(arr));
        }

        public int minimumSwaps(int[] arr)
        {
            int swapCount = 0;
            int swapKoef = arr.Length;
            int bestIndex = -1;
            bool swap = true;

            //while (swap)
            //{
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != i + 1)
                    {
                        //int tempKoef = Math.Abs(i + 1 - arr[arr[i] - 1]);
                        //if (tempKoef < swapKoef)
                        //{
                        //    bestIndex = i;
                        //    swapKoef = tempKoef;
                        //}

                        swap = Swap(arr, i);
                        bestIndex = -1;
                        swapKoef = arr.Length;
                        if (swap) swapCount++;

                    if (arr[i] != i + 1) i--;
                    }
                }
                //swap = Swap(arr, bestIndex);
                //bestIndex = -1;
                //swapKoef = arr.Length;
                //if (swap) swapCount++;
            //}

            return swapCount;
        }
        private bool Swap(int[] arr, int i)
        {
            if (i >= 0)
            {
                int temp = arr[i];
                arr[i] = arr[temp - 1];
                arr[temp - 1] = temp;
                return true;
            }
            return false;
        }
    }
}
