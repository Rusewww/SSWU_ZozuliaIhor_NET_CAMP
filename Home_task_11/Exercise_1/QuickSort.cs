using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    public static class QuickSort
    {
        public static void Sort<T>(T[] array, Func<T, T, int> compare)
        {
            QuickSortRecursive(array, 0, array.Length - 1, compare);
        }

        private static void QuickSortRecursive<T>(T[] array, int left, int right, Func<T, T, int> compare)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right, compare);
                QuickSortRecursive(array, left, pivotIndex - 1, compare);
                QuickSortRecursive(array, pivotIndex + 1, right, compare);
            }
        }

        private static int Partition<T>(T[] array, int left, int right, Func<T, T, int> compare)
        {
            T pivot = array[left];
            int i = left;

            for (int j = left + 1; j <= right; j++)
            {
                if (compare(array[j], pivot) < 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, left, i);

            return i;
        }

        private static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
