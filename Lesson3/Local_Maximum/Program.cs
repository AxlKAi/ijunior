using System;

namespace Local_Maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersArrayLength = 30;
            int maximumRandomNumber = 9;
            int minimumRandomNumber = 0;

            int[] numbers = new int[numbersArrayLength];

            Random random = new Random();
            for(int i=0; i<numbers.Length; i++)
            {
                numbers[i] = random.Next(minimumRandomNumber, maximumRandomNumber);
            }
        }
    }
}
