using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public abstract class _ProblemBase
    {
        protected static void PrintHorizontal(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();
        }
        protected static void PrintVertical(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]} ");
            }

            Console.WriteLine();
        }

        protected static void PrintHorizontal(object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine();
        }

        protected static void PrintVertical<T>(IEnumerable<T> arr)
        {
            foreach (var t in arr)
            {
                Console.Write($"{t} ");
            }
            Console.WriteLine();
        }

        protected static void PrintHorizontal<T>(IEnumerable<T> arr)
        {
            foreach (var t in arr)
            {
                Console.WriteLine($"{t} ");
            }
        }
    }
}
