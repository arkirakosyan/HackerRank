using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public class Scopes : _ProblemBase
    {
        public static void MainRun()
        {
            GenerateParens(4);
        }
        private static void AddParen(List<string> list, int leftRem, int rightRem, char[] str, int index)
        {
            if (leftRem < 0 || rightRem < leftRem) return;

            if (leftRem == 0 && rightRem == 0)
                list.Add(new string(str));
            else
            {
                str[index] = '(';
                AddParen(list, leftRem - 1, rightRem, str, index + 1);

                str[index] = ')';
                AddParen(list, leftRem, rightRem - 1, str, index + 1);
            }
        }

        private static List<string> GenerateParens(int count)
        {
            char[] str = new char[count * 2];
            List<string> list = new List<string>();
            AddParen(list, count, count, str, 0);

            PrintArrVertical<string>(list);
            return list;
        }
    }
}
