using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFilter
{
    public static class StringListExtension
    {
        /// <summary>
        /// Extension method for the string list which determines which items in the list are a combination of other 2.
        /// The method should be fast, especially at large lists, HashSet provides highly performance regarding sets of data.
        /// The performance should be around O(n*n + 1).
        /// It can be done faster by creating a list of combinations of sub-words that could match another word,
        /// but that would mean more memory as a trade off for a bit more performance. Don't know if is justifiable.
        /// Before doing the concatenation of the strings, there are conditions in the place, regarding length of the final words,
        /// which brings much more speed / less string concatenations.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="wordLength"></param>
        /// <returns></returns>
        public static List<string> FilterBySubStrCombination(this List<string> list, int wordLength)
        {
            HashSet<string> words = new HashSet<string>();
            List<string> matchWords = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                var listItem = list[i];

                if (listItem.Length == wordLength)
                    words.Add(listItem);
            }

            for (int i = 0; i < list.Count; i++)
            {
                var listItem = list[i];

                if (listItem.Length < wordLength)
                    for (int j = 0; j < list.Count; j++)
                        if (j != i)
                        {
                            var listItem2 = list[j];

                            if (listItem.Length + listItem2.Length == wordLength)
                            {
                                var strCompose = listItem + listItem2;

                                if (words.Contains(strCompose))
                                {
                                    words.Remove(strCompose);
                                    matchWords.Add(strCompose);
                                }
                            }
                        }
            }

            return matchWords;
        }
    }
}
