using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class Subsets : _ProblemBase
    {
        public override void MainRun()
        {
            var allSubSets = GenerateSubSets(new int[] { 1, 2, 3, 4 }, 2);

            allSubSets.ForEach(x => PrintArrHorizontal(x));



            //var combinations = GenerateWordCombinations(new string[] { "coffee", "ice-cream", "chocolate", "red" }, 2);

            //combinations.ForEach(x => Console.WriteLine($"({x})"));

            //PrintSubsets(maskList);

            //List<byte[]> allMaskList = SubsetMasks(10);
            //Print(allMaskList.Count);
            ////PrintSubsets(maskList);


            //List<byte[]> maskList = GetAllSubsetsOfK(3,6);

            //Print(maskList.Count);
            //PrintSubsets(maskList);
        }

        public List<byte[]> SubsetMasks(int n)
        {
            List<byte[]> maskList = new List<byte[]>();

            byte[] mask = new byte[n];
            maskList.Add(mask);

            for (int i = 1; i < 2 << n; i++)
            {
                mask = NextMask(mask);
                maskList.Add(mask);
            }

            return maskList;
        }

        private byte[] NextMask(byte[] mask)
        {
            byte[] nextMask = new byte[mask.Length];

            bool justCopy = false;
            for (int i = mask.Length - 1; i >= 0; i--)
            {
                if (justCopy)
                {
                    nextMask[i] = mask[i];
                }
                else
                {
                    if (mask[i] == 0)
                    {
                        nextMask[i] = 1;
                        justCopy = true;
                    }
                    else
                    {
                        nextMask[i] = 0;
                    }
                }
            }
            return nextMask;
        }
        private void PrintSubsets(List<byte[]> maskList)
        {
            foreach (var mask in maskList)
            {
                PrintArrHorizontal(mask);
            }
        }



        public List<byte[]> GetAllSubsetsOfK(int n, int k)
        {
         
            List<byte[]> newXList = new List<byte[]>();

            if (k > n)
            {
                Console.WriteLine("Paxar");
                return newXList;
            }

            if (n <= k)
            {
                var x = new byte[n];
                for (int i = 0; i < k; i++)
                    x[i] = 1;

                newXList.Add(x);
                return newXList;
            }

            var prevXList = GetAllSubsetsOfK(n - 1, k);

            Dictionary<string, byte[]> newXListLong = new Dictionary<string, byte[]>();

            foreach (var prevX in prevXList)
            {
                //PrintLine($"Prev: {string.Join(", ", prevX)}");

                int oneFound = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    if (prevX[i] == 1)
                    {
                        oneFound++;

                        byte[] newX = CopyArrayExtendted(prevX, i);

                        string xNewLong = BitConverter.ToString(newX, 0);

                        if (!newXListLong.ContainsKey(xNewLong))
                        {
                            newXListLong.Add(xNewLong, newX);
                            newXList.Add(newX);
                            //if(n== N)
                            //PrintArrHorizontal(newX);
                        }

                        if (oneFound == k)
                        {
                            newX = CopyArrayExtendted(prevX, prevX.Length);
                            xNewLong = BitConverter.ToString(newX, 0);

                            if (!newXListLong.ContainsKey(xNewLong))
                            {
                                newXListLong.Add(xNewLong, newX);
                                newXList.Add(newX);
                                //if(n== N)
                                //PrintArrHorizontal(newX);
                            }
                        }
                    }
                }
            }
            return newXList;
        }
        private byte[] CopyArrayExtendted(byte[] arr, int index)
        {
            byte[] newArr = new byte[arr.Length + 1];

            int oneAdded = 0;
            for (int j = 0; j <= arr.Length; j++)
            {
                if (j == index)
                {
                    newArr[j] = 0;
                    if (++j > arr.Length)
                        break;
                    newArr[j] = arr[j - 1];
                    oneAdded++;
                }
                else
                {
                    newArr[j] = arr[j - oneAdded];
                }
            }

            return newArr;
        }



        public List<string> GenerateWordCombinations(string[] inputWords, int? maxWordsPerCombination = null)
        {
            var combinations = new List<string> { "" };
            GenerateWordCombinations(inputWords, "", maxWordsPerCombination ?? inputWords.Length, combinations);
            return combinations;
        }

        private void GenerateWordCombinations(IEnumerable<string> words, string prefix, int maxWordsPerCombination, IList<string> combinations)
        {
            if (words.Count() == 0 || maxWordsPerCombination == 0)
            {
                return;
            }

            foreach (var word in words)
            {
                GenerateWordCombinations(words.Where(x => x != word), prefix + word + " ", maxWordsPerCombination - 1, combinations);
                combinations.Add(prefix + word);
            }
        }




        public List<List<int>> GenerateSubSets(int[] input, int k)
        {
            var allSubSets = new List<List<int>>();
            var set = new List<int>();

            GenerateSubSets(input, set, k, allSubSets);
            return allSubSets;
        }

        private void GenerateSubSets(IEnumerable<int> input, List<int> set, int k, List<List<int>> allSubSets)
        {
            if (input.Count() == 0 || k == 0)
            {
                return;
            }

            foreach (var i in input)
            {
                set.Add(i);
                GenerateSubSets(input.Where(x => x != i), set, k - 1, allSubSets);
                allSubSets.Add(set);
                set = new List<int>();
            }
        }
    }
}
