using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class StringProblems : _ProblemBase
    {
        public override void MainRun()
        {
            //Print(StrStr("hell", "ll"));

            //var v = FindSubstring("abababab", new string[] { "a", "b", "a" });
            var v = FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" });
            //var t = FindSubstring("abababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababab", new string[] { "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba", "ab", "ba" });
        }

        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;
            if (needle.Length > haystack.Length) return -1;

            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                int k = 0;
                while (k < needle.Length && haystack[i + k] == needle[k])
                {
                    k++;
                }
                if (k == needle.Length) return i;
            }
            return -1;
        }

        private int StrStr(string haystack, string needle, int startIndex)
        {
            if (needle.Length == 0) return 0;
            if (needle.Length > haystack.Length - startIndex) return -1;

            for (int i = startIndex; i < haystack.Length - needle.Length + 1; i++)
            {
                int k = 0;
                while (k < needle.Length && haystack[i + k] == needle[k])
                {
                    k++;
                }
                if (k == needle.Length) return i;
            }
            return -1;
        }

        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> results = new List<int>();
            if (words.Length == 0) return results;
            int oneWordLength = words[0].Length;
            int wordsCount = words.Length;
            int substringLength = wordsCount * oneWordLength;


            Dictionary<string, int> dict = new Dictionary<string, int>(wordsCount);
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict[word] = 1;
                }
            }

            for (int i = 0; i < s.Length - substringLength + 1; i++)
            {
                string firstWord = s.Substring(i, oneWordLength);
                Dictionary<string, int> dict1 = new Dictionary<string, int>();

                if (dict.ContainsKey(firstWord))
                {
                    dict1.Add(firstWord, dict[firstWord]-1);

                    int j = 1;
                    while (j < words.Length)
                    {
                        var nextWord = s.Substring(i + j * oneWordLength, oneWordLength);
                        if (dict.ContainsKey(nextWord) && (!dict1.ContainsKey(nextWord) || dict1[nextWord] > 0))
                        {
                            if (!dict1.ContainsKey(nextWord))
                                dict1.Add(nextWord, dict[nextWord] - 1);
                            else
                                dict1[nextWord]--;
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (j == words.Length)
                    {
                        results.Add(i);
                    }
                }
            }

            return results;
        }


        public IList<int> FindSubstring1(string s, string[] words)
        {
            HashSet<string> hash = new HashSet<string>();
            IList<int> results = new List<int>();
            if (words.Length == 0) return results;
            int oneWordLength = words[0].Length;
            int substringLength = words.Length * oneWordLength;


            for (int i = 0; i < words.Length; i++)
            {
                if (!hash.Contains(words[i]))
                {
                    hash.Add(words[i]);
                    int firstIndex = 0;

                    while (firstIndex + substringLength <= s.Length)
                    {
                        if (StartsWith(s, words[i], firstIndex))
                        {
                            if (CheckSubstring(s, GetRemainingWords(words, i), firstIndex + oneWordLength))
                            {
                                results.Add(firstIndex);
                            }
                        }
                        firstIndex++;
                    }
                }
            }
            return results;
        }


        private bool CheckSubstring(string s, string[] words, int startIndex)
        {
            if (words.Length == 0) return true;

            for (int i = 0; i < words.Length; i++)
            {
                if (StartsWith(s, words[i], startIndex) && CheckSubstring(s, GetRemainingWords(words, i), startIndex + words[i].Length))
                {
                    return true;
                }
            }
            return false;
        }
        private bool StartsWith(string s, string p, int i)
        {
            int j = 0;
            while (j < p.Length && s[i + j] == p[j])
            {
                j++;
            }
            return j == p.Length;
        }
        private string[] GetRemainingWords(string[] words, int k)
        {
            string[] newS = new string[words.Length - 1];
            int j = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (i == k) continue;
                newS[j++] = words[i];
            }
            return newS;
        }


    }
}
