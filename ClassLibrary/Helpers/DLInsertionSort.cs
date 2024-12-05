using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Helpers
{
    public class DLInsertionSort
    {
        public static void Sort(List<DLStringValuePair> list)
        {
            DLStringValuePair currentValuePair;
            for(int i = 1; i<list.Count;i++)
            {
                currentValuePair = list[i];
                int j = i - 1;
                while(j>=0 && currentValuePair.DLValue < list[j].DLValue)
                {
                    list[j+1] = list[j];
                    j--;
                }
                list[j + 1] = currentValuePair;
            }
        }
    }
}
