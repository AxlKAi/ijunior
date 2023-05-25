using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3._7_String_Word_Split
{
    class Program
    {
        static void Main(string[] args)
        {
            string textLine = "Хочу создать крутую игру. Fly-экшон в стиле Star Wars.";

            string[] words = textLine.Split(' ');

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }        
    }
}
