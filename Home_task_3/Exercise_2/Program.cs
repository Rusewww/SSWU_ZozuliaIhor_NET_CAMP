namespace Exercise_2
{
    internal class Program
    {// Користувач використовує воду з вежі... Чому стрілка до валідатора пунктирна. Валідатор використовують...
        private static void Main(string[] args)
        {
            var text = new StringManipulator("Baa nan dBaa nan bana nan Ban Ape");
            Console.WriteLine("Текст: " + text.Text);
            Console.WriteLine($"Iндекс другого входження слова nan: {text.FindSecondIndex("nan")}");
            Console.WriteLine($"Кiлькiсть слiв, якi починаються з великої лiтери: {text.CountWordsStartingWithCapitalLetter()}");
            Console.WriteLine($"Строка, де слова з подвоєннями замiненi на 0: {text.ReplaceWordWithDoubleLetters("0")}");
        }
    }
}
