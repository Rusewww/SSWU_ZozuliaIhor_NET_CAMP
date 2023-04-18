using System.Text.RegularExpressions;

namespace Exercise_1
{
    public class TextEditor
    {
        private List<string> _text;
        public List<string> Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public TextEditor(List<string> text)
        {
            Text = text;
        }

        public List<string> SortSentencesInArray()
        {
            List<string> sentences = new List<string>();
            string currentSentence = "";
// Речення можуть бути на кілька стрічок (не обов'язково в двох сусідніх., як і інформація в дужках! Не  все алгоритмічно добре.
            foreach (string line in Text)
            {
                string[] lineSentences = line.Split('.', '!', '?');
                //Тут я поєдную початок речення з його продовженням. 
                lineSentences[0] = currentSentence + lineSentences[0];
                if (!line.EndsWith('.') && !line.EndsWith('!') && !line.EndsWith('?'))
                {
                    currentSentence = lineSentences[lineSentences.Length - 1];
                    lineSentences = lineSentences.Take(lineSentences.Length - 1).ToArray();
                }
                else
                {
                    currentSentence = "";
                }
                sentences.AddRange(lineSentences);
            }
            Text = sentences;
            return sentences;
        }

        public List<string> FindBrackets(char openBracket = '(', char closeBracket = ')')
        {
            var sentencesInBrackets = new List<string>();
            foreach (var sentence in Text)
            {
                if (sentence.Contains(openBracket) && sentence.Contains(closeBracket))
                {
                    sentencesInBrackets.Add(sentence);
                }
            }
            return sentencesInBrackets;
        }
        
        //Варіація функції FindBrackets з використанням regex та LINQ.
        public List<string> FindBracketsRegex(char openBracket = '(', char closeBracket = ')')
        {
            var pattern = $"{Regex.Escape(openBracket.ToString())}.*?{Regex.Escape(closeBracket.ToString())}";
            var regex = new Regex(pattern);
            return Text.Where(sentence => regex.IsMatch(sentence)).ToList();
        }
    }
}
