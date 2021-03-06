﻿//**************** Max Score *****************//
//******************* 35 ********************//
//*******************************************//

using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Problems
{
    /// <summary>
    /// New Year Chaos
    /// </summary>
    public class NewYearChaos : _ProblemBase
    {
        public override void MainRun()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            List<string> bribesCount = new List<string>();

            for (int a0 = 0; a0 < T; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] q_temp = Console.ReadLine().Split(' ');
                int[] q = Array.ConvertAll(q_temp, Int32.Parse);
                if (q.Length != n) Console.WriteLine("Wring input");
                bribesCount.Add(BribesCount(q));
            }

            foreach (var bribe in bribesCount)
            {
                Console.WriteLine(bribe);
            }

        }

        private bool IsQueueValid(int[] queue)
        {
            return !queue.Where((t, i) => t - i > 3).Any();
        }

        private bool IsQueueStaibized(int[] queue)
        {
            bool stabile = true;
            for (int i = 0; i < queue.Length; i++)
            {
                if (queue[i] != i + 1)
                {
                    stabile = false;
                }
            }

            return stabile;
        }

        private string BribesCount(int[] queue)
        {
            if (!IsQueueValid(queue))
                return "Too chaotic";

            int bribes = 0;
            while (!IsQueueStaibized(queue))
            {
                for (int i = 0; i < queue.Length - 1; i++)
                {
                    if (queue[i] > queue[i + 1])
                    {
                        bribes++;
                        int t = queue[i + 1];
                        queue[i + 1] = queue[i];
                        queue[i] = t;
                    }
                }
            }
            return bribes.ToString();
        }
    }
}
