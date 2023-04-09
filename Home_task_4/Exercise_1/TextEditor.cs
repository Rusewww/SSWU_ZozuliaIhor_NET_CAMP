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

            foreach (string line in Text)
            {
                string[] lineSentences = line.Split('.', '!', '?');
                
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

        public List<string> FindBrackets()
        {
            var sentencesInBrackets = new List<string>();
            foreach (var sentence in Text)
            {
                if (sentence.Contains("(") && sentence.Contains(")"))
                {
                    sentencesInBrackets.Add(sentence);
                }
            }
            return sentencesInBrackets;
        }
    }
}