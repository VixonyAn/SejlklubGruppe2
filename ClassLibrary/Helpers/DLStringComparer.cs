using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Helpers
{
    public class DLStringComparer
    {
        public static int Compare(string a, string b)
        {
            int[,] matrix = new int[a.Length + 1, b.Length + 1];
            int cost = 0;

            for (int i = 0; i <= a.Length; i++)
            {
                matrix[i, 0] = i;
            }
            for (int i = 0; i <= b.Length; i++)
            {
                matrix[0, i] = i;
            }

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        cost = 0;
                    }
                    else cost = 2;

                    matrix[i, j] = Math.Min(matrix[i - 1, j] + 1,
                        Math.Min(matrix[i, j - 1] + 1,
                        matrix[i - 1, j - 1] + cost));

                    if (i > 1 && j > 1 && a[i - 1] == b[j - 2] && a[i - 2] == b[j - 1])
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + 1);
                    }
                }
            }

            return matrix[a.Length, b.Length];
        }

        public static List<DLStringValuePair> SortPairs(List<string> matchables, string query)
        {
            List<DLStringValuePair> sortables = new List<DLStringValuePair>();
            foreach (string s in matchables)
            {
                sortables.Add(new DLStringValuePair(Compare(query.ToLower(), s.ToLower()), s));
            }

            DLInsertionSort.Sort(sortables);

            return sortables;
        }


        public static List<String> Matches(List<string> matchables, string query, int maxDLCost)
        {
            List<DLStringValuePair> sortables = new List<DLStringValuePair>();
            foreach(string s in matchables)
            {
                sortables.Add(new DLStringValuePair(Compare(query.ToLower(),s.ToLower()), s));
            }

            DLInsertionSort.Sort(sortables);

            List<string> results = new List<string>();

            for(int i = 0; i<sortables.Count;i++)
            {
                results.Add(sortables[i].DLString);
            }

            return results;
        }
    }
}
