using System;

namespace Lesson_3._4_Dynamic_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            const string SumCommand = "sum";
            const string ExitCommand = "exit";

            string userInput;
            bool isMainLoopActive = true;
            int numbersSum;
            int inputNumber;
            int[] numbers = new int[0];
            int[] tempArray;

            Console.WriteLine("Введите:");
            Console.WriteLine("число - для добавления в массив");
            Console.WriteLine($"{SumCommand} - для подсчета суммы всех чисел массива");
            Console.WriteLine($"{ExitCommand} - для выхода");
            Console.WriteLine();

            while (isMainLoopActive)
            {
                Console.Write(":");
                userInput = Console.ReadLine();

                if(userInput == ExitCommand)
                {
                    isMainLoopActive = false;
                    Console.WriteLine("ВсеГО хо-ро-шЭ-ГО!");
                }
                else if (userInput == SumCommand)
                {
                    numbersSum = 0;

                    foreach (int number in numbers)
                        numbersSum += number;

                    Console.WriteLine($"Сумма элементов массива ={numbersSum}");
                }
                else
                {
                    int newArrayLength = numbers.Length + 1;
                    inputNumber = Convert.ToInt32(userInput);                    
                    tempArray = new int[newArrayLength];

                    for(int i=0; i<numbers.Length; i++)
                        tempArray[i] = numbers[i];

                    tempArray[newArrayLength - 1] = inputNumber;
                    numbers = tempArray;
                }
            }
        }
    }
}
