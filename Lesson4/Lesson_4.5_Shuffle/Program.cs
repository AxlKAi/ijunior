using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4._5_Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "раз", "два", "три", "четыре", "пять" };
            ShowArray<string>(words);

            Console.WriteLine();
            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            ShowArray<int>(numbers);

            Console.WriteLine("\n\n перемешанные массивы.....");
            Shuffle<string>(ref words);
            Shuffle<int>(ref numbers);

            Console.WriteLine();
            ShowArray<string>(words);

            Console.WriteLine();
            ShowArray<int>(numbers);

            Console.ReadKey();
        }

        static void ShowArray<T>(T[] array)
        {
            Console.WriteLine($"Вывод массива из {array.Length} элементов.") ;

            foreach (var element in array)
            {
                Console.Write(element +" ");
            }
        }

        static void Shuffle<T>(ref T[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(array.Length);
                T oldElement = array[j];
                array[j] = array[i];
                array[i] = oldElement;
            }
        }
    }
}
