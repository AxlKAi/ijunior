using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 5;
            int lastNumber = 96;
            int step = 7;

            for(int i=startNumber; i<=lastNumber; i=i + step)
            {
                Console.WriteLine(i);
            }
        }
    }
}
