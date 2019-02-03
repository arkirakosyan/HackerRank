using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Arrays
{
    public class MergeSort : _ProblemBase
    {
        public override void MainRun()
        {
            throw new NotImplementedException();
        }

        //private int[] Sort(int[] arr)
        //{
        //    if (arr.Length == 1)
        //        return arr;

        //    int halfSize = arr.Length / 2;

        //    //return MergeSortedArrays()
        //}

        private int[] MergeSortedArrays(int[] x, int[] y)
        {
            int[] output = new int[x.Length + y.Length];
            int xi = 0;
            int yi = 0;

            for (int i = 0; i < output.Length; i++)
            {
                if (xi == x.Length)
                {
                    output[i] = y[yi++];
                }
                else if (yi == y.Length)
                {
                    output[i] = x[xi++];
                }
                else
                {
                    output[i] = x[xi] < y[yi] ? x[xi++] : y[yi++];
                }
            }

            return output;
        }
    }
}
