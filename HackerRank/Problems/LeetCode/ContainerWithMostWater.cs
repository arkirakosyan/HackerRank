using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class ContainerWithMostWater : _ProblemBase
    {
        public override void MainRun()
        {
            Print(MaxArea1(new int[] { 1,8,6,2,5,4,8,3,7}));
            Print(MaxArea1(new int[] { 2, 3, 10, 5, 7, 8, 9 }));
        }

        public int MaxArea(int[] height)
        {
            int maxArea = 0;

            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    maxArea = Math.Max(maxArea, (j - i) * Math.Min(height[i], height[j]));
                }
            }

            return maxArea;
        }

        public int MaxArea1(int[] height)
        {
            int maxArea = 0;
            int l = 0;
            int r = height.Length - 1;

            while (l < r)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] > height[r])
                {
                    r--;
                }
                else
                {
                    l++;
                }
            }
            return maxArea;
        }
    }
}
