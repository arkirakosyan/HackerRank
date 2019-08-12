using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class FirstMissingPositiveProblem : _ProblemBase
    {
        public override void MainRun()
        {
            Print(FirstMissingPositive(new int[] { 3, 4, -1, 1 }));
        }

        public int FirstMissingPositive(int[] nums)
        {
            LinkedList<int> l = new LinkedList<int>();

            

            int i = 0;
            while(i < nums.Length && nums[i] != 1)
            {
                i++;
            }
            if (i == nums.Length) return 1;
            if (nums.Length == 1) return 2;

            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= 0 || nums[i] > nums.Length)
                {
                    nums[i] = 1;
                }
            }

            for (i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i]) - 1] > 0)
                {
                    nums[Math.Abs(nums[i]) - 1] = -nums[Math.Abs(nums[i]) - 1];
                }
            }

            for (i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0) return i + 1;
            }

            return nums.Length + 1;
        }
    }
}
