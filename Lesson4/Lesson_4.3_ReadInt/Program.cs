using System;

namespace Lesson_4._3_ReadInt
{
    class Program
    {
        static void Main(string[] args)
        {
            int enteredNumber = 0;
            bool isNumberEntered = false;

            Console.WriteLine("Введите целочисленное значение.");
            Console.WriteLine("Вводимое значение должно содержать целочисленное значение.");
            Console.WriteLine("Строка не может быть пустой.");

            while (isNumberEntered == false)
            { 
                Console.Write("Введите число:");
                isNumberEntered = TryReadInt(ref enteredNumber);
            } 

            Console.WriteLine($"Введено значение {enteredNumber}. Нажмите для завершения программы...");
            Console.ReadKey();
        }

        static bool TryReadInt(ref int enteredNumber)
        {
            return Int32.TryParse(Console.ReadLine(), out enteredNumber);
        }
    }
}
