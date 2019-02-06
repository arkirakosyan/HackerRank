using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using HackerRank.Problems;
using HackerRank.Problems.Medium;
using HackerRank.Problems.Other;
using HackerRank.Problems.LeetCode;
using HackerRank.Problems.Arrays;
using HackerRank.Problems.Codility;

class Solution
{
    static void Main(string[] args)
    {

        new RemoveInvalidParentheses().MainRun();

        ////string[] str = new string[] { "asd", "avfga", "", "tryaaagvxca", "rfca", "a" };
        //string[] str = new string[] { "aaa", "apa", "aaxa", "yaaaaxxxxxaaba" };

        //tt.solution(str);
        // Console.Write((int)Math.Ceiling((decimal)(85 - 10) / 30));
        //(new LongestString()).MainRun();
    }

    public class TTTTT
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[] d = new int[A.Length];
            List<int> l = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                {
                    l.Add(A[i]);
                }
            }

            l.Sort();

            int min = 1;

            foreach (int i in l)
            {
                if (i == min)
                {
                    min++;
                }
                else if (min < i)
                    return min;
            }
            return l.Count + 1;
        }
    }

}
