using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.GeekForGeeks
{
    public class MinJumps : _ProblemBase
    {
        public override void MainRun()
        {
            Print(CalcMinJumps(new int[] { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9, }));
        }

        private int CalcMinJumps(int[] arr)
        {
            int[] minJumps = new int[arr.Length];
            for (int i = 0; i < minJumps.Length; i++)
            {
                minJumps[i] = int.MaxValue;
            }

            minJumps[0] = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int c = 1; c <= arr[i]; c++)
                {
                    if(i + c < arr.Length)
                        minJumps[i + c] = Math.Min(minJumps[i + c], minJumps[i] + 1);
                }
            }

            return minJumps[arr.Length - 1];
        }
    }
}
