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
            var t = GenerateParenthesis(1);
        }

        public IList<string> GenerateParenthesis(int n)
        {
            List<string> l = new List<string>();
            if (n < 1) return l;
            GenerateParanthesesRecursive(n, "(",1, 0, l);
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
                        if(stack.Count == 0 || stack.Peek() != '(')
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
