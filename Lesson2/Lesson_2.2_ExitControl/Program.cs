using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2._2_ExitControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            string exitCommand = "exit";

            Console.WriteLine("Здравствуйте. Если Вас что-то тревожит, " +
                "можете излить мне душу, путем ввода символьных строк.");
            Console.WriteLine($"Для завершения программы наберите {exitCommand}") ;

            while(userInput != exitCommand)
            {
                userInput = Console.ReadLine();
            }
        }
    }
}
