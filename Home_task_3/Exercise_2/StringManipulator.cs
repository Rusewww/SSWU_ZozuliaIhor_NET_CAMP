using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    internal class StringManipulator
    {
        public static int? FindSecondIndex(string text, string subString)
        {
            int firstIndex = text.IndexOf(subString);
            if (firstIndex == -1)
            {
                return null;
            }
            else
            {
                int secondIndex = text.IndexOf(subString, firstIndex + 1);
                if (secondIndex == -1)
                {
                    return null;
                }
                else
                {
                    return secondIndex;
                }
            }
        }
    }
}
