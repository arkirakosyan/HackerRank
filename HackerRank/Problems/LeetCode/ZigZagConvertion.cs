using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class ZigZagConvertion : _ProblemBase
    {
        public override void MainRun()
        {
            Print(Convert("A", 1));
        }

        private string Convert(string str, int numRows)
        {
            if (numRows < 1 || string.IsNullOrEmpty(str) || numRows > str.Length) return str;

            StringBuilder[] rowBuilder = new StringBuilder[numRows];
            bool topDown = true;
            for (int i = 0; i < str.Length; i++)
            {
                int k = i % (numRows - 1);
                if (i > 0 && topDown && k == 0)
                {
                    topDown = false;
                }
                else if (!topDown && k == 0)
                {
                    topDown = true;
                }

                int row = topDown ? k : (numRows - 1) - k;

                if (rowBuilder[row] == null)
                {
                    rowBuilder[row] = new StringBuilder();
                }
                rowBuilder[row].Append(str[i]);
            }

            StringBuilder convertedString = new StringBuilder();
            foreach (StringBuilder s in rowBuilder)
            {
                convertedString.Append(s.ToString());
            }

            return convertedString.ToString();
        }
    }
}
