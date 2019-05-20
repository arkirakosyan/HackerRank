using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.GeekForGeeks
{
    public class AllPermutions : _ProblemBase
    {
        int count = 0;

        public override void MainRun()
        {
            List<string> aa = new List<string>();
            //GetPermutions("ABCD", 0, aa);
            string str = "ABCD";
            //permute("ABCD", 0, str.Length - 1);

            GetPermutions("ABCD","",aa);
        }

        public void GetPermutions(string str, string fixedChars, List<string> permutions)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(fixedChars);
                permutions.Add(fixedChars);
                return;
            }

            for (int i = 0; i < str.Length; i++)
            {
                GetPermutions(str.Substring(0,i) + str.Substring(i + 1), fixedChars + str[i], permutions);
            }
        }
        private static void permutation(String prefix, String str)
        {
            int n = str.Length;
            if (n == 0) Console.WriteLine(prefix);
            else
            {
                for (int i = 0; i < n; i++)
                    permutation(prefix + str[i], str.Substring(0, i) + str.Substring(i + 1));
            }
        }
        private void permute(String str, int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }

        public static String swap(String a,
                              int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }
        //public List<string> GetPermutions(string str, int n)
        //{
        //    if (n == 0)
        //    {
        //        return new List<string>();
        //    }
        //}
    }
}
