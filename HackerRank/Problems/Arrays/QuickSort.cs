using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HackerRank.Problems.Arrays
{
    public class QuickSort : _ProblemBase
    {
        public override void MainRun()
        {
            //var a = new[] { 9, 7, 10, 4, 6, 2, 5 };
            //BubbleSort(ref a);
            //PrintArrHorizontal(a);
            //return;

            List<int> testList = new List<int>();

            Random r = new Random();
            for (int i = 0; i < 10000; i++)
            {
                testList.Add(r.Next(1000000));
                //Thread.Sleep(2);
            }

            int[] arr = testList.Distinct().ToArray();
            int[] arr1 = testList.Distinct().ToArray();

            Print($"Array length: {arr.Length}");
            DateTime start = DateTime.Now;
            List<int> ss = arr.ToList();
            ss.Sort();
            Print("C# sort: " + (DateTime.Now - start).TotalSeconds);




            start = DateTime.Now;
            Sort(ref arr);
            BubbleSort(ref arr);
            Print($"QuickSort: " +(DateTime.Now - start).TotalSeconds);

            start = DateTime.Now;
            BubbleSort(ref arr1);
            Print("Bubble sort: " + (DateTime.Now - start).TotalSeconds);


            //for (int i = 0; i < ss.Count(); i++)
            //{
            //    if (ss[i] != arr[i])
            //    {
            //        Print($"Sort does not match at index {i}, List value: {ss[i]}, arr value: {arr[i]}");
            //        break;
            //    }
            //}


            //Print($"List last value: {ss[ss.Count() - 1]}, arr last value: {arr[arr.Length - 1]}");
            //Print($"List first value: {ss[0]}, arr first value: {arr[0]}");

            //PrintArrHorizontal(arr);



            //PrintArrHorizontal<string>(Sort(new[] { "a", "g", "b", "t", "w", "s", "l" }));

        }

        private void Sort(ref int[] arr)
        {
            Sort(0, arr.Length - 1, ref arr);
        }

        private void Sort(int start, int end, ref int[] arr)
        {
            if (end - start < 1)
                return;

            int newPivotIndex = SetCorrectIndex(start, end, ref arr);

            Sort(start, newPivotIndex - 1, ref arr);
            Sort(newPivotIndex + 1, end, ref arr);
        }

        private int SetCorrectIndex(int start, int end, ref int[] arr)
        {
            int pivot = arr[end];
            int nextPivotIndex = start;

            for (int i = start; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    int temp = arr[nextPivotIndex];
                    arr[nextPivotIndex] = arr[i];
                    arr[i] = temp;

                    nextPivotIndex++;
                }
            }

            if (arr[nextPivotIndex] > pivot)
            {
                int temp1 = arr[nextPivotIndex];
                arr[nextPivotIndex] = pivot;
                arr[end] = temp1;
            }
            return nextPivotIndex;
        }

        private void BubbleSort(ref int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        int temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }

        private T[] Sort<T>(T[] arr) where T : IComparable
        {
            Sort(0, arr.Length - 1, ref arr);
            return arr;
        }

        private void Sort<T>(int start, int end, ref T[] arr) where T : IComparable
        {
            if (end - start < 1)
                return;

            int newPivotIndex = SetCorrectIndex(start, end, ref arr);

            Sort(start, newPivotIndex - 1, ref arr);
            Sort(newPivotIndex + 1, end, ref arr);
        }

        private int SetCorrectIndex<T>(int start, int end, ref T[] arr) where T : IComparable
        {
            T pivot = arr[end];
            int nextPivotIndex = start;

            for (int i = start; i < end; i++)
            {
                if (arr[i].CompareTo(pivot) < 0)
                {
                    T temp = arr[nextPivotIndex];
                    arr[nextPivotIndex] = arr[i];
                    arr[i] = temp;

                    nextPivotIndex++;
                }
            }

            if (arr[nextPivotIndex].CompareTo(pivot) > 0)
            {
                T temp1 = arr[nextPivotIndex];
                arr[nextPivotIndex] = pivot;
                arr[end] = temp1;
            }
            return nextPivotIndex;
        }
    }
}
