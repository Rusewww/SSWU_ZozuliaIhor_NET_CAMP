namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };

            SpiralMatrix spiralMatrix = new SpiralMatrix(matrix);

            foreach (int num in spiralMatrix)
            {
                Console.Write(num + " ");
            }
        }
    }
}