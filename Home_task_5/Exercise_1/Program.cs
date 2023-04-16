namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tree> trees1 = new List<Tree>()
            {
                new Tree(1.0, 1.0),
                new Tree(4.0, 1.0),
                new Tree(1.0, 4.0),
                new Tree(4.0, 4.0),
                new Tree(2.0, 2.0),
            };

            List<Tree> trees2 = new List<Tree>()
            {
                new Tree(1.0, 1.0),
                new Tree(3.0, 3.0),
                new Tree(3.0, 0.0),
                new Tree(1.0, 5.0),
                new Tree(7.0, 6.0),
                new Tree(5.0, 1.0),
                new Tree(3.0, 3.0)
            };

            Garden garden1 = new Garden(trees1);
            Garden garden2 = new Garden(trees2);

            Console.WriteLine("Довжина огорожi першого саду: " + garden1.CalculateFenceLength());
            Console.WriteLine("Довжина огорожi другого саду: " + garden2.CalculateFenceLength());
            
            Console.WriteLine(garden1 > garden2);
            Console.WriteLine(garden1 < garden2);
            Console.WriteLine(garden1 == garden2);
            Console.WriteLine(garden1 != garden2);
        }
    }
}

