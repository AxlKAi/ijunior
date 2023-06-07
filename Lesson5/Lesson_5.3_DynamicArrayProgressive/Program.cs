using System;
using System.Collections.Generic;

namespace Lesson_5._3_DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            const string SumCommand = "sum";
            const string ExitCommand = "exit";

            string userInput;
            bool isMainLoopActive = true;
            List<int> numbers = new List<int>();

            Console.WriteLine("Введите:");
            Console.WriteLine("число - для добавления в массив");
            Console.WriteLine($"{SumCommand} - для подсчета суммы всех чисел массива");
            Console.WriteLine($"{ExitCommand} - для выхода");
            Console.WriteLine();

            while (isMainLoopActive)
            {
                Console.Write(":");
                userInput = Console.ReadLine();

                if (userInput == ExitCommand)
                {
                    isMainLoopActive = false;
                    Console.WriteLine("ВсеГО хо-ро-шЭ-ГО!");
                }
                else if (userInput == SumCommand)
                {
                    int numbersSum = 0;

                    foreach (int number in numbers)
                        numbersSum += number;

                    Console.WriteLine($"Сумма элементов массива = {numbersSum}");
                }
                else 
                {
                    int number = 0;

                    if (Int32.TryParse(userInput,out number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода, не могу распознать команду или число.");
                    }                    
                }
            }
        }
    }
}
