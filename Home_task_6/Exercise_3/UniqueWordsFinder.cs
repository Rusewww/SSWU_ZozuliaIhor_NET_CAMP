using System.Text.RegularExpressions;

namespace Exercise_3
{
    public class UniqueWordsFinder
    {
        private string _text;
        //не потрібно
        private IEnumerable<string> _uniqueWords;

        public IEnumerable<string> UniqueWords
        {
            get { return new List<string>(_uniqueWords); }
        }

        public UniqueWordsFinder(string text)
        {
            _text = (string)text.Clone();
        }
        
        public IEnumerable<string> GetUniqueWords()
        {
            var words = _text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var uniqueWords = new HashSet<string>();

            foreach (var word in words)
            {
                var cleanedWord =
                    Regex.Replace(word, @"[^\w\s]", ""); //Видаляємо зайві символи, які можуть залишитися в словах

                if (uniqueWords.Add(cleanedWord))
                {
                    yield return cleanedWord;
                }
            }
//Не потрібно
            _uniqueWords = uniqueWords;
        }
    }
}
