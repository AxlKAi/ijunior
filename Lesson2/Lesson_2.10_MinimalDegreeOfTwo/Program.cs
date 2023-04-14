using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalDegreeOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            int degreeOfCalculatedNumber = 0;
            int multiplierOfCalculatedNumber = 2;
            int calculatedNumber = 1;
            int randomNumber;
            int randomNumberMaximum = 100000;
            int randomNumberMinimum = 1;
            Random random;

            random = new Random();
            randomNumber = random.Next(randomNumberMinimum, randomNumberMaximum);
            Console.WriteLine($"Программа найдет минимальную степень двойки, превосходящую число {randomNumber}.");

            while (calculatedNumber <= randomNumber)
            {
                calculatedNumber *=  multiplierOfCalculatedNumber;
                degreeOfCalculatedNumber++;
            }
            Console.WriteLine("Степень двойки = {0}; 2^{0} = {1} ", 
                degreeOfCalculatedNumber, calculatedNumber);
            Console.WriteLine("Нажмите ENTER для завершения программы.");
            Console.ReadLine();
        }
    }
}
