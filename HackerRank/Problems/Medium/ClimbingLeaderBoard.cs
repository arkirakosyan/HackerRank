using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public class ClimbingLeaderBoard : _ProblemBase
    {
        public static void MainRun()
        {
            int scoresCount = Convert.ToInt32(Console.ReadLine());

            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
            ;
            int aliceCount = Convert.ToInt32(Console.ReadLine());

            int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
            ;
            int[] result = climbingLeaderboard(scores, alice);

            PrintHorizontal<int>(result);
        }

        private static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int[] aliceRanks = new int[alice.Length];
            int[] distinctScores = scores.Distinct().ToArray();

            int j = distinctScores.Length - 1;

            for (int i = 0; i < alice.Length; i++)
            {
                while (alice[i] >= distinctScores[j] && j > 0)
                {
                    j--;
                }

                if (j == 0)
                {
                    for (; i < alice.Length; i++)
                    {
                        aliceRanks[i] = 1;
                    }
                }
                else
                {
                    aliceRanks[i] = j + 2;
                }
            }

            return aliceRanks;
        }

    }
}
