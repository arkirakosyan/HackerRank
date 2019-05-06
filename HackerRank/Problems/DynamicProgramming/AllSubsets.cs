using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.DynamicProgramming
{
    public class AllSubsets : _ProblemBase
    {
        public override void MainRun()
        {
            List<int[]> subsets = new List<int[]>();
            GetAllSubsets(new int[] { 1, 2, 3, 4 }, 3, int.MaxValue, subsets);


            foreach (var set in subsets)
            {
                PrintArrHorizontal(set);
            }

            foreach (var t in recRequests)
            {
                PrintLine(t);
            }
        }

        public List<int> recRequests = new List<int>();
        public List<int[]> GetAllSubsets(int[] set, int i, int maxSubSetLength)
        {
            recRequests.Add(i);

            if (i == 0)
            {
                var x = new List<int[]>();
                x.Add(new int[] { });
                x.Add(new int[] { set[0] });
                return x;
            }

            var list = GetAllSubsets(set, i - 1, maxSubSetLength);

            int prevItemsCount = list.Count;
            for (int j = 0; j < prevItemsCount; j++)
            {
                if (list[j].Length < maxSubSetLength)
                {
                    int[] newSubSet = new int[(list[j]).Length + 1];
                    for (int k = 0; k < newSubSet.Length - 1; k++)
                    {
                        newSubSet[k] = list[j][k];
                    }
                    newSubSet[newSubSet.Length - 1] = set[i];

                    list.Add(newSubSet);
                }
            }

            return list;
        }

        public void GetAllSubsets(int[] set, int i, int maxSubSetLength, List<int[]> subsets)
        {
            if (i == 0)
            {
                subsets.Add(new int[] { });
                subsets.Add(new int[] { set[0] });
                return;
            }
            GetAllSubsets(set, i - 1, maxSubSetLength, subsets);
            int prevItemsCount = subsets.Count;
            for (int j = 0; j < prevItemsCount; j++)
            {
                if (subsets[j].Length < maxSubSetLength)
                {
                    int[] newSubSet = new int[(subsets[j]).Length + 1];
                    for (int k = 0; k < newSubSet.Length - 1; k++)
                    {
                        newSubSet[k] = subsets[j][k];
                    }
                    newSubSet[newSubSet.Length - 1] = set[i];
                    subsets.Add(newSubSet);
                }
            }
        }
    }
}
