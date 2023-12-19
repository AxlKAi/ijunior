using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            int picturesInRow = 3;
            int totalPictures = 52;
            int overMeasureRowPictures = totalPictures % picturesInRow;
            int lineCounts = totalPictures / picturesInRow 
                    + Convert.ToInt32(overMeasureRowPictures > 0);
            
            Console.WriteLine($"Всего рядов:{lineCounts}; " +
                $"Картинок в ряду сверх меры:{overMeasureRowPictures};"); 
        }
    }
}
