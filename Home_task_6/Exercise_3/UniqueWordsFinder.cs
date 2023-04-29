using System.Text.RegularExpressions;

namespace Exercise_3
{
    public class UniqueWordsFinder
    {
        public static IEnumerable<string> GetUniqueWords(string text)
        {
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
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
        }
    }
}