using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class RemoveInvalidParentheses : _ProblemBase
    {
        public override void MainRun()
        {
            string input = Console.ReadLine();

            input = TrimParentheses(input);

            List<int> leftParenthesIndexes = new List<int>();
            List<int> rightParenthesIndexes = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '(':
                        leftParenthesIndexes.Add(i);
                        break;
                    case ')':
                        rightParenthesIndexes.Add(i);
                        break;
                }
            }

            if (rightParenthesIndexes.Count > leftParenthesIndexes.Count)
            {
                int incorrectCount = rightParenthesIndexes.Count - leftParenthesIndexes.Count;

                List<byte[]> incorrectList = GetAllSubsetsOfK(rightParenthesIndexes.Count, incorrectCount);

                foreach (byte[] set in incorrectList)
                {

                }
            }

        }
        private string TrimParentheses(string s)
        {
            bool extraParenth = s.Length > 0 && (s[0] == ')' || s[s.Length - 1] == '(');

            int suffixCount = 0;
            int prefxCount = 0;
            int i = 0;

            while (i < s.Length && extraParenth)
            {
                if (s[i] == ')')
                    prefxCount++;
                else if (s[s.Length - i] == '(')
                    suffixCount++;

                i++;
                extraParenth = s[i] == ')' || s[s.Length - i] == '(';
            }

            return s.Substring(prefxCount, s.Length - suffixCount);
        }

        private string TrimSuffixParentheses(string s)
        {
            int i = 0;
            while (s[i++] == ')')
            { }

            return s.Substring(i);
        }

        private string TrimPrefixParentheses(string s)
        {
            int i = s.Length - 1;
            while (s[i--] == '(')
            { }

            return s.Substring(0, s.Length - i);
        }

        public List<byte[]> GetAllSubsetsOfK(int n, int k)
        {
            List<byte[]> newXList = new List<byte[]>();

            if (n <= k)
            {
                var x = new byte[n];
                for (int i = 0; i < k; i++)
                    x[i] = 1;

                newXList.Add(x);
                return newXList;
            }

            var prevXList = GetAllSubsetsOfK(n - 1, k);

            Dictionary<string, byte[]> newXListLong = new Dictionary<string, byte[]>();

            foreach (var prevX in prevXList)
            {
                //PrintLine($"Prev: {string.Join(", ", prevX)}");

                int oneFound = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    if (prevX[i] == 1)
                    {
                        oneFound++;

                        byte[] newX = CopyArrayExtendted(prevX, i);

                        string xNewLong = BitConverter.ToString(newX, 0);

                        if (!newXListLong.ContainsKey(xNewLong))
                        {
                            newXListLong.Add(xNewLong, newX);
                            newXList.Add(newX);
                            //if(n== N)
                            //PrintArrHorizontal(newX);
                        }

                        if (oneFound == k)
                        {
                            newX = CopyArrayExtendted(prevX, prevX.Length);
                            xNewLong = BitConverter.ToString(newX, 0);

                            if (!newXListLong.ContainsKey(xNewLong))
                            {
                                newXListLong.Add(xNewLong, newX);
                                newXList.Add(newX);
                                //if(n== N)
                                //PrintArrHorizontal(newX);
                            }
                        }
                    }
                }
            }
            return newXList;
        }

        public byte[] CopyArrayExtendted(byte[] arr, int index)
        {
            byte[] newArr = new byte[arr.Length + 1];

            int oneAdded = 0;
            for (int j = 0; j <= arr.Length; j++)
            {
                if (j == index)
                {
                    newArr[j] = 0;
                    if (++j > arr.Length)
                        break;
                    newArr[j] = arr[j - 1];
                    oneAdded++;
                }
                else
                {
                    newArr[j] = arr[j - oneAdded];
                }
            }

            return newArr;
        }

        public bool ValidateParentheses(List<int> left, List<int> right)
        {
            if (right.Count != left.Count) return false;

            for (int i = 0; i < right.Count; i++)
            {
                if (right[i] < left[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
