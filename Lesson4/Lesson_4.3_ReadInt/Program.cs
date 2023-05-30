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
            enteredNumber = ValidateIntEnter();
            Console.WriteLine($"Введено значение {enteredNumber}. Нажмите для завершения программы...");
            Console.ReadKey();
        }

        static int ValidateIntEnter()
        {
            bool isValidateCheckProcess = true;
            string textInput = "";
            int convertedInt = 0;

            while (isValidateCheckProcess)
            {
                Console.Write(":");
                textInput = Console.ReadLine();
                // нужно ли делать принудительно первый символ заглавным ?
                if (Int32.TryParse(textInput, out convertedInt))
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

            return convertedInt;
        }
    }
}
