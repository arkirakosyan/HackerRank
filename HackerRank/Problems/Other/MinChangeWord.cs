using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class MinChangeWord : _ProblemBase
    {
        public override void MainRun()
        {
            string[] words = new string[] { "hot", "dot", "lot", "dog", "log", "cog" };

            Console.WriteLine( MinChangeCount(words, "hit", "cog"));
        }

        public int MinChangeCount(string[] words, string beginWord, string endWord)
        {
            HashSet<string> wordsSet = new HashSet<string>(words);
            Dictionary<string, int> foundWordsSet = new Dictionary<string, int>();

            if (beginWord == endWord) return 0;

            int? minCount = RecursiveChange(0, wordsSet, foundWordsSet, words, beginWord, endWord, null);

            if (!minCount.HasValue)
            {
                throw new Exception();
            }

            return minCount.Value + 1;
        }
        private int COUNT = 0;
        private int? RecursiveChange(int deep, HashSet<string> wordsSet,Dictionary<string, int> foundWordsSet, string[] words, string beginWord, string endWord, int? minCount)
        {
            int changeCount = 0;
            if (beginWord == endWord) return changeCount;
            int y = -1;
            for (int i = 0; i < beginWord.Length; i++)
            {
              
                for (int j = 0; j < words.Length; j++)
                {
                    if (beginWord[i] != words[j][i] && beginWord[i] != endWord[i])
                    {
                        string newWord = beginWord.Substring(0, i) + words[j][i] + beginWord.Substring(i + 1);

                        if (wordsSet.Contains(newWord) && (!foundWordsSet.ContainsKey(newWord) || foundWordsSet[newWord] > deep))
                        {
                            if (i != y)
                            {
                                changeCount++;
                                y = i;
                            }
                            Console.WriteLine($"Deep: {deep}, {beginWord}-->{newWord}, ChangeCount:{changeCount}, Min:{minCount}");

                            if (newWord == endWord)
                            {
                                return changeCount;
                            }
                            foundWordsSet.Add(newWord, deep);
                            var count = RecursiveChange(deep + 1, wordsSet, foundWordsSet, words, newWord, endWord, minCount.HasValue ? minCount.Value + changeCount : minCount);

                            if (count.HasValue)
                                minCount = minCount.HasValue ? Math.Min( count.Value + changeCount, minCount.Value) : count + changeCount;
                        }
                    }

                }
            }
            Console.WriteLine($"---------------Deep: {deep}, {beginWord}, ChangeCount:{changeCount}, Min:{minCount}");

            return minCount;
        }
    }
}
