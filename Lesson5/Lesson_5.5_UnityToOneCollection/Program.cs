using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_5._5_UnityToOneCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stringsOne = { "1", "2", "3", "4", "5" };
            string[] stringsTwo = { "1", "2", "6", "7", "8" };

            var unityStrings = stringsOne.Union(stringsTwo).ToArray();

            ShowElements(unityStrings);
            Console.ReadKey();
        }

        static void ShowElements(string[] strings)
        {
            foreach(string element in strings)
            {
                Console.Write(element + "  ");
            }
        }
    }
}
