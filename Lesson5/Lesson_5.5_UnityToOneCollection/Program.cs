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
            MergeElement(unityStrings, stringsOne);
            ShowElements(unityStrings);
            Console.ReadKey();
        }

        static void MergeElement(List<string> unityStrings, string[] strings)
        {
            foreach (string element in strings)
            {
                if (unityStrings.Contains(element) == false)
                {
                    unityStrings.Add(element);
                }
            }
        }

        static void ShowElements(List<string> unityStrings)
        {
            foreach(string element in unityStrings)
            {
                Console.Write(element + "  ");
            }
        }
    }
}
