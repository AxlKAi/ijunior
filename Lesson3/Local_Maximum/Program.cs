using System;

namespace Local_Maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            uint numbersArrayLength = 5;
            int maximumRandomNumber = 9;
            int minimumRandomNumber = 0;
            int previousElement;
            int nextElement;
            int currentElement;

            int[] numbers = new int[numbersArrayLength];

            Random random = new Random();

            if(numbersArrayLength > 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }

                Console.WriteLine();

                for (int i = 0; i < numbers.Length; i++)
                {
                    currentElement = numbers[i];

                    if (i > 0)
                        previousElement = numbers[i - 1];
                    else
                        previousElement = 0;

                    if (i < (numbers.Length - 1))
                        nextElement = numbers[i + 1];
                    else
                        nextElement = 0;

                    if (currentElement > previousElement && currentElement > nextElement)
                        Console.WriteLine($"Элемент массива с индексом {i} равный {currentElement} локальный максимум");
                }
            } 
            else
            {
                Console.WriteLine("Массив 0-вой величины.");
            }            
        }
    }
}
