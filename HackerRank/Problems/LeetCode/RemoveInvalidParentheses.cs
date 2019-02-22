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
            GetAllSubsetsOfK(5, 3);
            Console.ReadKey();
            return;
            string input = Console.ReadLine();

            var set = Array.ConvertAll(input.Split(' '), x => Convert.ToInt32(x));

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
