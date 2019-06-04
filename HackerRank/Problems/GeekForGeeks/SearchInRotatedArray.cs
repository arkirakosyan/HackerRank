
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.GeekForGeeks
{
    public class SearchInRotatedArray : _ProblemBase
    {
        public override void MainRun()
        {
            //int testsCount = Convert.ToInt32(Console.ReadLine());
            //for (int i= 0; i < testsCount; i++)
            //{
            //    int arrLength = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), x => Convert.ToInt32(x));
            //    int number = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine(GetNumberIndex(arr, number));
            //}
            int[] x = SearchRange(new int[] { 1, 3, 5, 6 },2);

            Print(x);
        }

        public int[] SearchRange(int[] nums, int target)
        {
            int pivot = FindAny(nums, 0, nums.Length - 1, target);
            if(pivot == -1)
            {
                return new int[] { -1, -1 };
            }

            int left = pivot;
            int right = pivot;

            while (left - 1 >= 0 && nums[left - 1] == nums[pivot])
            {
                left--;
            }

            while (right + 1 < nums.Length && nums[right + 1] == nums[pivot])
            {
                right++;
            }

            return new int[] { left, right };
        }

        public int FindAny(int[] nums, int start, int end, int target)
        {
            if (start > end) return -1;

            int pivot = start + (end - start) / 2;

            if (nums[pivot] == target)
            {
                return pivot;
            }

            if (nums[pivot] > target)
            {
                return FindAny(nums, start, pivot - 1, target);
            }
            return FindAny(nums, pivot + 1, end, target);
        }


        public int GetNumberIndex(int[] arr, int number)
        {
            int rotationIndex = FindRotationIndex(arr, 0, arr.Length - 1);
            int rotationCount = (rotationIndex > 0) ? arr.Length - rotationIndex : 0;
            return FindNumberIndexRecursive(arr, number, 0, arr.Length - 1, rotationCount);
        }
        private int FindNumberIndexRecursive(int[] arr, int number, int start, int end, int rotationCount)
        {
            if (start > end) return -1;

            int checkIndex = start + (end - start) / 2 - rotationCount;
            if (checkIndex < 0)
            {
                checkIndex += arr.Length;
            }

            if (arr[checkIndex] == number)
            {
                return checkIndex;
            }
            else if (arr[checkIndex] > number)
            {
                return FindNumberIndexRecursive(arr, number, start, start + (end - start) / 2 - 1, rotationCount);
            }
            else
            {
                return FindNumberIndexRecursive(arr, number, start + (end - start) / 2 + 1, end, rotationCount);
            }
        }
        private int FindRotationIndex(int[] arr, int start, int end)
        {
            if (arr.Length == 1 || start > end) return -1;

            int checkIndex = start + (end - start) / 2;
            if (checkIndex > 0 && arr[checkIndex - 1] > arr[checkIndex])
            {
                return checkIndex;
            }

            if (checkIndex - 1 > 0 && arr[0] > arr[checkIndex - 1])
            {
                return FindRotationIndex(arr, start, checkIndex - 1);
            }

            return FindRotationIndex(arr, checkIndex + 1, end);

        }
    }

}
