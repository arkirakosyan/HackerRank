using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class StringToInteger : _ProblemBase
    {
        public override void MainRun()
        {
            Print((-189).ToString());
            Print(MyAtoi("+1"));
        }

        private int MyAtoi(string str)
        {
            long x = 0;
            int state = 0;
            int sign = 1;

            for (int i = 0; i < str.Length; i++)
            {
                switch (state)
                {
                    case 0:
                        if (str[i] == ' ')
                        {
                            continue;
                        }
                        else if (str[i] == '-' || str[i] == '+')
                        {
                            if (i < str.Length - 1)
                            {
                                if (str[i + 1] >= '0' && str[i + 1] <= '9')
                                {
                                    state = 1;
                                    sign = str[i] == '-' ? -1 : 1;
                                    x = sign * (str[++i] - '0');
                                    continue;
                                }
                            }
                            return 0;
                        }
                        else if (str[i] >= '0' && str[i] <= '9')
                        {
                            state = 1;
                            x = str[i] - '0';
                        }
                        else
                        {
                            return 0;
                        }
                        break;
                    case 1:
                        if (str[i] >= '0' && str[i] <= '9')
                        {
                            x = x * 10 + sign*(str[i] - '0');
                        }
                        else
                        {
                            i = str.Length;
                        }
                        break;
                }
                if(x > int.MaxValue || x < int.MinValue)
                {
                    break;
                }
            }

            if (x > int.MaxValue) return int.MaxValue;
            if (x < int.MinValue) return int.MinValue;
            return (int)x;
        }
    }
}
