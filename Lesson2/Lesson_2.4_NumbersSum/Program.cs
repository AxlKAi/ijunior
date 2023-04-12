using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {            
            int randomMaxNumber = 0;
            int taskMinimum = 1;
            int taskMaximum = 100;
            int multipleNumber = 3;
            int multipleSum = 0;
            Random rand;

            rand = new Random();
            randomMaxNumber = rand.Next(taskMinimum, taskMaximum);
            Console.WriteLine($"Программа выведет сумму всех положительных чисел до {randomMaxNumber} кратных {multipleNumber}.");
            Console.WriteLine("барабанная дробь.....");

            for (int i=taskMinimum; i<=randomMaxNumber; i++)
            {
                if (i % multipleNumber == 0)
                    multipleSum += i;                  
            }

            Console.WriteLine($"Сумма = {multipleSum}");
        }
    }
}
