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
            var xyz = ThreeSums1(new int[] { 0,0 });


            var t9 = ThreeSums1(new int[] { -2, -1, 2, -4, -1, -1, -1, -5, -4, 3, -2, 0 });


            var t = ThreeSums1(new int[] {  0, 4, 0, -2, 3, 1, -5, 0});
            var y = ThreeSums1(new int[] { -2, 0, 1, 1, 2 });
            var x = ThreeSums1(new int[] { 7, -1, 14, -12, -8, 7, 2, -15, 8, 8, -8, -14, -4, -5, 7, 9, 11, -4, -15, -6, 1, -14, 4, 3, 10, -5, 2, 1, 6, 11, 2, -2, -5, -7, -6, 2, -15, 11, -6, 8, -4, 2, 1, -1, 4, -6, -15, 1, 5, -15, 10, 14, 9, -8, -6, 4, -6, 11, 12, -15, 7, -1, -9, 9, -1, 0, -4, -1, -12, -2, 14, -9, 7, 0, -3, -4, 1, -2, 12, 14, -10, 0, 5, 14, -1, 14, 3, 8, 10, -8, 8, -5, -2, 6, -11, 12, 13, -7, -12, 8, 6, -13, 14, -2, -5, -11, 1, 3, -6 });

            var xy = ThreeSums1(new int[] { -1, 0, 1, 2, -1, -4 });
        }

        public IList<IList<int>> ThreeSums1(int[] nums)
        {
            IList<IList<int>> sumList = new List<IList<int>>();
            if (nums.Length < 3) return sumList;
            HashSet<string> hash = new HashSet<string>();

            List<int> numsList = new List<int>(nums);
            numsList.Sort();

            for (int i = 0; i < numsList.Count - 2; i++)
            {
                int r = numsList.Count - 1;
                int sum = numsList[i] + numsList[r];
                if (numsList[i] == numsList[r])
                {
                    if (numsList[i] == 0 && !hash.Contains("0_0_0"))
                    {
                        sumList.Add(new List<int> { 0,0,0 });
                    }
                    return sumList;
                }
                while (--r > i)
                {
                    if (numsList[r] >=  -sum)
                    {
                        int foundIndex = FindItem(numsList, i + 1, r, -1 * sum);
                        if (foundIndex > 0)
                        {
                            string key = numsList[i] + "_" + numsList[foundIndex] + "_" + numsList[r + 1];
                            if (!hash.Contains(key))
                            {
                                sumList.Add(new List<int> { numsList[i], numsList[foundIndex], numsList[r + 1] });
                                hash.Add(key);
                            }
                        }
                    }
                    while (sum == numsList[i] + numsList[r] && r > i + 1)
                    {
                        r--;
                    }
                    sum = numsList[i] + numsList[r];
                }
            }

            return sumList;
        }

        private int FindItem(List<int> list, int start, int end, int item)
        {
            if (end < start) return -1;
            int c = (end - start) / 2 + start;

            if (item == list[c]) return c;
            if (item < list[c]) return FindItem(list, start, c - 1, item);
            if (item > list[c]) return FindItem(list, c + 1, end, item);

            return -1;
        }
        private string BuildKey(int a, int b, int c)
        {
                return Math.Min(a, c) + "_" + Math.Max(a, Math.Min(b, c)) + "_" + Math.Max(b, c);
            //return Math.Min(b, c) + "_" + Math.Max(b, Math.Min(a, c)) + "_" + Math.Max(a, c);
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
