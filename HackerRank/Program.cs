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
using HackerRank.Problems.DynamicProgramming;

class Solution
{
    static void Main(string[] args)
    {
        new Knapsack().MainRun();
        Console.ReadKey();
    }

    //static void PrintSubArrayPositions(int[] arr, int sum)
    //{
    //    int startPosition = 0;
    //    int subArraySum = 0;

    //    for (int i = 0; i < arr.Length; i++)
    //    {
    //        subArraySum += arr[i];

    //        while (subArraySum > sum)
    //        {
    //            subArraySum -= arr[startPosition];
    //            startPosition++;
    //        }

    //        if (subArraySum == sum)
    //        {
    //            Console.WriteLine($"{startPosition + 1} {i + 1}");
    //            return;
    //        }
    //    }

    //    Console.WriteLine("-1");
    //}
    //static string RemoveComments(string code)
    //{

    //    Dictionary<int, int> comments = new Dictionary<int, int>();
    //    for (int i = 0; i < code.Length - 1; i++)
    //    {
    //        if (code[i] == '/')
    //        {
    //            int commentLength = 0;
    //            if (code[i + 1] == '/' )
    //            {
    //                commentLength = 2;
    //                while (++i < code.Length - 1 && (code[i] != '\r'))
    //                {
    //                    commentLength++;
    //                }

    //                comments.Add(i - commentLength + 1, commentLength);
    //            }
    //            else if (code[i + 1] == '*')
    //            {
    //                commentLength = 2;
    //                while (++i < code.Length - 1 && (!(code[i] == '*' && code[i + 1] == '/')))
    //                {
    //                    commentLength++;
    //                }

    //                comments.Add(i - commentLength + 1, commentLength);
    //            }

    //        }
    //    }

    //    StringBuilder uncommentedCode = new StringBuilder();
    //    int codeIndex = 0;
    //    foreach (var index in comments.Keys)
    //    {
    //        uncommentedCode.Append(code.Substring(codeIndex, index));
    //        codeIndex += index + comments[index];
    //    }

    //    return uncommentedCode.ToString();
    //}

}
