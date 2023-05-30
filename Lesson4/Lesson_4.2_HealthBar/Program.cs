using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_4._2_HealthBar
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowHealthBar(.33f, 3, 3);
            Console.ReadKey();
        }

        static void ShowHealthBar(float normalizedHealth, int x = 0, int y = 0, char fillSymbol = '#')
        {
            char leftBorder = '[';
            char rightBorder = ']';
            char emptySymbol = '_';
            float healthBarLength = 10;
            float normalizedСoefficient = 1;
            float filledToEmptyFrontier = 0f;
            float persentageStep = normalizedСoefficient / healthBarLength;

            if (normalizedHealth > 1)
                normalizedHealth = 1;

            if (normalizedHealth < 0)
                normalizedHealth = 0;

            normalizedHealth = (float)Math.Round(normalizedHealth, 1);

            Console.SetCursorPosition(x, y);
            Console.Write(leftBorder);
            for (float i = 0; i < normalizedHealth; i = i + persentageStep)
            {
                Console.Write(fillSymbol);
                filledToEmptyFrontier = i;
            }            

            for (float i = filledToEmptyFrontier + persentageStep; i < normalizedСoefficient; i = i + persentageStep)
            {
                Console.Write(emptySymbol);
            }

            Console.Write(rightBorder);
        }
    }
}
