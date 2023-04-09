using System;
using System.Collections.Generic;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Демонстрація на українській
            string[] textUa = {"Це (речення 1).А це", " (речення 2)!", "А також (речення 3 без закритої дужки.", "Текст."};
            var stringTextUa = new TextEditor(new List<string>(textUa));
            
            Console.WriteLine("Сортування речень по строкам:");
            foreach (string str in stringTextUa.SortSentencesInArray())
            {
                Console.WriteLine("\t" + str);
            }
            
            Console.WriteLine("\nВиведення речень, якi мають у собi текст в дужках:");
            foreach (string bracket in stringTextUa.FindBrackets())
            {
                Console.WriteLine("\t" + bracket);
            }
            
            //Демонстрація на англійській
            string[] textEn =
            {
                "This is (sentence 1).And this", "(sentence 2)!",
                "As well as (sentence 3 without a closed parenthesis.", "Text."
            };
            var stringTextEn = new TextEditor(new List<string>(textEn));
            
            Console.WriteLine("\nSorting sentences by lines:");
            foreach (string str in stringTextEn.SortSentencesInArray())
            {
                Console.WriteLine("\t" + str);
            }

            Console.WriteLine("\nPrint sentences that contain text in brackets:");
            foreach (string bracket in stringTextEn.FindBrackets())
            {
                Console.WriteLine("\t" + bracket);
            }
        }
    }
}
