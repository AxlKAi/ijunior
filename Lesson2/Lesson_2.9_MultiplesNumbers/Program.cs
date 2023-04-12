using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplesNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int multiplieNumber;
            int maxMultiplieNumberPlusOne = 28;
            int minMultiplieNumber = 1;
            int calculationMaxNumber = 999;
            int calculationMinNumber = 100;
            int multipliesSum = 0;
            Random rand;

            rand = new Random();
            multiplieNumber = rand.Next(minMultiplieNumber, maxMultiplieNumberPlusOne);
            Console.WriteLine($"Программа выведет сумму чисел кратных {multiplieNumber} от {calculationMinNumber} до {calculationMaxNumber} не прибегая к умножению и делению.\n"); ;
            Console.WriteLine("Ловкость рук, никакого мошенства!!!\n");
            
            Console.WriteLine("Числа попадающие в подсчет : ");
            for (int i = 0; i <= calculationMaxNumber; i = i + multiplieNumber)
            {
                if (i >= calculationMinNumber)
                {
                    multipliesSum += i;                    
                    Console.Write(i+ " ");
                }
            }
            Console.WriteLine($"\nСумма = {multipliesSum}");
            Console.WriteLine("\nНажмите ENTER для завершение программы.");
            Console.ReadLine();
        }
    }
}
