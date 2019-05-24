using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class RomanNumbers : _ProblemBase
    {
        Dictionary<int, string> drd = new Dictionary<int, string>();
        Dictionary<string, int> rdd = new Dictionary<string, int>();

        public override void MainRun()
        {
            Print(RomanToInt(IntToRoman(9889)));
        }

        public RomanNumbers()
        {
            drd[1000] = "M";
            drd[900] = "CM";
            drd[500] = "D";
            drd[400] = "CD";
            drd[100] = "C";
            drd[90] = "XC";
            drd[50] = "L";
            drd[40] = "XL";
            drd[10] = "X";
            drd[9] = "IX";
            drd[5] = "V";
            drd[4] = "IV";
            drd[1] = "I";


            rdd["M"] = 1000;
            rdd["CM"] = 900;
            rdd["D"] = 500;
            rdd["CD"] = 400;
            rdd["C"] = 100;
            rdd["XC"] = 90;
            rdd["L"] = 50;
            rdd["XL"] = 40;
            rdd["X"] = 10;
            rdd["IX"] = 9;
            rdd["V"] = 5;
            rdd["IV"] = 4;
            rdd["I"] = 1;
        }

        public string IntToRoman(int num)
        {
            string romanNumber = "";

            foreach (int key in drd.Keys)
            {
                if (key <= num)
                {
                    int count = num / key;
                    while (count > 0)
                    {
                        romanNumber += drd[key];
                        count--;
                    }
                    num = num % key;
                }
            }

            return romanNumber;
        }

        public int RomanToInt1(string roman)
        {
            int number = 0;
            int i = 0;
            foreach (var romanDigit in rdd.Keys)
            {
                int count = 0;
                while (i + romanDigit.Length <= roman.Length && roman.Substring(i, romanDigit.Length) == romanDigit)
                {
                    count++;
                    i += romanDigit.Length;
                }
                number += count * rdd[romanDigit];
            }

            return number;
        }

        public int RomanToInt(string s)
        {
            var dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            if (s.Length == 0)
                return 0;
            int n = 0;

            for (int i = 0; i < s.Length; i++)
            {
                n = (i + 1 < s.Length && dict[s[i]] < dict[s[i + 1]]) ? n - dict[s[i]] : n + dict[s[i]];
            }
            return n;
        }
    }
}
