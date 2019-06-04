using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class ParenthesesProblems : _ProblemBase
    {
        public override void MainRun()
        {
            //Print(IsValid("([)]"));
            var t = LongestValidParentheses(")()())");
        }

        public int longestValidParentheses(String s)
        {
            int maxans = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxans = Math.Max(maxans, i - stack.Peek());
                    }
                }
            }
            return maxans;
        }

        public int LongestValidParentheses(string s)
        {
            int maxWellFormedLength = 0;
            int extraOpenScopesCount = 0;
            int extraCloseScopesCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    extraOpenScopesCount++;
                }
                else
                {
                    extraCloseScopesCount++;
                }

                if (extraOpenScopesCount == extraCloseScopesCount)
                {
                    maxWellFormedLength = Math.Max(2 * extraOpenScopesCount, maxWellFormedLength);
                }
                else if (extraCloseScopesCount > extraOpenScopesCount)
                {
                    extraOpenScopesCount = extraCloseScopesCount = 0;
                }
            }


            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')')
                {
                    extraCloseScopesCount++;
                }
                else
                {
                    extraOpenScopesCount++;
                }

                if (extraCloseScopesCount == extraOpenScopesCount)
                {
                    maxWellFormedLength = Math.Max(2 * extraOpenScopesCount, maxWellFormedLength);
                }
                else if(extraOpenScopesCount > extraCloseScopesCount)
                {
                    extraOpenScopesCount = extraCloseScopesCount = 0;
                }
            }

            return maxWellFormedLength;
        }


        public string LongestValidParentheses1(string s)
        {
            int extraOpenScopesCount = 0;
            int extraCloseScopesCount = 0;


            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    extraOpenScopesCount++;
                }
                else
                {
                    if (extraOpenScopesCount > 0)
                    {
                        extraOpenScopesCount--;
                    }
                    else
                    {
                        extraCloseScopesCount++;
                    }
                }
            }


            StringBuilder wellFormed = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                while (s[i] == '(' && extraOpenScopesCount > 0)
                {
                    i++;
                    extraOpenScopesCount--;
                }

                while (s[i] == ')' && extraCloseScopesCount > 0)
                {
                    i++;
                    extraCloseScopesCount--;
                }
                wellFormed.Append(s[i]);
            }

            return wellFormed.ToString();

        }


        public IList<string> GenerateParenthesis(int n)
        {
            List<string> l = new List<string>();
            if (n < 1) return l;
            GenerateParanthesesRecursive(n, "(", 1, 0, l);
            return l;
        }

        private void GenerateParanthesesRecursive(int n, string current, int openParCount, int closeParCount, IList<string> list)
        {
            if (openParCount > n || closeParCount > n) return;
            if (n == openParCount && n == closeParCount)
            {
                list.Add(current);
                return;
            }

            if (openParCount > closeParCount)
            {
                GenerateParanthesesRecursive(n, current + ")", openParCount, closeParCount + 1, list);
            }
            GenerateParanthesesRecursive(n, current + "(", openParCount + 1, closeParCount, list);
        }
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();


            foreach (char ch in s)
            {
                switch (ch)
                {
                    case '{':
                    case '[':
                    case '(':
                        stack.Push(ch);
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Peek() != '{')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Peek() != '[')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Peek() != '(')
                        {
                            return false;
                        }
                        stack.Pop();
                        break;
                }
            }

            return stack.Count == 0;
        }
    }
}
