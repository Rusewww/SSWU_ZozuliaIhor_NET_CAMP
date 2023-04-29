namespace Exercise_2
{
    public class SortedArrayMerger
    {
        public static IEnumerable<int> MergeSortedArrays(params int[][] arrays)
        {
            var mergedArray = arrays.SelectMany(x => x).OrderBy(x => x);
            foreach (var item in mergedArray)
            {
                yield return item;
            }
        }
    }
}