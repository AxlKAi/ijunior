using System;

namespace Local_Maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            uint numbersArrayLength = 1;
            int minimumRandomNumber = 0;
            int maximumRandomNumber = 9;
            int previousElement;
            int nextElement;

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
            else
            {
                Console.WriteLine("Массив 0-вой величины.");
            }            
        }
    }
}
