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
            Print(IsMatch("abbabaaaaaaacaa", "a*.*b.a.*c*b*a*c*"));
            Print(IsMatch("abbabaaaaaaacaa", "a*.*b.a.*c*b*a*"));
            Print(IsMatch("aa", "a*c*"));

            Print(IsMatch("bbab", "a*.*b"));

            Print(IsMatch("a", "ac*"));

            Print(IsMatch("a", "ab*a"));

            Print(IsMatch("aa", "a*"));

            Print(IsMatch("aaa", "a.a"));

            Print(IsMatch("mississippi", "."));
            Print(IsMatch("pi", "p*."));
            //Print(IsMatch("ii", "s*."));


            Print(IsMatch("aaaaab", ".a..aa*b"));
            Print(IsMatch("ab", "a*b"));

            Print(IsMatch("a", "ab*"));
            Print(IsMatch("a", ".*"));
            Print(IsMatch("a", ".*..a*"));
        }

        public bool IsMatch(string s, string p)
        {
            if (s == p || (s.Length == 1 && p == ".")) return true;

            int sIndex = 0;
            int i = 0;
            for (i = 0; i < p.Length; i++)
            {
                if (i < p.Length - 1 && p[i + 1] == '*')
                {
                    do
                    {
                        if (sIndex <= s.Length && IsMatch(s.Substring(sIndex), p.Substring(i + 2)))
                        {
                            return true;
                        }
                    }
                    while (sIndex < s.Length && (s[sIndex++] == p[i] || p[i] == '.'));
                    break;
                }
                else
                {
                    if (sIndex >= s.Length || (p[i] != '.' && s[sIndex] != p[i])) return false;
                    sIndex++;
                }
            }

            return p == s || (sIndex == s.Length && (p.Length == i || (p.Length - i == 2 && p[i + 1] == '*')));
        }

            public bool IsMatch(string s, string p, Dictionary<string, bool> memo)
            {
                string key = s +"_"+ p;

                if (memo.ContainsKey(key))
                {
                    return memo[key];
                }
                if (s == p || (s.Length == 1 && p == "."))
                {
                    memo[key] = true;
                    return true;
                };



                int sIndex = 0;
                int i = 0;
                for (i = 0; i < p.Length; i++)
                {
                    if (i < p.Length - 1 && p[i + 1] == '*')
                    {
                        do
                        {
                            if (sIndex <= s.Length && IsMatch(s.Substring(sIndex), p.Substring(i + 2), memo))
                            {
                                memo[key] = true;
                                return true;
                            }
                        }
                        while (sIndex < s.Length && (s[sIndex++] == p[i] || p[i] == '.'));
                        break;
                    }
                    else
                    {
                        if (sIndex >= s.Length || (p[i] != '.' && s[sIndex] != p[i]))
                        {
                            memo[key] = false;
                            return false;
                        } 
                        sIndex++;
                    }
                }

                memo[key] = p == s || (sIndex == s.Length && (p.Length == i || (p.Length - i == 2 && p[i + 1] == '*')));
                return memo[key];

            }
    }
}

