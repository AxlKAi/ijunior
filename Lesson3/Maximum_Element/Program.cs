using System;

namespace Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersMatrixLength = 10;
            int numbersMatrixHeight = 10;
            int maximumRandomNumber = 9;
            int minimumRandomNumber = 0;
            int maximumNumber = int.MinValue;

            int[,] numbersMatrix = new int[numbersMatrixHeight, numbersMatrixLength];

            Random random = new Random();
            Console.WriteLine("Начальная матрица:");

            for (int i=0; i < numbersMatrix.GetLength(0); i++)
            {
                for(int j=0; j<numbersMatrix.GetLength(1); j++)
                {
                    numbersMatrix[i, j] = random.Next(minimumRandomNumber, maximumRandomNumber);
                    Console.Write(numbersMatrix[i,j]+" ");

                    if (maximumNumber < numbersMatrix[i, j])
                    {
                        maximumNumber = numbersMatrix[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nМаксимальный элемент = {maximumNumber} \n\n");

            Console.WriteLine("Измененная матрица:");

            for (int i = 0; i < numbersMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < numbersMatrix.GetLength(1); j++)
                {
                    if (numbersMatrix[i, j] == maximumNumber)
                    {
                        numbersMatrix[i, j] = 0;
                    }

                    Console.Write(numbersMatrix[i, j] + " ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
