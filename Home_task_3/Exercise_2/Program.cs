using Exercise_2;

string text = "Baa nan dBaa nan bana nan Ban Ape";
Console.WriteLine("Текст: " + text);
Console.WriteLine($"Iндекс другого входження слова nan: { StringManipulator.FindSecondIndex(text, "nan")}");
Console.WriteLine($"Кiлькiсть слiв, якi починаються з великої лiтери: {StringManipulator.CountWordsStartingWithCapitalLetter(text)}");
Console.WriteLine($"Строка, де слова з подвоєннями замiненi на 0: {StringManipulator.ReplaceWordWithDoubleLetters(text, "0")}");