﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public class CustomMultiplication : _ProblemBase
    {
        public override void MainRun()
        {
            Multiple(708954, 32408);
        }
        public int Multiple(int a, int b)
        {
            if (a > b)
            {
                b = a + b;
                a = b - a;
                b = b - a;
            }

            int sum = MultipleProcess(a, b);

            if (sum == a * b)
            {
                PrintLine("");
                PrintLine(sum);
                PrintLine("");
                PrintLine("CONGRATULATIONS!!!!!!");
            }
            return sum;
        }
        private int MultipleProcess(int a, int b)
        {
            Console.WriteLine($"a = {a}, b = {b}");

            if (a == 0) return a;
            if (a == 1) return b;

            int rem = 0;
            if (a % 2 > 0)
            {
                rem = b;
            }

            int halfSum = MultipleProcess(a >> 1, b);

            return halfSum + halfSum + rem;
        }
    }
}
