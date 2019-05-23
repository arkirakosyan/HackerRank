using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class MyRegEx : _ProblemBase
    {
        public override void MainRun()
        {
            Print(IsMatch("aab", "c*a*b"));
        }

        public bool IsMatch(string s, string p)
        {
            int sIndex = 0;

            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] >= 'a' && p[i] <= 'z')
                {
                    if (i < p.Length - 1 && p[i + 1] == '*')
                    {
                        if (i < p.Length - 2)
                        {
                            do
                            {
                                if (IsMatch(s.Substring(sIndex), p.Substring(i + 2)))
                                {
                                    return true;
                                }
                            }
                            while (s[sIndex++] == s[i]);
                          
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (s[sIndex] != p[i] || (++sIndex >= s.Length && i + 1 < p.Length)) return false;
                    }
                }
                else if (p[i] == '.')
                {
                    if (i < p.Length - 1 && p[i + 1] == '*')
                    {
                        if (i < p.Length - 2)
                        {
                            while (s[sIndex] == s[i])
                            {
                                if (IsMatch(s.Substring(sIndex++), p.Substring(i + 2)))
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if(++sIndex > s.Length && i + 1 < p.Length) return false;
                    }
                }

            }

            return sIndex == s.Length;
        }
    }
}

