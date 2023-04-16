using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            // вывод 516
            Console.WriteLine(++a + 2 + 1 + a++ + "1" + ++a * 2);
            //               (++a) + 2 + 1 + (a++) + "1" + (++a) * 2)
            //            a=   1               1             3
        }
    }
}
