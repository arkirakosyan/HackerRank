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

class Solution
{



    static void Main(string[] args)
    {
        //QueensAttack.MainRun();
        DateTime start = DateTime.Now;

        MyHashTable myHash = new MyHashTable();

        for (int i = 1; i <= 2000000; i++)
        {
            myHash["key" + i] = "value" + i;
        }

        for (int i = 1; i < 100; i++)
        {
            Random r = new Random();
            int index = r.Next(200000);
            Console.WriteLine(myHash["key" + index]);
        }

        Console.WriteLine("Time: {0}", (DateTime.Now - start).Milliseconds);
        Console.ReadKey();




        start = DateTime.Now;
        Hashtable hash = new Hashtable();

        for (int i = 1; i <= 2000000; i++)
        {
            hash["key" + i] = "value" + i;
        }

        for (int i = 1; i < 100; i++)
        {
            Random r = new Random();
            int index = r.Next(200000);
            Console.WriteLine(hash["key" + index]);
        }

        Console.WriteLine("Time: {0}", (DateTime.Now - start).Milliseconds);
        Console.ReadKey();
    }
}
