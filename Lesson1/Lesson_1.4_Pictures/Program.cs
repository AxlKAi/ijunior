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
            /*
            На экране, в специальной зоне, выводятся картинки, 
            по 3 в ряд (условно, ничего рисовать не надо). 
            Всего у пользователя в альбоме 52 картинки. 
            Код должен вывести, сколько полностью заполненных рядов можно будет вывести, 
            и сколько картинок будет сверх меры.             
            */
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
