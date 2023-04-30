namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "do Lorem ipsum do. dolor do. sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

            UniqueWordsFinder info = new UniqueWordsFinder(text);

            foreach (var word in info.GetUniqueWords())
            {
                Console.Write(word + " ");
            }
        }
    }
}

