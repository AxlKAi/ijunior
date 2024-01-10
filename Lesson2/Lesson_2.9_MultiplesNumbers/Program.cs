using System;

namespace MultiplesNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int multiplieNumber;
            int maxMultiplieNumber = 27;
            int minMultiplieNumber = 1;
            int calculationMaxNumber = 999;
            int calculationMinNumber = 100;
            int multipliesSum = 0;
            Random random;

            random = new Random();
            multiplieNumber = random.Next(minMultiplieNumber, maxMultiplieNumber + 1);
            Console.WriteLine($"Программа выведет сумму чисел кратных {multiplieNumber} от {calculationMinNumber} до {calculationMaxNumber} не прибегая к умножению и делению.\n"); ;
            Console.WriteLine("Ловкость рук, никакого мошенства!!!\n");
            Console.WriteLine("Числа попадающие в подсчет : ");

            for (int i = 0; i <= calculationMaxNumber; i = i + multiplieNumber)
            {
                if (i >= calculationMinNumber)
                {
                    multipliesSum += i;
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine($"\nСумма = {multipliesSum}\n");
            Console.WriteLine("Нажмите ENTER для завершение программы.");
            Console.ReadLine();
        }
    }
}
