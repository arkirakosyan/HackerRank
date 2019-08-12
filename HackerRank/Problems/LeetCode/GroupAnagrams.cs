using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class GroupAnagramsProblem : _ProblemBase
    {
        public override void MainRun()
        {
            var tt = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<Anagram> anagrams = new List<Anagram>();
            foreach (var s in strs)
            {
                var arr = Anagram.GetArray(s);
                bool added = false;
                foreach(var a in anagrams)
                {
                    if (a.TryAddAnagram(arr,s))
                    {
                        added = true;
                        break;
                    }
                }
                if (!added)
                    anagrams.Add(new Anagram(arr,s));
                added = false;
            }

            IList<IList<string>> results = new List<IList<string>>();

            foreach (var s in anagrams)
            {
                results.Add(new List<string>(s.ang));
            }

            return results;
        }

        private class Anagram
        {
            int[] letters = new int[26];
            public List<string> ang = new List<string>();

            public static int[] GetArray(string str)
            {
                int[] temp = new int[26];
                foreach (var s in str)
                {
                    temp[s - 'a']++;
                }
                return temp;
            }
            public Anagram(int[] arr, string str)
            {
                letters = arr;
                ang.Add(str);
            }
            public bool TryAddAnagram(int[] arr, string str)
            {
                for (int i = 0; i < 26; i++)
                {
                    if (letters[i] != arr[i]) return false;
                }
                ang.Add(str);
                return true;
            }
        }
    }
}
