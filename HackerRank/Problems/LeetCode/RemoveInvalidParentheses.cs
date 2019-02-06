using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class RemoveInvalidParentheses : _ProblemBase
    {



       

     void BinaryIncrement()
    {
        for (int i = n - 1; i >= 0; i--)
        {
            if (binary[i] == 0)
            {
                binary[i] = 1;
                return;
            }
            binary[i] = 0;
        }
    }

    void Printsubset()
    {
            List<int> subset = new List<int>();

        for (int i = n - 1; i >= 0; i--)
        {
            if (binary[i] == 1) subset.Add(set[n - 1 - i]);
        }

        Console.WriteLine("");
        Console.Write(String.Join(",", subset));
    }



        public int[] set;
        public byte[] binary;
        public int n;

    public override void MainRun()
        {
            Test(5, 3, 0);
            string input = Console.ReadLine();

            set = Array.ConvertAll(input.Split(' '), x => Convert.ToInt32(x));

            //n = set.Length;
            //binary = new byte[n];

            //// ...
            //int size = 2 << (n - 1);

            //for (int i = 0; i < size; i++)
            //{
            //    Printsubset();
            //    BinaryIncrement();
            //}
            //return;

            var x1 = GetItem(3, set, 0);

            Console.WriteLine(x1);


            List<int[]> a = GetExtraParentheses(new List<int>(set), 3);

            foreach (var i in a)
            {
                PrintArrHorizontal(i);
                Console.WriteLine();
            }
            Console.ReadKey();
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

                List<int> incorrectList = new List<int>();

                //while (incorrectCount > 0)
                //{
                for (int i = 0; i < rightParenthesIndexes.Count; i++)
                {
                    incorrectList.Add(rightParenthesIndexes[i]);
                }
                //}
            }

        }


        public List<int[]> GetExtraParentheses(List<int> list, int extraLimit)
        {
            int[] indeces = new int[extraLimit];
            List<int[]> indecesList = new List<int[]>();
           
            for (int i = 0; i < list.Count - extraLimit; i++)
            {
                //indeces[0] = list[i];
                for (int k = i + 1; k <= list.Count - extraLimit + 1; k++)
                {
                    indeces = new int[extraLimit];
                    indeces[0] = list[i];
                    for (int j = 1; j < extraLimit; j++)
                    {
                        indeces[j] = list[j + k - 1];
                    }
                    indecesList.Add(indeces);
                }
            }

            return indecesList;
        }

        public void Test(int n, int k, int u)
        {
            if (u >= n - k) return;

            int[] x = new int[n];

            for (int i = u; i < k + u; i++)
            {
                x[i] = 1;
            }

            int t = k;

            PrintArrHorizontal(x);

            int found = 0;
            while (t > 0)
            {
                for (int i = u; i < n; i++)
                {
                    if (x[i] == 1) found++;
                    if (found == t && i < n -1 && x[i + 1] == 0)
                    {
                        x[i] = 0;
                        x[i + 1] = 1;
                        PrintArrHorizontal(x);
                        found--;
                    }
                }
                t--;
                found = 0;

            }
            Test(n, k, ++u);

        }

        private void MyPrint(int[] a, int k)
        {
            while (k > 0)
            {
                Print(k--);
            }

            PrintArrHorizontal(a);
        }

        public void Test1(int n, int k, int u)
        {
            if (u >= n - k) return;

            int[] x = new int[n - k - 1];

            x[0] = 0;

            MyPrint(x, k);
           
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (x[i] == 1)
                {
                    x[i] = 0;
                    x[i + 1] = 1;
                    MyPrint(x, k);
                }
            }
            Test(n, k, ++u);
        }


        public string GetItem(int setLength, int[] list, int startIndex)
        {
            if (setLength <= 1)
                return list[startIndex].ToString();

            string s = "";
            for (int i = 0; i < setLength; i++)
            {
                s += GetItem(setLength - i, list, startIndex + i);
            }

            return s;
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
