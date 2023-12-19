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
            int tryCount = 5;
            Random rand = new Random();

            while (tryCount-- > 0)
            {
                Console.WriteLine(tryCount);
            }
            // тут tryCount = -1 а не 0 !!
            Console.WriteLine(tryCount);

            int a = 10;

            int b = 38;
                        
            int c;
            c =(31-5 * a) / b ;

            Console.WriteLine(c);

        }
    }
}
