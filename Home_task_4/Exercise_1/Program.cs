namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Демонстрація українською
            string[] textUa = {"Це (речення 1).А це", " (речення 2)!", "А також (речення 3 без [закритої] дужки.", "Текст."};
            var stringTextUa = new TextEditor(new List<string>(textUa));
            
            Console.WriteLine("Сортування речень по строкам:");
            foreach (string str in stringTextUa.SortSentencesInArray())
            {
                Console.WriteLine("\t" + str);
            }
            
            Console.WriteLine("Виведення речень, якi мають у собi текст в дужках ( та ):");
            foreach (string bracket in stringTextUa.FindBrackets())
            {
                Console.WriteLine("\t" + bracket);
            }
            
            Console.WriteLine("Реченя, якi мають у собi текст в дужках [ та ], використовується Regex:");
            foreach (string bracket in stringTextUa.FindBracketsRegex('[', ']'))
            {
                Console.WriteLine("\t" + bracket);
            }
            
            //Демонстрація англійською
            string[] textEn =
            {
                "This is (sentence 1).And this", "(sentence 2)!",
                "As {well} as (sentence 3 without a closed parenthesis.", "Text."
            };
            var stringTextEn = new TextEditor(new List<string>(textEn));
            Console.WriteLine("Sorting sentences by lines:");
            
            foreach (string str in stringTextEn.SortSentencesInArray())
            {
                Console.WriteLine("\t" + str);
            }

            Console.WriteLine("Print sentences that contain text in brackets { and }:");
            foreach (string bracket in stringTextEn.FindBrackets('{', '}'))
            {
                Console.WriteLine("\t" + bracket);
            }
            
            Console.WriteLine("Print sentences that contain text in brackets ( and ) use Regex:");
            foreach (string bracket in stringTextEn.FindBracketsRegex())
            {
                Console.WriteLine("\t" + bracket);
            }
        }
    }
}
