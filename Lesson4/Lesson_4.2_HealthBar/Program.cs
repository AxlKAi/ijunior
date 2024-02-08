using System;

namespace Lesson_4._2_HealthBar
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowBar(.3f, 3, 3);
            ShowBar(.5f, 3, 4);
            ShowBar(.7f, 3, 5, '$');
            Console.ReadKey();
        }

        static void ShowBar(float normalizedHealth, int positionX = 0, int positionY = 0, char fillSymbol = '#')
        {
            char leftBorder = '[';
            char rightBorder = ']';
            char emptySymbol = '_';
            float healthBarLength = 30;
            float normalizedСoefficient = 1;
            float filledToEmptyFrontier = 0f;
            float persentageStep = normalizedСoefficient / healthBarLength;

            if (normalizedHealth > 1)
                normalizedHealth = 1;
            else if (normalizedHealth < 0)
                normalizedHealth = 0;

            normalizedHealth = (float)Math.Round(normalizedHealth, 1);

            Console.SetCursorPosition(positionX, positionY);
            Console.Write(leftBorder);

            for (float i = 0; i < normalizedHealth; i = i + persentageStep)
            {
                Console.Write(fillSymbol);
                filledToEmptyFrontier = i;
            }            

            for (float i = filledToEmptyFrontier + persentageStep; i < normalizedСoefficient; i += persentageStep)
            {
                Console.Write(emptySymbol);
            }

            Console.Write(rightBorder);
        }
    }
}
