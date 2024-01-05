using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            char borderSymbol;
            string userName;
            string horizontalBorder = "";

            Console.Write("Введите имя : ");
            userName = Console.ReadLine();

            Console.Write("Введите символ для создания рамки : ");
            borderSymbol = Convert.ToChar(Console.ReadLine());

            string outputLine = borderSymbol + " " + userName + " " + borderSymbol;

            for (int i = 0; i < outputLine.Length; i++)
            {
                horizontalBorder += borderSymbol;
            }

            Console.WriteLine(horizontalBorder);
            Console.WriteLine(outputLine);
            Console.WriteLine(horizontalBorder);

            Console.WriteLine("\n");
            Console.WriteLine("Нажмите ENTER для завершение программы.");
            Console.ReadLine();
        }
    }
}
