using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Medium
{
    public class ACMICPCTeam : _ProblemBase
    {

        public static void MainRun()
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            string[] topic = new string[n];

            for (int i = 0; i < n; i++)
            {
                string topicItem = Console.ReadLine();
                topic[i] = topicItem;
            }

            int[] result = acmTeam(topic);

            PrintVertical(result);
        }

        static int[] acmTeam(string[] topic)
        {

            int maxMatchCount = 0;
            int maxCount = 0;

            for (int i = 0; i < topic.Length - 1; i++)
            {
                for (int j = i + 1; j < topic.Length; j++)
                {
                    int matchCount = MatchCount(topic[i], topic[j]);
                    if (matchCount > maxMatchCount)
                    {
                        maxMatchCount = matchCount;
                        maxCount = 1;
                    }
                    else if (matchCount == maxMatchCount)
                    {
                        maxCount++;
                    }
                }

            }
            return new int[2] { maxMatchCount, maxCount };
        }

        private static int MatchCount(string a, string b)
        {
            int maxCount = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] + b[i] > 96)
                {
                    maxCount++;
                }
            }
            return maxCount;
        }

    }
}
