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
            int borderPadding = 4;

            Console.Write("Введите имя : ");
            userName = Console.ReadLine();

            Console.Write("Введите символ для создания рамки : ");
            borderSymbol = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < userName.Length + borderPadding; i++)
            {
                horizontalBorder += borderSymbol;
            }

            Console.WriteLine(horizontalBorder);
            Console.WriteLine(borderSymbol + " " + userName + " " + borderSymbol);
            Console.WriteLine(horizontalBorder);

            Console.WriteLine("\n");
            Console.WriteLine("Нажмите ENTER для завершение программы.");
            Console.ReadLine();
        }
    }
}
