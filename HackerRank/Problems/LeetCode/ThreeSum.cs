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
            var y2 = FourSum(new int[] { -1, 0, 1, 2 }, 2);

            var y1 = FourSum(new int[] { 1, -2, -5, -4, -3, 3, 3, 5 }, -11);

            var y = FourSum(new int[] { -4, -2, 1, -5, -4, -4, 4, -2, 0, 4, 0, -2, 3, 1, -5, 0 }, 0);

            var x = ThreeSums(new int[] { 7, -1, 14, -12, -8, 7, 2, -15, 8, 8, -8, -14, -4, -5, 7, 9, 11, -4, -15, -6, 1, -14, 4, 3, 10, -5, 2, 1, 6, 11, 2, -2, -5, -7, -6, 2, -15, 11, -6, 8, -4, 2, 1, -1, 4, -6, -15, 1, 5, -15, 10, 14, 9, -8, -6, 4, -6, 11, 12, -15, 7, -1, -9, 9, -1, 0, -4, -1, -12, -2, 14, -9, 7, 0, -3, -4, 1, -2, 12, 14, -10, 0, 5, 14, -1, 14, 3, 8, 10, -8, 8, -5, -2, 6, -11, 12, 13, -7, -12, 8, 6, -13, 14, -2, -5, -11, 1, 3, -6 });
        }


        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> sumList = new List<IList<int>>();
            HashSet<string> hash = new HashSet<string>();

            List<int> list = new List<int>(nums);
            list.Sort();

            if (nums.Length < 4) return sumList;

            for (int l = 0; l < list.Count - 3; l++)
            {
                //if (list[l] > target) break;

                for (int r = list.Count - 1; r > l + 2; r--)
                {
                    if (list[r] < target) break;

                    int sum = list[l] + list[r];

                    int l1 = l + 1;
                    int r1 = r - 1;

                    while (l1 < r1)
                    {
                        int s = list[l1] + list[r1];
                        if (s + sum == target)
                        {
                            string key = $"{list[l]}_{list[l1]}_{list[r1]}_{list[r]}";
                            if (!hash.Contains(key))
                            {
                                sumList.Add(new List<int> { list[l], list[l1], list[r1], list[r] });
                                hash.Add(key);
                            }
                            do { r1--; } while (r1 > l1 && list[r1] == list[r1 + 1]);
                            do { l1++; } while (r1 > l1 && list[l1] == list[l1 - 1]);
                        }
                        else if (s + sum < target)
                        {
                            l1++;
                        }
                        else if (s + sum > target)
                        {
                            r1--;
                        }
                    }
                }
            }
            return sumList;
        }

        public IList<IList<int>> ThreeSums(int[] nums)
        {
            IList<IList<int>> sumList = new List<IList<int>>();
            HashSet<string> hash = new HashSet<string>();

            List<int> list = new List<int>(nums);
            list.Sort();

            if (nums.Length < 3) return sumList;

            for (int l = 0; l < list.Count - 2; l++)
            {
                int r = list.Count - 1;
                int m = l + 1;
                while (m < r)
                {
                    int sum = list[l] + list[m] + list[r];

                    if (sum > 0)
                    {
                        r--;
                    }
                    else if (sum < 0)
                    {
                        m++;
                    }
                    else if (sum == 0)
                    {
                        string key = list[l] + "_" + list[m] + "_" + list[r];
                        if (!hash.Contains(key))
                        {
                            sumList.Add(new List<int> { list[l], list[m], list[r] });
                            hash.Add(key);
                        }

                        if (list[m] == list[r]) break;
                        do { r--; } while (r > m && list[r] == list[r + 1]);
                        do { m++; } while (r > m && list[m] == list[m - 1]);
                    }
                }
            }
            return sumList;
        }

        private int FindItem(List<int> list, int start, int end, int item)
        {
            int c = (end - start) / 2 + start;
            return 0;
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            List<int> list = new List<int>(nums);
            list.Sort();

            if (nums.Length < 3) return -1;

            int closestSum = nums[0] + nums[1] + nums[2];
            int closestTarget = Math.Abs(target - closestSum);

            for (int l = 0; l < list.Count - 2; l++)
            {
                int r = list.Count - 1;
                int m = l + 1;
                while (m < r)
                {
                    int sum = list[l] + list[m] + list[r];
                    if (Math.Abs(target - sum) < closestTarget)
                    {
                        closestSum = sum;
                        closestTarget = Math.Abs(target - sum);
                    }

                    if (sum > target)
                        r--;
                    else if (sum < target)
                        m++;
                    else if (sum == target)
                        return sum;
                }
            }
            return closestSum;
        }
    }
}
