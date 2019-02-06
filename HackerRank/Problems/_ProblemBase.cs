using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public abstract class _ProblemBase
    {
        public abstract void MainRun();

        protected static void PrintArrHorizontal(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();
        }
        protected static void PrintArrVertical(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]} ");
            }

            Console.WriteLine();
        }

        protected static void PrintArrHorizontal(object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();
        }

        protected static void PrintArrVertical<T>(IEnumerable<T> arr)
        {
            foreach (var t in arr)
            {
                Console.WriteLine($"{t} ");
            }
        }

        protected static void PrintArrHorizontal<T>(IEnumerable<T> arr)
        {
            foreach (var t in arr)
            {
                Console.Write($"{t} ");
            }
            Console.WriteLine();
        }
        protected static void PrintLine<T>(T t)
        {
            Console.WriteLine($"{t}");
        }

        protected static void Print<T>(T t)
        {
            Console.Write($"{t} ");
        }
    }
}
