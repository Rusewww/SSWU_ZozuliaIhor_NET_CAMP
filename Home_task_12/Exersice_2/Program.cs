namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBAdapter adapter = new DBAdapter();
            CLI CLI = new CLI(adapter);
            CLI.OpenCLI();
        }
    }
}
