using System;
using System.Collections.Generic;

namespace Lesson_5._5_UnityToOneCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringsOne = { "1", "2", "3", "4", "5" };
            string[] stringsTwo = { "1", "2", "6", "7", "8" };
            List<string> unityStrings = new List<string>();

            MergeElement(unityStrings, stringsOne);
            MergeElement(unityStrings, stringsTwo);
            ShowElements(unityStrings);
            Console.ReadKey();
        }

        static void MergeElement(List<string> unityStrings, string[] stringsArray)
        {
            foreach (string element in stringsArray)
            {
                if (unityStrings.Contains(element) == false)
                {
                    unityStrings.Add(element);
                }
            }
        }

        static void ShowElements(List<string> strings)
        {
            foreach(string element in strings)
            {
                Console.Write(element + "  ");
            }
        }
    }
}
