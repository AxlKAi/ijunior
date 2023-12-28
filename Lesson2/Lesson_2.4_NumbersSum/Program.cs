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
            int multipleNumber1 = 3;
            int multipleSum1 = 0;
            int multipleNumber2 = 5;
            int multipleSum2 = 0;
            Random random;

            random = new Random();
            randomMaxNumber = random.Next(taskMinimum, taskMaximum);
            Console.WriteLine($"Программа выведет сумму всех положительных чисел до {randomMaxNumber} кратных {multipleNumber1} и {multipleNumber2}.");
            Console.WriteLine("барабанная дробь.....");

            for (int i=taskMinimum; i<=randomMaxNumber; i++)
            {
                if (i % multipleNumber1 == 0)
                {
                    multipleSum1 += i;
                }

                if (i % multipleNumber2 == 0)
                {
                    multipleSum2 += i;
                }
            }

            Console.WriteLine($"Сумма всех чисел кратных {multipleNumber1} = {multipleSum1}");
            Console.WriteLine($"Сумма всех чисел кратных {multipleNumber2} = {multipleSum2}");
        }
    }
}
