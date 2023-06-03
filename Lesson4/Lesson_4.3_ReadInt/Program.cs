using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4._3_ReadInt
{
    class Program
    {
        static void Main(string[] args)
        {
            int enteredNumber;

            Console.WriteLine("Введите целочисленное значение");
            enteredNumber = GetNumber();

            Console.WriteLine($"Введено значение {enteredNumber}. Нажмите для завершения программы...");
            Console.ReadKey();
        }

        static int GetNumber()
        {
            int number = 0;

            do
            {
                Console.WriteLine("Вводимое значение должно содержать целочисленное значение.");
                Console.WriteLine("Строка не может быть пустой.");
                Console.Write(":");
            } while (!Int32.TryParse(Console.ReadLine(), out number));

            return number;
        }
    }
}
