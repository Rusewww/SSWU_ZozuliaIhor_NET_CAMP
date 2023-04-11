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
        private string _text = "";

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public StringManipulator(string text)
        {
            _text = text;
        }

        public int? FindSecondIndex(string subString)
        {
            int firstIndex = Text.IndexOf(subString);
            if (firstIndex == -1)
            {
                return null;
            }
            else
            {
                int secondIndex = Text.IndexOf(subString, firstIndex + 1);
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

        public int? CountWordsStartingWithCapitalLetter()
        { //регулярний застосовано правильно. А якщо без регулярного?
            int count = 0;
            Regex regex = new Regex(@"\b[A-Z][a-z]*\b");
            MatchCollection matches = regex.Matches(Text);
            foreach (Match match in matches)
            {
                if (char.IsUpper(match.Value[0]))
                {
                    count++;
                }
            }
            return count;
        }
// цей метод не подобається. Поясню при потребі усно.
        public string ReplaceWordWithDoubleLetters(string replace)
        {
            StringBuilder output = new StringBuilder();
            StringBuilder currentWord = new StringBuilder();

            for (int i = 0; i < Text.Length; i++)
            {
                char c = Text[i];

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
