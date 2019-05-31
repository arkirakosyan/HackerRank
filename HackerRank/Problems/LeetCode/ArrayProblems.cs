using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class ArrayProblems : _ProblemBase
    {
        public override void MainRun()
        {
           Print( RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
        }

        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            int j = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != nums[j - 1])
                    nums[j++] = nums[i];
            }
            return j;
        }

        public int RemoveElement(int[] nums, int val)
        {
            int j = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[j++] = nums[i];
                }
            }
            return j;
        }
    }
}
