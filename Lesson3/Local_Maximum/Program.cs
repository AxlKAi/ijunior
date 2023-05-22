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

                if(numbers[0] > numbers[1])
                    Console.WriteLine($"Первый элемент массива с индексом 0 равный {numbers[0]} локальный максимум");

                if (numbers[numbers.Length-1] > numbers[numbers.Length - 2])
                    Console.WriteLine($"Последний элемент массива с индексом {numbers.Length - 1} равный {numbers[numbers.Length - 1]} локальный максимум");

                for (int i = 1; i < numbers.Length - 1; i++)
                {
                    if (i == 0)
                        previousElement = int.MinValue;
                    else
                        previousElement = numbers[i - 1];

                    if (i == (numbers.Length - 1))
                        nextElement = int.MinValue;
                    else
                        nextElement = numbers[i + 1];

                    if (numbers[i] > previousElement && numbers[i] > nextElement)
                        Console.WriteLine($"Элемент массива с индексом {i} равный {numbers[i]} локальный максимум");
                }
            }            
        }
    }
}
