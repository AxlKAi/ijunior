using System;

namespace NumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {            
            int randomMaxNumber;
            int taskMinimum = 1;
            int taskMaximum = 100;
            int multipleNumber = 5;
            int multipleSum = 0;
            Random rand;

            rand = new Random();
            randomMaxNumber = rand.Next(taskMinimum, taskMaximum);
            Console.WriteLine($"Программа выведет сумму всех положительных чисел до {randomMaxNumber} кратных {multipleNumber}.");
            Console.WriteLine("барабанная дробь.....");

            for (int i=taskMinimum; i<=randomMaxNumber; i++)
            {
                if (i % multipleNumber == 0)
                {
                    multipleSum += i;
                    Console.WriteLine($"+ {i}");
                }                    
            }

            Console.WriteLine($" = {multipleSum}");
        }
    }
}
