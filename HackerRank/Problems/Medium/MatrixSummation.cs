using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Medium
{
    public class MatrixSummation : _ProblemBase
    {
        public override void MainRun()
        {
            int[,] m = new int[3, 3] { { 2, 5, 9 }, { 7, 16, 27 }, { 15, 33, 54 } };

            int[,] o = GetBeforeMatrix(m);
        }

        public int[,] GetBeforeMatrix(int[,] afterMatrix)
        {
            int[,] beforeMatrix = new int[afterMatrix.Rank + 1, afterMatrix.Rank + 1];

            for (int i = 0; i <= afterMatrix.Rank; i++)
            {
                for (int j = 0; j <= afterMatrix.Rank; j++)
                {
                    beforeMatrix[i, j] = CalcBefore(i, j, beforeMatrix, afterMatrix);
                }
            }
            return beforeMatrix;
        }

        private int CalcBefore(int i, int j, int[,] beforeMatrix, int[,] afterMatrix )
        {
            if (i == 0 && j == 0) return afterMatrix[0,0];

            if (i == 0)
            {
                return afterMatrix[i, j] - afterMatrix[i, j - 1];
            }

            if (j == 0)
            {
                return afterMatrix[i, j] - afterMatrix[i - 1, j];
            }

            int d = afterMatrix[i, j] - afterMatrix[i - 1, j];
            int s = 0;

            for (int k = 0; k <= j; k++)
            {
                s += beforeMatrix[i, k];
            }

            return d - s;
        }
    }
}
