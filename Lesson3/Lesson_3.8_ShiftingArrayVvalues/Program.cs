using System;

namespace Lesson_3._8_ShiftingArrayVvalues
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersArrayLength = 5;
            int[] numbers = new int[numbersArrayLength];
            int minimumRandomNumber = 0;
            int maximumRandomNumber = 10;
            int shiftTimes = 0;

            Random random;
            random = new Random();

            Console.WriteLine("Генерируем массив:");

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]+"  ");
            }

            Console.WriteLine("\nВведите количество сдвигов массива:");
            shiftTimes = Convert.ToInt32(Console.ReadLine());

            if (shiftTimes >= numbers.Length)
            {
                shiftTimes = shiftTimes % numbers.Length;
                Console.WriteLine($"\nКоличество сдвигов больше чем длинна массива, сокращаем до:{shiftTimes}");
            }

            for(int j=0; j<shiftTimes; j++)
            {
                int firstNumber = numbers[0];

                for (int i = 1; i < numbers.Length; i++)
                {
                    numbers[i - 1] = numbers[i];
                }

                numbers[numbers.Length - 1] = firstNumber;
            }

            Console.WriteLine("\nМассив после сдвига:");
            for (int i = 0; i < numbersArrayLength; i++)
            {
                Console.Write(numbers[i] + "  ");
            }

            Console.ReadLine();
        }
    }
}
