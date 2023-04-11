namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text =
            {
                "simple@example.com adsasdqwrqsfa Abcex@ample.com dawdaw wdawdq rqw 21 1 ewe q eaWEawd",
                "sadasdasdas other.email-with-hyphen@example.com a@asd mailhothis\\still\\not\allowe@asd dsusername@example.org"
            };
            var stringText = new TextFinder(new List<string>(text));
            Console.WriteLine("Виводимо валiднi емейли:");
            foreach (string bracket in stringText.FindEmails().emails)
            {
                Console.WriteLine("\t" + bracket);
            }
            
            Console.WriteLine("Виводимо лексеми з @:");
            foreach (string bracket in stringText.FindEmails().lexemes)
            {
                Console.WriteLine("\t" + bracket);
            }
        }
    }
}
