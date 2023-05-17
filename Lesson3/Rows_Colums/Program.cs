using System;

namespace Rows_Colums
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] array = { 
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            };

            int rowSum = 0;
            int rowForSumCalculation = 1;

            int columnMultiplication = 1;
            int columnForMultiplication = 2;

            for (int i=0; i<array.GetLength(0); i++)
            {
                for(int j = 0; j<array.GetLength(1); j++)
                {
                    Console.Write(array[i,j] + " ");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                rowSum += array[rowForSumCalculation, i];
            }

            Console.WriteLine($"Сумма {rowForSumCalculation} ряда {rowSum}");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                columnMultiplication *= array[i, columnForMultiplication];
            }

            Console.WriteLine($"Произведение {columnForMultiplication} столбца {columnMultiplication}");
        }
    }
}
