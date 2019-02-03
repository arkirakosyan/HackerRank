using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Arrays
{
    public class MergeSortedArrays : _ProblemBase
    {
        public override void MainRun()
        {
            int[] a = new int[] { 1, 2, 5, 7, 8 };
            int[] b = new int[] { 2, 3, 4, 9, 9, 16 };
            PrintArrHorizontal(MergeWithoutDuplicates(a, b));
            PrintArrHorizontal(Merge(a, b));


        }

        private int[] Merge(int[] x, int[] y)
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

        private int[] MergeWithoutDuplicates(int[] x, int[] y)
        {
            List<int> output = new List<int>();

            int xi = 0;
            int yi = 0;
            while(xi + yi < x.Length + y.Length )
            {
                int nextVal;

                if (xi == x.Length)
                {
                    nextVal = y[yi++];
                }
                else if (yi == y.Length)
                {
                    nextVal = x[xi++];
                }
                else
                {
                    nextVal = x[xi] < y[yi] ? x[xi++] : y[yi++];
                }

                if (!output.Any() || output.Last() < nextVal)
                {
                    output.Add(nextVal);
                }
            }

            return output.ToArray();
        }
    }
}
