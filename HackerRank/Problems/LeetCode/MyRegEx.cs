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
            //Print(IsMatch1("bbab", "b*a*"));

            Print(IsMatch("bbab", "b*a*"));  Print(IsMatch1("bbab", "b*a*"));
            Console.WriteLine();

            Print(IsMatch("abbabaaaaaaacaa", "a*.*b.a.*c*b*a*c*")); Print(IsMatch1("abbabaaaaaaacaa", "a*.*b.a.*c*b*a*c*"));
            Console.WriteLine();
            Print(IsMatch("abbabaaaaaaacaa", "a*.*b.a.*c*b*a*")); Print(IsMatch1("abbabaaaaaaacaa", "a*.*b.a.*c*b*a*"));
            Console.WriteLine();
            Print(IsMatch("aa", "a*c*")); Print(IsMatch1("aa", "a*c*"));
            Console.WriteLine();

            Print(IsMatch("bbab", "a*.*b")); Print(IsMatch1("bbab", "a*.*b"));
            Console.WriteLine();

            Print(IsMatch("a", "ac*")); Print(IsMatch1("a", "ac*"));
            Console.WriteLine();

            Print(IsMatch("a", "ab*a")); Print(IsMatch1("a", "ab*a"));
            Console.WriteLine();

            Print(IsMatch("aa", "a*")); Print(IsMatch1("aa", "a*"));
            Console.WriteLine();

            Print(IsMatch("aaa", "a.a")); Print(IsMatch1("aaa", "a.a"));
            Console.WriteLine();

            Print(IsMatch("mississippi", ".")); Print(IsMatch1("mississippi", "."));
            Console.WriteLine();
            Print(IsMatch("pi", "p*.")); Print(IsMatch1("pi", "p*."));
            //Print(IsMatch("ii", "s*."));
            Console.WriteLine();



            Print(IsMatch("aaaaab", ".a..aa*b")); Print(IsMatch1("aaaaab", ".a..aa*b"));
            Console.WriteLine();
            Print(IsMatch("ab", "a*b")); Print(IsMatch1("ab", "a*b"));
            Console.WriteLine();

            Print(IsMatch("a", "ab*")); Print(IsMatch1("a", "ab*"));
            Console.WriteLine();
            Print(IsMatch("a", ".*")); Print(IsMatch1("a", ".*"));
            Console.WriteLine();
            Print(IsMatch("a", ".*..a*")); Print(IsMatch1("a", ".*..a*"));
        }

        public bool IsMatch1(string s, string p)
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
                        if (sIndex <= s.Length && IsMatch1(s.Substring(sIndex), p.Substring(i + 2)))
                        {
                            return true;
                        }
                    }
                    while (sIndex < s.Length && (s[sIndex] == p[i] || p[i] == '.') && ++sIndex > 0);
                    return false;
                }
                else
                {
                    if (sIndex >= s.Length || (p[i] != '.' && s[sIndex] != p[i])) return false;
                    sIndex++;
                }
            }

            return p == s || (sIndex == s.Length && (p.Length == i || (p.Length - i == 2 && p[i + 1] == '*')));
        }

        public bool IsMatch(string s, string p)
        {
            return IsMatch(s, p, new Dictionary<string, bool>());
        }

        private bool IsMatch(string s, string p, Dictionary<string, bool> memo)
        {
            string key = s + "_" + p;
            if (s == p ) return true;

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            int sIndex = 0;
            int i = 0;
            int sLength = s.Length;
            int pLength = p.Length;

            for (i = 0; i < pLength; i++)
            {
                if (i < pLength - 1 && p[i + 1] == '*')
                {
                    do
                    {
                        if (sIndex <= sLength && IsMatch(s.Substring(sIndex), p.Substring(i + 2), memo))
                        {
                            memo[key] = true;
                            return true;
                        }
                    }
                    while (sIndex < sLength && (s[sIndex++] == p[i] || p[i] == '.'));
                    memo[key] = false;
                    return false;
                }
                else
                {
                    if (sIndex >= sLength || (p[i] != '.' && s[sIndex] != p[i]))
                    {
                        memo[key] = false;
                        return false;
                    }
                    sIndex++;
                }
            }

            memo[key] = p == s || sIndex == sLength;
            return memo[key];
        }
    }
}

