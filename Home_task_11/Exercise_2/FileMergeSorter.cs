using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Exercise_2
{
    class FileMergeSorter
    {
        private const int MaxArraySize = 50;

        public void Sort(string filename)
        {
            int[] numbers = ReadNumbersFromFile(filename);
            int length = numbers.Length;

            int[] temp = new int[length];
            SplitAndSort(numbers, temp, 0, length - 1);

            WriteNumbersToFile(numbers, filename);
        }

        private int[] ReadNumbersFromFile(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            int[] numbers = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                numbers[i] = int.Parse(lines[i]);
            }

            return numbers;
        }

        private void WriteNumbersToFile(int[] numbers, string filename)
        {
            File.WriteAllLines(filename, Array.ConvertAll(numbers, x => x.ToString()));
        }

        private void SplitAndSort(int[] numbers, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                if (middle - left + 1 > MaxArraySize)
                {
                    SplitAndSort(numbers, temp, left, left + MaxArraySize - 1);
                }
                else
                {
                    SplitAndSort(numbers, temp, left, middle);
                }

                if (right - middle > MaxArraySize)
                {
                    SplitAndSort(numbers, temp, middle + 1, middle + MaxArraySize);
                }
                else
                {
                    SplitAndSort(numbers, temp, middle + 1, right);
                }

                Merge(numbers, temp, left, middle, right);
            }
        }

        private void Merge(int[] numbers, int[] temp, int left, int middle, int right)
        {
            int i = left;
            int j = middle + 1;
            int k = left;

            while (i <= middle && j <= right)
            {
                if (numbers[i] <= numbers[j])
                {
                    temp[k++] = numbers[i++];
                }
                else
                {
                    temp[k++] = numbers[j++];
                }
            }

            while (i <= middle)
            {
                temp[k++] = numbers[i++];
            }

            while (j <= right)
            {
                temp[k++] = numbers[j++];
            }

            Array.Copy(temp, left, numbers, left, right - left + 1);
        }
    }
}

