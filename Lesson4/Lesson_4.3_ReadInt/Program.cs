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
            bool isValidateCheckProcess = true;
            string textInput = "";
            int number = 0;

            while (isValidateCheckProcess)
            {
                Console.Write(":");
                textInput = Console.ReadLine();
                
                if (Int32.TryParse(textInput, out number))
                {
                    isValidateCheckProcess = false;
                }
                else
                {
                    Console.WriteLine("Вводимое значение должно содержать целочисленное значение.");
                    Console.WriteLine("Строка не может быть пустой.");
                    Console.WriteLine("Пожалуйста, введите еще раз.");
                }
            }

            return number;
        }
    }
}
