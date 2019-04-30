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
        //new RemoveInvalidParentheses().MainRun();
        DateTime? expireDate = null;
        if (10 != int.MaxValue) expireDate = DateTime.UtcNow.Date;
        /*asda
        Console.WriteLine(expireDate);*/

        string sss = @"//new RemoveInvalidParentheses().MainRun();
        DateTime? expireDate = null;
        if (10 != int.MaxValue) expireDate = DateTime.UtcNow.Date;
        /*asda
        Console.WriteLine(expireDate);*/";

        RemoveComments(sss);

    }

    static string RemoveComments(string code)
    {

        Dictionary<int, int> comments = new Dictionary<int, int>();
        for (int i = 0; i < code.Length - 1; i++)
        {
            if (code[i] == '/')
            {
                int commentLength = 0;
                if (code[i + 1] == '/' )
                {
                    commentLength = 2;
                    while (++i < code.Length - 1 && (code[i] != '\r'))
                    {
                        commentLength++;
                    }

                    comments.Add(i - commentLength + 1, commentLength);
                }
                else if (code[i + 1] == '*')
                {
                    commentLength = 2;
                    while (++i < code.Length - 1 && (!(code[i] == '*' && code[i + 1] == '/')))
                    {
                        commentLength++;
                    }

                    comments.Add(i - commentLength + 1, commentLength);
                }

            }
        }

        StringBuilder uncommentedCode = new StringBuilder();
        int codeIndex = 0;
        foreach (var index in comments.Keys)
        {
            uncommentedCode.Append(code.Substring(codeIndex, index));
            codeIndex += index + comments[index];
        }

        return uncommentedCode.ToString();
    }

}
