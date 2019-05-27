using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class LetterCombinationsOfPhoneNumber : _ProblemBase
    {
        public override void MainRun()
        {
            var x = LetterCombinations("23");
        }

        public IList<string> LetterCombinations(string digits)
        {
            IList<string> list = new List<string>();

            if (digits.Length == 0) return list;

            Dictionary<char, char[]> dict = new Dictionary<char, char[]>();

            dict.Add('1', new char[] { });
            dict.Add('2', new char[] {'a', 'b', 'c' });
            dict.Add('3', new char[] { 'd', 'e', 'f' });
            dict.Add('4', new char[] { 'g', 'h', 'i' });
            dict.Add('5', new char[] { 'j', 'k', 'l' });
            dict.Add('6', new char[] { 'm', 'n', 'o' });
            dict.Add('7', new char[] { 'p', 'q', 'r', 's' });
            dict.Add('8', new char[] { 't', 'u', 'v' });
            dict.Add('9', new char[] { 'w', 'x', 'y', 'z' });

            list.Add("");

            IList<string> newList = new List<string>();

            StringBuilder strBuilder = new StringBuilder();
            
            foreach (char digit in digits)
            {
                foreach (char key in dict[digit])
                {
                    foreach (string str in list)
                    {
                        newList.Add(str + key.ToString());
                    }
                }
                list = newList;
                newList = new List<string>();
            }

            return list;
        }
    }
}
