using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3._6_Numbers_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersArrayLength = 100;
            int[] numbers = new int[numbersArrayLength];
            int minimumRandomNumber = 0;
            int maximumRandomNumber = 100;

            Random random;

            random = new Random();
            Console.WriteLine("Генерируем массив:");

            for (int i = 0; i < numbersArrayLength; i++)
            {
                numbers[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + "  ");
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                int sortingNumber = numbers[i];
                int checkingIndex = i - 1;

                while (checkingIndex >= 0 && numbers[checkingIndex] > sortingNumber)
                {
                    numbers[checkingIndex + 1] = numbers[checkingIndex];
                    numbers[checkingIndex] = sortingNumber;
                    checkingIndex--;
                }
            }

            Console.WriteLine("\n\nСортированный массив:");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + "  ");
            }

            Console.ReadLine();
        }
    }
}
