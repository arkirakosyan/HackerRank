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
            //string[] words = new string[] { "hot", "dot", "lot", "dog", "log", "cog", "hug", "cug" };
            //string[] words = new string[] { "hot","hog", "dot", "lot", "dog", "log", "cog", "hug", "cug" };
            string[] words = new string[] { "hot", "hog", "dot", "dit", "cog" };

            Console.WriteLine(MinChangeCount(words, "hit", "cog"));
        }



        public int MinChangeCount(string[] words, string beginWord, string endWord)
        {
            HashSet<string> wordsSet = new HashSet<string>(words);
            Dictionary<string, int> foundWordsSet = new Dictionary<string, int>();

            if (beginWord == endWord) return 0;

            int? minCount = RecursiveChange(0, wordsSet, foundWordsSet, words, beginWord, endWord, null);

            if (!minCount.HasValue)
            {
                return -1;
            }

            return minCount.Value + 1;
        }


        //public int MinChangeCountGraph(string[] words, string beginWord, string endWord)
        //{
        //    Graph graph = new Graph();
        //    graph.Nodes.Add()
        //}




        private int? RecursiveChange(int deep, HashSet<string> wordsSet, Dictionary<string, int> foundWordsSet, string[] words, string beginWord, string endWord, int? minCount)
        {
            int changeCount = 0;
            if (beginWord == endWord) return changeCount;
            int y = -1;

            for (int i = 0; i < beginWord.Length; i++)
            {
                if (beginWord[i] != endWord[i])
                {
                    for (int j = 0; j < words.Length; j++)
                    {
                        if (beginWord[i] != words[j][i])
                        {
                            string newWord = beginWord.Substring(0, i) + words[j][i] + beginWord.Substring(i + 1);

                            if (wordsSet.Contains(newWord) && (!foundWordsSet.ContainsKey(newWord) || foundWordsSet[newWord] >= deep))
                            {
                                if (i != y)
                                {
                                    changeCount++;
                                    y = i;
                                }
                                Console.WriteLine($"Deep: {deep}, {beginWord}-->{newWord}, ChangeCount:{changeCount}, Min:{minCount}");

                                if (foundWordsSet.ContainsKey(newWord))
                                    foundWordsSet[newWord] = deep;
                                else
                                    foundWordsSet.Add(newWord, deep);

                                if (newWord == endWord)
                                {
                                    Console.WriteLine();
                                    return changeCount;
                                }

                                var count = RecursiveChange(deep + 1, wordsSet, foundWordsSet, words, newWord, endWord, minCount.HasValue ? minCount.Value + changeCount : minCount);

                                if (count.HasValue)
                                    minCount = minCount.HasValue ? Math.Min(count.Value + changeCount, minCount.Value) : count + changeCount;
                            }
                        }
                    }
                }
            }
            return minCount;
        }
    }

    //public class WordGraph
    //{
    //    private Dictionary<string, int> wordNodeIndex = new Dictionary<string, int>();
    //    public List<WordNode> Words { get; set; }
    //    public WordNode BenginWord { get; set; }
    //    public WordNode EndWord { get; set; }

    //    private List<string> GetAllAvailableNeighbours(string myWord, HashSet<string> initialWords, Action<WordNode> addNeighbour)
    //    {
    //        List<string> myWordAvailableNeightbours = new List<string>();

    //        for (int i = 0; i < myWord.Length; i++)
    //        {
    //            foreach (var word in initialWords)
    //            {
    //                if (myWord != word && myWord[i] != word[i])
    //                {
    //                    string newWord = myWord.Substring(0, i) + word[i] + myWord.Substring(i + 1);
    //                    if (initialWords.Contains(newWord))
    //                    {
    //                        myWordAvailableNeightbours.Add(newWord);
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    public void InitGraph(string[] words, string beginWord, string endWord)
    //    {

    //        HashSet<string> wordsSet = new HashSet<string>(words);
    //        foreach (var word in words)
    //        {
    //            WordNode myWordNode = new WordNode(word);
    //            List<string> myWordAvailableNeightbours = GetAllAvailableNeighbours(word, wordsSet);
    //            for

    //        }




    //        if (!wordNodeIndex.ContainsKey(word))
    //        {
    //            var newNode = new WordNode(word);
    //            for (int i = 0; i < word.Length; i++)
    //            {
    //                string newWord = word.Substring(0, i) + words[j][i] + beginWord.Substring(i + 1);
    //            }

    //            Words.Add(new WordNode(word));
    //        }
    //    }
    //}

    public class WordNode
    {
        public WordNode(string word)
        {
            Value = word;
        }

        public string Value { get; set; }
        public List<WordNode> Neighbours { get; set; }
    }
}
