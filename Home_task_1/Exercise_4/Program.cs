namespace Exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //One Dimensional array demonstrating;
            Tensor tensorOneDimensional = new Tensor(4);
            Console.WriteLine(tensorOneDimensional.StringDimensions());
            tensorOneDimensional.Fill(1);
            Console.WriteLine(tensorOneDimensional.ToString());
            Console.WriteLine();
            
            //Two Dimensional array demonstrating;
            Tensor tensorTwoDimensional = new Tensor(4, 4);
            Console.WriteLine(tensorTwoDimensional.StringDimensions());
            tensorTwoDimensional.Fill(1);
            Console.WriteLine(tensorTwoDimensional.ToString());
            Console.WriteLine();
            
            //Three Dimensional array demonstrating;
            Tensor tensorThreeDimensional = new Tensor(2, 2, 2);
            Console.WriteLine(tensorThreeDimensional.StringDimensions());
            tensorThreeDimensional.Fill(1);
            Console.WriteLine(tensorThreeDimensional.ToString());
            Console.WriteLine();
            
            //Four Dimensional array demonstrating;
            Tensor tensorFourDimensional = new Tensor(2,2,2,2);
            Console.WriteLine(tensorFourDimensional.StringDimensions());
            tensorFourDimensional.Fill(1);
            Console.WriteLine(tensorFourDimensional.ToString());
            
            //Five and more dimensional array demonstrating;
            Tensor tensor = new Tensor(2,2,2,2,2);
            Console.WriteLine(tensor.StringDimensions());
        }
    }
}