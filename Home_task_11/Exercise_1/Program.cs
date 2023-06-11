using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Приклад використання зі строками
            string[] array = { "apple", "banana", "cherry", "date", "elderberry" };

            Console.WriteLine("Сортування з першим елементом в якості опорного:");
            QuickSort.Sort(array, (x, y) => x.CompareTo(y));
            PrintArray(array);

            Console.WriteLine("\nСортування з довільним елементом в якості опорного:");
            QuickSort.Sort(array, (x, y) => y.Length.CompareTo(x.Length));
            PrintArray(array);

            Console.WriteLine("\nСортування з медіаною в якості опорного:");
            QuickSort.Sort(array, (x, y) => x[0].CompareTo(y[0]));
            PrintArray(array);
        }

        static void PrintArray<T>(T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}