using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Codility
{
    public class LongestString : _ProblemBase
    {
        public override void MainRun()
        {
            string str = Console.ReadLine();

            while (str != ".")
            {
                PrintLine(solution(str.Split(' ')));
                str = Console.ReadLine();
            }
        }

        public int solution(string[] words)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            Dictionary<char, StringDetailsList> d = new Dictionary<char, StringDetailsList>();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    char x = words[i][j];

                    StringDetails sd = new StringDetails { Index = i, Chr = words[i][j], AvlPosition = j == 0 ? Positions.Front : Positions.None, Count = 1 };

                    while (j + 1 < words[i].Length && words[i][j + 1] == sd.Chr)
                    {
                        sd.Count++;
                        j++;
                    }

                    if (j == words[i].Length - 1)
                    {
                        sd.AvlPosition += 2;
                    }

                    if (!d.ContainsKey(sd.Chr))
                    {
                        d.Add(sd.Chr, new StringDetailsList());
                    }

                    d[sd.Chr].Add(sd);
                }
            }


            int bigMax = 0;
            foreach (char key in d.Keys)
            {
                bigMax = Math.Max(bigMax, d[key].CalcBestCount());
            }
            
            return bigMax;
        }

        public class StringDetails
        {
            public int Index;
            public char Chr;
            public int Count;
            public Positions AvlPosition;
        }

        public class StringDetailsList
        {
            public int _bothCount;
            public int _maxNoneCount;

            public List<StringDetails> _frontList = new List<StringDetails>();
            public List<StringDetails> _backList = new List<StringDetails>();


            public void Add(StringDetails sd)
            {
                switch (sd.AvlPosition)
                {
                    case Positions.Front:
                        _frontList.Add(sd);
                        break;
                    case Positions.None:
                        _maxNoneCount = Math.Max(sd.Count, _maxNoneCount);
                        break;
                    case Positions.Back:
                        _backList.Add(sd);
                        break;
                    case Positions.Both:
                        _bothCount += sd.Count;
                        break;
                }
            }

            public StringDetails GetMax(int excludeIndex, List<StringDetails> list)
            {
                if (list.Count == 0 || (list.Count == 1 && excludeIndex == 0))  return new StringDetails { Index = -1, Count = 0 };

                StringDetails maxDetails = new StringDetails { Index = -1, Count = 0 };

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Index != excludeIndex && list[i].Count > maxDetails.Count)
                    {
                        maxDetails = list[i];
                    }
                }
                return maxDetails;
            }
            public int CalcBestCount()
            {
                StringDetails maxFront = GetMax(-1, _frontList);
                StringDetails maxBack = GetMax(-1, _backList);

                if (maxFront.Index == maxBack.Index)
                {
                    var newMaxFront = GetMax(maxFront.Index, _frontList);
                    var newMaxBack = GetMax(maxBack.Index, _backList);

                    if (newMaxBack.Count + maxFront.Count > maxBack.Count + newMaxFront.Count)
                    {
                        maxBack = newMaxBack;
                    }
                    else
                    {
                        maxFront = newMaxFront;
                    }
                }

                return  Math.Max(_maxNoneCount, maxFront.Count + maxBack.Count + _bothCount);
            }
        }

        public enum Positions
        {
            None,
            Front,
            Back,
            Both
        }
    }
}
