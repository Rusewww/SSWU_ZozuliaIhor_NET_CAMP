namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var colorMatrix = new ColorMatrix(5, 5);
            colorMatrix.FillMatrixRandom();
            Console.Write(colorMatrix.ToString());
            var result = colorMatrix.FindColor();
            if (result.startRow != -1 && result.startCol != -1)
            {
                Console.Write("Колiр найдовшої горизонтальної лiнiї: {0} \n" +
                              "Iндекс початкової точки: [{1},{2}];\nIндекс кiнцевої точки:[{3},{4}].\n",
                                colorMatrix.Matrix[result.startRow, result.startCol], result.startRow, 
                                result.startCol, result.startRow, result.startCol + result.Length-1);
            }
            else
            {
                Console.WriteLine("Error: У матрицi не iснує послiдовного горизонтального спiвпвдiння кольорiв.");
            }
        }
    }
}
