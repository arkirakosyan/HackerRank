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
            permute("ABCD", 0, str.Length - 1);
        }
        
        public void GetPermutions(string str, int startIndex, List<string> permutions)
        {
            char[] strArr = str.ToArray();

            //for (int i = startIndex; i < str.Length - 1; i++)
            //{

            int i = startIndex;
            for (int j = i + 1; j < str.Length; j++)
            {
                GetPermutions(str, startIndex + 1, permutions);

                char temp = strArr[i];
                strArr[i] = strArr[j];
                strArr[j] = temp;
                count++;
                string newPermution = new string(strArr);
                permutions.Add(newPermution);
                GetPermutions(newPermution, startIndex + 1, permutions);
                strArr = str.ToArray();
            }
        }

        private  void permute(String str,  int l, int r)
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
