//**************** Max Score *****************//
//******************* 35 ********************//
//*******************************************//
using System;

namespace HackerRank.Problems
{
    public static class BiggerIsGreater
    {
        public static void MainRun(String[] args)
        {

            int strCount = Convert.ToInt32(Console.ReadLine());
            string[] strArr = new string[strCount];

            for (int i = 0; i < strCount; i++)
            {
                strArr[i] = Console.ReadLine();
            }

            for (int i = 0; i < strArr.Length; i++)
            {
                Console.WriteLine(LexicographicallyBigger(strArr[i]));
            }
        }
        private static string LexicographicallyBigger(string str)
        {
            char[] arr = str.ToCharArray();

            int pivot = arr.Length - 1;

            int leftIndex = -1;
            int rightIndex = -1;
            char choosedPivotValue = arr[pivot];

            while (pivot > 0)
            {
                for (int i = pivot - 1; i > leftIndex; i--)
                {
                    if (arr[i] < arr[pivot])
                    {
                        if (i > leftIndex || (i == leftIndex && arr[pivot] < choosedPivotValue))
                        {
                            leftIndex = i;
                            rightIndex = pivot;
                            choosedPivotValue = arr[pivot];
                        }
                    }
                }
                pivot--;
            }

            if (leftIndex >= rightIndex)
            {
                return "no answer";
            }

            char t = arr[leftIndex];
            arr[leftIndex] = arr[rightIndex];
            arr[rightIndex] = t;

            pivot = arr.Length - 1;

            while (pivot > 0)
            {
                for (int i = pivot; i > leftIndex; i--)
                {
                    if (arr[i] > arr[pivot])
                    {
                        t = arr[i];
                        arr[i] = arr[pivot];
                        arr[pivot] = t;
                    }
                }

                pivot--;
            }

            return string.Concat(arr);
        }
    }
}
