using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2._12_FightWhisBoss
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WindowX = 25;
            const int WindowY = 0;
            const int WindowLength = 50;
            const int WindowHeight = 10;
            const int WindowTextOffsetY = 1;

            string[] skeleton =  
            {
                "░░░░░░▄▄▄░░▄██▄",
                "░░░░░▐▀█▀▌░░░░▀█▄",
                "░░░░░▐█▄█▌░░░░░░▀█▄",
                "░░░░░░▀▄▀░░░▄▄▄▄▄▀▀",
                "░░░░▄▄▄██▀▀▀▀",
                "░░░█▀▄▄▄█░▀▀",
                "░░░▌░▄▄▄▐▌▀▀▀",
                "▄░▐░░░▄▄░█░▀▀",
                "▀█▌░░░▄░▀█▀░▀",
                "░░░░░░░▄▄▐▌▄▄",
                "░░░░░░░▀███▀█░▄",
                "░░░░░░▐▌▀▄▀▄▀▐▄",
                "░░░░░░▐▀░░░░░░▐▌",
                "░░░░░░█░░░░░░░░█",
                "░░░░░▐▌░░░░░░░░░█"
            };


            Console.SetWindowSize(100,30);

            Console.SetCursorPosition(WindowX,WindowY);
            for (int i = 0; i < WindowLength; i++)
                Console.Write("-");
            for(int i=1; i<WindowHeight-WindowTextOffsetY; i++)
            {
                Console.SetCursorPosition(WindowX, WindowY + i);
                Console.Write("|");
                Console.SetCursorPosition(WindowX + WindowLength -1, WindowY + i);
                Console.Write("|");
            }
            Console.SetCursorPosition(WindowX, WindowY + WindowHeight -1);
            for (int i = 0; i < WindowLength; i++)
                Console.Write("-");

            Console.SetCursorPosition(0,0);
            foreach (string line in skeleton)
                Console.WriteLine(line);

            Console.ReadLine();


        }
    }
}
