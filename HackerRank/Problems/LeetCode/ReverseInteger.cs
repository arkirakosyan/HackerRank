using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class ReverseInteger : _ProblemBase
    {
        public override void MainRun()
        {
            Print(Reverse(-878454));
        }

        public int Reverse(int x)
        {

            int sign = x > 0 ? 1 : -1;
            long y = 0;
            x *= sign;
            while (x > 0)
            {
                y = y * 10 + x % 10;
                x = x / 10;
            }
            y = sign * y;
            return y <= int.MaxValue && y >= int.MinValue ? (int)y : 0;
        }
    }
}
