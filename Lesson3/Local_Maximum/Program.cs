using System;

namespace Local_Maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            uint numbersArrayLength = 10;
            int minimumRandomNumber = 0;
            int maximumRandomNumber = 9;
            int previousElement;
            int nextElement;

            int[] numbers = new int[numbersArrayLength];

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

                if(numbers[numbers.GetLowerBound(0)] > numbers[numbers.GetLowerBound(0)+1])
                    Console.WriteLine($"Первый элемент массива с индексом {numbers.GetLowerBound(0)} равный {numbers[numbers.GetLowerBound(0)]} локальный максимум");

                for (int i = 1; i < numbers.Length - 1; i++)
                {
                    previousElement = numbers[i - 1];
                    nextElement = numbers[i + 1];

                    if (numbers[i] > previousElement && numbers[i] > nextElement)
                        Console.WriteLine($"Элемент массива с индексом {i} равный {numbers[i]} локальный максимум");
                }

                if (numbers[numbers.GetUpperBound(0)] > numbers[numbers.GetUpperBound(0) - 1])
                    Console.WriteLine($"Последний элемент массива с индексом {numbers.GetUpperBound(0)} равный {numbers[numbers.GetUpperBound(0)]} локальный максимум");
            }
        }
    }
}
