using System;

namespace Rows_Colums
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] numbers = { 
                { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 2, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 3, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            };

            int rowSum = 0;
            int rowForSumCalculation = 2;

            int columnMultiplication = 1;
            int columnForMultiplication = 1;

            for (int i=0; i<numbers.GetLength(0); i++)
            {
                for(int j = 0; j<numbers.GetLength(1); j++)
                {
                    Console.Write(numbers[i,j] + " ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                rowSum += numbers[rowForSumCalculation-1, i];
            }

            Console.WriteLine($"Сумма {rowForSumCalculation} ряда {rowSum}");

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                columnMultiplication *= numbers[i, columnForMultiplication-1];
            }

            Console.WriteLine($"Произведение {columnForMultiplication} столбца {columnMultiplication}");
        }
    }
}
