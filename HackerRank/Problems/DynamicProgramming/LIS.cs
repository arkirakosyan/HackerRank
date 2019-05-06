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
            PrintArr(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0);
        }


        private void PrintArr(int[] arr, int i)
        {
            //if (i < arr.Length)
            //{
            //    Console.WriteLine(arr[i]);
            //    PrintArr(arr, i + 1);
            //}

            if (i < 10)
            {
                PrintArr(arr, i + 1);
                Console.WriteLine(i);
            }
        }

        //private int CalcLISLength(int[] arr, )
        //{

        //}


        private int GetAllSubSets(int[] arr, int k, List<int[]> subsets)
        {
            if (k == 0)
            {
                subsets.Add(new int[] { });
                return 0;
            }

            if (k == 1)
            {
                subsets.Add(new int[] { arr[k - 1] });
                return 1;
            }

           return GetAllSubSets(arr, k - 1, subsets)
        }
    }


}
