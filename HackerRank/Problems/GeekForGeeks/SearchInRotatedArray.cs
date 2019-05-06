
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.GeekForGeeks
{
    public class SearchInRotatedArray : _ProblemBase
    {
        public override void MainRun()
        {
            //int testsCount = Convert.ToInt32(Console.ReadLine());
            //for (int i= 0; i < testsCount; i++)
            //{
            //    int arrLength = Convert.ToInt32(Console.ReadLine());
            //    int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), x => Convert.ToInt32(x));
            //    int number = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine(GetNumberIndex(arr, number));
            //}
            int x = GetNumberIndex(new int[] { 5, 6, 7, 8, 9, 10, 1, 2, 3 }, 4);

            Print(x);
        }

        private int GetNumberIndex(int[] arr, int number)
        {
            int rotationIndex = FindRotationIndex(arr, 0, arr.Length - 1);
            int rotationCount = (rotationIndex > 0) ? arr.Length - rotationIndex : 0;
            return FindNumberIndexRecursive(arr, number, 0, arr.Length - 1, rotationCount);
        }
        private int FindNumberIndexRecursive(int[] arr, int number, int start, int end, int rotationCount)
        {
            if (start > end) return -1;

            int checkIndex = start + (end - start) / 2 - rotationCount;
            if (checkIndex < 0)
            {
                checkIndex += arr.Length;
            }

            if (arr[checkIndex] == number)
            {
                return checkIndex;
            }
            else if (arr[checkIndex] > number)
            {
                return FindNumberIndexRecursive(arr, number, start, start + (end - start) / 2 - 1, rotationCount);
            }
            else
            {
                return FindNumberIndexRecursive(arr, number, start + (end - start) / 2 + 1, end, rotationCount);
            }
        }
        private int FindRotationIndex(int[] arr, int start, int end)
        {
            if (start > end) return -1;

            int checkIndex = start + (end - start) / 2;
            if (checkIndex > 0)
            {
                if (arr[checkIndex - 1] > arr[checkIndex])
                {
                    return checkIndex;
                }
            }
            else
            {
                if (arr[checkIndex + 1] < arr[checkIndex])
                {
                    return checkIndex;
                }
            }

            int newLeftEnd = start + (end - start) / 2 - 1;
            if (newLeftEnd > 0 && arr[newLeftEnd] < arr[0])
            {
                return FindRotationIndex(arr, start, newLeftEnd);
            }

            return FindRotationIndex(arr, start + (end - start) / 2 + 1, end);

        }
    }

}
