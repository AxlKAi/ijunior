using System;

namespace Lesson_4._3_ReadInt
{
    class Program
    {
        static void Main(string[] args)
        {
            int enteredNumber;

            Console.WriteLine("Введите целочисленное значение.");
            Console.WriteLine("Вводимое значение должно содержать целочисленное значение.");
            Console.WriteLine("Строка не может быть пустой.");
            enteredNumber = ReadInt();

            Console.WriteLine($"Введено значение {enteredNumber}. Нажмите для завершения программы...");
            Console.ReadKey();
        }

        static int ReadInt()
        {
            int number;

            do
            {
                Console.Write("Введите число:");
            } while (Int32.TryParse(Console.ReadLine(), out number) == false);

            return number;
        }
    }
}
