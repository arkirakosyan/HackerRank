using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class PermutationProblems : _ProblemBase
    {
        public override void MainRun()
        {
            var t = Permute(new int[] { 1, 2, 3 });
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> permutations = new List<IList<int>>();
            PermuteRecursive(nums, 0, permutations);

            return permutations;
        }

        public void PermuteRecursive(int[] nums, int fixedCount, IList<IList<int>> permutations)
        {
            if (nums.Length - fixedCount <= 1)
            {
                permutations.Add(nums.ToList());
                return;
            }

            for (int i = fixedCount; i < nums.Length; i++)
            {
                int temp = nums[fixedCount];
                nums[fixedCount] = nums[i];
                nums[i] = temp;

                int[] newArr = new int[nums.Length];
                Array.Copy(nums, newArr, nums.Length);
                PermuteRecursive(newArr, fixedCount + 1, permutations);
            }

        }
    }
}
