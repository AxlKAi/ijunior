using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2._1_LearningLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputString;
            int itterationCount;

            Console.Write("Введите строку символов для вывода:");
            outputString = Console.ReadLine();

            Console.Write("Введите количество повторов:");
            itterationCount = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i<itterationCount; i++)
            {
                Console.WriteLine(outputString);
            }
        }
    }
}
