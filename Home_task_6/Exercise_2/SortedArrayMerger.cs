namespace Exercise_2
{
    public class SortedArrayMerger
    {
        private int[][] _arrays;
        //краще на вході мати params
        public SortedArrayMerger(int[][] arrays)
        {
            this._arrays = (int[][]) arrays.Clone();
        }

        public IEnumerable<int> MergeSortedArrays()
        {// яка ефективність yield?
            var mergedArray = _arrays.SelectMany(x => x).OrderBy(x => x);
            foreach (var item in mergedArray)
            {
                yield return item;
            }
        }
    }
}
