using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class ThreeSum : _ProblemBase
    {
        public override void MainRun()
        {
            var x = ThreeSums(new int[] { 7, -1, 14, -12, -8, 7, 2, -15, 8, 8, -8, -14, -4, -5, 7, 9, 11, -4, -15, -6, 1, -14, 4, 3, 10, -5, 2, 1, 6, 11, 2, -2, -5, -7, -6, 2, -15, 11, -6, 8, -4, 2, 1, -1, 4, -6, -15, 1, 5, -15, 10, 14, 9, -8, -6, 4, -6, 11, 12, -15, 7, -1, -9, 9, -1, 0, -4, -1, -12, -2, 14, -9, 7, 0, -3, -4, 1, -2, 12, 14, -10, 0, 5, 14, -1, 14, 3, 8, 10, -8, 8, -5, -2, 6, -11, 12, 13, -7, -12, 8, 6, -13, 14, -2, -5, -11, 1, 3, -6 });
        }

        public IList<IList<int>> ThreeSums1(int[] nums)
        {
            IList<IList<int>> sumList = new List<IList<int>>();
            HashSet<string> hash = new HashSet<string>();

            List<int> numsList = new List<int>(nums);
            numsList.Sort();


            int l = 0;
            int r = numsList.Count;

            for (int i = 0; i < numsList.Count - 2; i++)
            {
                l = i;
                int sum = numsList[l] + numsList[r];


            }

            return sumList;
        }

        private int FindItem(List<int> list, int start, int end, int item)
        {
            int c = (end - start) / 2 + start;
            return 0;
        }
        public IList<IList<int>> ThreeSums(int[] nums)
        {
            IList<IList<int>> sumList = new List<IList<int>>();
            HashSet<string> hash = new HashSet<string>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            string key;
                            if (nums[i] < nums[j])
                            {
                                key = Math.Min(nums[i], nums[k]) + "_" + Math.Max(nums[i], Math.Min(nums[j], nums[k])) + "_" + Math.Max(nums[j], nums[k]);
                            }
                            else
                            {
                                key = Math.Min(nums[j], nums[k]) + "_" + Math.Max(nums[j], Math.Min(nums[i], nums[k])) + "_" + Math.Max(nums[i], nums[k]);
                            }

                            if (!hash.Contains(key))
                            {
                                hash.Add(key);
                                sumList.Add(new List<int> { nums[i], nums[j], nums[k] });
                            }
                        }
                    }
                }
            }

            return sumList;
        }
    }
}
