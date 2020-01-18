using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevenshteinDistanceCSharp
{
    public class LevenshteinDistance
    {
        private readonly Dictionary<string, int> Words = new Dictionary<string, int>();
        private readonly Dictionary<string, int[,]> PrecomputedArrays = new Dictionary<string, int[,]>();
        private readonly Dictionary<string, Dictionary<string, int>> SearchHistory = new Dictionary<string, Dictionary<string, int>>();


        #region Tools and helpers
        public Dictionary<string, int> SearchDistance(IEnumerable<string> wordList, string stringToSearch)
        {
            if (SearchHistory.ContainsKey(stringToSearch))
            {
                return SearchHistory[stringToSearch];
            }
            int limit = 50000;
            foreach (var word in wordList)
            {
                if (!Words.ContainsKey(word))
                {
                    var resultComputed = ComputeLevenshteinDistance(word, stringToSearch);

                    if (resultComputed >= word.Length || resultComputed >= stringToSearch.Length)
                        continue;

                    if (resultComputed == 0)
                    {
                        //exact match found
                        //resultTxt.Text = 
                    }
                    Words.Add(word, resultComputed);
                    limit--;
                }
                else
                {
                    return Words;
                }

                if (limit < 0)
                    return SearchHistory[stringToSearch] = Words;
            }

            return SearchHistory[stringToSearch] = null;
        }
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public int ComputeLevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
                return m;

            if (m == 0)
                return n;

            // Step 2
            //if (PrecomputedArrays.ContainsKey(s))
            //{
            //    d = PrecomputedArrays[s];
            //}
            //else
            //{
            for (int i = 0; i <= n; d[i, 0] = i++) { }
            //PrecomputedArrays[s] = d;
            //}

            for (int j = 0; j <= m; d[0, j] = j++) { }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        public IEnumerable<string> TextToList(string s) => s.Split(new string[] { Environment.NewLine, "\n", "\r", "\t", " " }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());
        #endregion

    }
}
