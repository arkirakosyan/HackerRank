using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class ValidParentheses : _ProblemBase
    {
        public override void MainRun()
        {
            Print(IsValid("([)]"));
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
