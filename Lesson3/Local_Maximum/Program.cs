using System;

namespace Local_Maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersArrayLength = 10;
            int[] numbers = new int[numbersArrayLength];
            int firstIndex = 0;
            int lastIndex = numbersArrayLength - 1;
            int minimumRandomNumber = 0;
            int maximumRandomNumber = 9;
            int previousElement;
            int nextElement;

            Random random = new Random();

            if (numbersArrayLength > 0) 
            {
                Console.WriteLine("Массив:");

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write(numbers[i] + " ");
                }

                Console.WriteLine();
            }

            if (numbersArrayLength == 0)
            {
                Console.WriteLine("Массив 0-вой величины.");
            }
            else if (numbersArrayLength == 1)
            {
                Console.WriteLine("В массиве один элемент, он является локальным максимумом.");
            }
            else         
            {
                Console.WriteLine();

                if(numbers[firstIndex] > numbers[firstIndex+1])
                    Console.WriteLine($"Первый элемент массива с индексом {firstIndex} равный {numbers[firstIndex]} локальный максимум");

                for (int i = 1; i < lastIndex; i++)
                {
                    previousElement = numbers[i - 1];
                    nextElement = numbers[i + 1];

                    if (numbers[i] > previousElement && numbers[i] > nextElement)
                        Console.WriteLine($"Элемент массива с индексом {i} равный {numbers[i]} локальный максимум");
                }

                if (numbers[lastIndex] > numbers[lastIndex - 1])
                    Console.WriteLine($"Последний элемент массива с индексом {lastIndex} равный {numbers[lastIndex]} локальный максимум");
            }
        }
    }
}
