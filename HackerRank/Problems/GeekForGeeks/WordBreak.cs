using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.GeekForGeeks
{
    public class WordBreak : _ProblemBase
    {
        public override void MainRun()
        {
            string[] dict = new string[] {"m", "this", "is", "famous", "word", "break", "b", "r", "e", "a", "k", "br", "bre", "brea", "ak", "proble" };
            string str = "wordbreakproblem";

            Console.WriteLine(CanBreakBottomUp(dict, str));

            MyTrie trie = new MyTrie();
            MyTrie.AddWord(trie, "word");
            MyTrie.AddWord(trie, "world");

            MyTrie.WordExists(trie, "wor");

        }

        public bool CanBreak(string[] dict, string str)
        {
            if (str.Length == 0) return true;

            for (int i = 0; i <= str.Length; i++)
            {
                if (dict.Any(x => x == str.Substring(0, i)) && CanBreak(dict, str.Substring(i)))
                    return true;
            }
            return false;
        }

        public bool CanBreakBottomUp(string[] dict, string str)
        {
            MyTrie head = new MyTrie();
            foreach (string word in dict)
            {
                MyTrie.AddWord(head, word);
            }

            bool[] good = new bool[str.Length + 1];
            good[0] = true;

            for (int i = 0; i < str.Length; i++)
            {
                if (good[i])
                {
                    MyTrie node = head;
                    for (int j = i; j < str.Length; j++)
                    {
                        if (node == null) break;

                        node = node.Nodes[str[j] - 'a'];

                        if (node != null && node.IsWord)
                        {
                            good[j + 1] = true;
                        }
                    }
                }
            }

            return good[str.Length];
        }
    }

    public class MyTrie
    {
        public MyTrie[] Nodes = new MyTrie[26];
        public bool IsWord { get; set; }

        public static void AddWord(MyTrie head, string word)
        {
            MyTrie trie = head;
            foreach (char ch in word)
            {
                if (trie.Nodes[ch - 'a'] == null)
                {
                    trie.Nodes[ch - 'a'] = new MyTrie();
                }

                trie = trie.Nodes[ch - 'a'];
            }
            trie.IsWord = true;
        }

        public static bool WordExists(MyTrie head, string word)
        {
            MyTrie node = head;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.Nodes[word[i] - 'a'] == null)
                {
                    return false;
                }

                node = node.Nodes[word[i] - 'a'];
            }

            return node.IsWord;
        }
    }
}
