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
            // Print( RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
            NextPermutation(new int[] { 5, 4, 7, 5, 3, 2 });
        }

        //public int FirstMissingPositive(int[] nums)
        //{
        //    int index = nums[0] + 1;

        //    for (int i = 1; i < nums.Length; i++)
        //    {

        //       if( nums[index] == 
        //    }
        //}

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

        public void NextPermutation(int[] nums)
        {
            int count = nums.Length;

            int left = 0;
            int right;
            bool descOrdered = true;
            for (int i = count - 1; i > 0; i--)
            {
                if (nums[i] > nums[i - 1])
                {
                    left = i - 1;
                    descOrdered = false;
                    break;
                }
            }


            if (descOrdered)
            {
                for (int i = 0; i < count / 2; i++)
                {
                    int temp1 = nums[i];
                    nums[i] = nums[count - i - 1];
                    nums[count - i - 1] = temp1;
                }
                return;
            }
            right = left;
            while (right + 1 < count && nums[right + 1] > nums[left])
            {
                right++;
            }

            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;

            for (int i = left + 1; i <left + (count - left + 1) / 2; i++)
            {
                int temp1 = nums[i];
                nums[i] = nums[count - i + left];
                nums[count - i + left]= temp1;
            }
        }
    }
}
