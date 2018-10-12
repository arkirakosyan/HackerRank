//**************** Max Score *****************//
//******************* 80 ********************//
//*******************************************//

using System;

namespace HackerRank.Problems.Difficult
{
    /// <summary>
    /// Matrix Layer Rotation
    /// </summary>
    public static class MatrixLayerRotation
    {
        public static void MainRun(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            string[] mnr = Console.ReadLine().Split(' ');
            int M = Convert.ToInt32(mnr[0]);
            int N = Convert.ToInt32(mnr[1]);
            int R = Convert.ToInt32(mnr[2]);

            int[,] matrix = ReadMatrx(M, N);
            CycleItems(matrix, Math.Min(M, N) / 2, R);

            PrintMatrx(matrix);
        }

        private static int[,] ReadMatrx(int M, int N)
        {
            int[,] matrix = new int[M, N];
            for (int i = 0; i < M; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = Convert.ToInt32(row[j]);
                }
            }

            return matrix;
        }
        private static void PrintMatrx(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        private static void CycleItems(int[,] matrix, int cyclesCount, int rank)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);

            for (int level = 0; level < cyclesCount; level++)
            {
                int cicleLength = 2 * (M + N - 2 - 4 * level);

                int[] arr_Cycle = new int[cicleLength];

                int k = 0;
                for (int i = level; i < N - level; i++)
                {
                    arr_Cycle[k] = matrix[level, i];
                    k++;
                }
                for (int i = level + 1; i < M - level; i++)
                {
                    arr_Cycle[k] = matrix[i, N - level - 1];
                    k++;
                }
                for (int i = N - level - 2; i >= level; i--)
                {
                    arr_Cycle[k] = matrix[M - level - 1, i];
                    k++;
                }
                for (int i = M - level - 2; i > level; i--)
                {
                    arr_Cycle[k] = matrix[i, level];
                    k++;
                }
                //////////////////////////////////////////////////////////
                k = 0;
                for (int i = level; i < N - level; i++)
                {
                    matrix[level, i] = arr_Cycle[(k + rank % cicleLength) % cicleLength];
                    k++;
                }
                for (int i = level + 1; i < M - level; i++)
                {
                    matrix[i, N - level - 1] = arr_Cycle[(k + rank % cicleLength) % cicleLength];
                    k++;
                }
                for (int i = N - level - 2; i >= level; i--)
                {
                    matrix[M - level - 1, i] = arr_Cycle[(k + rank % cicleLength) % cicleLength];
                    k++;
                }
                for (int i = M - level - 2; i > level; i--)
                {
                    matrix[i, level] = arr_Cycle[(k + rank % cicleLength) % cicleLength];
                    k++;
                }
            }
        }
     
    }
}
