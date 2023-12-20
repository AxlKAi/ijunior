using System;

namespace Pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            int picturesInRow = 3;
            int totalPictures = 52;
            int overMeasureRowPictures = totalPictures % picturesInRow;
            int lineCounts = totalPictures / picturesInRow;                    
            
            Console.WriteLine($"Полностью заполненных рядов:{lineCounts}; \n" +
                $"Картинок в ряду сверх меры:{overMeasureRowPictures};"); 
        }
    }
}
