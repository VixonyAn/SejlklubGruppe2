using ClassLibrary.Interfaces;
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
                    else cost = 2; //Values above 1 makes letter substitution much less desirable.
                                   //This means that the algorithm won't consider strings similar just because they have a similar length.
                                   //Mainly usefull with regards to surnames.


                    matrix[i, j] = //Here we save the "cheapest" possible cost for reaching this "square"
                        Math.Min(matrix[i - 1, j] + 1, //matrix[i - 1, j] + 1, is the cost of deleting a letter. This "moves" the comparison to a new letter combination
                        Math.Min(matrix[i, j - 1] + 1, //matrix[i, j - 1] + 1, is the cost of inserting a new letter. This also "moves" the comparison
                        matrix[i - 1, j - 1] + cost)); //matrix[i - 1, j - 1] + cost is the cost of substituting a letter with the correct one (cost = 0 if it was already the same)

                    if (i > 1 && j > 1 && a[i - 1] == b[j - 2] && a[i - 2] == b[j - 1]) //We can only swap neightbouring letters and only if we are on letter nr. 2 in both strings.
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + 1); //If two letters can be swapped the cost is matrix[i - 2, j - 2] + 1
                    }
                }
            }

            return matrix[a.Length, b.Length]; //Lower right corner of the grid is now the optimal cost (int)
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


        public static List<String> Matches(List<string> matchables, string query, int maxDLCost, int maxResults)
        {
            List<DLStringValuePair> sortables = new List<DLStringValuePair>();
            int checkValue;
            foreach(string s in matchables)
            {
                checkValue = Compare(query, s);

                if (checkValue < maxDLCost)
                {
                    sortables.Add(new DLStringValuePair(checkValue, s));
                }
            }

            DLInsertionSort.Sort(sortables);

            List<string> results = new List<string>();

            for(int i = 0; i<Math.Min(sortables.Count,maxResults);i++)
            {
                results.Add(sortables[i].DLString);
            }

            return results;
        }

        //Altered this one to specifically take DLStringValuePair instead of string, since you'd want both email and name to be displayed
        public static List<DLStringValuePair> Matches(List<DLStringValuePair> matchables, string query, int maxDLCost, int maxResults)
        {
            List<DLStringValuePair> sortables = new List<DLStringValuePair>();
            int checkValue;
            foreach (DLStringValuePair s in matchables)
            {
                checkValue = Compare(query, s.DLString);

                if (checkValue < maxDLCost)
                {
                    s.DLValue = checkValue;
                    sortables.Add(s);
                }
            }

            DLInsertionSort.Sort(sortables);

            List<DLStringValuePair> results = new List<DLStringValuePair>();

            for (int i = 0; i < Math.Min(sortables.Count, maxResults); i++)
            {
                results.Add(sortables[i]);
            }

            return results;
        }

        public static List<DLStringValuePair> ConvertFromMember(List<IMember> members)
        {
            List<DLStringValuePair> results = new List<DLStringValuePair>();

            foreach(IMember member in members)
            {
                results.Add(new DLStringValuePair(member.Name, member.Email));
            }

            return results;
        }
    }
}
