//**************** Max Score *****************//
//******************* 60 ********************//
//*******************************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public static class ArrayManipulations
    {
        public static void MainRun()
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            int[][] queries = new int[m][];

            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            long result = arrayManipulation(n, queries);

        }

        static long arrayManipulation(int n, int[][] queries)
        {

            long[] arr = new long[n];

            for (int i = 0; i < queries.Length; i++)
            {
                arr[queries[i][0] - 1] += queries[i][2];

                if (queries[i][1] < n)
                    arr[queries[i][1]] -= queries[i][2];
            }

            long max = 0;
            for (int i = 1; i < n; i++)
            {
                arr[i] += arr[i - 1];
                max = Math.Max(max, arr[i]);
            }

            PrintArray(arr);

            Console.WriteLine(max);
            return max;
        }

        static long arrayManipulationBadSolution(int n, int[][] queries)
        {

            int[] arr = new int[n];
            int max = 0;

            for (int i = 0; i < queries.Length; i++)
            {
                for (int k = queries[i][0] - 1; k <= queries[i][1] - 1; k++)
                {
                    arr[k] += queries[i][2];
                    max = Math.Max(max, arr[k]);
                }
            }
            return max;
        }

        static void PrintArray(long[] arr)
        {
            foreach (long a in arr)
            {
                Console.Write($"{a} ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }
    }
}
