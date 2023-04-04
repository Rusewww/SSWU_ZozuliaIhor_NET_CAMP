using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static int? CountWordsStartingWithCapitalLetter(string text)
        {
            int count = 0;
            Regex regex = new Regex(@"\b[A-Z][a-z]*\b");
            MatchCollection matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                if (char.IsUpper(match.Value[0]))
                {
                    count++;
                }
            }
            return count;
        }

        public static string ReplaceWordWithDoubleLetters(string text, string replace)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder currentWord = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetter(c))
                {
                    currentWord.Append(c);
                }
                else
                {
                    if (HasDoubleLetters(currentWord))
                    {
                        output.Append(replace);
                    }
                    else
                    {
                        output.Append(currentWord);
                    }
                    output.Append(c);
                    currentWord.Clear();
                }
            }
            if (HasDoubleLetters(currentWord))
            {
                output.Append(replace);
            }
            else
            {
                output.Append(currentWord);
            }
            return output.ToString();
        }

        private static bool HasDoubleLetters(StringBuilder word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
