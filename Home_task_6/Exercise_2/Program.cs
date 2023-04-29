namespace Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 4, 1, 5 };
            int[] array2 = { 2, 7, 3 };
            int[] array3 = { 6, 9, 8 };

            foreach (int number in SortedArrayMerger.MergeSortedArrays(array1, array2, array3))
            {
                Console.Write(number + " ");
            }
        }
    }
}
