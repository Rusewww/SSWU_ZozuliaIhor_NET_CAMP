// See https://aka.ms/new-console-template for more information
using Exercise_2;

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filename = "../../../input.txt";

        GenerateRandomNumbers(filename, 100, 1, 1000);

        FileMergeSorter mergeSort = new FileMergeSorter();

        mergeSort.Sort(filename);
    }

    static void GenerateRandomNumbers(string filename, int count, int minValue, int maxValue)
    {
        Random random = new Random();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            for (int i = 0; i < count; i++)
            {
                int number = random.Next(minValue, maxValue + 1);
                writer.WriteLine(number);
            }
        }
    }
}