using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class MinLetterChange : _ProblemBase
    {
        public override void MainRun()
        {
            //string[] words = new string[] { "hot", "dot", "lot", "dog", "log", "cog", "hug", "cug" };
            string[] words = new string[] { "hot", "hog", "dot", "lot", "dog", "log", "cog", "hug", "cug", "cuo", "aaa" };
            //string[] words = new string[] { "hot","dot","dog","lot","log","cog" };

            Console.WriteLine(MinChangeCountGraph(words, "hit", "aaa"));
        }
        public int MinChangeCountGraph(string[] words, string beginWord, string endWord)
        {
            WordGraph wordGraph = new WordGraph(words, beginWord, endWord);
            return wordGraph.FindMinChangesCount();
        }
    }

    public class WordGraph
    {
        private Dictionary<string, WordNode> _wordNodes;
        private WordNode _beginWord;
        private WordNode _endWord;

        public WordGraph(string[] words, string beginWord, string endWord)
        {
            InitWordGraph(words, beginWord, endWord);
        }

        public int FindMinChangesCount()
        {
            MarkDistance(_beginWord);

            Queue<WordNode> queue = new Queue<WordNode>(_beginWord.Neighbours.Values);

            while (queue.Any())
            {
                WordNode node = queue.Dequeue();

                if (node.Value == _endWord.Value)
                {
                    Console.WriteLine($"Word: {node.Value}, Distance: { node.Distance + 1 ?? -1}");
                    return node.Distance + 1 ?? -1;
                }

                if (!node.Visited)
                {
                    node.Visited = true;
                    MarkDistance(node);

                    foreach (var neighbour in node.Neighbours.Values.Where(x => !x.Visited))
                    {
                        queue.Enqueue(neighbour);
                    }

                    Console.WriteLine($"Word: {node.Value}, Distance: { node.Distance + 1 ?? -1}");
                }
            }

            return _endWord.Distance + 1 ?? -1;
        }

        private void InitWordGraph(string[] words, string beginWord, string endWord)
        {
            _wordNodes = new Dictionary<string, WordNode>();
            WordNode wordNode = null;

            foreach (var baseWord in words)
            {
                if (_wordNodes.ContainsKey(baseWord))
                {
                    wordNode = _wordNodes[baseWord];
                }
                else
                {
                    wordNode = new WordNode(baseWord);
                    _wordNodes.Add(baseWord, wordNode);
                }
                AddNewNode(wordNode, words, true);
            }
            wordNode = new WordNode(beginWord)
            {
                Distance = 0
            };
            _wordNodes.Add(beginWord, wordNode);

            AddNewNode(wordNode, words, false);


            _endWord = _wordNodes[endWord];
            _beginWord = _wordNodes[beginWord];
        }
        private void AddNewNode(WordNode wordNode, string[] words, bool twoWayNeighbour)
        {
            string baseWord = wordNode.Value;

            foreach (var word in words)
            {
                if (word != baseWord && !wordNode.Neighbours.ContainsKey(word))
                {
                    int missMatch = 0;

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] != baseWord[i] && ++missMatch > 1)
                        {
                            break;
                        }
                    }

                    if (missMatch == 1)
                    {
                        WordNode neighbour = null;
                        if (_wordNodes.ContainsKey(word))
                        {
                            neighbour = _wordNodes[word];
                            if (twoWayNeighbour && !neighbour.Neighbours.ContainsKey(baseWord))
                            {
                                neighbour.Neighbours.Add(baseWord, wordNode);
                            }
                        }
                        else
                        {
                            neighbour = new WordNode(word);
                            _wordNodes.Add(word, neighbour);
                            if (twoWayNeighbour)
                                neighbour.Neighbours.Add(baseWord, wordNode);
                        }
                        wordNode.Neighbours.Add(word, neighbour);
                    }
                }
            }
        }
        private void MarkDistance(WordNode wordNode)
        {
            foreach (var neighbourNode in wordNode.Neighbours)
            {
                if (!neighbourNode.Value.Distance.HasValue || neighbourNode.Value.Distance > wordNode.Distance.Value + 1)
                    neighbourNode.Value.Distance = wordNode.Distance.Value + 1;
            }
        }
        private class WordNode
        {
            public WordNode(string word)
            {
                Value = word;
                Neighbours = new Dictionary<string, WordNode>();
            }

            public string Value { get; set; }
            public Dictionary<string, WordNode> Neighbours { get; set; }
            public int? Distance { get; set; }
            public bool Visited { get; set; }
        }
    }
}
