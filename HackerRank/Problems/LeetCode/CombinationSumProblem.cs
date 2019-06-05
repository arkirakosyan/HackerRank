using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class CombinationSumProblem : _ProblemBase
    {
        public override void MainRun()
        {
            var t = CombinationSum2(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
        }
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Dictionary<int, int> uniqueCandidates = new Dictionary<int, int>();
            foreach (var candidate in candidates)
            {
                if (!uniqueCandidates.ContainsKey(candidate))
                {
                    uniqueCandidates.Add(candidate, 1);
                }
                else
                {
                    uniqueCandidates[candidate]++;
                }
            }

            return CombinationSumRecursive2(uniqueCandidates, uniqueCandidates.Keys.ToArray(), 0, target);
        }
        private IList<IList<int>> CombinationSumRecursive2(Dictionary<int, int> uniqueCandidates, int[] candidates, int start, int target)
        {
            List<IList<int>> results = new List<IList<int>>();
            if (target == 0)
            {
                results.Add(new List<int>());
                return results;
            }
            if (start == candidates.Length) return results;

            int candMaxCount = Math.Min( target / candidates[start], uniqueCandidates[candidates[start]]);

            while (candMaxCount > 0)
            {
                var prevResults = CombinationSumRecursive2(uniqueCandidates, candidates, start + 1, target - candMaxCount * candidates[start]);
                foreach (var list in prevResults)
                {
                    for (int i = 0; i < candMaxCount; i++)
                    {
                        list.Add(candidates[start]);
                    }
                }
                results.AddRange(prevResults);
                candMaxCount--;
            }

            results.AddRange(CombinationSumRecursive2(uniqueCandidates, candidates, start + 1, target));
            return results;
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            return CombinationSumRecursive(candidates, 0, target);
        }
        private IList<IList<int>> CombinationSumRecursive(int[] candidates, int start, int target)
        {
            List<IList<int>> results = new List<IList<int>>();
            if (target == 0)
            {
                results.Add(new List<int>());
                return results;
            }
            if (start == candidates.Length) return results;

            int candMaxCount = target / candidates[start];

            while (candMaxCount > 0)
            {
                var prevResults = CombinationSumRecursive(candidates, start + 1, target - candMaxCount * candidates[start]);
                foreach (var list in prevResults)
                {
                    for (int i = 0; i < candMaxCount; i++)
                    {
                        list.Add(candidates[start]);
                    }
                }
                results.AddRange(prevResults);
                candMaxCount--;
            }

            results.AddRange(CombinationSumRecursive(candidates, start + 1, target));
            return results;
        }
    }
}
