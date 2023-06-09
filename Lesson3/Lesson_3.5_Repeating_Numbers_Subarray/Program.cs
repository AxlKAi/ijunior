﻿using System;

namespace Lesson_3._5_Repeating_Numbers_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 2, 2, 3, 3, 3, 3, 3, 5, 5, 5, 5, 5, 5, 5, 7, 7, 7, 7, 7, 7, 7, 7, 7, 2, 2, 2, 1 };

            int previousNumber = numbers[0];
            int repeatTimes=1;
            int maximumRepeatTimes = 0;
            int maximumRepeatNumber = 0;

            Console.WriteLine("Массив чисел:");

            foreach (int number in numbers)
                Console.Write(number + " ");

            Console.WriteLine();

            for (int i=1; i<numbers.Length; i++)
            {
                if (previousNumber == numbers[i])
                {
                    repeatTimes++;
                }                    
                else
                {
                    if(maximumRepeatTimes<repeatTimes)
                    {
                        maximumRepeatTimes = repeatTimes;
                        maximumRepeatNumber = previousNumber;
                    }
                    previousNumber = numbers[i];
                    repeatTimes = 1;
                }
            }

            Console.WriteLine($"\n\nМаксимальное количество раз ({maximumRepeatTimes}) повторяется число {maximumRepeatNumber}.");            
        }
    }
}
